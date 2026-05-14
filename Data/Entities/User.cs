using Microsoft.AspNetCore.Identity;

namespace ratpdf.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public ICollection<Invoice>? Invoices { get; set; }
        public Subscription? Subscription { get; set; }
        public ICollection<Template>? Templates { get; set; }
        public BrandingSettings? BrandingSettings { get; set; }
        public ICollection<UsageLog>? UsageLogs { get; set; }
    }
}
