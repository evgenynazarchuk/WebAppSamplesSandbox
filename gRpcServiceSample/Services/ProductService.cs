using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc;
using Grpc.Core;

namespace gRpcServiceSample.Services
{
    public class ProductService : Product.ProductBase
    {
        public override Task<ProductFull> GetProduct(ProductIdentity request, ServerCallContext context)
        {
            return Task.FromResult(new ProductFull
            {
                Id = 1,
                Name = "Product name"
            });
        }
    }
}
