using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using Catalog.API.Features.Products.CreateProduct;
using Catalog.API.Features.Products.DeleteProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Delete
{
    [ApiController]
    [Route("api/products")]
    public class DeleteProductEndpoint(IMediator mediator) : ControllerBase
    {
        [HttpDelete("{id:guid}")]
        public async Task<Result> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            return await mediator.Send(command);
        }
    }
}
