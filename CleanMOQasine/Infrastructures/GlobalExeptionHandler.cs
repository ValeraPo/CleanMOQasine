using System.Net;
using System.Text.Json;

namespace CleanMOQasine.API.Infrastructures
{
    public class GlobalExeptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                ConstructResponse(context, HttpStatusCode.BadRequest, error.Message);
            }
        }

        private async Task ConstructResponse (HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "applications/json";
            context.Response.StatusCode = (int)code;
            var result = JsonSerializer.Serialize(new { message = message });
            await context.Response.WriteAsync(result);
        }
    }
}
