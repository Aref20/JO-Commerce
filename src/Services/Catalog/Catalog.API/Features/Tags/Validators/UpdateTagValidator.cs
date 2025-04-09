// Features/Tags/Validators/UpdateTagValidator.cs
using Catalog.API.Domain.DTOs.Tag;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Tags.Validators
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagDto>
    {
        public UpdateTagValidator(IStringLocalizer<UpdateTagValidator> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["TagNameRequired"])
                .MaximumLength(100)
                .WithMessage(localizer["TagNameTooLong"]);

            RuleFor(x => x.Slug)
                .NotEmpty()
                .WithMessage(localizer["SlugRequired"])
                .MaximumLength(100)
                .WithMessage(localizer["SlugTooLong"])
                .Matches("^[a-z0-9\\-]+$")
                .WithMessage(localizer["SlugInvalidFormat"]);
        }
    }
}