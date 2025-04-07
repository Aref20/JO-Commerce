using BuildingBlocks.BaseEntity;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Domian.Entities.Products
{
    public class Product : BaseEntity, ITenant
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string SKU { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOnSale { get; set; }
        public int StockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }

        // SEO properties
        public string MetaTitle { get; set; } = default!;
        public string MetaDescription { get; set; }  = default!;
        public string MetaKeywords { get; set; } = default!;

        // Relationships
        public Guid? CategoryId { get; set; }
        public ProductCategory Category { get; set; }   = default!;
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public Guid TenantId { get; set; }
    }
}
