using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace HttpContextCookies
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<SetCookieMiddleware>();
            app.UseMiddleware<ReadCookieMiddleware>();
            app.Run(async ctx => await ctx.Response.WriteAsync("Hello"));
        }
    }
}
