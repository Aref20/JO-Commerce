using BuildingBlocks.BaseEntity;
using Common.Enums;

namespace Catalog.API.Domain.Entities
{
    public class Attribute : BaseEntity // Inherit if using BaseEntity
    {
        public required string Name { get; set; } // Required in C# 11+
        public string? Description { get; set; } // Nullable if optional
        public AttributeType Type { get; set; } // Text, Number, Boolean, DateTime, Dropdown
        public bool IsFilterable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVariant { get; set; } // Used to generate variants
        public bool IsRequired { get; set; }
        public string? DefaultValue { get; set; } // Nullable if optional
        public string? ValidationRegex { get; set; } // Nullable if optional

        // Navigation Properties
        public ICollection<AttributeOption> Options { get; set; } = new List<AttributeOption>();
        public ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
    }
}
