
using Catalog.API.Domain.DTOs.Product;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Products.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator(IStringLocalizer<UpdateProductValidator> localizer)
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(_ => localizer["ProductNameRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["ProductNameTooLong"]);

            RuleFor(x => x.SKU)
                .NotEmpty()
                .WithMessage(_ => localizer["SKURequired"])
                .MaximumLength(50)
                .WithMessage(_ => localizer["SKUTooLong"]);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(_ => localizer["PriceMustBePositive"]);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage(_ => localizer["StockCannotBeNegative"]);
        }
    }
}