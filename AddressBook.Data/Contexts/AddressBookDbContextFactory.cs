//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AddressBook.Data.Contexts
//{
//    public class AddressBookDbContextFactory : IDesignTimeDbContextFactory<AddressBookDbContext>
//    {
//        public AddressBookDbContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile(@"C:\Users\Emad\Desktop\AddressBook\AddressBook.API\appsettings.Development.json", false, true)
//                .Build();
//            var optionBuilder = new DbContextOptionsBuilder<AddressBookDbContext>();
//            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
//            return new AddressBookDbContext(optionBuilder.Options);
//        }
//    }
//}
