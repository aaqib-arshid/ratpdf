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

        public static readonly ContentSource ITextHtml2Pdf = new(
            "iText html2pdf — HTML to PDF",
            "https://itextpdf.com/products/convert-html-css-to-pdf-itext-html2pdf",
            "iText Group",
            "HTML/CSS to PDF conversion engine used in server-side Java and .NET stacks.");

        public static readonly ContentSource EuVatDirective = new(
            "EU VAT Directive — invoicing rules",
            "https://taxation-customs.ec.europa.eu/taxation/vat/vat-invoicing-rules_en",
            "European Commission",
            "Mandatory VAT invoice content, simplified invoices, and reverse charge under Directive 2006/112/EC.");

        public static readonly ContentSource HmrcVatInvoice = new(
            "HMRC — VAT invoices (VAT Notice 700)",
            "https://www.gov.uk/vat-record-keeping/vat-invoices",
            "HM Revenue & Customs (UK)",
            "Required fields for full, simplified, and modified UK VAT invoices and record keeping.");

        public static readonly ContentSource AtoTaxInvoice = new(
            "ATO — Tax invoices",
            "https://www.ato.gov.au/businesses-and-organisations/gst-excise-and-indirect-taxes/gst/tax-invoices",
            "Australian Taxation Office",
            "Tax invoice requirements by sale amount, ABN, and GST display rules.");

        public static readonly ContentSource CraInvoiceInfo = new(
            "CRA — Records you need to support ITC claims",
            "https://www.canada.ca/en/revenue-agency/services/tax/businesses/topics/gst-hst-businesses/charge-collect-which-rate/get-ready-charge.html",
            "Canada Revenue Agency",
            "Tiered invoice information requirements and the GST/HST business number for input tax credits.");

        public static readonly ContentSource IrsRecordkeeping = new(
            "IRS — Recordkeeping for businesses",
            "https://www.irs.gov/businesses/small-businesses-self-employed/recordkeeping",
            "U.S. Internal Revenue Service",
            "Acceptable records (including electronic), supporting documents, and retention periods.");

        public static readonly ContentSource EuGdprGuide = new(
            "EU GDPR — official text overview",
            "https://gdpr.eu/",
            "European Union / gdpr.eu",
            "Personal data protection principles relevant to document disclosure and erasure.");

        public static readonly ContentSource HipaaHhs = new(
            "HHS — HIPAA for professionals",
            "https://www.hhs.gov/hipaa/for-professionals/index.html",
            "U.S. Department of Health and Human Services",
            "PHI safeguards, minimum necessary, and covered entity obligations.");

        public static readonly ContentSource Section508AccessBoard = new(
            "Section508.gov — ICT accessibility",
            "https://www.section508.gov/",
            "U.S. General Services Administration",
            "Federal ICT accessibility requirements including PDF documents.");

        public static readonly ContentSource SoxSecOverview = new(
            "SEC — Sarbanes-Oxley Act overview",
            "https://www.sec.gov/spotlight/sarbanes-oxley.htm",
            "U.S. Securities and Exchange Commission",
            "SOX financial reporting and internal control framework.");

        public static readonly ContentSource WcagW3c = new(
            "W3C — WCAG 2.2",
            "https://www.w3.org/TR/WCAG22/",
            "World Wide Web Consortium",
            "Web Content Accessibility Guidelines applicable to digital PDF distribution.");

        private static readonly Dictionary<string, ContentSource[]> BySlug = new(StringComparer.OrdinalIgnoreCase)
        {
            ["compress-pdf-guide"] = [GhostscriptDocs, AdobePdfReference],
            ["merge-pdf"] = [AdobePdfReference],
            ["pdf-to-word"] = [Pdf2Docx, TesseractOcr, LibreOfficeExport],
            ["pdf-to-word-vs-pdf-to-text"] = [Pdf2Docx, TesseractOcr],
            ["batch-compress-pdf"] = [GhostscriptDocs],
            ["merge-pdf-court-filing"] = [AdobePdfReference],
            ["ocr-pdf"] = [TesseractOcr],
            ["ocr-vs-pdf-to-text"] = [TesseractOcr, AdobePdfReference],
            ["compress-pdf-efiling"] = [GhostscriptDocs, AdobePdfReference],
            ["compress-pdf-incometax"] = [GhostscriptDocs, GstPortal],
            ["compress-pdf-digilocker"] = [GhostscriptDocs],
            ["compress-pdf-passport-india"] = [GhostscriptDocs],
            ["invoice-generator-india"] = [GstPortal],
            ["invoice-generator-usa"] = [IrsRecordkeeping],
            ["vat-invoice-eu-requirements"] = [EuVatDirective],
            ["hmrc-invoice-requirements"] = [HmrcVatInvoice],
            ["ato-invoice-requirements"] = [AtoTaxInvoice],
            ["cra-invoice-requirements"] = [CraInvoiceInfo],
            ["irs-tax-pdf-format"] = [IrsRecordkeeping],
            ["e-invoicing-india-pdf"] = [GstPortal],
            ["gdpr-pdf-redaction"] = [EuGdprGuide, AdobePdfReference],
            ["hipaa-pdf-handling"] = [HipaaHhs],
            ["section-508-pdf"] = [Section508AccessBoard, WcagW3c],
            ["sox-pdf-retention"] = [SoxSecOverview],
            ["wcag-22-pdf"] = [WcagW3c, Section508AccessBoard],
            ["compress-bank-statement-pdf"] = [GhostscriptDocs],
            ["compress-gst-invoice-pdf"] = [GhostscriptDocs, GstPortal],
            ["compress-pan-card-pdf"] = [GhostscriptDocs],
            ["compress-scanned-vs-digital-pdf"] = [GhostscriptDocs, AdobePdfReference],
            ["ghostscript-pdf-compression"] = [GhostscriptDocs],
            ["why-is-pdf-file-so-large"] = [GhostscriptDocs, AdobePdfReference],
            ["compress-pdf-accountants"] = [GhostscriptDocs],
            ["compress-pdf-lawyers"] = [GhostscriptDocs, AdobePdfReference],
            ["excel-to-pdf-without-adobe"] = [LibreOfficeExport, AdobePdfReference],
            ["extract-images-from-pdf-without-adobe"] = [AdobePdfReference],
            ["html-to-pdf-without-adobe"] = [ITextHtml2Pdf, AdobePdfReference],
            ["images-to-pdf-without-adobe"] = [AdobePdfReference],
            ["pdf-to-excel-without-adobe"] = [AdobePdfReference],
            ["pdf-to-jpg-without-adobe"] = [AdobePdfReference],
            ["pdf-to-markdown-without-adobe"] = [AdobePdfReference],
            ["pdf-to-png-without-adobe"] = [AdobePdfReference],
            ["pdf-to-powerpoint-without-adobe"] = [LibreOfficeExport, AdobePdfReference],
            ["powerpoint-to-pdf-without-adobe"] = [LibreOfficeExport, AdobePdfReference],
            ["text-to-pdf-without-adobe"] = [AdobePdfReference],
            ["word-to-pdf-without-adobe"] = [LibreOfficeExport, AdobePdfReference],
            ["merge-password-protected-pdf"] = [AdobePdfReference],
            ["merge-scanned-digital-pdf"] = [AdobePdfReference, TesseractOcr],
            ["pdf-to-text-legal"] = [AdobePdfReference, TesseractOcr],
            ["pdf-to-text-bank-statements"] = [TesseractOcr],
            ["pdf-to-word-resume"] = [Pdf2Docx, TesseractOcr],
            ["pdf-to-word-keep-formatting"] = [Pdf2Docx, TesseractOcr],
            ["pdf-to-word-invoice"] = [Pdf2Docx, GstPortal],
            ["compress-pdf-insurance-claims"] = [GhostscriptDocs],
            ["merge-pdf-without-quality-loss"] = [AdobePdfReference],
            ["pdf-to-text-multilingual"] = [TesseractOcr, AdobePdfReference],
            ["scanned-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["pdf-to-word-mac"] = [Pdf2Docx],
            ["pdf-to-word-without-word"] = [Pdf2Docx, LibreOfficeExport],
            ["pdf-to-text-accessibility"] = [TesseractOcr, AdobePdfReference],
            ["ocr-pdf-ediscovery"] = [TesseractOcr, AdobePdfReference],
            ["batch-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["pdf-to-word-vs-google-docs"] = [Pdf2Docx],
            ["recurring-invoice-generator"] = [GstPortal],
            ["compress-pdf-for-job-application"] = [GhostscriptDocs],
            ["merge-pdf-accountants"] = [AdobePdfReference, GhostscriptDocs],
            ["compress-pdf-for-indeed"] = [GhostscriptDocs],
            ["compress-pdf-for-university-application"] = [GhostscriptDocs],
            ["compress-pdf-common-app"] = [GhostscriptDocs],
            ["compress-before-merge-pdf"] = [GhostscriptDocs, AdobePdfReference],
            ["merge-pdf-students"] = [AdobePdfReference],
            ["compress-pdf-for-whatsapp"] = [GhostscriptDocs],
            ["compress-pdf-for-visa-application"] = [GhostscriptDocs],
            ["compress-pdf-for-government-forms"] = [GhostscriptDocs, GstPortal],
            ["merge-pdf-online"] = [AdobePdfReference],
            ["bulk-gst-invoice-generator"] = [GstPortal],
            ["compress-pdf-for-email"] = [GhostscriptDocs],
            ["compress-pdf-for-gmail"] = [GhostscriptDocs],
            ["compress-pdf-for-outlook"] = [GhostscriptDocs],
            ["compress-pdf-irctc"] = [GhostscriptDocs],
            ["compress-pdf-for-linkedin"] = [GhostscriptDocs],
            ["ocr-pdf-hindi"] = [TesseractOcr],
            ["ocr-pdf-arabic"] = [TesseractOcr],
            ["compress-pdf-for-telegram"] = [GhostscriptDocs],
            ["compress-pdf-for-naukri"] = [GhostscriptDocs],
            ["compress-pdf-cloud-storage"] = [GhostscriptDocs],
            ["compress-pdf-for-printing"] = [GhostscriptDocs],
            ["compress-pdf-for-protonmail"] = [GhostscriptDocs],
            ["compress-pdf-for-yahoo-mail"] = [GhostscriptDocs],
            ["compress-pdf-for-workday"] = [GhostscriptDocs],
            ["compress-pdf-schengen-visa"] = [GhostscriptDocs],
            ["compress-pdf-ukvi"] = [GhostscriptDocs],
            ["compress-pdf-home-affairs-australia"] = [GhostscriptDocs],
            ["compress-pdf-immigration-canada"] = [GhostscriptDocs],
            ["ocr-pdf-spanish"] = [TesseractOcr],
            ["compress-pdf-ucas"] = [GhostscriptDocs],
            ["compress-pdf-uidai"] = [GhostscriptDocs],
            ["compress-pdf-for-passport-application"] = [GhostscriptDocs],
            ["ocr-pdf-chinese"] = [TesseractOcr],
            ["ocr-pdf-french"] = [TesseractOcr],
            ["ocr-pdf-german"] = [TesseractOcr],
            ["ocr-pdf-japanese"] = [TesseractOcr],
            ["ocr-pdf-russian"] = [TesseractOcr],
            ["compress-pdf-usajobs"] = [GhostscriptDocs],
            ["ocr-pdf-poor-quality"] = [TesseractOcr],
            ["ocr-pdf-korean"] = [TesseractOcr],
            ["ocr-pdf-portuguese"] = [TesseractOcr],
            ["compress-pdf-on-iphone"] = [GhostscriptDocs],
            ["compress-pdf-on-android"] = [GhostscriptDocs],
            ["mistakes-pdf-to-word-for-scanned-tables"] = [Pdf2Docx, TesseractOcr],
            ["compress-pdf-on-mac"] = [GhostscriptDocs],
            ["compress-pdf-on-windows"] = [GhostscriptDocs],
            ["compress-pdf-with-images"] = [GhostscriptDocs],
            ["compress-pdf-without-quality-loss"] = [GhostscriptDocs],
            ["compress-pdf-made-it-larger"] = [GhostscriptDocs, AdobePdfReference],
            ["pdf-to-word-garbled-text"] = [Pdf2Docx, TesseractOcr],
            ["convert-contract-pdf-to-word"] = [Pdf2Docx, TesseractOcr, AdobePdfReference],
            ["convert-nda-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-lease-agreement-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-bank-statement-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-sow-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-purchase-order-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-quotation-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-proforma-invoice-pdf-to-word"] = [Pdf2Docx, GstPortal],
            ["convert-receipt-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-credit-note-pdf-to-word"] = [Pdf2Docx, GstPortal],
            ["convert-debit-note-pdf-to-word"] = [Pdf2Docx, GstPortal],
            ["convert-delivery-note-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["convert-tax-return-pdf-to-word"] = [Pdf2Docx, GstPortal],
            ["convert-transcript-pdf-to-word"] = [Pdf2Docx, TesseractOcr],
            ["compress-pdf-students"] = [GhostscriptDocs],
            ["compress-pdf-freelancers"] = [GhostscriptDocs],
            ["how-to-merge-pdf-files"] = [AdobePdfReference],
            ["glossary-compress-pdf-online"] = [GhostscriptDocs],
            ["glossary-pdf-to-word-converter"] = [Pdf2Docx],
            ["compress-pdf-teachers"] = [GhostscriptDocs],
            ["compress-pdf-recruiters"] = [GhostscriptDocs],
            ["compress-pdf-hr"] = [GhostscriptDocs],
            ["compress-pdf-government"] = [GhostscriptDocs],
            ["glossary-pdf-to-text-extractor"] = [TesseractOcr, AdobePdfReference],
            ["compress-pdf-ecommerce"] = [GhostscriptDocs],
            ["compress-pdf-real-estate"] = [GhostscriptDocs],
            ["compress-pdf-nonprofits"] = [GhostscriptDocs],
            ["compress-pdf-construction"] = [GhostscriptDocs],
            ["compress-pdf-marketing-agencies"] = [GhostscriptDocs],
            ["compress-pdf-healthcare-admin"] = [GhostscriptDocs],
            ["compress-pdf-for-lms"] = [GhostscriptDocs],
            ["merge-pdf-custom-order"] = [AdobePdfReference],
            ["combine-then-compress-pdf"] = [GhostscriptDocs, AdobePdfReference],
            ["extract-single-page-pdf"] = [AdobePdfReference],
            ["organize-pdf-pages"] = [AdobePdfReference],
            ["split-pdf-page-range"] = [AdobePdfReference],
            ["split-pdf-for-email"] = [GhostscriptDocs, AdobePdfReference],
            ["split-pdf-by-size"] = [GhostscriptDocs, AdobePdfReference],
            ["extract-text-without-adobe"] = [TesseractOcr, AdobePdfReference],
            ["tesseract-vs-online-ocr"] = [TesseractOcr, AdobePdfReference],
            ["edit-pdf-without-acrobat"] = [AdobePdfReference],
            ["edit-scanned-pdf"] = [TesseractOcr, AdobePdfReference],
            ["add-image-to-pdf"] = [AdobePdfReference],
            ["edit-pdf-forms"] = [AdobePdfReference, EsignAct],
            ["pdf-tool-security-comparison"] = [ILovePdfPrivacy, SmallpdfPrivacy, AdobePdfReference],
            ["browser-vs-desktop-pdf-tools"] = [ILovePdfPrivacy, SmallpdfPrivacy, AdobePdfReference],
            ["pdf-email-attachment-checklist"] = [GhostscriptDocs],
            ["merge-vs-compress"] = [GhostscriptDocs, AdobePdfReference],
            ["compress-vs-split"] = [GhostscriptDocs, AdobePdfReference],
            ["pdf-tools-small-business"] = [ILovePdfPrivacy, AdobePdfReference],
            ["pdf-to-text-python-workflow"] = [TesseractOcr, AdobePdfReference],
            ["compress-pdf-gst-portal"] = [GhostscriptDocs, GstPortal],
            ["extract-text-scanned-pdf"] = [TesseractOcr],
            ["word-to-pdf"] = [LibreOfficeExport],
            ["excel-to-pdf"] = [LibreOfficeExport],
            ["password-protect-pdf"] = [AdobePdfReference],
            ["sign-pdf-legally"] = [EsignAct, AdobePdfReference],
            ["gst-invoice-pdf-checklist"] = [GstPortal],
            ["invoice-generator-guide"] = [GstPortal],
            ["pdf-tool-alternatives"] = [ILovePdfPrivacy, SmallpdfPrivacy],
            ["secure-pdf-password-best-practices"] = [AdobePdfReference],
            ["choose-pdf-compression-level"] = [GhostscriptDocs],
            ["html-to-pdf-developers"] = [ITextHtml2Pdf, AdobePdfReference],
            ["html-to-pdf"] = [ITextHtml2Pdf],
            ["json-formatter-api-debugging"] = [AdobePdfReference],
            ["jwt-decoder-oauth-integration"] = [AdobePdfReference],
            ["json-formatter-guide"] = [AdobePdfReference],
            ["jwt-decoder-guide"] = [AdobePdfReference],
            ["html-formatter-guide"] = [ITextHtml2Pdf],
            ["dns-lookup-guide"] = [AdobePdfReference],
            ["text-comparer-guide"] = [AdobePdfReference],
            ["url-encoder-guide"] = [AdobePdfReference],
            ["img-to-base64-guide"] = [AdobePdfReference],
            ["developer-tools-guide"] = [AdobePdfReference],
        };

        private static readonly ContentSource[] DefaultPdfSources = [AdobePdfReference, GhostscriptDocs];

        public static ContentSource[] GetForSlug(string slug) =>
            BySlug.TryGetValue(slug, out var sources) ? sources : DefaultPdfSources;
    }
}
