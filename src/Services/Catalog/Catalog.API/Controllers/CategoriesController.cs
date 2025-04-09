// Create in Controllers/CategoriesController.cs
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Category;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto categoryDto)
        {
            var result = await categoryService.CreateCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            return Ok(await categoryService.GetCategoryByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll([FromQuery] bool includeInactive = false)
        {
            return Ok(await categoryService.GetAllCategoriesAsync(includeInactive));
        }

        [HttpGet("roots")]
        public async Task<ActionResult<List<CategoryDto>>> GetRootCategories([FromQuery] bool includeInactive = false)
        {
            return Ok(await categoryService.GetRootCategoriesAsync(includeInactive));
        }

        [HttpGet("{parentId:guid}/subcategories")]
        public async Task<ActionResult<List<CategoryDto>>> GetSubCategories(Guid parentId, [FromQuery] bool includeInactive = false)
        {
            return Ok(await categoryService.GetSubCategoriesAsync(parentId, includeInactive));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> Update(Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            return Ok(await categoryService.UpdateCategoryAsync(id, categoryDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}