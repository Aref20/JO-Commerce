﻿using BuildingBlocks.BaseEntity;

namespace Catalog.API.Domian.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsDefault { get; set; }
    }
}
