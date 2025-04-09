// Create in Features/Brands/Validators/CreateBrandValidator.cs
using Catalog.API.Domain.DTOs.Brand;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Brands.Validators
{
    public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandValidator(IStringLocalizer<CreateBrandValidator> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_ => localizer["BrandNameRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["BrandNameTooLong"]);

            RuleFor(x => x.Slug)
                .NotEmpty()
                .WithMessage(_ => localizer["SlugRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["SlugTooLong"])
                .Matches("^[a-z0-9\\-]+$")
                .WithMessage(_ => localizer["SlugInvalidFormat"]);
        }
    }
}