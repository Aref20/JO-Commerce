using Catalog.API.Domain.DTOs.Product;

namespace Catalog.API.Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto productDto);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
