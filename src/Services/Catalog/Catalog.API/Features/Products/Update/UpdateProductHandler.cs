using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Domian.Entities;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.Commands
{
    public class UpdateProductHandler(IDocumentSession session) :
           IRequestHandler<UpdateProductCommand, Result<ProductDto>>
    {

        public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await session.LoadAsync<Product>(request.Id);
                if (existingProduct == null)
                    return Result.Failure<ProductDto>($"Product with ID {request.Id} not found");

                // Map new values, keeping Id and TenantId intact
                request.ProductDto.Adapt(existingProduct);
                existingProduct.UpdatedAt = DateTime.UtcNow;
                existingProduct.UpdatedBy = "System"; // Ideally from current user context

                session.Store(existingProduct);
                await session.SaveChangesAsync();
                return Result.Success(existingProduct.Adapt<ProductDto>());
            }
            catch (Exception ex)
            {
                return Result.Failure<ProductDto>($"Failed to update product: {ex.Message}");
            }
        }

    }

}
