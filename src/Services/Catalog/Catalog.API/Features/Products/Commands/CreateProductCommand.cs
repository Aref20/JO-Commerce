using BuildingBlocks.BaseEntity;
using Catalog.API.Features.Products.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.Commands;

public class CreateProductCommand : IRequest<Result<ProductDto>>
{
    public CreateProductDto ProductDto { get; set; }  = default!;
    public Guid TenantId { get; set; }
}

