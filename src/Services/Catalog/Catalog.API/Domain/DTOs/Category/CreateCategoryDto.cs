
using Catalog.API.Domain.Entities;

namespace Catalog.API.Domain.DTOs.Category
{
    public class CreateCategoryDto
    {

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Slug { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public SEOMetadata? SEO { get; set; }
    }
}