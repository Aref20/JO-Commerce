using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.Get
{
    public class GetProductQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
    }
}
