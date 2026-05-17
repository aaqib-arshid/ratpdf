using Microsoft.EntityFrameworkCore;
using ratpdf.Constants;
using ratpdf.Data.AppDBContext;

namespace ratpdf.Services.Invoice.Feature
{
    public class FeatureAccessor
    {
        private readonly RatPDFDbContext _db;
        private readonly IHttpContextAccessor _http;

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
        public async Task<bool> CanUseBulkInvoicingAsync(Guid? userId = null)
        {
            var uid = userId ?? GetCurrentUserId();
            if (!uid.HasValue) return false;
            var sub = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == uid.Value
                                          && s.Status == "active"
                                          && s.CurrentPeriodEnd > DateTime.UtcNow);
            return sub != null && sub.PlanId == Plan.Business_Monthly;
        }
        public async Task<bool> CanRemoveWatermarkAsync(Guid? userId = null)
        {
            var uid = userId ?? GetCurrentUserId();
            if (!uid.HasValue) return false;
            var sub = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == uid.Value
                                          && s.Status == "active"
                                          && s.CurrentPeriodEnd > DateTime.UtcNow);
            return sub != null && (sub.PlanId == Plan.Pro_Monthly || sub.PlanId == Plan.Business_Monthly);
        }

        public async Task<bool> CanUploadLogoAsync() => await CanRemoveWatermarkAsync();

        public async Task<bool> CanSaveTemplatesAsync()
        {
            var uid = GetCurrentUserId();
            if (!uid.HasValue) return false;
            var sub = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == uid.Value && s.Status == "active" && s.CurrentPeriodEnd > DateTime.UtcNow);
            return sub != null; // both paid plans allow template saving
        }

        public async Task<int> MaxTemplatesAllowedAsync()
        {
            var uid = GetCurrentUserId();
            if (!uid.HasValue) return 0;
            var sub = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == uid.Value && s.Status == "active" && s.CurrentPeriodEnd > DateTime.UtcNow);
            if (sub == null) return 0;
            return sub.PlanId == Plan.Business_Monthly ? int.MaxValue : 1; // Pro = 1
        }
    }
}
