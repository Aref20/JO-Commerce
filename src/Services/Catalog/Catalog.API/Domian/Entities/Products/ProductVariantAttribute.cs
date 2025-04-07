using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductVariantAttribute : BaseEntity, ITenant
    {
        public string Name { get; set; } = default!;
        public string Value { get; set; } = default!;

        // Relationship
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = default!;
        public Guid TenantId { get; set; }
    }
}
