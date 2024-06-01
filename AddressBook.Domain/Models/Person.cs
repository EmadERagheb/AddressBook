using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Models
{
    public class Person : BaseDomainModel
    {
        #region Columns
        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public string Street { get; set; }
        public string City { get; set; }

        public string State { get; set; }   

        public string PostalCode { get; set; }

        public int? DepartmentId { get; set; }
        #endregion
        #region RS
        #region PersonDepartment
        //person may be in one Department 
        //optional
        //column DepartmentId
        //Navigation Property
        public Department? Department { get; set; }
        #endregion

        #endregion

    }
}
