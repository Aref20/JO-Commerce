using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.Tag
{
    public class UpdateTagDto
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }
    }
}
