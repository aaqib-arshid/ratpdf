using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using ratpdf.Models.Invoice;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Feature;

namespace ratpdf.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly RatPDFDbContext _db;
        private readonly InvoicePdfService _pdfService;
        private readonly FeatureAccessor _featureAccessor;
        private readonly UsageTracker _usageTracker;
        private readonly TemplateService _templateService;

        public InvoiceController(
            RatPDFDbContext db,
            InvoicePdfService pdfService,
            FeatureAccessor featureAccessor,
            UsageTracker usageTracker,
            TemplateService templateService)
        {
            _db = db;
            _pdfService = pdfService;
            _featureAccessor = featureAccessor;
            _usageTracker = usageTracker;
            _templateService = templateService;
        }

        // GET: /Invoice/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create(Guid? templateId)
        {
            var model = new InvoiceFormViewModel
            {
                Items = new List<InvoiceItemViewModel>
            {
                new InvoiceItemViewModel() 
            },
                TaxName = "GST",
                TaxRate = 18,
                Currency = "INR"
            }; 
            if (templateId.HasValue)
            {
                var template = await _templateService.GetTemplateAsync(templateId.Value);
                if (template != null)
                {
                    var userId = GetCurrentUserId();
                    if (template.UserId == userId)
                    {
                        try
                        {
                            var savedModel = System.Text.Json.JsonSerializer
                                .Deserialize<InvoiceFormViewModel>(template.InvoiceData);
                            if (savedModel != null) model = savedModel;
                        }
                        catch { }
                    }
                }
            }
            return View(model);
        }

        // POST: /Invoice/GeneratePdf
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneratePdf(InvoiceFormViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            // Build invoice entity
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                UserId = GetCurrentUserId(),
                InvoiceNumber = GenerateInvoiceNumber(),
                IssueDate = model.IssueDate ?? DateTime.Today,
                DueDate = model.DueDate,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerAddress = model.CustomerAddress,
                Notes = model.Notes,
                TaxName = model.TaxName,
                TaxRate = model.TaxRate,
                Subtotal = model.Items.Sum(i => i.Quantity * i.UnitPrice),
                TaxAmount = model.Items.Sum(i => i.Quantity * i.UnitPrice) * (model.TaxRate / 100m),
                Currency = model.Currency ?? "INR",
                Items = model.Items.Select(i => new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    Description = i.Description,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Amount = i.Amount
                }).ToList(),
                From = model.From,
            };
            invoice.Total = invoice.Subtotal + invoice.TaxAmount;

            if (User.Identity?.IsAuthenticated == true && invoice.UserId.HasValue)
            {
                _db.Invoices.Add(invoice);
                await _db.SaveChangesAsync();
            }
            var userId = GetCurrentUserId();
            await _usageTracker.LogAsync(userId, userId.HasValue ? "generate_invoice_registered" : "generate_invoice_guest");

            var pdfBytes = await _pdfService.GenerateInvoicePdfAsync(invoice, userId);

            return File(pdfBytes, "application/pdf", $"Invoice-{invoice.InvoiceNumber}.pdf");
        }

        // GET: /Invoice/Download/{id}
        [Authorize]
        public async Task<IActionResult> Download(Guid id)
        {
            var invoice = await _db.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == GetCurrentUserId());

            if (invoice == null) return NotFound();

            var pdfBytes = await _pdfService.GenerateInvoicePdfAsync(invoice, invoice.UserId);
            return File(pdfBytes, "application/pdf", $"Invoice-{invoice.InvoiceNumber}.pdf");
        }
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var invoice = await _db.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == GetCurrentUserId());

            if (invoice == null) return NotFound();

            _db.Remove(invoice);
            await _db.SaveChangesAsync();
            return Ok();
        }
        // POST: /Invoice/SaveTemplate
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTemplate(InvoiceFormViewModel model, string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName))
                return BadRequest("Template name required");

            var userId = GetCurrentUserId()!.Value;
            if (!await _featureAccessor.CanSaveTemplatesAsync())
                return Forbid("Template saving is a premium feature");

            await _templateService.SaveTemplateAsync(userId, templateName, model);
            return RedirectToAction("Create", new { saved = true });
        }

        private Guid? GetCurrentUserId()
        {
            var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (claim == null || !Guid.TryParse(claim.Value, out var uid))
                return null;
            return uid;
        }

        private string GenerateInvoiceNumber()
        {
            // Simple: INV-{year}{month}{random}
            return $"INV-{DateTime.UtcNow:yyyyMM}{new Random().Next(1000, 9999)}";
        }
    }
}
