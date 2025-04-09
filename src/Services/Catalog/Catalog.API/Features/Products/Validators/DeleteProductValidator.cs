
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Products.Validators
{
    public class DeleteProductValidator : AbstractValidator<Guid>
    {
        public DeleteProductValidator(IStringLocalizer<UpdateProductValidator> localizer)
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(_ => localizer["ProductIdRequired"]);
        }
    }
}
