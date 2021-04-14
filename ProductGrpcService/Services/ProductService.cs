using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace ProductGrpcService.Services
{
    public class ProductService : ProductGrpcService.ProductService.ProductServiceBase
    {
        public override Task<ProductFull> GetProduct(ProductIdentity request, ServerCallContext context)
        {
            return Task.FromResult(new ProductFull
            {
                Id = 1,
                Name = "Product name"
            });
        }

        public override Task<ProductIdentity> CreateProduct(ProductFull request, ServerCallContext context)
        {
            return Task.FromResult(new ProductIdentity
            {
                Id = 1
            });
        }
    }
}
