using AddressBook.API.Errors;
using System.Net;
using System.Text.Json;

namespace AddressBook.API.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var respanse =
                     new APIException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());
                     
                //var respanse = _env.IsDevelopment() ?
                //     new APIException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                //     new APIException((int)HttpStatusCode.InternalServerError);


                var respanse = _env.IsDevelopment() ?
                     new APIException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                     new APIException((int)HttpStatusCode.InternalServerError,details:"please contact us tech team");
               

                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var serilizeJsoResponsen = JsonSerializer.Serialize(respanse, jsonOptions);
                await context.Response.WriteAsync(serilizeJsoResponsen);
            }
        }
    }
}
