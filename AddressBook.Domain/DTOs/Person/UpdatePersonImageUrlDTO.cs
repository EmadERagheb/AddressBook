using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.Person
{
    public class UpdatePersonImageUrlDTO
    {
        public int Id { get; set; } 

        public IFormFile Image {  get; set; }
    }
}
