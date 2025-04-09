using Catalog.API.Domain.DTOs.Brand;

namespace Catalog.API.Core.Interfaces
{
    public interface IBrandService
    {
        Task<BrandDto> CreateBrandAsync(CreateBrandDto brandDto);
        Task<BrandDto> GetBrandByIdAsync(Guid id);
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto> UpdateBrandAsync(Guid id, UpdateBrandDto brandDto);
        Task<bool> DeleteBrandAsync(Guid id);
    }
}
