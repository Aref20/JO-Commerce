using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domain.Entities.Relationships
{
    public class ProductTag : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public Guid TagId { get; set; }
        public Tag Tag { get; set; } = default!;
    }
}
