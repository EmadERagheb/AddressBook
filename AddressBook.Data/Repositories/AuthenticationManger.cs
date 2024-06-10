using AddressBook.Data.Contexts;
using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.ApplicationUser;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AddressBook.Data.Repositories
{
    public class AuthenticationManger : IAuthenticationManger
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly IConfiguration _configuration;
        private readonly AddressBookIdentityDbContext _context;

        public AuthenticationManger(UserManager<ApplicationUser> manager, IConfiguration configuration, AddressBookIdentityDbContext context)
        {
            _manager = manager;
            _configuration = configuration;
            _context = context;
        }
        public async Task<AuthorizedResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _manager.FindByEmailAsync(loginDTO.Email);
            if (user is not null)
            {
                var result = await _manager.CheckPasswordAsync(user, loginDTO.Password);
                if (result)
                {
                    return new AuthorizedResponseDTO()
                    {
                        UserId = user.Id,
                        DisplayName = user.DisplayName,
                        Token = await GenerateTokenAsync(user),
                        RefreshToken = await GenerateRefreshTokenAsync(user),
                        Roles = await GetUserRoles(user)


                    };
                }
            }
            return null;

        }
        public async Task<IEnumerable<IdentityError>> RegisterAsync(RegisterDTO registerDTO, string role)
        {
            var newApplicationUser = new ApplicationUser()
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                DisplayName = registerDTO.DisplayName,

            };
            var createUserResult = await _manager.CreateAsync(newApplicationUser, registerDTO.Password);
            if (createUserResult.Succeeded)
            {
                var addUserToRoleResult = await _manager.AddToRoleAsync(newApplicationUser, role);
                return addUserToRoleResult.Errors;
            }
            return createUserResult.Errors;
        }
        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            // Token Security
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
            var credientials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            // Claims
            //Role Claims
            var Roles = await _manager.GetRolesAsync(user);
            var roleClaims = Roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            //Get User Claim From Db IF Exist
            var userCliam = await _manager.GetClaimsAsync(user);
            // union claim 
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.GivenName,user.DisplayName),
                new Claim (JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            }.Union(roleClaims).Union(userCliam);

            //build Token 
            var token = new JwtSecurityToken(
              issuer: _configuration["JWTSettings:Issuer"],
              expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWTSettings:DurationInMinutes"])),
              audience: _configuration["JWTSettings:Audience"],
              claims: claims,
              signingCredentials: credientials
              );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> GenerateRefreshTokenAsync(ApplicationUser user)
        {
            await _manager.RemoveAuthenticationTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken");
            var newRefreshToken = await _manager.GenerateUserTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken");
            await _manager.SetAuthenticationTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken", newRefreshToken);
            return newRefreshToken;
        }

        public async Task<bool> IsMailExistsAsync(string email)
        {
            var user = await _manager.FindByEmailAsync(email);
            return user is not null;
        }
        public async Task<AuthorizedResponseDTO> VerifyRefreshTokenAsync(TokenDTO tokenDTO)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenDTO.Token);
            var email = token.Claims.AsEnumerable().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            if (email is null)
            {
                return null;
            }
            var issure = token.Claims.AsEnumerable().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Iss)?.Value;
            if (issure is null)
            {
                return null;
            }
            var user = await _manager.FindByEmailAsync(email);
            if (user is null)
            {
                return null;
            }
            var row = _context.UserTokens.FirstOrDefault(q => q.UserId == user.Id);

            if (row is not null && row.UserId == user.Id &&
                issure == row.LoginProvider&&
                row.Value==tokenDTO.RefreshToken&&
                row.ExpireTime > DateTime.UtcNow)
            {
                return new AuthorizedResponseDTO
                {
                    UserId = user.Id,
                    DisplayName = user.DisplayName,
                    Token = await GenerateTokenAsync(user),
                    RefreshToken = await GenerateRefreshTokenAsync(user),
                    Roles = await GetUserRoles(user)
                };
            }
            await _manager.RemoveAuthenticationTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken");

            return null;


            //var isValid = await _manager.VerifyUserTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken", tokenDTO.RefreshToken);
            //if (!isValid)
            //{
            //    await _manager.RemoveAuthenticationTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken");
            //    return null;
            //}


            //var expiretime = _context.UserTokens.FirstOrDefault(q => q.UserId == user.Id).ExpireTime;
            //if (row.ExpireTime < DateTime.UtcNow)
            //{
            //    await _manager.RemoveAuthenticationTokenAsync(user, _configuration["JWTSettings:Issuer"], "RefreshToken");

            //    return null;
            //};


            //return new AuthorizedResponseDTO
            //{
            //    UserId = user.Id,
            //    DisplayName = user.DisplayName,
            //    Token = await GenerateTokenAsync(user),
            //    RefreshToken = await GenerateRefreshTokenAsync(user),
            //    Roles = await GetUserRoles(user)
            //};


        }

        public async Task<AuthorizedResponseDTO> GetCurrentUserAsync(string email)
        {
            var user = await _manager.FindByEmailAsync(email);
            if (user is not null)
            {
                return new AuthorizedResponseDTO()
                {
                    UserId = user.Id,
                    DisplayName = user.DisplayName,
                    Token = await GenerateTokenAsync(user),
                    RefreshToken = await GenerateRefreshTokenAsync(user),
                    Roles = await GetUserRoles(user)
                };
            }
            return null;
        }

        public async Task<IEnumerable<string>> GetUserRoles(ApplicationUser user)
        {
            return await _manager.GetRolesAsync(user);
        }




    }
}
