using Catalog.API.Domain.DTOs.Attribute;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Attributes.Validators
{
    public class UpdateAttributeValidator : AbstractValidator<UpdateAttributeDto>
    {
        public UpdateAttributeValidator(IStringLocalizer<UpdateAttributeValidator> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.DefaultValue).MaximumLength(250);
            RuleFor(x => x.ValidationRegex).MaximumLength(250);
        }
    }
}