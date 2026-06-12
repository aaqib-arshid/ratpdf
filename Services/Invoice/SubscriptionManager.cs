using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;

namespace ratpdf.Services.Invoice
{
    public class SubscriptionManager
    {
        private readonly RatPDFDbContext _db;

        public SubscriptionManager(RatPDFDbContext db) => _db = db;

        public async Task<Subscription?> GetActiveSubscriptionAsync(Guid userId)
        {
            return await _db.Subscriptions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == userId
                                           && s.Status == "active"
                                           && s.CurrentPeriodEnd > DateTime.UtcNow);
        }

        public async Task ActivateOrUpdateSubscriptionAsync(
            Guid userId,
            string planId,
            string razorpaySubscriptionId,
            DateTime? start,
            DateTime? end)
        {
            var existing = await _db.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId);
            if (existing == null)
            {
                existing = new Subscription
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    PlanId = planId,
                    Status = "active",
                    RazorpaySubscriptionId = razorpaySubscriptionId,
                    CurrentPeriodStart = start ?? DateTime.UtcNow,
                    CurrentPeriodEnd = end ?? DateTime.UtcNow.AddMonths(1),
                    CreatedAt = DateTime.UtcNow
                };
                _db.Subscriptions.Add(existing);
            }
            else
            {
                existing.PlanId = planId;
                existing.RazorpaySubscriptionId = razorpaySubscriptionId;
                existing.Status = "active";
                existing.CurrentPeriodStart = start ?? DateTime.UtcNow;
                existing.CurrentPeriodEnd = end ?? DateTime.UtcNow.AddMonths(1);
            }
            await _db.SaveChangesAsync();
        }

        public async Task CancelSubscriptionAsync(Guid userId)
        {
            var sub = await _db.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId && s.Status == "active");
            if (sub != null)
            {
                sub.Status = "cancelled";
                await _db.SaveChangesAsync();
            }
        }

        public async Task ExpireSubscriptionAsync(Guid userId)
        {
            var sub = await _db.Subscriptions.FirstOrDefaultAsync(s => s.UserId == userId && s.Status == "active");
            if (sub != null && sub.CurrentPeriodEnd < DateTime.UtcNow)
            {
                sub.Status = "expired";
                await _db.SaveChangesAsync();
            }
        }
    }
}