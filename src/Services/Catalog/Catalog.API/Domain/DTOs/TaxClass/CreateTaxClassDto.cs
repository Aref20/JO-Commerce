using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.Tax
{
    public class CreateTaxClassDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
