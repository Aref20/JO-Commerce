using Catalog.API.Domain.DTOs.Attribute;
using Catalog.API.Domain.DTOs.Attribute.Catalog.API.Domain.DTOs.Attribute;

namespace Catalog.API.Core.Interfaces
{
    public interface IAttributeService
    {
        Task<AttributeDto> CreateAsync(CreateAttributeDto dto);
        Task<AttributeDto> GetByIdAsync(Guid id);
        Task<List<AttributeDto>> GetAllAsync();
        Task<AttributeDto> UpdateAsync(Guid id, UpdateAttributeDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<AttributeDto>> GetVariantAttributesAsync();
    }
}