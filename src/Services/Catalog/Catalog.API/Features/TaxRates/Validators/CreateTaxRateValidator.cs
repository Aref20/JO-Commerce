// Features/TaxRates/Validators/CreateTaxRateValidator.cs
using Catalog.API.Domain.DTOs.TaxRate;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.TaxRates.Validators
{
    public class CreateTaxRateValidator : AbstractValidator<CreateTaxRateDto>
    {
        public CreateTaxRateValidator(IStringLocalizer<CreateTaxRateValidator> localizer)
        {
            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .WithMessage(localizer["CountryCodeRequired"])
                .Length(2)
                .WithMessage(localizer["CountryCodeLength"]);

            RuleFor(x => x.StateCode)
                .MaximumLength(2)
                .WithMessage(localizer["StateCodeTooLong"])
                .When(x => !string.IsNullOrEmpty(x.StateCode));

            RuleFor(x => x.PostalCode)
                .MaximumLength(10)
                .WithMessage(localizer["PostalCodeTooLong"])
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.Rate)
                .GreaterThanOrEqualTo(0)
                .WithMessage(localizer["RateNegative"])
                .LessThanOrEqualTo(100)
                .WithMessage(localizer["RateTooHigh"]);

            RuleFor(x => x.TaxClassId)
                .NotEmpty()
                .WithMessage(localizer["TaxClassRequired"]);
        }
    }
}