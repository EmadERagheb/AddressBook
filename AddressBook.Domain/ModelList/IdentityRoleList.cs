using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.ModelList
{
    public class IdentityRoleList
    {
        public static List<IdentityRole> Roles { get; set; } = new List<IdentityRole>()
        {
           new IdentityRole()
           {
               Id="ce78aeb6-7cd4-47db-a96a-598bef56a1d9",
                Name = "Administrator",
               NormalizedName = "Administrator".ToUpper()
           },
           new IdentityRole()
           {
               Id="54364591-ad1f-42f9-ba53-2a25f8fb4dcf",
               Name="User",
               NormalizedName="User".ToUpper()
           }
        };
    }
}
