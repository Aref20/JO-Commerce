using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs;
using Catalog.API.Domian.Entities.Products;
using MapsterMapper;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.Get
{
    public class GetProductHandler(IDocumentSession session, IMapper mapper) :
        IRequestHandler<GetProductQuery, Result<ProductDto>>
    {

        public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id);
            if (product == null)
                return Result.Failure<ProductDto>($"Product with ID {request.Id} not found");

            return Result.Success(mapper.Map<ProductDto>(product));
        }

    }
}
