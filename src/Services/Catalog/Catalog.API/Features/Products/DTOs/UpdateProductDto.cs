namespace Catalog.API.Features.Products.DTOs
{
    public class UpdateProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string SKU { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsOnSale { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
    }
}
