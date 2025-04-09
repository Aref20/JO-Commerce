using BuildingBlocks.BaseEntity;


namespace Catalog.API.Domain.Entities
{
    public class VariantAttributeValue : BaseEntity
    {
        // Foreign Keys
        public Guid VariantId { get; set; }
        public Guid AttributeId { get; set; }
        public Guid? OptionId { get; set; } // Nullable if not all attributes use options

        // Navigation Properties
        public ProductVariant Variant { get; set; } = default!;
        public Attribute Attribute { get; set; } = default!;
        public AttributeOption? Option { get; set; } // Nullable if OptionId is nullable
    }
}
