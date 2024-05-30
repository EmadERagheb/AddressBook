using AddressBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.ModelList
{
    public static class JobList
    {
        public static List<Job>Jobs { get; set; }= new List<Job>()
        {
            new Job(){Id=1, Name="Doctor"},
            new Job(){Id=2, Name="Engineer"},
            new Job(){Id=3, Name= "Layer"},
            new Job(){Id=4, Name="Teacher"},
        };
    }
}
