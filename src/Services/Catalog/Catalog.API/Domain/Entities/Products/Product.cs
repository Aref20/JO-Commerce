using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities.Relationships;
using Common.Enums;
using System.ComponentModel.DataAnnotations;


namespace Catalog.API.Domain.Entities
{
    public class Product : BaseEntity
    {
   
        public required string Name { get; set; }
        public string ShortDescription { get; set; } = string.Empty;

        public string FullDescription { get; set; } = string.Empty;

        public string Sku { get; set; } = string.Empty;
        public string? Gtin { get; set; }

        public string? Mpn { get; set; }

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }

        public decimal? Cost { get; set; }

        public required int StockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool AllowBackorder { get; set; }
        public int LowStockThreshold { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public WeightUnit? WeightUnit { get; set; }
        public DimensionUnit? DimensionUnit { get; set; }
        public bool HasVariants { get; set; }
        public ProductType ProductType { get; set; }

        public string Slug { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public Guid BrandId { get; set; }
        public virtual Brand.Brand Brand { get; set; } = default!;

        public virtual ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
        public virtual ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<RelatedProduct> RelatedProducts { get; set; } = new List<RelatedProduct>();
        public virtual ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();

        public SEOMetadata? SEO { get; set; }
        public virtual TaxClass TaxClass { get; set; } = default!;
    }



}
