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
    }
}
