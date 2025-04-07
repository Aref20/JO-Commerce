using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subdomain { get; set; }
        public string[] CustomDomains { get; set; }
        public string LogoUrl { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string CurrencyCode { get; set; }
        public string TimeZone { get; set; }
        //public TenantSettings Settings { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        //public SubscriptionTier SubscriptionTier { get; set; }
    }
}
