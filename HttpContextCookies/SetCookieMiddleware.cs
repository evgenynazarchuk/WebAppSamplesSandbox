using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HttpContextCookies
{
    public class SetCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public SetCookieMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            if (!ctx.Request.Cookies.ContainsKey("key1"))
            {
                ctx.Response.Cookies.Append("key1", "value1");
            }

            if (!ctx.Request.Cookies.ContainsKey("key2"))
            {
                Person person = new("First Name", "LastName");
                ctx.Response.Cookies.Append("key2", person);
            }

            await this._next.Invoke(ctx);
        }
    }
}
