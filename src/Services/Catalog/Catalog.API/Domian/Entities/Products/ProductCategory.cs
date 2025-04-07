using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductCategory : BaseEntity, ITenant
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public ProductCategory ParentCategory { get; set; } = new ProductCategory();
        public Guid? ParentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Guid TenantId { get; set; }
    }
}
