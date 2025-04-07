using BuildingBlocks.BaseEntity;
using Catalog.API.Features.Products.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<Result<List<ProductDto>>>
    {
        public Guid TenantId { get; set; }
    }
}
