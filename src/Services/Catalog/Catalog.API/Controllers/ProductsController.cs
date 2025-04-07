using MediatR;
using Microsoft.AspNetCore.Mvc;
using BuildingBlocks.BaseEntity;
using Catalog.API.Features.Products.Commands;
using Catalog.API.Features.Products.DTOs;
using Catalog.API.Features.Products.Queries;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<Result<List<ProductDto>>> GetAll()
        {
            var query = new GetProductsQuery {  };
            return await _mediator.Send(query);
        }

        [HttpGet("{id:guid}")]
        public async Task<Result<ProductDto>> GetById(Guid id)
        {
            var query = new GetProductQuery { Id = id };
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<Result<ProductDto>> Create([FromBody] CreateProductDto productDto)
        {

            var command = new CreateProductCommand
            {
                ProductDto = productDto,
            };

            return await _mediator.Send(command);
        }

        [HttpPut("{id:guid}")]
        public async Task<Result<ProductDto>> Update(Guid id, [FromBody] UpdateProductDto productDto)
        {


            var command = new UpdateProductCommand
            {
                Id = id,
                ProductDto = productDto
            };

            return await _mediator.Send(command);
        }

        [HttpDelete("{id:guid}")]
        public async Task<Result> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            return await _mediator.Send(command);
        }

        #region Helper Methods

        private Guid GetTenantId()
        {
            // In a real application, you would extract the tenant ID from:
            // 1. A claim in the user's JWT token
            // 2. A custom header
            // 3. Subdomain parsing
            // 4. A query parameter

            // For this example, we'll assume it comes from a header
            if (Request.Headers.TryGetValue("X-TenantId", out var tenantIdValue) &&
                Guid.TryParse(tenantIdValue, out var tenantId))
            {
                return tenantId;
            }

            return Guid.Empty;
        }

        #endregion
    }
}