using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain.DTOs.Person
{
    public class PostPersonDTO : BasePersonDTO
    {
        //[Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public int? DepartmentId { get; set; }
    }
}
