using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace ListServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private IServiceCollection services;

        public void ConfigureServices(IServiceCollection services)
        {
            this.services = services;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Все сервисы</h1>");
                sb.Append("<table>");
                sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
                foreach (var svc in this.services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}
