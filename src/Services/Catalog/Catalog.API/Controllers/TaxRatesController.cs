// Controllers/TaxRatesController.cs
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.TaxRate;
using Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class TaxRatesController(ITaxRateService taxRateService) : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<TaxRateDto>> Create([FromBody] CreateTaxRateDto taxRateDto)
        {
            var result = await taxRateService.CreateTaxRateAsync(taxRateDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaxRateDto>> GetById(Guid id)
        {
            return Ok(await taxRateService.GetTaxRateByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<TaxRateDto>>> GetAll()
        {
            return Ok(await taxRateService.GetAllTaxRatesAsync());
        }

        [HttpGet("by-class/{taxClassId:guid}")]
        public async Task<ActionResult<List<TaxRateDto>>> GetByClass(Guid taxClassId)
        {
            return Ok(await taxRateService.GetTaxRatesByClassAsync(taxClassId));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TaxRateDto>> Update(Guid id, [FromBody] UpdateTaxRateDto taxRateDto)
        {
            return Ok(await taxRateService.UpdateTaxRateAsync(id, taxRateDto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await taxRateService.DeleteTaxRateAsync(id);
            return NoContent();
        }
    }
}