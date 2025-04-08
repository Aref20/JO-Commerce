//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using BuildingBlocks.BaseEntity;
//using Catalog.API.Features.Products.Commands;
//using Catalog.API.Features.Products.Queries;
//using Catalog.API.Features.Products.Create;
//using Catalog.API.Features.Products.Update;
//using Catalog.API.Domian.DTOs;

//namespace Catalog.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ProductsController(IMediator _mediator) : ControllerBase
//    {






//        #region Helper Methods

//        private Guid GetTenantId()
//        {
//            // In a real application, you would extract the tenant ID from:
//            // 1. A claim in the user's JWT token
//            // 2. A custom header
//            // 3. Subdomain parsing
//            // 4. A query parameter

//            // For this example, we'll assume it comes from a header
//            if (Request.Headers.TryGetValue("X-TenantId", out var tenantIdValue) &&
//                Guid.TryParse(tenantIdValue, out var tenantId))
//            {
//                return tenantId;
//            }

//            return Guid.Empty;
//        }

//        #endregion
//    }
//}