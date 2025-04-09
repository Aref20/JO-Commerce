using BuildingBlocks.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.Entities
{
    public class TaxClass : BaseEntity
    {

        public required string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<TaxRate> TaxRates { get; set; } = new List<TaxRate>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
