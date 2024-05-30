namespace AddressBook.API.Extensions
{
    public static class SwaggerDocumentationExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {

            // Configure the HTTP request pipeline.


            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
