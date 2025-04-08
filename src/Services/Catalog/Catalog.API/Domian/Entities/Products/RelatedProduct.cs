using BuildingBlocks.BaseEntity;
using Common.Enums;

namespace Catalog.API.Domian.Entities;
public class RelatedProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public Guid RelatedProductId { get; set; }
    public Product Related { get; set; } = default!;
    public RelationType RelationType { get; set; }
    public int DisplayOrder { get; set; }
}

