using BuildingBlocks.BaseEntity;
using Catalog.API.Features.Products.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.Queries
{
    public class GetProductQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
    }
}
