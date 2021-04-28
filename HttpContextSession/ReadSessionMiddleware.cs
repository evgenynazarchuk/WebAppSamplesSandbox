using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace HttpContextSession
{
    public class ReadSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public ReadSessionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            string key1 = Encoding.UTF8.GetString(ctx.Session.Get("key1"));
            int? key2 = ctx.Session.GetInt32("key2");
            string key3 = ctx.Session.GetString("key3");
            Person key4 = ctx.Session.GetObject<Person>("key4");

            await ctx.Response.WriteAsync($"{key1} {key2} {key3}\n{key4.FirstName} {key4.LastName}");
        }
    }
}
