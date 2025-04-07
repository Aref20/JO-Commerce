namespace Catalog.API.Domian.Entities.Tax
{
    public class TaxRate
    {
        public Guid Id { get; set; }
        public Guid TaxClassId { get; set; }
        public TaxClass TaxClass { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string PostalCode { get; set; }
        public decimal Rate { get; set; }
        public bool IsDefault { get; set; }
    }
}
