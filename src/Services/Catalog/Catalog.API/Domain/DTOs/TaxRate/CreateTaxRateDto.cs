﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Domain.DTOs.TaxRate
{
    public class CreateTaxRateDto
    {
        public required string CountryCode { get; set; }

        public string? StateCode { get; set; }

        public string? PostalCode { get; set; }

        public decimal Rate { get; set; }

        public bool IsDefault { get; set; }

        public Guid TaxClassId { get; set; }
    }
}
