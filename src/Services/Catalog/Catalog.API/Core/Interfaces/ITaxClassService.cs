using Catalog.API.Domain.DTOs.Tax;

namespace Catalog.API.Core.Interfaces
{
    public interface ITaxClassService
    {
        Task<TaxClassDto> CreateTaxClassAsync(CreateTaxClassDto taxClassDto);
        Task<TaxClassDto> GetTaxClassByIdAsync(Guid id);
        Task<List<TaxClassDto>> GetAllTaxClassesAsync();
        Task<TaxClassDto> UpdateTaxClassAsync(Guid id, UpdateTaxClassDto taxClassDto);
        Task<bool> DeleteTaxClassAsync(Guid id);
    }
}
