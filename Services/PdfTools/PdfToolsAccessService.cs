using Microsoft.AspNetCore.Identity;
using ratpdf.Constants;
using ratpdf.Data.Entities;
using ratpdf.Models;
using ratpdf.Services.Invoice;

namespace ratpdf.Services.PdfTools
{
    public record PdfToolAccessResult(
        bool Allowed,
        bool IsPremium,
        int RemainingFreeUses,
        string? DenyReason = null);

    /// <summary>
    /// Freemium gate for PDF tools: 3 free uses/day per tool, unlimited for subscribers.
    /// </summary>
    public class PdfToolsAccessService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SubscriptionManager _subscriptionManager;
        private readonly UserManager<User> _userManager;

        public PdfToolsAccessService(
            IHttpContextAccessor httpContextAccessor,
            SubscriptionManager subscriptionManager,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _subscriptionManager = subscriptionManager;
            _userManager = userManager;
        }

        public async Task<PdfToolAccessResult> CheckAccessAsync(string toolId, int requestedUses = 1)
        {
            var ctx = _httpContextAccessor.HttpContext
                ?? throw new InvalidOperationException("HttpContext is not available.");

            if (await IsPremiumUserAsync(ctx))
            {
                return new PdfToolAccessResult(true, true, int.MaxValue);
            }

            var key = BuildUsageKey(toolId);
            var used = ctx.Session.GetInt32(key) ?? 0;
            var remaining = Math.Max(0, PdfToolLimits.FreeUsesPerDay - used);

            if (used + requestedUses > PdfToolLimits.FreeUsesPerDay)
            {
                return new PdfToolAccessResult(
                    false,
                    false,
                    remaining,
                    $"Free limit reached ({PdfToolLimits.FreeUsesPerDay}/day). Subscribe for unlimited access.");
            }

            return new PdfToolAccessResult(true, false, remaining - requestedUses + 1);
        }

        public async Task RecordUsageAsync(string toolId, int count = 1)
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx == null)
                return;

            if (await IsPremiumUserAsync(ctx))
                return;

            var key = BuildUsageKey(toolId);
            var used = ctx.Session.GetInt32(key) ?? 0;
            ctx.Session.SetInt32(key, used + count);
        }

        public async Task<PdfToolAccessResult> GetStatusAsync(string toolId)
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx == null)
                return new PdfToolAccessResult(true, false, PdfToolLimits.FreeUsesPerDay);

            if (await IsPremiumUserAsync(ctx))
                return new PdfToolAccessResult(true, true, int.MaxValue);

            var key = BuildUsageKey(toolId);
            var used = ctx.Session.GetInt32(key) ?? 0;
            var remaining = Math.Max(0, PdfToolLimits.FreeUsesPerDay - used);
            return new PdfToolAccessResult(remaining > 0, false, remaining);
        }

        public async Task<PdfToolLimitsDto> GetLimitsAsync() =>
            await GetLimitsForToolAsync(PdfToolIds.Compress);

        public async Task<PdfToolLimitsDto> GetLimitsForToolAsync(string toolId)
        {
            var ctx = _httpContextAccessor.HttpContext;
            var isPremium = ctx != null && await IsPremiumUserAsync(ctx);
            var perFileMax = isPremium ? PdfToolLimits.MaxPremiumFileSizeBytes : PdfToolLimits.MaxFileSizeBytes;
            var isMerge = string.Equals(toolId, PdfToolIds.Merge, StringComparison.OrdinalIgnoreCase);

            long? totalBatchMax = null;
            string? totalBatchLabel = null;
            if (isMerge && isPremium)
            {
                totalBatchMax = PdfToolLimits.MergeMaxTotalBatchBytesPremium;
                totalBatchLabel = "4 GB combined";
            }

            return new PdfToolLimitsDto
            {
                IsPremium = isPremium,
                MaxFileSizeBytes = perFileMax,
                MaxBatchFiles = PdfToolLimits.ResolveMaxBatchFiles(toolId),
                MaxTotalBatchBytes = totalBatchMax,
                MaxTotalBatchLabel = totalBatchLabel,
                FreeUsesPerDay = PdfToolLimits.FreeUsesPerDay,
                MaxFileSizeLabel = FormatBytes(perFileMax),
            };
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes >= 1024L * 1024 * 1024)
                return $"{bytes / (1024.0 * 1024 * 1024):0.#} GB";
            return $"{bytes / (1024 * 1024)} MB";
        }

        private static string BuildUsageKey(string toolId)
        {
            var day = DateTime.UtcNow.ToString("yyyyMMdd");
            return $"pdf_tool_{toolId}_{day}";
        }

        private async Task<bool> IsPremiumUserAsync(HttpContext ctx)
        {
            if (ctx?.User?.Identity?.IsAuthenticated != true)
                return false;

            try
            {
                var user = await _userManager.GetUserAsync(ctx.User);
                if (user == null)
                    return false;

                var sub = await _subscriptionManager.GetActiveSubscriptionAsync(user.Id);
                return sub != null
                       && (sub.PlanId == Plan.Pro_Monthly || sub.PlanId == Plan.Business_Monthly);
            }
            catch
            {
                // DB unavailable — fail open to free tier rather than crash tool pages.
                return false;
            }
        }
    }
}
