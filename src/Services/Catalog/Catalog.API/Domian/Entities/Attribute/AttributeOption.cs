namespace Catalog.API.Domian.Entities.Attribute
{
    public class AttributeOption
    {
        public Guid Id { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string Value { get; set; }
        public string DisplayText { get; set; }
        public int DisplayOrder { get; set; }
        public string ColorCode { get; set; } // For color swatches
        public string ImageUrl { get; set; } // For image swatches
    }
}
