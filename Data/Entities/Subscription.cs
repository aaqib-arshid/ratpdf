using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ratpdf.Data.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [MaxLength(100)]
        public string PlanId { get; set; } = string.Empty;  // 'free', 'pro_monthly', 'business_monthly'

        [MaxLength(50)]
        public string Status { get; set; } = "active";       // 'active', 'cancelled', 'expired'

        [MaxLength(200)]
        public string? RazorpaySubscriptionId { get; set; }

        public DateTime? CurrentPeriodStart { get; set; }
        public DateTime? CurrentPeriodEnd { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
