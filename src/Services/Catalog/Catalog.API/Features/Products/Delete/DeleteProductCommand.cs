using BuildingBlocks.BaseEntity;
using MediatR;

namespace Catalog.API.Features.Products.DeleteProduct;

   public class DeleteProductCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

