using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.Person
{
    public class GetPagingPersonsDTO:BasePersonDTO
    {
        public string Department { get; set; }

        public string Job { get; set; }
    }
}
