
using AddressBook.API.Extensions;

namespace AddressBook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices(builder.Configuration, builder.Environment);
            builder.Services.AddSwaggerDocumentation();
            var app = builder.Build();
            app.UseStaticFiles();


            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
