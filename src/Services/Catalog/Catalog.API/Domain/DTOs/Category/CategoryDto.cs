// Create in Domain/DTOs/Category/CategoryDto.cs
using Catalog.API.Domain.Entities;

namespace Catalog.API.Domain.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Slug { get; set; } = null!;
        public Guid? ParentCategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public SEOMetadata? SEO { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public CategoryDto? ParentCategory { get; set; }
        public List<CategoryDto> SubCategories { get; set; } = new();
    }
}