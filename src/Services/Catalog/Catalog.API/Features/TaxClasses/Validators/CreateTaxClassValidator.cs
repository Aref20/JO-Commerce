namespace Catalog.API.Features.TaxClasses.Validators
{
    using FluentValidation;
    using global::Catalog.API.Domain.DTOs.Tax;
    using Microsoft.Extensions.Localization;

    namespace Catalog.API.Features.TaxClasses.Validators
    {
        public class CreateTaxClassValidator : AbstractValidator<CreateTaxClassDto>
        {
            public CreateTaxClassValidator(IStringLocalizer<CreateTaxClassValidator> localizer)
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
}
