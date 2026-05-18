using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using ratpdf.Models.Invoice;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Feature;
using System.IO.Compression;

namespace ratpdf.Controllers
{
    [Authorize]
    public class BulkInvoiceController : Controller
    {
        private readonly RatPDFDbContext _db;
        private readonly FeatureAccessor _featureAccessor;
        private readonly InvoicePdfService _pdfService;
        private readonly UsageTracker _usageTracker;

        public BulkInvoiceController(RatPDFDbContext db, FeatureAccessor featureAccessor, InvoicePdfService pdfService, UsageTracker usageTracker)
        {
            _db = db;
            _featureAccessor = featureAccessor;
            _pdfService = pdfService;
            _usageTracker = usageTracker;
        }

        private Guid? GetCurrentUserId()
        {
            var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (claim == null || !Guid.TryParse(claim.Value, out var uid))
                return null;
            return uid;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            var canBulk = userId.HasValue && await _featureAccessor.CanUseBulkInvoicingAsync(userId.Value);
            if (!canBulk)
            {
                ViewBag.UpgradeMessage = "Bulk invoice generation is available only for Business plan users. Upgrade to access this feature.";
                return View("UpgradeRequired");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadCsv(IFormFile csvFile)
        {
            var userId = GetCurrentUserId();

            if (!userId.HasValue || !await _featureAccessor.CanUseBulkInvoicingAsync(userId.Value))
            {
                return Forbid();
            }

       
            if (csvFile == null || csvFile.Length == 0)
            {
                ModelState.AddModelError("", "Please select a CSV file.");
                return View("Index");
            }

            var extension = Path.GetExtension(csvFile.FileName).ToLower();

            if (extension != ".csv")
            {
                ModelState.AddModelError("", "Only CSV files are allowed.");
                return View("Index");
            }

            var invoices = new List<(Invoice invoice, byte[] pdfBytes)>();
            var invoicesToSave = new List<Invoice>();
            var errors = new List<string>();

            try
            {
                
                using var reader = new StreamReader(csvFile.OpenReadStream());

                using var csv = new CsvHelper.CsvReader(
                    reader,
                    System.Globalization.CultureInfo.InvariantCulture
                );

                var records = csv.GetRecords<BulkInvoiceRow>().ToList();

            
                if (records.Count > 100)
                {
                    ModelState.AddModelError("", "You can upload a maximum of 100 rows only.");
                    return View("Index");
                }

                int rowNumber = 1;

          
                _db.ChangeTracker.AutoDetectChangesEnabled = false;

                foreach (var row in records)
                {
                    rowNumber++;

                    try
                    {
                        var invoice = MapRowToInvoice(row, userId.Value);

                       
                        invoice.Subtotal = invoice.Items.Sum(i => i.Quantity * i.UnitPrice);

                       
                        if (invoice.TaxType == "CGST/SGST" || invoice.TaxType == "IGST")
                        {
                            invoice.TaxRate = 18;
                            invoice.TaxAmount = invoice.Subtotal * 0.18m;
                        }
                        else
                        {
                            invoice.TaxRate = 0;
                            invoice.TaxAmount = 0;
                        }

                       
                        invoice.Total = invoice.Subtotal + invoice.TaxAmount;

                        
                        invoice.InvoiceNumber = GenerateInvoiceNumber();
                        invoice.IssueDate = DateTime.Today;
                        invoice.DueDate = DateTime.Today.AddDays(15);

                        invoicesToSave.Add(invoice);
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Row {rowNumber}: {ex.Message}");
                    }
                }

                if (invoicesToSave.Any())
                {
                    _db.Invoices.AddRange(invoicesToSave);

                    await _db.SaveChangesAsync();
                }

                _db.ChangeTracker.AutoDetectChangesEnabled = true;

                foreach (var invoice in invoicesToSave)
                {
                    try
                    {
                        var pdfBytes = await _pdfService.GenerateInvoicePdfAsync(invoice, userId);

                        invoices.Add((invoice, pdfBytes));
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"PDF generation failed for Invoice {invoice.InvoiceNumber}: {ex.Message}");
                    }
                }

                if (invoicesToSave.Any())
                {
                    await _usageTracker.LogAsync(userId, $"bulk_invoice_generated_{invoicesToSave.Count}");
                }

                if (errors.Any())
                {
                    ViewBag.Errors = errors;

                    if (invoices.Any())
                    {
                        var partialZip = CreateZipArchive(invoices);

                        return File(
                            partialZip,
                            "application/zip",
                            "partial_invoices.zip"
                        );
                    }

                    return View("Index");
                }

                var zipBytes = CreateZipArchive(invoices);

                return File(
                    zipBytes,
                    "application/zip",
                    $"invoices_{DateTime.Now:yyyyMMdd}.zip"
                );
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Upload failed: {ex.Message}");

                return View("Index");
            }
            finally
            {
                _db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        private Invoice MapRowToInvoice(BulkInvoiceRow row, Guid userId)
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CustomerName = row.ClientName,
                ClientGstin = row.ClientGstin,
                YourGstin = row.YourGstin,
                HsnSacCode = row.HsnSac,
                TaxType = row.TaxType,
                PlaceOfSupply = row.PlaceOfSupply,
                Notes = row.Notes,
                Currency = "INR",
                From = User.Identity.Name ?? "Your Firm",
                Items = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    Id = Guid.NewGuid(),
                    Description = row.ServiceDescription,
                    Quantity = row.Quantity,
                    UnitPrice = row.UnitPrice,
                    Amount = row.Quantity * row.UnitPrice,
                    HsnSacCode = row.HsnSac // optional
                }
            }
            };
            return invoice;
        }

        private string GenerateInvoiceNumber()
        {
            // Implement your logic, e.g., "INV-" + DateTime.Now.Ticks
            return "INV-" + DateTime.Now.Ticks.ToString();
        }

        private byte[] CreateZipArchive(List<(Invoice invoice, byte[] pdfBytes)> invoices)
        {
            using var ms = new MemoryStream();
            using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                foreach (var (inv, bytes) in invoices)
                {
                    var entry = archive.CreateEntry($"Invoice_{inv.InvoiceNumber}.pdf");
                    using var entryStream = entry.Open();
                    entryStream.Write(bytes, 0, bytes.Length);
                }
            }
            return ms.ToArray();
        }
    }
}
