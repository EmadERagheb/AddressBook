using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.DTOs.Person
{
    public class GetPagingPersonsDTO:BasePersonDTO
    {
        public int Id { get; set; }

        public string Department { get; set; }

        public string Job { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
