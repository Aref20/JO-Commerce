using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.Entities;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.DeleteProduct;

    public class DeleteProductHandler(IDocumentSession session) :
           IRequestHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await session.LoadAsync<Product>(request.Id);
                if (product == null)
                    throw new Exception($"Product with ID {request.Id} not found.");

                session.Delete<Product>(request.Id);
                await session.SaveChangesAsync();
                return Unit.Value;
        }
            catch (Exception ex)
            {
            throw;
            }
        }
    }


