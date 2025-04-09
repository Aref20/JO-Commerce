// Controllers/TaxClassesController.cs
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Tax;

using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class TaxClassesController(ITaxClassService taxClassService) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<TaxClassDto>> Create([FromBody] CreateTaxClassDto taxClassDto)
        {
            var result = await taxClassService.CreateTaxClassAsync(taxClassDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaxClassDto>> GetById(Guid id)
        {
            return Ok(await taxClassService.GetTaxClassByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<TaxClassDto>>> GetAll()
        {
            return Ok(await taxClassService.GetAllTaxClassesAsync());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TaxClassDto>> Update(Guid id, [FromBody] UpdateTaxClassDto taxClassDto)
        {
            return Ok(await taxClassService.UpdateTaxClassAsync(id, taxClassDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await taxClassService.DeleteTaxClassAsync(id);
            return NoContent();
        }
    }
}