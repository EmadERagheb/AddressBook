using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.Person
{
    public abstract class BasePersonDTO
    {
        [Required] 
        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }



    }
}
