using AddressBook.Data.Contexts;
using AddressBook.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AddressBook.API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment  environment)
        {
            services.AddDbContext<AddressBookIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityDefaultConnection"),
                    setup => setup.CommandTimeout(30).EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null))
                .LogTo(Console.WriteLine, LogLevel.Information);
                if (environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging(true);
                    options.EnableDetailedErrors(true);
                }
            });

            services.AddIdentityCore<ApplicationUser>()
              .AddRoles<IdentityRole>()
              .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(configuration["JWTSettings:Issuer"])
              .AddEntityFrameworkStores<AddressBookIdentityDbContext>()
              .AddSignInManager<SignInManager<ApplicationUser>>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JWTSettings:Issuer"],
                ValidAudiences = configuration["JWTSettings:Audiences"].Split(","),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
            });

            services.AddAuthorization();
            //services.AddScoped<IAuthenticationManger, AuthenticationManger>();


            return services;
        }
    }
}
