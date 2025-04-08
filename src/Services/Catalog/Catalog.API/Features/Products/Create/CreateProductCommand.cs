using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Features.Products.Create;
using MediatR;

namespace Catalog.API.Features.Products.CreateProduct;

public class CreateProductCommand : IRequest<ProductDto>
{
    public CreateProductDto ProductDto { get; set; }  = default!;
}

