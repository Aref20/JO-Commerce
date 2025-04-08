using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Features.Products.Commands;
using Catalog.API.Features.Products.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Update
{
    [ApiController]
    [Route("api/products")]
    public class UpdateProductsEndpoint(IMediator mediator) : ControllerBase
    {


        [HttpPut("{id:guid}")]
        public async Task<Result<ProductDto>> Update(Guid id, [FromBody] UpdateProductDto productDto)
        {


            var command = new UpdateProductCommand
            {
                Id = id,
                ProductDto = productDto
            };

            return await mediator.Send(command);
        }



    }
}
