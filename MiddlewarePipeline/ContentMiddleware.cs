using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewarePipeline
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello!");
            await _next.Invoke(context);
        }
    }
}
