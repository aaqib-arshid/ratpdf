using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("resources")]
    public class ResourcesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Free PDF & Business Document Resources | RatPDF";
            ViewData["Description"] = "Free statistics, research, calculators, and reference tools for PDF workflows, invoicing, GST compliance, and freelancer document tasks.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(LinkBuildingCatalog.HubPath);
            return View(LinkBuildingCatalog.All.ToList());
        }
    }

    [Route("research")]
    public class ResearchController : Controller
    {
        [HttpGet("attachment-size-limits")]
        public IActionResult AttachmentSizeLimits()
        {
            ViewData["Title"] = "PDF & Email Attachment Size Limits (2026 Reference Table) | RatPDF";
            ViewData["Description"] = "2026 reference table: Gmail, Outlook, Yahoo, WhatsApp, job portals, and government PDF upload limits with official sources.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/research/attachment-size-limits");
            return View();
        }

        [HttpGet("pdf-compression-benchmark")]
        public IActionResult PdfCompressionBenchmark()
        {
            ViewData["Title"] = "PDF Compression Benchmark Study 2026 — RatPDF Methodology & Results";
            ViewData["Description"] = "Original benchmark: compression ratios for digital, scanned, and invoice PDFs at Ghostscript quality levels. Methodology, data table, and sources.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/research/pdf-compression-benchmark");
            return View();
        }

        [HttpGet("freelancer-invoicing-statistics")]
        public IActionResult FreelancerInvoicingStatistics()
        {
            ViewData["Title"] = "Freelancer & SMB Invoicing Statistics 2026 | RatPDF Research";
            ViewData["Description"] = "Payment terms, late payment rates, invoice errors, and GST compliance gaps — statistics for freelancers and small businesses with cited sources.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/research/freelancer-invoicing-statistics");
            return View();
        }

        [HttpGet("document-retention-periods")]
        public IActionResult DocumentRetentionPeriods()
        {
            ViewData["Title"] = "Document Retention Periods — Invoices, Tax & Contracts by Region";
            ViewData["Description"] = "Reference guide: how long to keep invoices, GST records, tax documents, and contracts in India, UK, US, Australia, and Canada.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/research/document-retention-periods");
            return View();
        }
    }
}
