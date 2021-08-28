using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO.Compression;

namespace AppWithResponseCache
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // for kestrel
            services.AddResponseCompression(configureOptions =>
            {
                configureOptions.EnableForHttps = true;
                configureOptions.Providers.Clear();
                configureOptions.Providers.Add(new BrotliCompressionProvider(new BrotliCompressionProviderOptions()
                {
                    Level = CompressionLevel.Optimal
                }));
                configureOptions.Providers.Add(new GzipCompressionProvider(new GzipCompressionProviderOptions()
                {
                    Level = CompressionLevel.Optimal
                }));
            });

            // for kestrel
            //services.Configure<BrotliCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Optimal;
            //});
            //
            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Optimal;
            //});

            services.AddControllersWithViews(configure =>
            {
                // control cache (iis, apache, nginx, proxy)
                configure.CacheProfiles.Add("No Cache", new CacheProfile
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });

                configure.CacheProfiles.Add("Public Cache", new CacheProfile
                {
                    Duration = 300,
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                });

                configure.CacheProfiles.Add("Client Cache", new CacheProfile
                {
                    Duration = 300,
                    Location = ResponseCacheLocation.Client,
                    NoStore = false
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
                }
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
