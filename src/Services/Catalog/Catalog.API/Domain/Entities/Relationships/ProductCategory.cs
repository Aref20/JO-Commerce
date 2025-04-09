using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domain.Entities.Relationships
{
    public class ProductCategory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
    }
}
