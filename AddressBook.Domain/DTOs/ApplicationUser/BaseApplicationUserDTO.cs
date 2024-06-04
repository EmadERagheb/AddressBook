using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain.DTOs.ApplicationUser
{
    public class BaseApplicationUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
     
    }
}
