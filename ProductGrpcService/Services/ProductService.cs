using Grpc.Core;
using System.Threading.Tasks;

namespace ProductGrpcService.Services
{
    public class ProductService : ProductGrpcService.ProductService.ProductServiceBase
    {
        public override Task<ProductSimpleDto> GetProduct(ProductIdentityDto request, ServerCallContext context)
        {
            return Task.FromResult(new ProductSimpleDto
            {
                Id = 1,
                Name = "Product name"
            });
        }

        public override Task<ProductIdentityDto> CreateProduct(ProductSimpleDto request, ServerCallContext context)
        {
            return Task.FromResult(new ProductIdentityDto
            {
                Id = 1
            });
        }
    }
}
