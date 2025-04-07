using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductVariant : BaseEntity, ITenant
    {
        public string SKU { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOnSale { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }

        // Relationship
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public ICollection<ProductVariantAttribute> VariantAttributes { get; set; } = new List<ProductVariantAttribute>();

        public Guid TenantId { get; set; }
    }
}
