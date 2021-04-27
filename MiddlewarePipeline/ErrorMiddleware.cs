using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewarePipeline
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                await context.Response.WriteAsync("Error Auth");
            }
        }
    }
}