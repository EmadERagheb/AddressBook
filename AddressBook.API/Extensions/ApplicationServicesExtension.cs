using AddressBook.API.Errors;
using AddressBook.Data.Contexts;
using AddressBook.Data.Helper;
using AddressBook.Data.Repositories;
using AddressBook.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
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

            #region IOC
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                     .SelectMany(e => e.Value.Errors)
                     .Select(e => e.ErrorMessage).ToArray();
                    var errorResponse = new APIValidationErrorResponse(error);
                    return new BadRequestObjectResult(errorResponse);
                };

            }
            );

            services.AddCors(setupAction=>
            setupAction.AddDefaultPolicy(configurePolicy =>
                configurePolicy.AllowAnyMethod().AllowAnyHeader().WithOrigins(configuration["ClientsOrgins"])));
            return services;

        }
    }
}
