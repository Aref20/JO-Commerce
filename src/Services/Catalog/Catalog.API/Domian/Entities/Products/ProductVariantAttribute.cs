using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities
{
    public class ProductVariantAttribute : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Value { get; set; } = default!;

        // Relationship
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = default!;
    }
}
