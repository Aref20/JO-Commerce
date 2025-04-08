using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Get
{
    [ApiController]
    [Route("api/products")]
    public class GetProductEndpoint(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<Result<ProductDto>> GetById(Guid id)
        {
            var query = new GetProductQuery { Id = id };
            return await mediator.Send(query);
        }

    }
}
