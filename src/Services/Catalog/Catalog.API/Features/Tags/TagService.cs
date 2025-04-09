
// Features/Tags/TagService.cs
using Catalog.API.Core.Common.Exceptions;
using Catalog.API.Core.Interfaces;
using Catalog.API.Domain.DTOs.Tag;
using Catalog.API.Domain.Entities;
using FluentValidation;
using Mapster;
using Marten;

namespace Catalog.API.Features.Tags
{
    public class TagService : ITagService
    {
        private readonly IDocumentSession _session;
        private readonly IValidator<CreateTagDto>? _createValidator;
        private readonly IValidator<UpdateTagDto>? _updateValidator;

        public TagService(
            IDocumentSession session,
            IValidator<CreateTagDto>? createValidator = null,
            IValidator<UpdateTagDto>? updateValidator = null)
        {
            _session = session;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<TagDto> CreateTagAsync(CreateTagDto tagDto)
        {
            if (_createValidator != null)
            {
                var validationResult = await _createValidator.ValidateAsync(tagDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var tag = tagDto.Adapt<Tag>();
            tag.CreatedAt = DateTime.UtcNow;
            tag.CreatedBy = "System";

            _session.Store(tag);
            await _session.SaveChangesAsync();

            return tag.Adapt<TagDto>();
        }

        public async Task<bool> DeleteTagAsync(Guid id)
        {
            var tag = await _session.LoadAsync<Tag>(id);
            if (tag == null)
                throw new NotFoundException($"Tag with ID {id} not found");

            _session.Delete<Tag>(id);
            await _session.SaveChangesAsync();

            return true;
        }

        public async Task<List<TagDto>> GetAllTagsAsync()
        {
            var tags = await _session.Query<Tag>().ToListAsync();
            return tags.Adapt<List<TagDto>>();
        }

        public async Task<TagDto> GetTagByIdAsync(Guid id)
        {
            var tag = await _session.LoadAsync<Tag>(id);
            if (tag == null)
                throw new NotFoundException($"Tag with ID {id} not found");

            return tag.Adapt<TagDto>();
        }

        public async Task<TagDto> UpdateTagAsync(Guid id, UpdateTagDto tagDto)
        {
            if (_updateValidator != null)
            {
                var validationResult = await _updateValidator.ValidateAsync(tagDto);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            var existingTag = await _session.LoadAsync<Tag>(id);
            if (existingTag == null)
                throw new NotFoundException($"Tag with ID {id} not found");

            tagDto.Adapt(existingTag);
            existingTag.UpdatedAt = DateTime.UtcNow;
            existingTag.UpdatedBy = "System";

            _session.Store(existingTag);
            await _session.SaveChangesAsync();

            return existingTag.Adapt<TagDto>();
        }
    }
}