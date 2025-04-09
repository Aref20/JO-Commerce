using Catalog.API.Domain.DTOs.TaxRate;

namespace Catalog.API.Core.Interfaces
{
    public interface ITaxRateService
    {
        Task<TaxRateDto> CreateTaxRateAsync(CreateTaxRateDto taxRateDto);
        Task<TaxRateDto> GetTaxRateByIdAsync(Guid id);
        Task<List<TaxRateDto>> GetAllTaxRatesAsync();
        Task<List<TaxRateDto>> GetTaxRatesByClassAsync(Guid taxClassId);
        Task<TaxRateDto> UpdateTaxRateAsync(Guid id, UpdateTaxRateDto taxRateDto);
        Task<bool> DeleteTaxRateAsync(Guid id);
    }
}
