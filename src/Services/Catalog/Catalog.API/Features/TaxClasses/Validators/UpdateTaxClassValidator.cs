// Features/TaxClasses/Validators/UpdateTaxClassValidator.cs
using Catalog.API.Domain.DTOs.Tax;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.TaxClasses.Validators
{
    public class UpdateTaxClassValidator : AbstractValidator<UpdateTaxClassDto>
    {
        public UpdateTaxClassValidator(IStringLocalizer<UpdateTaxClassValidator> localizer)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizer["TaxClassNameRequired"])
                .MaximumLength(100)
                .WithMessage(localizer["TaxClassNameTooLong"]);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage(localizer["TaxClassDescriptionTooLong"]);
        }
    }
}