namespace Catalog.API.Domian.Entities.Products
{
    public class RelatedProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid RelatedProductId { get; set; }
        public Product Related { get; set; }
        public RelationType RelationType { get; set; } // Related, CrossSell, UpSell
        public int DisplayOrder { get; set; }
    }
}
