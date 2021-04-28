using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HttpContextItems
{
    public class ReadItemsMiddleware
    {
        //private readonly RequestDelegate _next;

        public ReadItemsMiddleware(RequestDelegate next)
        {
            //this._next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            ctx.Items.TryGetValue("key1", out object value1);
            ctx.Items.TryGetValue("key2", out object value2);
            ctx.Items.TryGetValue("key3", out object value3);

            await ctx.Response.WriteAsync($"{value1} {value2} {value3}");

            //await this._next.Invoke(ctx);
        }
    }
}
