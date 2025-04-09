using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities;
using Common.Enums;
using System.ComponentModel.DataAnnotations;


namespace Catalog.API.Domain.Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(250)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; } = string.Empty;

        public string FullDescription { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Sku { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Gtin { get; set; }

        [MaxLength(50)]
        public string? Mpn { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? CompareAtPrice { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Cost { get; set; }

        public required int StockQuantity { get; set; }
        public bool TrackInventory { get; set; }
        public bool AllowBackorder { get; set; }
        public int LowStockThreshold { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Weight { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Length { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Width { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Height { get; set; }

        public WeightUnit? WeightUnit { get; set; }
        public DimensionUnit? DimensionUnit { get; set; }
        public bool HasVariants { get; set; }
        public ProductType ProductType { get; set; }

        [MaxLength(300)]
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
