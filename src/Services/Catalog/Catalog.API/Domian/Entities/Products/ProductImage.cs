using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities.Products
{
    public class ProductImage : BaseEntity, ITenant
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDefault { get; set; }
        public Guid TenantId { get; set; }
    }
}
