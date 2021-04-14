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

            ProductFull product1 = null;
            ProductFull product2 = null;
            for (var i = 0; i < 10; i++)
            {
                product1 = client.Request<ProductFull, ProductIdentity>(
                    ProductServiceMethods.GetProduct
                    , new ProductIdentity { Id = 1 }
                );

                client.Request(
                    ProductServiceMethods.GetProduct
                    , new ProductIdentity { Id = 1 }
                    , out product2
                );

                client.Request(
                    ProductServiceMethods.GetProduct
                    , new ProductIdentity { Id = 1 }
                    , out ProductFull product3
                );

                client.Request(
                    ProductServiceMethods.GetProduct
                    , new ProductIdentity { Id = 1 }
                );
            }

            Console.WriteLine(product1);
            Console.WriteLine(product2);
            //Console.WriteLine(product3);
        }

        public static class ProductServiceMethods
        {
            public const string GetProduct = "GetProduct";
        }
    }
}