using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Models
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set;}
    }
}
