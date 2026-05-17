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
        #region Private fields
        private readonly RatPDFDbContext _db;
        private readonly InvoicePdfService _pdfService;
        private readonly FeatureAccessor _featureAccessor;
        private readonly UsageTracker _usageTracker;
        private readonly TemplateService _templateService;
        #endregion
        #region Construtor
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
        #endregion
        #region Endpoints
        // GET: /Invoice/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create(Guid? templateId)
        {
            var userId = GetCurrentUserId();
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
            ViewBag.IsPaid = await _featureAccessor.CanRemoveWatermarkAsync(userId);
            return View(model);
        }

        // POST: /Invoice/GeneratePdf
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneratePdf(InvoiceFormViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

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
            var userIdValue = invoice.UserId.HasValue ? invoice.UserId.Value : Guid.Empty;
            var isSubscribed = await _featureAccessor.CanRemoveWatermarkAsync(userIdValue);
            if (User.Identity?.IsAuthenticated == true && invoice.UserId.HasValue && isSubscribed)
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
            return Redirect("~/InvoiceDashboard/Index");
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
                return RedirectToAction("Plans","Subscription");

            await _templateService.SaveTemplateAsync(userId, templateName, model);
            return RedirectToAction("Create", new { saved = true });
        }
        #endregion
        #region Private
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
        #endregion

        #region SEO
        [HttpGet("invoice/gst-invoice-generator")] public async Task<IActionResult> GstInvoiceGenerator() => View();
        [HttpGet("invoice/invoice-generator-freelancers")] public async Task<IActionResult> InvoiceGeneratorForFreelancers() => View();
        [HttpGet("invoice/free-invoice-no-signup")] public async Task<IActionResult> FreeInvoiceNoSinup() => View();
        [HttpGet("invoice/invoice-generator-india")] public async Task<IActionResult> InvoiceGeneratorIndia() => View();
        [HttpGet("invoice/invoice-generator-no-login")] public async Task<IActionResult> InvoiceGeneratorNoLogin() => View();
        [HttpGet("invoice/free-invoice-generator-pdf")] public async Task<IActionResult> FreeInvoiceGeneratorPdf() => View();

        [HttpGet("invoice/invoice-generator-gst")] public async Task<IActionResult> InvoiceGeneratorGst() => View();

        [HttpGet("invoice/gst-invoice-maker-free")] public async Task<IActionResult> GstInvoiceMakerFree() => View();

        [HttpGet("invoice/vat-invoice-generator-uk")] public async Task<IActionResult> VatInvoiceGeneratorUk() => View();

        [HttpGet("invoice/invoice-generator-photographers")] public async Task<IActionResult> InvoiceGeneratorPhotographers() => View();

        [HttpGet("invoice/tax-invoice-generator")] public async Task<IActionResult> TaxInvoiceGenerator() => View();

        [HttpGet("invoice/invoice-generator-uk")] public async Task<IActionResult> InvoiceGeneratorUk() => View();

        [HttpGet("invoice/invoice-generator-contractors")] public async Task<IActionResult> InvoiceGeneratorContractors() => View();

        [HttpGet("invoice/invoice-generator-designers")] public async Task<IActionResult> InvoiceGeneratorDesigners() => View();

        [HttpGet("invoice/invoice-generator-plumbers")] public async Task<IActionResult> InvoiceGeneratorPlumbers() => View();

        [HttpGet("invoice/simple-invoice-generator")] public async Task<IActionResult> SimpleInvoiceGenerator() => View();

        [HttpGet("invoice/proforma-invoice-generator")] public async Task<IActionResult> ProformaInvoiceGenerator() => View();

        [HttpGet("invoice/instant-invoice-generator")] public async Task<IActionResult> InstantInvoiceGenerator() => View();

        [HttpGet("invoice/invoice-maker-india")] public async Task<IActionResult> InvoiceMakerIndia() => View();

        [HttpGet("invoice/invoice-generator-cleaning")] public async Task<IActionResult> InvoiceGeneratorCleaning() => View();

        [HttpGet("invoice/free-pdf-invoice-maker")] public async Task<IActionResult> FreePdfInvoiceMaker() => View();

        [HttpGet("invoice/invoice-generator-download-pdf")] public async Task<IActionResult> InvoiceGeneratorDownloadPdf() => View();

        [HttpGet("invoice/invoice-generator-electricians")] public async Task<IActionResult> InvoiceGeneratorElectricians() => View();

        [HttpGet("invoice/invoice-generator-sole-trader")] public async Task<IActionResult> InvoiceGeneratorSoleTrader() => View();

        [HttpGet("invoice/invoice-generator-australia")] public async Task<IActionResult> InvoiceGeneratorAustralia() => View();

        [HttpGet("invoice/invoice-generator-consultants")] public async Task<IActionResult> InvoiceGeneratorConsultants() => View();

        [HttpGet("invoice/invoice-generator-landscaping")] public async Task<IActionResult> InvoiceGeneratorLandscaping() => View();

        [HttpGet("invoice/invoice-generator-canada")] public async Task<IActionResult> InvoiceGeneratorCanada() => View();

        [HttpGet("invoice/invoice-generator-web-developers")] public async Task<IActionResult> InvoiceGeneratorWebDevelopers() => View();

        [HttpGet("invoice/invoice-generator-coaches")] public async Task<IActionResult> InvoiceGeneratorCoaches() => View();

        [HttpGet("invoice/professional-invoice-generator")] public async Task<IActionResult> ProfessionalInvoiceGenerator() => View();

        [HttpGet("invoice/hourly-invoice-generator")] public async Task<IActionResult> HourlyInvoiceGenerator() => View();

        [HttpGet("invoice/invoice-generator-singapore")] public async Task<IActionResult> InvoiceGeneratorSingapore() => View();

        [HttpGet("invoice/invoice-generator-new-zealand")] public async Task<IActionResult> InvoiceGeneratorNewZealand() => View();

        [HttpGet("invoice/invoice-generator-tutors")] public async Task<IActionResult> InvoiceGeneratorTutors() => View();

        [HttpGet("invoice/invoice-generator-online")] public async Task<IActionResult> InvoiceGeneratorOnline() => View();

        [HttpGet("invoice/invoice-generator-south-africa")] public async Task<IActionResult> InvoiceGeneratorSouthAfrica() => View();

        [HttpGet("invoice/invoice-generator-small-business")] public async Task<IActionResult> InvoiceGeneratorSmallBusiness() => View();

        [HttpGet("invoice/invoice-generator-philippines")] public async Task<IActionResult> InvoiceGeneratorPhilippines() => View();

        [HttpGet("invoice/recurring-invoice-generator")] public async Task<IActionResult> RecurringInvoiceGenerator() => View();
       
        // Accountants and agencies target
        [HttpGet("invoice/accountants")] public async Task<IActionResult> InvoiceAccountants() => View();
        [HttpGet("invoice/invoice-generator-accountants")] public async Task<IActionResult> InvoiceGeneratorAccountants() => View();

        [HttpGet("invoice/invoice-generator-ca-firms")] public async Task<IActionResult> InvoiceGeneratorCaFirms() => View();

        [HttpGet("invoice/gst-invoice-ca")] public async Task<IActionResult> GstInvoiceCa() => View();

        [HttpGet("invoice/invoice-software-accountants-india")] public async Task<IActionResult> InvoiceSoftwareAccountantsIndia() => View();

        [HttpGet("invoice/invoice-generator-chartered-accountants")] public async Task<IActionResult> InvoiceGeneratorCharteredAccountants() => View();

        [HttpGet("invoice/bulk-gst-invoice-generator")] public async Task<IActionResult> BulkGstInvoiceGenerator() => View();

        [HttpGet("invoice/invoice-generator-bookkeepers")]
        public async Task<IActionResult> InvoiceGeneratorBookkeepers() => View();

        [HttpGet("invoice/invoice-generator-tax-consultants")]
        public async Task<IActionResult> InvoiceGeneratorTaxConsultants() => View();

        [HttpGet("invoice/invoice-generator-multiple-clients")]
        public async Task<IActionResult> InvoiceGeneratorMultipleClients() => View();

        [HttpGet("invoice/bulk-invoice-generator")]
        public async Task<IActionResult> BulkInvoiceGenerator() => View();

        //[HttpGet("invoice/invoice-generator-clients")]
        //public async Task<IActionResult> InvoiceGeneratorClients() => View();

        //[HttpGet("invoice/multi-client-invoice-generator")]
        //public async Task<IActionResult> MultiClientInvoiceGenerator() => View();

        //[HttpGet("invoice/invoice-management-small-business")]
        //public async Task<IActionResult> InvoiceManagementSmallBusiness() => View();

        //[HttpGet("invoice/recurring-invoice-clients")] public async Task<IActionResult> RecurringInvoiceClients() => View();

        //[HttpGet("invoice/white-label-invoice-generator")]
        //public async Task<IActionResult> WhiteLabelInvoiceGenerator() => View();

        //[HttpGet("invoice/invoice-generator-digital-agency")]
        //public async Task<IActionResult> InvoiceGeneratorDigitalAgency() => View();

        //[HttpGet("invoice/invoice-generator-marketing-agency")]
        //public async Task<IActionResult> InvoiceGeneratorMarketingAgency() => View();

        //[HttpGet("invoice/invoice-template-agency")]
        //public async Task<IActionResult> InvoiceTemplateAgency() => View();

        //[HttpGet("invoice/invoice-generator-it-companies")]
        //public async Task<IActionResult> InvoiceGeneratorItCompanies() => View();

        //[HttpGet("invoice/invoice-generator-consulting-firm")]
        //public async Task<IActionResult> InvoiceGeneratorConsultingFirm() => View();

        //[HttpGet("invoice/invoice-generator-staffing-agency")]
        //public async Task<IActionResult> InvoiceGeneratorStaffingAgency() => View();

        //[HttpGet("invoice/invoice-generator-recruitment-agency")]
        //public async Task<IActionResult> InvoiceGeneratorRecruitmentAgency() => View();

        //[HttpGet("invoice/agency-invoice-pdf")]
        //public async Task<IActionResult> AgencyInvoicePdf() => View();

        //[HttpGet("invoice/invoice-generator-web-agency")]
        //public async Task<IActionResult> InvoiceGeneratorWebAgency() => View();

        //[HttpGet("invoice/invoice-generator-event-management")]
        //public async Task<IActionResult> InvoiceGeneratorEventManagement() => View();
        #endregion
    }
}
