using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Product;
using Catalog.API.Domain.Entities;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.Products
{
    public class ProductService : IProductService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateProductDto> _createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;

        public ProductService(
            IDocumentSession session,
            IValidator<CreateProductDto> createValidator,
            IValidator<UpdateProductDto> updateValidator)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
        {
            // Validate
            var validationResult = await _createValidator.ValidateAsync(productDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Create product
            var product = productDto.Adapt<Product>();
            product.CreatedAt = DateTime.UtcNow;
            product.CreatedBy = "System"; // Ideally from current user context

            _session.Store(product);
            await _session.SaveChangesAsync();

            return product.Adapt<ProductDto>();
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _session.LoadAsync<Product>(id);
            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");

            _session.Delete<Product>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _session.Query<Product>().ToListAsync();
            return products.Adapt<List<ProductDto>>();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _session.LoadAsync<Product>(id);
            if (product == null)
                throw new NotFoundException($"Product with ID {id} not found");

            return product.Adapt<ProductDto>();
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto productDto)
        {
            // Validate
            var validationResult = await _updateValidator.ValidateAsync(productDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = await _session.LoadAsync<Product>(id);
            if (existingProduct == null)
                throw new NotFoundException($"Product with ID {id} not found");

            // Map new values, keeping Id intact
            productDto.Adapt(existingProduct);
            existingProduct.UpdatedAt = DateTime.UtcNow;
            existingProduct.UpdatedBy = "System"; // Ideally from current user context

            _session.Store(existingProduct);
            await _session.SaveChangesAsync();

            return existingProduct.Adapt<ProductDto>();
        }
    }
}
