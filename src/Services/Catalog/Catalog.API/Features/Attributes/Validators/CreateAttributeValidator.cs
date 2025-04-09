using Catalog.API.Domain.DTOs.Attribute;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Attributes.Validators
{
    public class CreateAttributeValidator : AbstractValidator<CreateAttributeDto>
    {
        public CreateAttributeValidator(IStringLocalizer<CreateAttributeValidator> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.DefaultValue).MaximumLength(250);
            RuleFor(x => x.ValidationRegex).MaximumLength(250);
        }
    }
}