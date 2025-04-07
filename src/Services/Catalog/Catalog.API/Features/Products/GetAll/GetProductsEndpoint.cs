using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.GetAll
{
    [ApiController]
    [Route("api/products")]
    public class GetProductsEndpoint(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<Result<List<ProductDto>>> GetAll()
        {
            var query = new GetProductsQuery { };
            return await mediator.Send(query);
        }



    }
}
