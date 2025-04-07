﻿using BuildingBlocks.BaseEntity;
using Catalog.API.Features.Products.DTOs;
using MediatR;

namespace Catalog.API.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
        public UpdateProductDto ProductDto { get; set; } = default!;
        public Guid TenantId { get; set; }
    }
}
