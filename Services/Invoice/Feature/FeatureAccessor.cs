using Microsoft.EntityFrameworkCore;
using ratpdf.Constants;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;

namespace ratpdf.Services.Invoice.Feature
{
    public class FeatureAccessor
    {
        private readonly RatPDFDbContext _db;
        private readonly IHttpContextAccessor _http;
        private Subscription? _cachedSubscription;
        private Guid? _cachedUserId;

        public FeatureAccessor(RatPDFDbContext db, IHttpContextAccessor http)
        {
            _db = db;
            _http = http;
        }

        private Guid? GetCurrentUserId()
        {
            var claim = _http.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (claim == null || !Guid.TryParse(claim.Value, out var uid))
                return null;
            return uid;
        }

        private async Task<Subscription?> GetActiveSubscriptionAsync(Guid? userId = null)
        {
            var uid = userId ?? GetCurrentUserId();
            if (!uid.HasValue) return null;

            if (_cachedSubscription != null && _cachedUserId == uid)
                return _cachedSubscription;

            _cachedUserId = uid;
            _cachedSubscription = await _db.Subscriptions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == uid.Value
                    && s.Status == "active"
                    && s.CurrentPeriodEnd > DateTime.UtcNow);
            return _cachedSubscription;
        }

        public async Task<bool> CanUseBulkInvoicingAsync(Guid? userId = null)
        {
            var sub = await GetActiveSubscriptionAsync(userId);
            return sub != null && sub.PlanId == Plan.Business_Monthly;
        }

        public async Task<bool> CanRemoveWatermarkAsync(Guid? userId = null)
        {
            var sub = await GetActiveSubscriptionAsync(userId);
            return sub != null && (sub.PlanId == Plan.Pro_Monthly || sub.PlanId == Plan.Business_Monthly);
        }

        public async Task<bool> CanUploadLogoAsync() => await CanRemoveWatermarkAsync();

        public async Task<bool> CanSaveTemplatesAsync()
        {
            var sub = await GetActiveSubscriptionAsync();
            return sub != null;
        }

        public async Task<int> MaxTemplatesAllowedAsync()
        {
            var sub = await GetActiveSubscriptionAsync();
            if (sub == null) return 0;
            return sub.PlanId == Plan.Business_Monthly ? int.MaxValue : 1;
        }
    }
}
