using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace AddressBook.Domain.ModelList
{
    public class ApplicationUserList
    {
        public static List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>()
        {
            new ApplicationUser()
            {
                Id="c0bsdf33-57b5-4b18-8878-d24bda5e8e5a",
                Email="emaderagheb@gmail.com",
                NormalizedEmail="emaderagheb@gmail.com".ToUpper(),
                UserName="emaderagheb@gmail.com",
                DisplayName="Admin Emad",
                NormalizedUserName="emaderagheb@gmail.com".ToUpper(),
                EmailConfirmed=true,
                PasswordHash=(new PasswordHasher<ApplicationUser>()).HashPassword(null,"Pa$$word123"),
            }  ,  new ApplicationUser()
            {
                Id="c0bsdf33-57b5-4b18-2303-d24bda5e8e5a",
                Email="emadeidragheb@gmail.com",
                NormalizedEmail="emadeidragheb@gmail.com".ToUpper(),
                UserName="emadeidragheb@gmail.com",
                DisplayName="User Emad",
                NormalizedUserName="emadeidragheb@gmail.com".ToUpper(),
                EmailConfirmed=true,
                PasswordHash=(new PasswordHasher<ApplicationUser>()).HashPassword(null,"Pa$$word123"),
            }  ,
            new ApplicationUser()
            {
                Id="9d5489cc-09aa-46b1-a580-f18ec0084946",
                Email="shussein@tamweely.com.eg",
                NormalizedEmail="shussein@tamweely.com.eg".ToUpper(),
                UserName="shussein@tamweely.com.eg",
                DisplayName="Sameh Hussein",
                NormalizedUserName="sushussein@tamweely.com.eg".ToUpper(),
                EmailConfirmed=true,
                PasswordHash=(new PasswordHasher<ApplicationUser>()).HashPassword(null,"Pa$$word123@UAE"),
            }  ,
            new ApplicationUser()
            {
                Id="9d5489cc-09aa-46b1-a580-f18ec1235874",
                Email="admin.shussein@tamweely.com.eg",
                NormalizedEmail="admin.shussein@tamweely.com.eg".ToUpper(),
                UserName="admin.shussein@tamweely.com.eg",
                DisplayName="Admin Sameh Hussein",
                NormalizedUserName="admin.sushussein@tamweely.com.eg".ToUpper(),
                EmailConfirmed=true,
                PasswordHash=(new PasswordHasher<ApplicationUser>()).HashPassword(null,"Pa$$word123@Admin"),
            }
        };
    }
}
