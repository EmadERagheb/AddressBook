using AddressBook.Domain.DTOs.ApplicationUser;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Contracts
{
    public interface IAuthenticationManger
    {
        Task<AuthorizedResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task<IEnumerable<IdentityError>> RegisterAsync(RegisterDTO registerDTO, string role);
        Task<bool> IsMailExistsAsync(string email);

        Task<string> GenerateTokenAsync(ApplicationUser user);
        Task<AuthorizedResponseDTO> GetCurrentUserAsync(string email);

        //Very Important
        /// <summary>
        /// To Work With Refresh token you need 
        /// add token provider which we set at configuration  to identity configuration at program.cs
        /// and Add.DefaultToken Profiver

        Task<string> GenerateRefreshTokenAsync(ApplicationUser user);
        Task<AuthorizedResponseDTO> VerifyRefreshTokenAsync(TokenDTO tokenDTO);
    }
}
