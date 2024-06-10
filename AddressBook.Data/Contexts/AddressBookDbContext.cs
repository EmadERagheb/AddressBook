//using AddressBook.Data.Configurations.AddressBook;
using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AddressBook.Data.Contexts
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), n => n.Namespace == "AddressBook.Data.Configurations.AddressBook");
            base.OnModelCreating(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties(typeof(string)).HaveMaxLength(500);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseDomainModel>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
