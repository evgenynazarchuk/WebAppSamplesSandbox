using System;
using System.Threading.Tasks;
using ProductGrpcService;

namespace ProductGrpcClient
{
    class Program
    {
        static void Main()
        {
            //using var channel = Grpc.Net.Client.GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new ProductGrpcService.ProductService.ProductServiceClient(channel);

            // async
            //var responseGet = await client.GetProductAsync(new ProductGrpcService.ProductIdentity { Id = 1 });
            //Console.WriteLine(responseGet.Name);
            //
            //// not async
            //var responseCreate = client.CreateProduct(new ProductGrpcService.ProductFull { Id = 1, Name = "Product name" });
            //Console.WriteLine(responseCreate.Id);

            var serviceType = typeof(ProductGrpcService.ProductService.ProductServiceClient);
            var address = "https://localhost:5001";

            var client = new GrpcClientTool(serviceType, address);

            ProductSimpleDto product2;
            ProductSimpleDto product3;

            client.Request(
                ProductServiceMethods.GetProduct,
                new ProductIdentityDto { Id = 1 },
                out ProductSimpleDto product1
            ); // 1

            { // block
                client.Request(
                    ProductServiceMethods.GetProduct,
                    new ProductIdentityDto { Id = 1 },
                    out product2
                ); // 2
            }

            product3 = client.Request<ProductSimpleDto, ProductIdentityDto>(
                    ProductServiceMethods.GetProduct,
                    new ProductIdentityDto { Id = 1 }
            ); // 3

            client.Request(
                ProductServiceMethods.GetProduct,
                new ProductIdentityDto { Id = 1 }
            ); // 4

            Console.WriteLine(product1);
            Console.WriteLine(product2);
            Console.WriteLine(product3);
        }

        public static class ProductServiceMethods
        {
            public const string GetProduct = "GetProduct";
        }

        public static class ProductBuilder
        {
            public static ProductIdentityDto BuildDefaultProductIdentity()
            {
                return new ProductIdentityDto { Id = 1 };
            }
        }
    }
}