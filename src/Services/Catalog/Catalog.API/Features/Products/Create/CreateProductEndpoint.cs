using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Features.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Create
{
    [ApiController]
    [Route("api/products")]
    public class CreateProductEndpoint(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ProductDto> Create([FromBody] CreateProductDto productDto)
        {

            var command = new CreateProductCommand
            {
                ProductDto = productDto,
            };

            return await mediator.Send(command);
        }
    }
}
