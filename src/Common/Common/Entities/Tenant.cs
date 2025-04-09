using BuildingBlocks.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Tenant : BaseEntity
    {
        public required string  Name { get; set; }
        public required string SubDomain { get; set; }
        public string[] CustomDomains { get; set; } = Array.Empty<string>();
        public string LogoUrl { get; set; } = string.Empty;
        public string PrimaryColor { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        //public TenantSettings Settings { get; set; }
        public bool IsActive { get; set; }
        //public SubscriptionTier SubscriptionTier { get; set; }
    }
}
