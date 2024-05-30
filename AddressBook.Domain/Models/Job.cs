using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Models
{
    public class Job:BaseDomainModel
    {

        #region Column
        public string Name { get; set; }
        #endregion

        #region RS


        #region DepartmentJob
        //job has list of department
        //no cloumn
        //navigation property
        public List<Department> Departments { get; set; } = new List<Department>();
        #endregion
        #region MyRegion

        #endregion
        #endregion
    }
}
