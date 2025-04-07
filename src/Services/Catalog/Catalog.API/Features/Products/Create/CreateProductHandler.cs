using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using Catalog.API.Domian.Entities.Products;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.CreateProduct
{
    public class CreateProductHandler(IDocumentSession session) :
           IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = request.ProductDto.Adapt<Product>();
                product.CreatedAt = DateTime.UtcNow;
                product.CreatedBy = "System"; // Ideally from current user context

                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);
                return Result.Success(product.Adapt<ProductDto>());
            }
            catch (Exception ex)
            {
                return Result.Failure<ProductDto>($"Failed to create product: {ex.Message}");
            }
        }
    }

}
