using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductAttribute : BaseEntity, ITenant
    {
        public string Name { get; set; }  = default!;
        public string Value { get; set; } = default!;

        // Relationship
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public Guid TenantId { get; set; }
    }
}
