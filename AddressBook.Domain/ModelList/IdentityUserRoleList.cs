using Microsoft.AspNetCore.Identity;

namespace AddressBook.Domain.ModelList
{
    public class IdentityUserRoleList
    {
        public static List<IdentityUserRole<string>> UserRoles { get; set; } = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>()
            {
                UserId="c0bsdf33-57b5-4b18-8878-d24bda5e8e5a",
                RoleId="ce78aeb6-7cd4-47db-a96a-598bef56a1d9"
            }  ,
            new IdentityUserRole<string>()
            {
                UserId="c0bsdf33-57b5-4b18-2303-d24bda5e8e5a",
                RoleId="54364591-ad1f-42f9-ba53-2a25f8fb4dcf"

            }  ,
            new IdentityUserRole<string>()
            {
                UserId="9d5489cc-09aa-46b1-a580-f18ec0084946",
                RoleId="54364591-ad1f-42f9-ba53-2a25f8fb4dcf"
            },
            new IdentityUserRole<string>()
            {
                UserId="9d5489cc-09aa-46b1-a580-f18ec1235874",
                RoleId="ce78aeb6-7cd4-47db-a96a-598bef56a1d9"
            }
        };
    }
}
