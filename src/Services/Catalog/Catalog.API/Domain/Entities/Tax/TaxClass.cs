using BuildingBlocks.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class TaxClass : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
