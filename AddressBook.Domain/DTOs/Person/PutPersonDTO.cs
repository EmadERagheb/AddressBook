namespace AddressBook.Domain.DTOs.Person
{
    public class PutPersonDTO : BasePersonDTO
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public int? DepartmentId { get; set; }
    }
}
