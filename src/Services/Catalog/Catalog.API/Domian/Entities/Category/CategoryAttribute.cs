namespace Catalog.API.Domian.Entities.Category
{
    public class CategoryAttribute
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
    }
}
