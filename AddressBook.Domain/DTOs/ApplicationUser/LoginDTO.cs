﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.ApplicationUser
{
    public class LoginDTO:BaseApplicationUserDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
