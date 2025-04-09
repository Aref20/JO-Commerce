using Catalog.API.Domain.DTOs.Tag;

namespace Catalog.API.Core.Interfaces
{
    public interface ITagService
    {
        Task<TagDto> CreateTagAsync(CreateTagDto tagDto);
        Task<TagDto> GetTagByIdAsync(Guid id);
        Task<List<TagDto>> GetAllTagsAsync();
        Task<TagDto> UpdateTagAsync(Guid id, UpdateTagDto tagDto);
        Task<bool> DeleteTagAsync(Guid id);
    }
}
