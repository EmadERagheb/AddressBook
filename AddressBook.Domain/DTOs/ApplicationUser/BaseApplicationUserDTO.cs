using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain.DTOs.ApplicationUser
{
    public class BaseApplicationUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = " password expects at least 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be at least 6 characters")]
        public string Password { get; set; }
    }
}
