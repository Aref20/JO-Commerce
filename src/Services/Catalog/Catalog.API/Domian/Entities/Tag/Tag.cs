namespace Catalog.API.Domian.Entities.Tag
{
    public class Tag
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
