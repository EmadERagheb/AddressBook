using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Models
{
    public class Person:BaseDomainModel
    {
        #region Columns
        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public DateOnly BirthDate { get; set; }

        public Address Address { get; set; }

    

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
