using ratpdf.Models;

namespace ratpdf.Content
{
    /// <summary>Primary sources referenced in guides for citation and E-E-A-T.</summary>
    public static class ContentSourcesCatalog
    {
        public static readonly ContentSource GhostscriptDocs = new(
            "Ghostscript documentation — PDF settings",
            "https://www.ghostscript.com/doc/current/Use.htm",
            "Artifex Software",
            "Compression level behavior and PDF output settings.");

        public static readonly ContentSource Pdf2Docx = new(
            "pdf2docx — PDF to DOCX library",
            "https://github.com/ArtifexSoftware/pdf2docx",
            "Artifex Software / GitHub",
            "Table and layout extraction approach used in PDF to Word conversion.");

        public static readonly ContentSource LibreOfficeExport = new(
            "LibreOffice — Export as PDF",
            "https://help.libreoffice.org/latest/en-US/text/shared/guide/export_pdf.html",
            "The Document Foundation",
            "Word/Excel to PDF export and print settings.");

        public static readonly ContentSource TesseractOcr = new(
            "Tesseract OCR — documentation",
            "https://tesseract-ocr.github.io/",
            "Google / open source",
            "OCR accuracy factors and language packs.");

        public static readonly ContentSource AdobePdfReference = new(
            "Adobe PDF Reference — encryption",
            "https://opensource.adobe.com/dc-acrobat-sdk-docs/pdfstandards/PDF32000_2008.pdf",
            "Adobe",
            "PDF password protection and encryption standards (ISO 32000).");

        public static readonly ContentSource GstPortal = new(
            "GST Portal — invoice guidelines",
            "https://www.gst.gov.in/",
            "Government of India",
            "Official GST resources for tax invoice requirements.");

        public static readonly ContentSource EsignAct = new(
            "U.S. ESIGN Act (1999)",
            "https://www.fdic.gov/resources/supervision-and-examinations/consumer-compliance/compliance-manual/documents/10/x-3.1.pdf",
            "U.S. FDIC",
            "High-level reference for electronic records and signatures in the U.S.");

        public static readonly ContentSource ILovePdfPrivacy = new(
            "iLovePDF — Privacy policy",
            "https://www.ilovepdf.com/privacy",
            "iLovePDF",
            "Competitor file retention and processing claims for comparisons.");

        public static readonly ContentSource SmallpdfPrivacy = new(
            "Smallpdf — Security & privacy",
            "https://smallpdf.com/privacy",
            "Smallpdf",
            "Competitor security certifications and retention policy.");

        private static readonly Dictionary<string, ContentSource[]> BySlug = new(StringComparer.OrdinalIgnoreCase)
        {
            ["compress-pdf-guide"] = [GhostscriptDocs, AdobePdfReference],
            ["merge-pdf"] = [AdobePdfReference],
            ["pdf-to-word"] = [Pdf2Docx, TesseractOcr, LibreOfficeExport],
            ["ocr-pdf"] = [TesseractOcr],
            ["word-to-pdf"] = [LibreOfficeExport],
            ["excel-to-pdf"] = [LibreOfficeExport],
            ["password-protect-pdf"] = [AdobePdfReference],
            ["sign-pdf-legally"] = [EsignAct, AdobePdfReference],
            ["gst-invoice-pdf-checklist"] = [GstPortal],
            ["invoice-generator-guide"] = [GstPortal],
            ["pdf-tool-alternatives"] = [ILovePdfPrivacy, SmallpdfPrivacy],
            ["secure-pdf-password-best-practices"] = [AdobePdfReference],
            ["choose-pdf-compression-level"] = [GhostscriptDocs],
        };

        private static readonly ContentSource[] DefaultPdfSources = [AdobePdfReference, GhostscriptDocs];

        public static ContentSource[] GetForSlug(string slug) =>
            BySlug.TryGetValue(slug, out var sources) ? sources : DefaultPdfSources;
    }
}
