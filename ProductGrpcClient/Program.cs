using System;
using System.Threading.Tasks;

namespace ProductGrpcClient
{
    class Program
    {
        static async Task Main()
        {
            using var channel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductGrpcService.ProductService.ProductServiceClient(channel);

            // async
            var responseGet = await client.GetProductAsync(new ProductGrpcService.ProductIdentity { Id = 1 });
            Console.WriteLine(responseGet.Name);

            // not async
            var responseCreate = client.CreateProduct(new ProductGrpcService.ProductFull { Id = 1, Name = "Product name" });
            Console.WriteLine(responseCreate.Id);
        }
    }
}
