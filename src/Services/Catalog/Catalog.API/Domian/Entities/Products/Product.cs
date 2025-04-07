using BuildingBlocks.BaseEntity;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Catalog.API.Domian.Entities.Products
{
    public class Product : BaseEntity, ITenant
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Sku { get; set; }
        public string Gtin { get; set; } // Global Trade Item Number
        public string Mpn { get; set; } // Manufacturer Part Number
        public decimal Price { get; set; }
        public decimal? CompareAtPrice { get; set; }
        public decimal Cost { get; set; }
        public int StockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool AllowBackorder { get; set; }
        public int LowStockThreshold { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string WeightUnit { get; set; }
        public string DimensionUnit { get; set; }
        public bool HasVariants { get; set; }
        public ProductType ProductType { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; }
        public ICollection<ProductVariant> Variants { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public ICollection<ProductTag> Tags { get; set; }
        public SEOMetadata SEO { get; set; }
        public TaxClass TaxClass { get; set; }
    }
}
