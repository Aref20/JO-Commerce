using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Brand;
using Catalog.API.Domain.Entities.Brand;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.Brands
{
    public class BrandService : IBrandService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateBrandDto>? _createValidator;
        private readonly IValidator<UpdateBrandDto>? _updateValidator;

        public BrandService(
            IDocumentSession session,
            IValidator<CreateBrandDto>? createValidator = null,
            IValidator<UpdateBrandDto>? updateValidator = null)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<BrandDto> CreateBrandAsync(CreateBrandDto brandDto)
        {
            // Validate if validator is provided
            if (_createValidator != null)
            {
                var validationResult = await _createValidator.ValidateAsync(brandDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            // Create brand
            var brand = brandDto.Adapt<Brand>();
            brand.CreatedAt = DateTime.UtcNow;
            brand.CreatedBy = "System"; // Ideally from current user context
            brand.IsActive = true;

            _session.Store(brand);
            await _session.SaveChangesAsync();

            return brand.Adapt<BrandDto>();
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var brand = await _session.LoadAsync<Brand>(id);
            if (brand == null)
                throw new NotFoundException($"Brand with ID {id} not found");

            _session.Delete<Brand>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _session.Query<Brand>().ToListAsync();
            return brands.Adapt<List<BrandDto>>();
        }

        public async Task<BrandDto> GetBrandByIdAsync(Guid id)
        {
            var brand = await _session.LoadAsync<Brand>(id);
            if (brand == null)
                throw new NotFoundException($"Brand with ID {id} not found");

            return brand.Adapt<BrandDto>();
        }

        public async Task<BrandDto> UpdateBrandAsync(Guid id, UpdateBrandDto brandDto)
        {
            // Validate if validator is provided
            if (_updateValidator != null)
            {
                var validationResult = await _updateValidator.ValidateAsync(brandDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var existingBrand = await _session.LoadAsync<Brand>(id);
            if (existingBrand == null)
                throw new NotFoundException($"Brand with ID {id} not found");

            // Map new values, keeping Id intact
            brandDto.Adapt(existingBrand);
            existingBrand.UpdatedAt = DateTime.UtcNow;
            existingBrand.UpdatedBy = "System"; // Ideally from current user context

            _session.Store(existingBrand);
            await _session.SaveChangesAsync();

            return existingBrand.Adapt<BrandDto>();
        }
    }
}
