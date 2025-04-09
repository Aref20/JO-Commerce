using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Brand;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class BrandsController(IBrandService brandService) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<BrandDto>> Create([FromBody] CreateBrandDto brandDto)
        {
            var result = await brandService.CreateBrandAsync(brandDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BrandDto>> GetById(Guid id)
        {
            var result = await brandService.GetBrandByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> GetAll()
        {
            return Ok(await brandService.GetAllBrandsAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BrandDto>> Update(Guid id, [FromBody] UpdateBrandDto brandDto)
        {
            var result = await brandService.UpdateBrandAsync(id, brandDto);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await brandService.DeleteBrandAsync(id);
            return NoContent();
        }
    }
}
