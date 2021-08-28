using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace HttpContextSession
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(configure =>
            {
                configure.Cookie.Name = "user_session";
                configure.Cookie.IsEssential = true;
                configure.IdleTimeout = TimeSpan.FromDays(1);
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();

            Person person = new("First Name", "Last Name");

            app.Use(async (ctx, next) =>
            {
                ctx.Session.Set("key1", Encoding.UTF8.GetBytes("value1"));
                ctx.Session.SetInt32("key2", 42);
                ctx.Session.SetString("key3", "value3");
                ctx.Session.SetObject("key4", person);

                await next.Invoke();
            });

            app.UseMiddleware<ReadSessionMiddleware>();
        }
    }
}
