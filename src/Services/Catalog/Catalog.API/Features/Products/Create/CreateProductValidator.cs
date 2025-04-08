using Catalog.API.Features.Products.CreateProduct;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Products.Create
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator(IStringLocalizer<CreateProductValidator> localizer)
        {
            RuleFor(x => x.ProductDto.Name)
                .NotEmpty()
                .WithMessage(_ => localizer["ProductNameRequired"])
                .MaximumLength(100)
                .WithMessage(_ => localizer["ProductNameTooLong"]);

            RuleFor(x => x.ProductDto.SKU)
                .NotEmpty()
                .WithMessage(_ => localizer["SKURequired"])
                .MaximumLength(50)
                .WithMessage(_ => localizer["SKUTooLong"]);

            RuleFor(x => x.ProductDto.Price)
                .GreaterThan(0)
                .WithMessage(_ => localizer["PriceMustBePositive"]);

            RuleFor(x => x.ProductDto.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage(_ => localizer["StockCannotBeNegative"]);
        }
    }
}