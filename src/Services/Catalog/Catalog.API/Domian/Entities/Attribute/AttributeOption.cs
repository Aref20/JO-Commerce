using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities
{
    public class AttributeOption : BaseEntity // Inherit if using BaseEntity
    {
        public required string Value { get; set; } // Required in C# 11+
        public required string DisplayText { get; set; } // Required in C# 11+
        public int DisplayOrder { get; set; }
        public string? ColorCode { get; set; } // Nullable if optional
        public string? ImageUrl { get; set; } // Nullable if optional

        // Foreign Key & Navigation
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; } = default!;
    }
}
