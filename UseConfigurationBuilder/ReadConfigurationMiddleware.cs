using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace UseConfigurationBuilder
{
    public class ReadConfigurationMiddleware
    {
        //private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly Network _network;

        public ReadConfigurationMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            IOptions<Network> network
            )
        {
            //this._next = next;
            this._configuration = configuration;
            this._network = network.Value;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            Person person = new();
            Country country = new();

            _configuration.Bind(person);
            country = _configuration.GetSection("country").Get<Country>();

            await ctx.Response.WriteAsync($"{this._configuration["key1"]} {this._configuration["key2"]}\n" +
                $"{this._configuration["CountryName"]} {this._configuration["CapitalInfo:Name"]}\n" +
                $"{this._configuration["text"]} {this._configuration["info:description"]}\n" +
                $"{this._configuration["address"]} {this._configuration["host"]}\n" +
                $"{this._configuration["key3"]} {this._configuration["key4"]}\n" +
                $"{this._configuration["KeyNotFound"]}\n" +
                $"{person?.FirstName} {person?.LastName} {person?.Country?.Name} {person?.Country?.Capital}\n" +
                $"{country.Name} {country.Capital}\n" +
                $"{this._network.Address} {this._network.Host}");
        }
    }
}
