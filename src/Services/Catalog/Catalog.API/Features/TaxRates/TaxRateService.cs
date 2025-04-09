// Features/TaxRates/TaxRateService.cs
using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.TaxRate;
using Catalog.API.Domain.Entities;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.TaxRates
{
    public class TaxRateService : ITaxRateService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateTaxRateDto>? _createValidator;
        private readonly IValidator<UpdateTaxRateDto>? _updateValidator;

        public TaxRateService(
            IDocumentSession session,
            IValidator<CreateTaxRateDto>? createValidator = null,
            IValidator<UpdateTaxRateDto>? updateValidator = null)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<TaxRateDto> CreateTaxRateAsync(CreateTaxRateDto taxRateDto)
        {
            if (_createValidator != null)
            {
                var validationResult = await _createValidator.ValidateAsync(taxRateDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            // Verify tax class exists
            var taxClassExists = await _session.Query<TaxClass>().AnyAsync(tc => tc.Id == taxRateDto.TaxClassId);
            if (!taxClassExists)
                throw new NotFoundException($"TaxClass with ID {taxRateDto.TaxClassId} not found");

            var taxRate = taxRateDto.Adapt<TaxRate>();
            taxRate.CreatedAt = DateTime.UtcNow;
            taxRate.CreatedBy = "System";

            _session.Store(taxRate);
            await _session.SaveChangesAsync();

            return taxRate.Adapt<TaxRateDto>();
        }

        public async Task<bool> DeleteTaxRateAsync(Guid id)
        {
            var taxRate = await _session.LoadAsync<TaxRate>(id);
            if (taxRate == null)
                throw new NotFoundException($"TaxRate with ID {id} not found");

            _session.Delete<TaxRate>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<TaxRateDto>> GetAllTaxRatesAsync()
        {
            var taxRates = await _session.Query<TaxRate>().ToListAsync();
            return taxRates.Adapt<List<TaxRateDto>>();
        }

        public async Task<TaxRateDto> GetTaxRateByIdAsync(Guid id)
        {
            var taxRate = await _session.LoadAsync<TaxRate>(id);
            if (taxRate == null)
                throw new NotFoundException($"TaxRate with ID {id} not found");

            return taxRate.Adapt<TaxRateDto>();
        }

        public async Task<List<TaxRateDto>> GetTaxRatesByClassAsync(Guid taxClassId)
        {
            var taxRates = await _session.Query<TaxRate>()
                .Where(tr => tr.TaxClassId == taxClassId)
                .ToListAsync();

            return taxRates.Adapt<List<TaxRateDto>>();
        }

        public async Task<TaxRateDto> UpdateTaxRateAsync(Guid id, UpdateTaxRateDto taxRateDto)
        {
            if (_updateValidator != null)
            {
                var validationResult = await _updateValidator.ValidateAsync(taxRateDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            // Verify tax class exists
            var taxClassExists = await _session.Query<TaxClass>().AnyAsync(tc => tc.Id == taxRateDto.TaxClassId);
            if (!taxClassExists)
                throw new NotFoundException($"TaxClass with ID {taxRateDto.TaxClassId} not found");

            var existingTaxRate = await _session.LoadAsync<TaxRate>(id);
            if (existingTaxRate == null)
                throw new NotFoundException($"TaxRate with ID {id} not found");

            taxRateDto.Adapt(existingTaxRate);
            existingTaxRate.UpdatedAt = DateTime.UtcNow;
            existingTaxRate.UpdatedBy = "System";

            _session.Store(existingTaxRate);
            await _session.SaveChangesAsync();

            return existingTaxRate.Adapt<TaxRateDto>();
        }
    }
}