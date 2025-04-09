using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.Tax
{
    public class UpdateTaxClassDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
