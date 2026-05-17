using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Models.Invoice;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Feature;
using System.Security.Claims;

namespace ratpdf.Controllers
{
    [Authorize]
    public class InvoiceDashboardController : Controller
    {
        private readonly RatPDFDbContext _db;
        private readonly FeatureAccessor _featureAccessor;
        private readonly TemplateService _templateService;

        public InvoiceDashboardController(
            RatPDFDbContext db,
            FeatureAccessor featureAccessor,
            TemplateService templateService)
        {
            _db = db;
            _featureAccessor = featureAccessor;
            _templateService = templateService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return Challenge();
            
            int pageSize = 5;
            
            var totalInvoices = await _db.Invoices
            .Where(i => i.UserId == userId.Value)
            .CountAsync();
            
            var invoices = await _db.Invoices
           .Where(i => i.UserId == userId.Value)
           .OrderByDescending(i => i.CreatedAt)
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();
            var templates = await _templateService.GetUserTemplatesAsync(userId.Value);
            var subscription = await _db.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == userId.Value && s.Status == "active");

            var model = new DashboardViewModel
            {
                Invoices = invoices,
                Templates = templates,
                IsPremium = subscription != null,
                PlanName = subscription?.PlanId ?? "Free",
                TotalInvoices = totalInvoices,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalInvoices / (double)pageSize)
            };
            var canBulkUpload = userId.HasValue && await _featureAccessor.CanUseBulkInvoicingAsync(userId.Value);
            ViewBag.CanBulkUpload = canBulkUpload;
            return View(model);
        }

        private Guid? GetCurrentUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null && Guid.TryParse(claim.Value, out var uid) ? uid : null;
        }
    }
}
