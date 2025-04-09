using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities;

namespace Catalog.API.Domain.Entities
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
