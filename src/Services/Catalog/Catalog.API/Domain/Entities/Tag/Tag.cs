using BuildingBlocks.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-z0-9\-]+$")]
        public required string Slug { get; set; }

        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
