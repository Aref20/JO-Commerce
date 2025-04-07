using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductCategory : BaseEntity, ITenant
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
        public Guid TenantId { get; set; }
    }
}
