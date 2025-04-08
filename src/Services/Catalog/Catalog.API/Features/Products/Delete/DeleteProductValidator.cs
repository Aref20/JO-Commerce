using Catalog.API.Features.Products.DeleteProduct;
using Catalog.API.Features.Products.Update;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Catalog.API.Features.Products.Delete
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator(IStringLocalizer<UpdateProductValidator> localizer)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(_ => localizer["ProductIdRequired"]);
        }
    }
}
