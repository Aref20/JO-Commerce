using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domian.Entities.Brand
{
    public class Brand : BaseEntity // Inherits ID, TenantId, audit fields if needed
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; } // Nullable if optional

        [MaxLength(2048)] // URL length limit
        public string? LogoUrl { get; set; } // Nullable if optional

        [Required]
        [MaxLength(100)]
        public required string Slug { get; set; } // SEO-friendly URL

        public bool IsActive { get; set; } = true; // Default to true

        public SEOMetadata? SEO { get; set; } // Nullable if optional

        // Navigation property (if Brand has Products)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
