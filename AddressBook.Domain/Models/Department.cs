using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Models
{
    public class Department:BaseDomainModel
    {
        public string Name { get; set; }

        public int JobId { get; set; }


        #region RS
        #region PersonDepartment
        //Department may have may persons
        //optional
        //Navigation Property
        public List<Person> Persons { get; set; } = new List<Person>();
        #endregion
        #region DepartmentJob
        //Department must have job
        //required
        //column JobId
        //Navigation Property 
        public Job Job { get; set; }
        #endregion

        #endregion
    }
}
