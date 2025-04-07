using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductImage : BaseEntity, ITenant
    {
        public string Url { get; set; } = default!;
        public string AltText { get; set; } = default!;
        public int SortOrder { get; set; }
        public bool IsDefault { get; set; }

        // Relationship
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public Guid TenantId { get; set; }
    }
}
