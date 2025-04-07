namespace Catalog.API.Domian.Entities.Tax
{
    public class TaxClass
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TaxRate> TaxRates { get; set; }
    }
}
