using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Contexts
{
    public class AddressBookDbContext:DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext>options):base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),n=>n.Namespace== "AddressBook.Data.Configurations.AddressBook");
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties(typeof(string)).HaveMaxLength(500);
        }
    }
}
