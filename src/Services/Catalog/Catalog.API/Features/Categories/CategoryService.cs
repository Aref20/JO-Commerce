// Create in Features/Categories/CategoryService.cs
using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Category;
using Catalog.API.Domain.Entities;
using FluentValidation;
using Mapster;
using Marten;
using Marten.Linq;

namespace Catalog.API.Features.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateCategoryDto>? _createValidator;
        private readonly IValidator<UpdateCategoryDto>? _updateValidator;

        public CategoryService(
            IDocumentSession session,
            IValidator<CreateCategoryDto>? createValidator = null,
            IValidator<UpdateCategoryDto>? updateValidator = null)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            // Validate if validator is provided
            if (_createValidator != null)
            {
                var validationResult = await _createValidator.ValidateAsync(categoryDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            // Check if parent category exists
            if (categoryDto.ParentCategoryId.HasValue)
            {
                var parentExists = await _session.Query<Category>()
                    .AnyAsync(c => c.Id == categoryDto.ParentCategoryId.Value);

                if (!parentExists)
                    throw new NotFoundException($"Parent category with ID {categoryDto.ParentCategoryId} not found");
            }

            // Create category
            var category = categoryDto.Adapt<Category>();
            category.CreatedAt = DateTime.UtcNow;
            category.CreatedBy = "System"; // Ideally from current user context

            _session.Store(category);
            await _session.SaveChangesAsync();

            return await GetCategoryByIdAsync(category.Id);
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _session.LoadAsync<Category>(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");

            // Check if category has subcategories
            var hasSubCategories = await _session.Query<Category>()
                .AnyAsync(c => c.ParentCategoryId == id);

            if (hasSubCategories)
                throw new InvalidOperationException("Cannot delete category with subcategories");

            _session.Delete<Category>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync(bool includeInactive = false)
        {
            var query = _session.Query<Category>().AsQueryable();

            if (!includeInactive)
                query = query.Where(c => c.IsActive);

            var categories = await query.ToListAsync();
            return await BuildCategoryTree(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _session.LoadAsync<Category>(id);
            if (category == null)
                throw new NotFoundException($"Category with ID {id} not found");

            var dto = category.Adapt<CategoryDto>();

            // Load parent category if exists
            if (category.ParentCategoryId.HasValue)
            {
                var parent = await _session.LoadAsync<Category>(category.ParentCategoryId.Value);
                dto.ParentCategory = parent?.Adapt<CategoryDto>();
            }

            return dto;
        }

        public async Task<List<CategoryDto>> GetRootCategoriesAsync(bool includeInactive = false)
        {
            var query = _session.Query<Category>()
                .Where(c => c.ParentCategoryId == null);

            if (!includeInactive)
                query = query.Where(c => c.IsActive);

            var categories = await query.ToListAsync();
            return await BuildCategoryTree(categories);
        }

        public async Task<List<CategoryDto>> GetSubCategoriesAsync(Guid parentId, bool includeInactive = false)
        {
            var query = _session.Query<Category>()
                .Where(c => c.ParentCategoryId == parentId);

            if (!includeInactive)
                query = query.Where(c => c.IsActive);

            var categories = await query.ToListAsync();
            return await BuildCategoryTree(categories);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            // Validate if validator is provided
            if (_updateValidator != null)
            {
                var validationResult = await _updateValidator.ValidateAsync(categoryDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var existingCategory = await _session.LoadAsync<Category>(id);
            if (existingCategory == null)
                throw new NotFoundException($"Category with ID {id} not found");

            // Check if parent category exists
            if (categoryDto.ParentCategoryId.HasValue)
            {
                var parentExists = await _session.Query<Category>()
                    .AnyAsync(c => c.Id == categoryDto.ParentCategoryId.Value);

                if (!parentExists)
                    throw new NotFoundException($"Parent category with ID {categoryDto.ParentCategoryId} not found");
            }

            // Map new values, keeping Id intact
            categoryDto.Adapt(existingCategory);
            existingCategory.UpdatedAt = DateTime.UtcNow;
            existingCategory.UpdatedBy = "System"; // Ideally from current user context

            _session.Store(existingCategory);
            await _session.SaveChangesAsync();

            return await GetCategoryByIdAsync(id);
        }

        private async Task<List<CategoryDto>> BuildCategoryTree(IReadOnlyList<Category> categories)
        {
            var dtos = categories.Adapt<List<CategoryDto>>();
            var result = new List<CategoryDto>();

            // Build hierarchy
            foreach (var dto in dtos.Where(c => c.ParentCategoryId == null))
            {
                await PopulateSubCategories(dto, dtos);
                result.Add(dto);
            }

            return result;
        }

        private async Task PopulateSubCategories(CategoryDto parent, List<CategoryDto> allCategories)
        {
            parent.SubCategories = allCategories
                .Where(c => c.ParentCategoryId == parent.Id)
                .ToList();

            foreach (var subCategory in parent.SubCategories)
            {
                await PopulateSubCategories(subCategory, allCategories);
            }
        }
    }
}