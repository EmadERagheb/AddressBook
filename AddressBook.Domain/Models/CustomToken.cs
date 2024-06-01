using Microsoft.AspNetCore.Identity;

namespace AddressBook.Domain.Models
{
    public class CostumeToken : IdentityUserToken<string>
    {
        public DateTime ExpireTime
        {
            get;
            set;
        } = DateTime.UtcNow.AddDays(15);


    }
}

