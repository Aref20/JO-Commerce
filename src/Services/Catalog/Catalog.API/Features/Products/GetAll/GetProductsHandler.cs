using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Domian.Entities;
using MapsterMapper;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.GetAll
{
    public class GetProductsHandler(IDocumentSession session,IMapper mapper) :
        IRequestHandler<GetProductsQuery, Result<List<ProductDto>>>
    {

        public async Task<Result<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync();
            return Result.Success(mapper.Map<List<ProductDto>>(products));
        }
    }
}
