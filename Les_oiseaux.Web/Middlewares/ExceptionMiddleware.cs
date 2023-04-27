using System.Net.Mime;

namespace Les_oiseaux.Web.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(
            HttpContext context,
            RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                await context.Response.WriteAsJsonAsync<dynamic>(new
                {
                    IsException = true,
                    Error = ex.Message,
                    Date = DateTime.Now
                });
            }
        }
    }
}
