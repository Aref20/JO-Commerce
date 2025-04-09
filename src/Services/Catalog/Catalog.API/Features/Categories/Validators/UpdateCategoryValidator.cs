// Create in Features/Categories/Validators/UpdateCategoryValidator.cs
using Catalog.API.Domain.DTOs.Category;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator(IStringLocalizer<UpdateCategoryValidator> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_ => localizer["CategoryNameRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["CategoryNameTooLong"]);

            RuleFor(x => x.Slug)
                .NotEmpty()
                .WithMessage(_ => localizer["SlugRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["SlugTooLong"])
                .Matches("^[a-z0-9\\-]+$")
                .WithMessage(_ => localizer["SlugInvalidFormat"]);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage(_ => localizer["DescriptionTooLong"]);

            RuleFor(x => x.ImageUrl)
                .MaximumLength(2048)
                .WithMessage(_ => localizer["ImageUrlTooLong"]);
        }
    }
}