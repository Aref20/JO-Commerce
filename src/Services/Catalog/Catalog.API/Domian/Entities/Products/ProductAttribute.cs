using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.Entities.Attribute;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductAttribute : BaseEntity, ITenant
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string TextValue { get; set; }
        public decimal? NumberValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime? DateTimeValue { get; set; }
        public Guid? OptionId { get; set; }
        public AttributeOption Option { get; set; }
        public Guid TenantId { get; set; }
    }
}
