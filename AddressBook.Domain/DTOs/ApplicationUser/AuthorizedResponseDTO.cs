using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.ApplicationUser
{
    public class AuthorizedResponseDTO
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
