using Catalog.API.Domain.Entities;

namespace Catalog.API.Domain.DTOs.Brand
{
    public class CreateBrandDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public required string Slug { get; set; }
        public SEOMetadata? SEO { get; set; }
    }
}
