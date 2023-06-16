using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<ExceptionHandlerMiddleware> Logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            Logger = logger;
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception exception)
            {
                await ExceptionResponseAsync(exception, context);
            }
        }
        private async Task ExceptionResponseAsync(Exception exception, HttpContext context)
        {
            context.Response.Headers.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(exception.Message)));
        }
    }
}