using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace UseConfigurationBuilder
{
    public class Startup
    {
        public Startup(IConfiguration configurationBase)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                })
                .AddJsonFile("Configs/country.json")
                .AddXmlFile("Configs/ui.xml")
                .AddXmlFile("Configs/person.xml")
                .AddIniFile("Configs/network.ini")
                .AddEnvironmentVariables()
                .AddConfiguration(configurationBase);

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfiguration>(provider => this.Configuration);
            services.Configure<Network>(Configuration);
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ReadConfigurationMiddleware>();
        }
    }
}
