using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Product;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class ProductsController(IProductService productService) : BaseController
    {

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto productDto)
        {
            var result = await productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var result = await productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            return Ok(await productService.GetAllProductsAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] UpdateProductDto productDto)
        {
            var result = await productService.UpdateProductAsync(id, productDto);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}