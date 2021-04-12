using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AppRunSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var product = new Product(name: "Automotive");
            app.Run(async (ctx) =>
            {
                //await ctx.Response.WriteAsync("Hello world");
                await ctx.Response.WriteAsJsonAsync(product);
            });
        }

        public class Product
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }

            public Product(string name, Guid? id = null)
            {
                this.Id = id ?? Guid.NewGuid();
                this.Name = name;
            }
        }
    }
}
