using BuildingBlocks.BaseEntity;
using Catalog.API.Domian.DTOs.Product;
using Catalog.API.Domian.Entities;
using Mapster;
using Marten;
using MediatR;

namespace Catalog.API.Features.Products.CreateProduct
{
    public class CreateProductHandler(IDocumentSession session) :
           IRequestHandler<CreateProductCommand, ProductDto>
    {

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = request.ProductDto.Adapt<Product>();
                product.CreatedAt = DateTime.UtcNow;
                product.CreatedBy = "System"; // Ideally from current user context

                session.Store(product);
                await session.SaveChangesAsync(cancellationToken);
                return product.Adapt<ProductDto>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
