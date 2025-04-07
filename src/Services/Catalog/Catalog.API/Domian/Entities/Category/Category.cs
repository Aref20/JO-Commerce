using System.ComponentModel;

namespace Catalog.API.Domian.Entities.Category
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public string ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public SEOMetadata SEO { get; set; }
        public ICollection<CategoryAttribute> Attributes { get; set; }
    }
}
