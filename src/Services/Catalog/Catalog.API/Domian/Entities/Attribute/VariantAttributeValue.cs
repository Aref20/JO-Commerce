using Catalog.API.Domian.Entities.Products;

namespace Catalog.API.Domian.Entities.Attribute
{
    public class VariantAttributeValue
    {
        public Guid VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public Guid OptionId { get; set; }
        public AttributeOption Option { get; set; }
    }
}
