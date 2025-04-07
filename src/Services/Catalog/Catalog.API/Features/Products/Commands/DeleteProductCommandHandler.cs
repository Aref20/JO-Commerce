using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.Entities.Products;
using Catalog.API.Features.Products.DTOs;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.Commands;

    public class DeleteProductCommandHandler(IDocumentSession session) :
           IRequestHandler<DeleteProductCommand, Result>
    {
        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await session.LoadAsync<Product>(request.Id);
                if (product == null)
                    return Result.Failure($"Product with ID {request.Id} not found");

                session.Delete<Product>(request.Id);
                await session.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Failed to delete product: {ex.Message}");
            }
        }
    }


