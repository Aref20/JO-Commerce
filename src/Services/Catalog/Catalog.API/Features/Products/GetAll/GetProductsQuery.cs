using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.GetAll
{
    public class GetProductsQuery : IRequest<Result<List<ProductDto>>>
    {
        public Guid TenantId { get; set; }
    }
}
