

using Catalog.API.Domain.Entities;

namespace Catalog.API.Domian.DTOs.Brand
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public required string Slug { get; set; }
        public SEOMetadata? SEO { get; set; }
    }
}
