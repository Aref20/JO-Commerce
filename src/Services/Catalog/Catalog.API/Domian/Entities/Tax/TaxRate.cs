using BuildingBlocks.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domian.Entities
{
    public class TaxRate : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public required string CountryCode { get; set; }

        [MaxLength(3)]
        public string? StateCode { get; set; }

        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [Range(0, 100)]
        public decimal Rate { get; set; }

        public bool IsDefault { get; set; }

        public Guid TaxClassId { get; set; }
        public TaxClass TaxClass { get; set; } = default!;
    }
}
