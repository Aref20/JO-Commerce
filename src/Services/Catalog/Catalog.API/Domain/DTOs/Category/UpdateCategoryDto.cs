// Create in Domain/DTOs/Category/UpdateCategoryDto.cs
using Catalog.API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.Category
{
    public class UpdateCategoryDto
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