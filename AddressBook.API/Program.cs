
using AddressBook.API.Extensions;
using AddressBook.API.MiddleWares;
using AddressBook.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices(builder.Configuration, builder.Environment);
            builder.Services.AddIdentityService(builder.Configuration, builder.Environment);
            builder.Services.AddSwaggerDocumentation();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseSwaggerDocumentation();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            #region Insure DataBase Exists And Seeds Before Run Application
            //if (app.Environment.IsProduction())
            //{

            //    using var scope = app.Services.CreateScope();
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AddressBookDbContext>();
            //    var identitycontext = services.GetRequiredService<AddressBookIdentityDbContext>();
            //    var logger = services.GetRequiredService<ILogger<Program>>();
            //    try
            //    {

            //        await context.Database.MigrateAsync();
            //        await identitycontext.Database.MigrateAsync();
            //        logger.LogInformation("migration run success");

            //    }
            //    catch (Exception ex)
            //    {

            //        logger.LogError(ex, "An Error occurred During Migration");
            //    }
            //}


            #endregion


            app.Run();
        }
    }
}
