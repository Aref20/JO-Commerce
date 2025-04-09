using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Tax;
using Catalog.API.Domain.Entities;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.TaxClasses
{
    public class TaxClassService : ITaxClassService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateTaxClassDto>? _createValidator;
        private readonly IValidator<UpdateTaxClassDto>? _updateValidator;

        public TaxClassService(
            IDocumentSession session,
            IValidator<CreateTaxClassDto>? createValidator = null,
            IValidator<UpdateTaxClassDto>? updateValidator = null)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<TaxClassDto> CreateTaxClassAsync(CreateTaxClassDto taxClassDto)
        {
            if (_createValidator != null)
            {
                var validationResult = await _createValidator.ValidateAsync(taxClassDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var taxClass = taxClassDto.Adapt<TaxClass>();
            taxClass.CreatedAt = DateTime.UtcNow;
            taxClass.CreatedBy = "System";

            _session.Store(taxClass);
            await _session.SaveChangesAsync();

            return taxClass.Adapt<TaxClassDto>();
        }

        public async Task<bool> DeleteTaxClassAsync(Guid id)
        {
            var taxClass = await _session.LoadAsync<TaxClass>(id);
            if (taxClass == null)
                throw new NotFoundException($"TaxClass with ID {id} not found");

            // Check if tax class is used by any products
            var isUsed = await _session.Query<Product>().AnyAsync(p => p.TaxClass.Id == id);
            if (isUsed)
                throw new InvalidOperationException("Cannot delete tax class that is assigned to products");

            _session.Delete<TaxClass>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<TaxClassDto>> GetAllTaxClassesAsync()
        {
            var taxClasses = await _session.Query<TaxClass>().ToListAsync();
            return taxClasses.Adapt<List<TaxClassDto>>();
        }

        public async Task<TaxClassDto> GetTaxClassByIdAsync(Guid id)
        {
            var taxClass = await _session.LoadAsync<TaxClass>(id);
            if (taxClass == null)
                throw new NotFoundException($"TaxClass with ID {id} not found");

            return taxClass.Adapt<TaxClassDto>();
        }

        public async Task<TaxClassDto> UpdateTaxClassAsync(Guid id, UpdateTaxClassDto taxClassDto)
        {
            if (_updateValidator != null)
            {
                var validationResult = await _updateValidator.ValidateAsync(taxClassDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var existingTaxClass = await _session.LoadAsync<TaxClass>(id);
            if (existingTaxClass == null)
                throw new NotFoundException($"TaxClass with ID {id} not found");

            taxClassDto.Adapt(existingTaxClass);
            existingTaxClass.UpdatedAt = DateTime.UtcNow;
            existingTaxClass.UpdatedBy = "System";

            _session.Store(existingTaxClass);
            await _session.SaveChangesAsync();

            return existingTaxClass.Adapt<TaxClassDto>();
        }
    }
}
