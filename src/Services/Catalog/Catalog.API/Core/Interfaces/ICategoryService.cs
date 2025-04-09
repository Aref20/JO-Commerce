// Create in Core/Interfaces/ICategoryService.cs
using Catalog.API.Domain.DTOs.Category;

namespace Catalog.API.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<List<CategoryDto>> GetAllCategoriesAsync(bool includeInactive = false);
        Task<List<CategoryDto>> GetRootCategoriesAsync(bool includeInactive = false);
        Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<List<CategoryDto>> GetSubCategoriesAsync(Guid parentId, bool includeInactive = false);
    }
}