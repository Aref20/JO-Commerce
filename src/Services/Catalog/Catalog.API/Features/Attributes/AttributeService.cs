using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Attribute;
using Catalog.API.Domain.DTOs.Attribute.Catalog.API.Domain.DTOs.Attribute;
using Catalog.API.Domain.Entities;
using Catalog.API.Domain.Entities.Relationships;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.Attributes
{
    public class AttributeService : IAttributeService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateAttributeDto> _createValidator;
        private readonly IValidator<UpdateAttributeDto> _updateValidator;

        public AttributeService(
            IDocumentSession session,
            IValidator<CreateAttributeDto> createValidator,
            IValidator<UpdateAttributeDto> updateValidator)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<AttributeDto> CreateAsync(CreateAttributeDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var attribute = dto.Adapt<Domain.Entities.Attribute>();
            attribute.CreatedAt = DateTime.UtcNow;
            _session.Store(attribute);
            await _session.SaveChangesAsync();
            return attribute.Adapt<AttributeDto>();
        }

        public async Task<List<AttributeDto>> GetAllAsync()
        {
            var attributes = await _session.Query<Domain.Entities.Attribute>().ToListAsync();
            return attributes.Adapt<List<AttributeDto>>();
        }

        public async Task<AttributeDto> GetByIdAsync(Guid id)
        {
            var attribute = await _session.LoadAsync<Domain.Entities.Attribute>(id);
            if (attribute == null)
                throw new NotFoundException($"Attribute with ID {id} not found");
            return attribute.Adapt<AttributeDto>();
        }

        public async Task<List<AttributeDto>> GetVariantAttributesAsync()
        {
            var attributes = await _session.Query<Domain.Entities.Attribute>()
                .Where(a => a.IsVariant)
                .ToListAsync();
            return attributes.Adapt<List<AttributeDto>>();
        }

        public async Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existing = await _session.LoadAsync<Domain.Entities.Attribute>(id);
            if (existing == null)
                throw new NotFoundException($"Attribute with ID {id} not found");

            dto.Adapt(existing);
            existing.UpdatedAt = DateTime.UtcNow;
            _session.Store(existing);
            await _session.SaveChangesAsync();
            return existing.Adapt<AttributeDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var attribute = await _session.LoadAsync<Domain.Entities.Attribute>(id);
            if (attribute == null)
                throw new NotFoundException($"Attribute with ID {id} not found");

            var hasProducts = await _session.Query<ProductAttribute>()
                .AnyAsync(pa => pa.AttributeId == id);
            if (hasProducts)
                throw new InvalidOperationException("Cannot delete attribute used by products");

            _session.Delete<Domain.Entities.Attribute>(id);
            await _session.SaveChangesAsync();
            return true;
        }
    }
}