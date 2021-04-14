using System;
using Grpc.Net.Client;
using ProductGrpcService;
using System.Threading.Tasks;

namespace ProductGrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductService.ProductServiceClient(channel);
            var response = await client.GetProductAsync(new ProductIdentity { Id = 1 });
            Console.WriteLine(response.Name);
        }
    }
}
