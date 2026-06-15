using ratpdf.Constants;
using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    public static class ProgrammaticMetadataService
    {
        public static string BuildTitle(string displayTitle, IntentClassification intent, bool isPillar)
        {
            if (isPillar)
                return $"{displayTitle} | RatPDF";

            return intent.Intent switch
            {
                SearchIntent.TaskBased => $"{displayTitle} — Step-by-Step Guide | RatPDF",
                SearchIntent.DeviceBased => $"{displayTitle} — {intent.Device} Guide | RatPDF",
                SearchIntent.ErrorRecovery => $"{displayTitle} — Troubleshooting | RatPDF",
                SearchIntent.Navigational => $"{displayTitle} — Free Online | RatPDF",
                _ => $"{displayTitle} | RatPDF",
            };
        }

        public static string BuildDescription(string displayTitle, IntentClassification intent)
        {
            if (intent.HasCompetitorNoise)
                return GenericNoCompetitorDescription(intent.Vertical);

            return intent.Intent switch
            {
                SearchIntent.DeviceBased => DeviceDescription(intent.Vertical, intent.Device ?? "your device"),
                SearchIntent.ErrorRecovery => ErrorDescription(intent.Vertical, displayTitle),
                SearchIntent.TaskBased => TaskDescription(intent.Vertical, displayTitle),
                SearchIntent.Navigational => NavDescription(intent.Vertical, displayTitle),
                _ => NavDescription(intent.Vertical, displayTitle),
            };
        }

        public static string BuildCanonical(string routePrefix, string slug) =>
            PdfToolSeo.Canonical($"/{routePrefix.Trim('/')}/{slug}");

        private static string GenericNoCompetitorDescription(PdfToolVertical vertical) => vertical switch
        {
            PdfToolVertical.PdfToWord => "Convert PDF to editable Word (DOCX) with RatPDF — free browser tool, HTTPS upload, files deleted after processing.",
            PdfToolVertical.EditPdf => "Edit PDF files online with RatPDF — add text, sign, and annotate in your browser. Secure upload, automatic deletion.",
            PdfToolVertical.CompressPdf => "Compress PDF files online with RatPDF — reduce size for email and portals. Ghostscript-powered, free tier available.",
            _ => "Extract text from PDFs with RatPDF — free browser tool, HTTPS upload, files deleted after processing.",
        };

        private static string DeviceDescription(PdfToolVertical vertical, string device) => vertical switch
        {
            PdfToolVertical.PdfToWord => $"Convert PDF to Word on {device} with RatPDF — Safari or Chrome upload, DOCX download, no app install.",
            PdfToolVertical.EditPdf => $"Edit PDFs on {device} with RatPDF in your mobile or desktop browser — no software install.",
            PdfToolVertical.CompressPdf => $"Compress PDFs on {device} with RatPDF — upload in the browser, download a smaller file.",
            _ => $"Extract PDF text on {device} with RatPDF — browser-based, no install.",
        };

        private static string ErrorDescription(PdfToolVertical vertical, string displayTitle) => vertical switch
        {
            PdfToolVertical.PdfToWord => $"Fix PDF to Word conversion issues: {displayTitle}. Scanned PDFs may need OCR first; unlock password-protected files before upload.",
            PdfToolVertical.EditPdf => $"Troubleshoot PDF editing: {displayTitle}. Image-only scans need OCR; password PDFs must be unlocked first.",
            PdfToolVertical.CompressPdf => $"PDF compression problems: {displayTitle}. Try moderate compression; extremely large scans may need splitting first.",
            _ => $"Fix PDF text extraction: {displayTitle}. Check for scans, passwords, or missing text layers.",
        };

        private static string TaskDescription(PdfToolVertical vertical, string displayTitle) => vertical switch
        {
            PdfToolVertical.PdfToWord => $"Step-by-step: {displayTitle}. Upload to RatPDF PDF to Word, download DOCX — free, secure, digital PDFs convert best.",
            PdfToolVertical.EditPdf => $"Step-by-step: {displayTitle}. Open RatPDF Edit PDF, upload, modify, download — works in any modern browser.",
            PdfToolVertical.CompressPdf => $"Step-by-step: {displayTitle}. Upload to RatPDF Compress PDF, pick a level, download — ideal for email and portal limits.",
            _ => $"Step-by-step: {displayTitle}. Upload to RatPDF PDF to Text, extract, download .txt — free and secure.",
        };

        private static string NavDescription(PdfToolVertical vertical, string displayTitle) => vertical switch
        {
            PdfToolVertical.PdfToWord => $"{displayTitle} with RatPDF — free PDF to Word in your browser. HTTPS upload, automatic file deletion, Pro up to 4 GB.",
            PdfToolVertical.EditPdf => $"{displayTitle} with RatPDF — free browser PDF editor. HTTPS upload, files deleted after processing.",
            PdfToolVertical.CompressPdf => $"{displayTitle} with RatPDF — Ghostscript compression for email and upload limits. Free tier: 3 uses/day.",
            _ => $"{displayTitle} with RatPDF — free browser tool. HTTPS upload, automatic file deletion, Pro up to 4 GB.",
        };
    }
}
