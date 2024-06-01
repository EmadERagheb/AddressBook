using AddressBook.API.Errors;
using AddressBook.Domain.Contracts;
using AddressBook.Domain.DTOs.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthenticationManger _manger;

        public AccountsController(IAuthenticationManger manger)
        {
            _manger = manger;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthorizedResponseDTO>> Login(LoginDTO loginDTO)
        {
            var result = await _manger.LoginAsync(loginDTO);
            return result is not null ? Ok(result) : Unauthorized(new APIResponse(401));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost("register")]
       
        public async Task<ActionResult<AuthorizedResponseDTO>> Register(RegisterDTO registerDTO)
        {
            if (await _manger.IsMailExistsAsync(registerDTO.Email))
            {
                return BadRequest(
                    new APIValidationErrorResponse(new List<string>() { $"the mail {registerDTO.Email} is already token." }));
            }
            else
            {
                var errors = await _manger.RegisterAsync(registerDTO, "User");
                if (!errors.Any())
                {
                    return await _manger.LoginAsync(new LoginDTO() { Email = registerDTO.Email, Password = registerDTO.Password });
                }
                return BadRequest(new APIValidationErrorResponse(errors.Select(e => e.Description).ToArray()));
            }
        }
        [Authorize()]
        [HttpGet("getCurrentUser")]
        public async Task<ActionResult<AuthorizedResponseDTO>> GetCurrentUser()
        {
            var email = User.Claims.FirstOrDefault(q => q.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
                return Unauthorized(new APIResponse(401));
            else
            {
                var result = await _manger.GetCurrentUserAsync(email);
                if (result == null)
                    return Unauthorized(new APIResponse(401));
                else
                    return Ok(result);
            }


        }
        [HttpGet("isEmailExist")]
        public async Task<ActionResult<bool>> IsMailExists(string email)
        {
            return await _manger.IsMailExistsAsync(email);
        }

        [HttpPost("isValidRefreshToken")]
        public async Task<ActionResult<AuthorizedResponseDTO>> IsValidRefreshToken(TokenDTO tokenDTO)
        {
            var result = await _manger.VerifyRefreshTokenAsync(tokenDTO);
            return result is null ? Unauthorized(new APIResponse(401)) : Ok(result);

        }
    }
}

