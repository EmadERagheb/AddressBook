using AddressBook.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment)
        {
           
            services.AddDbContext<AddressBookDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    action => action.CommandTimeout(30).EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.LogTo(Console.WriteLine, LogLevel.Information);
                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                };
            });
            return services;

        }
    }
}
