using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Attribute;
using Catalog.API.Domain.DTOs.Attribute.Catalog.API.Domain.DTOs.Attribute;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/attributes")]
    public class AttributesController : BaseController
    {
        private readonly IAttributeService _service;

        public AttributesController(IAttributeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttributeDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("variant")]
        public async Task<ActionResult<List<AttributeDto>>> GetVariantAttributes()
        {
            return Ok(await _service.GetVariantAttributesAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AttributeDto>> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<AttributeDto>> Create([FromBody] CreateAttributeDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AttributeDto>> Update(Guid id, [FromBody] UpdateAttributeDto dto)
        {
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}