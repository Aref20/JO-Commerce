using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; } = default!;
        public string? TextValue { get; set; }
        public decimal? NumberValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? OptionId { get; set; }
        public AttributeOption? Option { get; set; }
    }
}
