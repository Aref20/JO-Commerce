using System.ComponentModel.DataAnnotations;
using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities;



namespace Catalog.API.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Slug { get; set; }  

        public Guid? ParentCategoryId { get; set; }  
        public Category? ParentCategory { get; set; } 

        public ICollection<Category> SubCategories { get; set; } = new List<Category>(); 

        [MaxLength(2048)] 
        public string? ImageUrl { get; set; } 

        public int DisplayOrder { get; set; } = 0; 

        public bool IsActive { get; set; } = true;  

        public SEOMetadata? SEO { get; set; } 

        public ICollection<CategoryAttribute> Attributes { get; set; } = new List<CategoryAttribute>();
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}