namespace Catalog.API.Domian.Entities.Brand
{
    public class Brand
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public SEOMetadata SEO { get; set; }
    }
}
