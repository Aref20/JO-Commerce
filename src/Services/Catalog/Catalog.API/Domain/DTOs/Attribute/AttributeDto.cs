using Common.Enums;

namespace Catalog.API.Domain.DTOs.Attribute
{
    namespace Catalog.API.Domain.DTOs.Attribute
    {
        public class AttributeDto
        {
            public Guid Id { get; set; }
            public required string Name { get; set; }
            public string Description { get; set; } = string.Empty;
            public AttributeType Type { get; set; }
            public bool IsFilterable { get; set; }
            public bool IsSearchable { get; set; }
            public bool IsVariant { get; set; }
            public bool IsRequired { get; set; }
            public string DefaultValue { get; set; } = string.Empty;
            public string ValidationRegex { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }
    }
}
