using BuildingBlocks.BaseEntity;
using Catalog.API.Domain.Entities.Relationships;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
