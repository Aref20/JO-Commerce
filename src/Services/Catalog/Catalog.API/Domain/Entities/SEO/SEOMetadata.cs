using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class SEOMetadata
    {
        [MaxLength(100)]
        public string? MetaTitle { get; set; }

        [MaxLength(200)]
        public string? MetaDescription { get; set; }

        [MaxLength(200)]
        public string? MetaKeywords { get; set; } 

        [MaxLength(100)]
        public string? OpenGraphTitle { get; set; } 

        [MaxLength(200)]
        public string? OpenGraphDescription { get; set; } 

        [MaxLength(2048)] 
        public string? OpenGraphImageUrl { get; set; }  
    }
}