using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HttpContextCookies
{
    public class ReadCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public ReadCookieMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            ctx.Request.Cookies.TryGetValue("key1", out string value1);
            ctx.Request.Cookies.TryGetValue("key2", out Person person);

            await ctx.Response.WriteAsync($"{value1}\n{person?.FirstName} {person?.LastName}");

            await this._next.Invoke(ctx);
        }
    }
}
