using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities;

namespace Catalog.API.Domain.Entities
{
    public class CategoryAttribute : BaseEntity  // Inherit if needed
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;  // Required navigation

        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; } = default!;  // Required navigation

        public bool IsRequired { get; set; } = false;  // Default to false
        public int DisplayOrder { get; set; } = 0;  // Default to 0
    }
}
