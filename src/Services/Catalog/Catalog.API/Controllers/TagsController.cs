// Controllers/TagsController.cs
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Tag;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class TagsController(ITagService tagService) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<TagDto>> Create([FromBody] CreateTagDto tagDto)
        {
            var result = await tagService.CreateTagAsync(tagDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TagDto>> GetById(Guid id)
        {
            return Ok(await tagService.GetTagByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDto>>> GetAll()
        {
            return Ok(await tagService.GetAllTagsAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TagDto>> Update(Guid id, [FromBody] UpdateTagDto tagDto)
        {
            return Ok(await tagService.UpdateTagAsync(id, tagDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await tagService.DeleteTagAsync(id);
            return NoContent();
        }
    }
}