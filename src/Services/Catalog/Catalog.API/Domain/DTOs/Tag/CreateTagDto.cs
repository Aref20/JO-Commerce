using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.Tag
{
    public class CreateTagDto
    {
        public required string Name { get; set; }

        public required string Slug { get; set; }
    }
}
