namespace Catalog.API.Domain.DTOs.TaxRate
{
    public class TaxRateDto
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; } = null!;
        public string? StateCode { get; set; }
        public string? PostalCode { get; set; }
        public decimal Rate { get; set; }
        public bool IsDefault { get; set; }
        public Guid TaxClassId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
