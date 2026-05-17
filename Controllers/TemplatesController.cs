using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Feature;
using System.Security.Claims;

namespace ratpdf.Controllers
{
    [Authorize]
    public class TemplatesController : Controller
    {
        private readonly TemplateService _templateService;
        private readonly FeatureAccessor _featureAccessor;
        public TemplatesController(TemplateService templateService, FeatureAccessor featureAccessor)
        {
            _templateService = templateService;
            _featureAccessor = featureAccessor;
        }

        // GET: /Templates
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return Challenge();

            var templates = await _templateService.GetUserTemplatesAsync(userId.Value);
            var maxAllowed = await _featureAccessor.MaxTemplatesAllowedAsync();

            ViewBag.MaxTemplates = maxAllowed;
            return View(templates);
        }
        [HttpGet("templates/bulk_invoice_template.csv")]
        public IActionResult DownloadCsvTemplate()
        {
            var csvContent = "ClientName,ClientGstin,YourGstin,ServiceDescription,Quantity,UnitPrice,HsnSac,TaxType,PlaceOfSupply,Notes\n" +
                             "ABC Pvt Ltd,27AAACA1234A1Z,27AAACC5678B2Z,Tax Audit,1,25000,9983,CGST/SGST,27,Audit due 31 Oct\n" +
                             "XYZ Traders,27AAACB5678B2Z,27AAACC5678B2Z,GST Filing,1,10000,9985,IGST,27,Monthly return";
            var bytes = System.Text.Encoding.UTF8.GetBytes(csvContent);
            return File(bytes, "text/csv", "bulk_invoice_template.csv");
        }
        // POST: /Templates/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return Challenge();

            await _templateService.DeleteTemplateAsync(id);
            TempData["Message"] = "Template deleted.";
            return Redirect("~/Templates/Index");
        }

        // GET: /Templates/Load/{id}
        [AllowAnonymous] 
        public async Task<IActionResult> Load(Guid id)
        {
            var userId = GetCurrentUserId();
            var template = await _templateService.GetTemplateAsync(id);

            if (template == null || (template.UserId != userId))
                return NotFound();

            return RedirectToAction("Create", "Invoice", new { templateId = id });
        }

        private Guid? GetCurrentUserId()
        {
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(claim, out var uid) ? uid : null;
        }
    }
}
