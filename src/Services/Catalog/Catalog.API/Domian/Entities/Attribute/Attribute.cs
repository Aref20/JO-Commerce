namespace Catalog.API.Domian.Entities.Attribute
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AttributeType Type { get; set; } // Text, Number, Boolean, DateTime, Dropdown
        public bool IsFilterable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVariant { get; set; } // Used to generate variants
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string ValidationRegex { get; set; }
        public ICollection<AttributeOption> Options { get; set; } // For dropdown types
    }
}
