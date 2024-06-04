using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.ApplicationUser
{
    public class RegisterDTO:BaseApplicationUserDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = " password expects at least 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be at least 6 characters")]
        public string Password { get; set; }
    }
}
