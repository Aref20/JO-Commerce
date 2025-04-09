using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class SEOMetadata
    {
        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }


        public string? MetaKeywords { get; set; } 

        public string? OpenGraphTitle { get; set; } 

        public string? OpenGraphDescription { get; set; } 

        public string? OpenGraphImageUrl { get; set; }  
    }
}