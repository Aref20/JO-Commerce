using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductVariant : BaseEntity, ITenant
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Sku { get; set; }
        public string Gtin { get; set; }
        public decimal Price { get; set; }
        public decimal? CompareAtPrice { get; set; }
        public decimal Cost { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public ICollection<VariantAttributeValue> AttributeValues { get; set; }
        public decimal Weight { get; set; }
    }
}
