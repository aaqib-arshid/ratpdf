namespace ratpdf.Content
{
    /// <summary>Staggered review dates and default FAQ resolution for guides.</summary>
    internal static class ContentGuideSeo
    {
        private static readonly DateTime ReviewEpoch = new(2026, 6, 1);

        public static DateTime LastReviewedFor(string slug, string? cluster, string category)
        {
            var key = cluster ?? category;
            var hash = Hash(slug) ^ Hash(key);
            var dayOffset = Math.Abs(hash % 90);
            return ReviewEpoch.AddDays(dayOffset);
        }

        public static (string[]? Questions, string[]? Answers) ResolveFaqs(
            string slug,
            string? cluster,
            string? toolUrl,
            string[]? explicitQuestions,
            string[]? explicitAnswers)
        {
            if (explicitQuestions is { Length: > 0 } && explicitAnswers is { Length: > 0 }
                && explicitQuestions.Length == explicitAnswers.Length)
                return (explicitQuestions, explicitAnswers);

            if (slug.StartsWith("glossary-", StringComparison.OrdinalIgnoreCase))
            {
                if (slug is "glossary-overprint" or "glossary-flattened-pdf")
                    return PrintingFaqs(slug);
                return GlossaryFaqs(slug);
            }

            if (slug.EndsWith("-alternative", StringComparison.OrdinalIgnoreCase)
                || slug is "pdf-tool-alternatives" or "best-free-pdf-tools-2026" or "pdf-tool-security-comparison"
                    or "choose-pdf-tool" or "pdf-tool-market-comparison")
                return CompareFaqs(slug);

            if (toolUrl?.Contains("/invoice", StringComparison.OrdinalIgnoreCase) == true)
                return InvoiceFaqs(slug);

            if (toolUrl?.Contains("pdftodoc", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("doctopdf", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("pdf-to-word", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("scanned-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.StartsWith("convert-", StringComparison.OrdinalIgnoreCase)
                || slug.StartsWith("word-to-pdf", StringComparison.OrdinalIgnoreCase))
                return PdfToWordFaqs(slug);

            if (toolUrl?.Contains("convertimages", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("ppttopdf", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("images-to-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("powerpoint-to-pdf", StringComparison.OrdinalIgnoreCase))
                return ConvertFaqs(slug);

            if (toolUrl?.Contains("pdftoexcel", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("exceltopdf", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("htmltopdf", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("pdftomarkdown", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("pdftoimages", StringComparison.OrdinalIgnoreCase) == true
                || slug is "pdf-conversion-guide" or "extract-tables-from-pdf"
                    or "html-to-pdf-email-template"
                || slug.Contains("pdf-to-excel", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("excel-to-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("html-to-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("pdf-to-markdown", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("pdf-to-jpg", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("pdf-to-png", StringComparison.OrdinalIgnoreCase)
                || slug is "pdf-to-images")
                return ConversionFaqs(slug);

            if (toolUrl?.Contains("editpdf", StringComparison.OrdinalIgnoreCase) == true
                || slug.StartsWith("edit-", StringComparison.OrdinalIgnoreCase)
                || slug is "add-image-to-pdf" or "organize-pdf-pages" or "extract-single-page-pdf")
                return EditFaqs(slug);

            if (toolUrl?.Contains("/password", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("unlockpdf", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("/watermark", StringComparison.OrdinalIgnoreCase) == true
                || toolUrl?.Contains("redaction", StringComparison.OrdinalIgnoreCase) == true
                || slug is "secure-pdf-workflow" or "pdf-security-compliance-guide"
                    or "blackout-text-in-pdf" or "remove-password-from-pdf"
                    or "password-protect-before-email" or "password-protect-pdf-mac"
                || slug.Contains("password-protect", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("watermark-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.StartsWith("unlock-", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("redact", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("hipaa", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("metadata-remove", StringComparison.OrdinalIgnoreCase))
                return SecurityFaqs(slug);

            if (toolUrl?.Contains("pdftotext", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("pdf-to-text", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("extract-text", StringComparison.OrdinalIgnoreCase))
                return PdfToTextFaqs(slug);

            if (toolUrl?.Contains("/split", StringComparison.OrdinalIgnoreCase) == true
                || slug.StartsWith("split-pdf", StringComparison.OrdinalIgnoreCase))
                return SplitFaqs(slug);

            if (toolUrl?.Contains("/compress", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("compress", StringComparison.OrdinalIgnoreCase))
                return CompressFaqs(slug);

            if (toolUrl?.Contains("/merge", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("merge-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("merge-", StringComparison.OrdinalIgnoreCase))
                return MergeFaqs(slug);

            if (toolUrl?.Contains("ocrpdf", StringComparison.OrdinalIgnoreCase) == true
                || slug.StartsWith("ocr-pdf", StringComparison.OrdinalIgnoreCase))
                return OcrFaqs(slug);

            if (slug is "pdf-accessibility-wcag" or "pdf-accessibility-checker"
                or "tagged-pdf-checklist" or "section-508-pdf"
                || slug.Contains("accessibility", StringComparison.OrdinalIgnoreCase))
                return ComplianceFaqs(slug);

            if (toolUrl?.Contains("pdfmetadata", StringComparison.OrdinalIgnoreCase) == true
                || slug is "pdf-standards-guide" or "pdf-standards-archiving-hub"
                    or "pdf-a-archival" or "convert-to-pdf-a" or "pdf-a-conversion-online"
                    or "pdf-ua-accessibility" or "pdf-x-print-standard"
                    or "document-retention-pdf" or "pdf-archival-best-practices"
                    or "xmp-metadata-pdf" or "pdf-version-compatibility"
                    or "long-term-pdf-storage" or "pdf-metadata-audit"
                    or "beginner-pdf-metadata-explained"
                || slug.Contains("pdf-a", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("pdf-ua", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("pdf-x", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("retention", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("archival", StringComparison.OrdinalIgnoreCase)
                || slug is "pdf-metadata" or "add-page-numbers")
                return StandardsFaqs(slug);

            if (toolUrl?.Contains("flatten", StringComparison.OrdinalIgnoreCase) == true
                || slug is "pdf-printing-guide" or "print-to-pdf-windows" or "edge-print-to-pdf"
                    or "chrome-save-as-pdf-settings" or "print-pdf-double-sided"
                    or "print-pdf-black-and-white" or "pdf-fit-to-page-printing"
                    or "embed-fonts-before-printing" or "print-to-pdf-vs-save-as-pdf"
                    or "mac-print-to-pdf" or "print-pdf-from-ipad"
                    or "commercial-print-pdf-checklist" or "pdf-print-as-image"
                    or "glossary-overprint" or "glossary-flattened-pdf"
                || slug.Contains("print-to-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("print-pdf", StringComparison.OrdinalIgnoreCase)
                || slug is "compress-pdf-for-printing" or "flatten-pdf")
                return PrintingFaqs(slug);

            if (slug is "pdf-device-workflows-hub" or "merge-pdf-on-mac" or "merge-pdf-windows-11"
                    or "merge-pdf-on-android" or "pdf-to-word-on-mac" or "scan-to-pdf-phone"
                    or "split-pdf-on-mac" or "split-pdf-on-windows" or "ocr-pdf-on-phone"
                    or "safari-save-as-pdf" or "firefox-save-as-pdf" or "browser-vs-desktop-pdf-tools"
                    or "pdf-tools-on-chromebook" or "pdf-workflow-on-ipad" or "split-pdf-on-iphone"
                    or "convert-pdf-on-android" or "linux-pdf-tools-browser"
                || slug.Contains("merge-pdf-on", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("split-pdf-on", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("-on-mac", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("-on-windows", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("-on-android", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("-on-iphone", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("chromebook", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("linux-pdf", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("safari-save", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("firefox-save", StringComparison.OrdinalIgnoreCase)
                || slug is "scan-to-pdf-phone" or "ocr-pdf-on-phone")
                return DeviceFaqs(slug);

            if (slug is "pdf-regional-workflows-hub" or "india-job-portal-pdf-limits"
                    or "pdf-workflow-government" or "pdf-tools-government-applicants"
                || slug.Contains("visa-application-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("bank-statement-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("contract-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("invoice-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("tax-document-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("university-application-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("payslip-pdf-workflow", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("rent-receipt-pdf-workflow", StringComparison.OrdinalIgnoreCase))
                return RegionalFaqs(slug);

            if (slug is "pdf-troubleshooting" or "pdf-won-t-open" or "pdf-file-corrupted"
                or "repair-pdf-online" or "corrupted-pdf-repair" or "pdf-attachment-blocked"
                or "pdf-printing-blank-pages" or "print-pdf-without-margins"
                or "pdf-colors-wrong-when-printing" or "pdf-blank-pages-after-merge"
                or "pdf-file-too-large-to-email" or "pdf-upload-failed-portal"
                or "pdf-wont-open-password-unknown" or "pdf-merge-failed-error"
                or "pdf-download-incomplete" or "pdf-fonts-missing" or "pdf-text-not-selectable"
                || slug.Contains("corrupt", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("repair", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("won-t-open", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("wont-open", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("printing-blank", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("upload-failed", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("merge-failed", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("download-incomplete", StringComparison.OrdinalIgnoreCase))
                return TroubleshootFaqs(slug);

            if (slug is "gst-invoice-format-india" or "e-invoicing-india-pdf"
                or "pdf-redaction-permanent" or "wcag-22-pdf" or "gdpr-pdf-redaction"
                || toolUrl?.Contains("redaction", StringComparison.OrdinalIgnoreCase) == true
                || slug.Contains("wcag", StringComparison.OrdinalIgnoreCase)
                || slug.Contains("gdpr", StringComparison.OrdinalIgnoreCase))
                return ComplianceFaqs(slug);

            var c = cluster?.ToLowerInvariant() ?? "";
            if (c.Contains("invoice")) return InvoiceFaqs(slug);
            if (c.Contains("pdf to word")) return PdfToWordFaqs(slug);
            if (c.Contains("images") || c.Contains("powerpoint") || c.Contains("ppt")) return ConvertFaqs(slug);
            if (c.Contains("convert") || c.Contains("excel") || c.Contains("html") || c.Contains("markdown"))
                return ConversionFaqs(slug);
            if (c.Contains("edit") || c.Contains("organize")) return EditFaqs(slug);
            if (c.Contains("compress")) return CompressFaqs(slug);
            if (c.Contains("merge")) return MergeFaqs(slug);
            if (c.Contains("ocr")) return OcrFaqs(slug);
            if (c.Contains("pdf to text")) return PdfToTextFaqs(slug);
            if (c.Contains("split")) return SplitFaqs(slug);
            if (c.Contains("troubleshoot") || c.Contains("problem-solving")) return TroubleshootFaqs(slug);
            if (c.Contains("security") || c.Contains("hipaa") || c.Contains("redact")) return SecurityFaqs(slug);
            if (c.Contains("standard") || c.Contains("archiv") || c.Contains("retention")) return StandardsFaqs(slug);
            if (c.Contains("printing") || c.Contains("print")) return PrintingFaqs(slug);
            if (c.Contains("device") || c.Contains("browser") || c.Contains("mobile")
                || c.Contains("mac workflow") || c.Contains("windows workflow"))
                return DeviceFaqs(slug);
            if (c.Contains("regional") || c.Contains("visa") || c.Contains("government applicant"))
                return RegionalFaqs(slug);
            if (c.Contains("compliance") || c.Contains("gst") || c.Contains("gdpr") || c.Contains("wcag"))
                return ComplianceFaqs(slug);

            return DefaultFaqs(slug, toolUrl);
        }

        /// <summary>Generic HowTo steps when GuideHowToSteps has no slug-specific entry.</summary>
        public static string[]? DefaultHowToSteps(string? toolUrl, string slug)
        {
            if (string.IsNullOrEmpty(toolUrl)) return null;
            var tool = ToolLabel(toolUrl);
            return
            [
                $"Open {tool} at ratpdf.com{toolUrl}.",
                "Upload your file or enter the required details.",
                "Process and wait for the result (most jobs finish in under a minute).",
                "Download the output and verify quality before sharing externally.",
            ];
        }

        private static string ToolLabel(string toolUrl)
        {
            if (toolUrl.Contains("/invoice", StringComparison.OrdinalIgnoreCase)) return "Create Invoice";
            if (toolUrl.Contains("pdftodoc", StringComparison.OrdinalIgnoreCase)) return "PDF to Word";
            if (toolUrl.Contains("compress", StringComparison.OrdinalIgnoreCase)) return "Compress PDF";
            if (toolUrl.Contains("/merge", StringComparison.OrdinalIgnoreCase)) return "Merge PDF";
            if (toolUrl.Contains("/split", StringComparison.OrdinalIgnoreCase)) return "Split PDF";
            if (toolUrl.Contains("ocrpdf", StringComparison.OrdinalIgnoreCase)) return "OCR PDF";
            return "the free tool";
        }

        private static (string[], string[]) DefaultFaqs(string slug, string? toolUrl)
        {
            var tool = string.IsNullOrEmpty(toolUrl) ? "/guides/pdf-tools" : toolUrl;
            var label = ToolLabel(tool);
            return (
                [
                    "How do I complete this task with RatPDF?",
                    "Is this free on RatPDF?",
                    "What are the upload and daily limits?",
                ],
                [
                    $"Follow the workflow in this guide, then open {label} at ratpdf.com{tool}.",
                    "Yes — RatPDF free tier includes 3 uses per tool per day (200 MB per file).",
                    "Free: 200 MB per file, 3 uses/tool/day. Pro supports uploads up to 4 GB — see /subscription/plans.",
                ]
            );
        }

        private static (string[], string[]) InvoiceFaqs(string slug) =>
        (
            [
                "How do I create a PDF invoice with RatPDF?",
                "Is the invoice generator free?",
                "Can I download the invoice as PDF instantly?",
            ],
            [
                $"Open Create Invoice, enter your business and client details, add line items, and click Generate PDF. See /guides/{slug} for country-specific fields.",
                "Yes — single invoices are free on the Create Invoice tool (3 uses/day per tool on free tier).",
                "Yes — every invoice downloads as a print-ready PDF you can email or archive.",
            ]
        );

        private static (string[], string[]) PdfToWordFaqs(string slug) =>
        (
            [
                "How do I convert PDF to Word online?",
                "Will tables survive PDF to Word conversion?",
                "Do scanned PDFs need OCR before converting to Word?",
            ],
            [
                "Upload your PDF to PDF to Word at ratpdf.com, wait for conversion, and download DOCX. Details in this guide.",
                "Digital PDFs with real tables usually convert to editable Word tables — verify in Word after download.",
                "Yes — image-only scans need OCR PDF first so Word receives a searchable text layer.",
            ]
        );

        private static (string[], string[]) CompressFaqs(string slug) =>
        (
            [
                "How do I compress a PDF online?",
                "Which compression level should I use?",
                "Will compression remove text from my PDF?",
            ],
            [
                "Open Compress PDF, upload your file, choose a level, and download the smaller PDF.",
                "Recommended (Medium) for most email; Low for legal scans; High only when portals still reject the file.",
                "No — text stays as vectors; embedded images are re-encoded to reduce file size.",
            ]
        );

        private static (string[], string[]) MergeFaqs(string slug) =>
        (
            [
                "How do I merge PDF files online?",
                "Will merging PDFs reduce quality?",
                "Can I merge password-protected PDFs?",
            ],
            [
                $"Upload two or more PDFs to Merge PDF at ratpdf.com, arrange order, and download one file. See /guides/{slug} for workflow details.",
                "RatPDF uses vector-preserving merge on digital PDFs — scans stay image-based. See merge without quality loss guide.",
                "Unlock each file with the correct password first via Unlock PDF, then merge decrypted copies.",
            ]
        );

        private static (string[], string[]) OcrFaqs(string slug) =>
        (
            [
                "How do I OCR a PDF online?",
                "Do scanned PDFs need OCR before searching?",
                "Can I convert OCR PDF to Word?",
            ],
            [
                $"Upload image-only PDF to OCR PDF, wait for processing, download searchable PDF. Details in /guides/{slug}.",
                "Yes — image PDFs have no text layer until OCR runs; then Ctrl+F and copy work in viewers.",
                "Yes — OCR first, then PDF to Word on the searchable output. See scanned PDF to Word guide.",
            ]
        );

        private static (string[], string[]) ComplianceFaqs(string slug) =>
        (
            [
                "What makes a GST invoice PDF compliant in India?",
                "How is permanent PDF redaction different from black boxes?",
                "What does WCAG 2.2 require for PDF documents?",
            ],
            [
                "Include GSTIN, HSN/SAC, tax split, place of supply, and unique serial — see gst-invoice-format-india guide and Create Invoice tool.",
                "True redaction removes text from the PDF object stream; overlays can still be copied. Use PDF Redaction and verify with search.",
                "Tagged structure, alt text, contrast, and logical reading order — start from accessible source exports, not scans alone.",
            ]
        );

        private static (string[], string[]) PdfToTextFaqs(string slug) =>
        (
            [
                "How do I extract text from a PDF online?",
                "Do scanned PDFs need OCR before PDF to Text?",
                "When should I use PDF to Text instead of PDF to Word?",
            ],
            [
                $"Upload your PDF to PDF to Text at ratpdf.com and download a .txt file. See /guides/{slug} for workflow details.",
                "Yes — image-only scans need OCR PDF first so text export has characters to extract.",
                "Use PDF to Text for scripts, grep, and search — use PDF to Word when you need editable layout and tables.",
            ]
        );

        private static (string[], string[]) SplitFaqs(string slug) =>
        (
            [
                "How do I split a PDF online?",
                "When should I split instead of compress a PDF?",
                "Can I split a PDF by page range?",
            ],
            [
                $"Open Split PDF, choose page ranges, and download separate files. Details in /guides/{slug}.",
                "Split when compression would blur legal text or stamps — email Parts 1/2/3 with an index in the message body.",
                "Yes — enter start and end pages per part in the Split PDF tool before downloading.",
            ]
        );

        private static (string[], string[]) ConvertFaqs(string slug) =>
        (
            [
                "How do I convert images to PDF online?",
                "How do I convert PowerPoint to PDF without Adobe?",
                "Should I compress after converting images to PDF?",
            ],
            [
                $"Upload JPG, PNG, or WEBP files to Images to PDF, arrange order, and download one PDF. See /guides/{slug}.",
                "Upload PPTX to PowerPoint to PDF in your browser — no Acrobat or desktop Office required.",
                "Often yes — phone photo bundles can exceed email limits; use Compress PDF after convert if needed.",
            ]
        );

        private static (string[], string[]) ConversionFaqs(string slug) =>
        (
            [
                "How do I convert PDF to Excel online?",
                "Can I convert HTML to PDF in the browser?",
                "PDF to JPG vs PNG — which should I use?",
            ],
            [
                $"Upload your PDF to PDF to Excel and download XLSX. OCR scans first — details in /guides/{slug}.",
                "Yes — upload HTML to HTML to PDF; inline critical CSS for email templates.",
                "JPG for smaller web files; PNG for sharp text slides and UI captures.",
            ]
        );

        private static (string[], string[]) EditFaqs(string slug) =>
        (
            [
                "How do I edit a PDF online?",
                "Do scanned PDFs need OCR before editing?",
                "Can I add an image or logo to a PDF?",
            ],
            [
                $"Open Edit PDF, upload your file, add text or images, and download. Workflow details in /guides/{slug}.",
                "Yes — run OCR PDF first so text tools and search work on scanned documents.",
                "Yes — use Edit PDF to place logos, stamps, or photos on any page before sending.",
            ]
        );

        private static (string[], string[]) TroubleshootFaqs(string slug) =>
        (
            [
                "Why won't my PDF open?",
                "Can I fix a corrupted PDF online?",
                "What should I try first when a PDF fails?",
            ],
            [
                "Often a truncated download or wrong file type — re-download, try another viewer, then see /guides/pdf-won-t-open.",
                "Re-export from source when possible; compress or split may salvage readable pages — see /guides/repair-pdf-online.",
                $"Use the symptom guide at /guides/{slug} — hub: /guides/pdf-troubleshooting.",
            ]
        );

        private static (string[], string[]) SecurityFaqs(string slug) =>
        (
            [
                "How do I password protect a PDF online?",
                "How is PDF redaction different from black boxes?",
                "When should I watermark instead of encrypt?",
            ],
            [
                $"Upload to Protect PDF, set a strong passphrase, share password separately. Details in /guides/{slug}.",
                "True redaction removes text from the PDF stream; black overlays may still copy. Verify with search after export.",
                "Watermark for draft status on trusted reviewers; password when unauthorized opening must be blocked.",
            ]
        );

        private static (string[], string[]) StandardsFaqs(string slug) =>
        (
            [
                "What is PDF/A and when do I need it?",
                "How do I check PDF metadata before sharing?",
                "What is the difference between PDF/A and PDF/UA?",
            ],
            [
                "PDF/A is for long-term archival — use when policy or regulations require ISO 19005 — validate with veraPDF.",
                $"Open PDF Metadata viewer, export properties, scrub author and title if needed. See /guides/{slug}.",
                "PDF/A preserves visual content for archives; PDF/UA ensures accessible structure for assistive technology.",
            ]
        );

        private static (string[], string[]) PrintingFaqs(string slug) =>
        (
            [
                "Why does my PDF print blank pages?",
                "Should I flatten a PDF before printing?",
                "How do I print a PDF without white margins?",
            ],
            [
                "Often annotations or form layers — flatten PDF or enable print-as-image in the driver. See /guides/pdf-printing-blank-pages.",
                $"Yes for filled forms and markup-heavy PDFs — use Flatten PDF then print test page. Details in /guides/{slug}.",
                "Use printer borderless mode if supported; fit-to-page may add letterboxing — see print without margins guide.",
            ]
        );

        private static (string[], string[]) DeviceFaqs(string slug) =>
        (
            [
                "Can I use RatPDF on Mac and Windows?",
                "How do I merge PDFs on my phone?",
                "Are browser PDF tools safe on mobile?",
            ],
            [
                "Yes — same tools in Safari, Edge, Chrome, and Firefox on all major platforms.",
                $"Open Merge PDF in mobile browser — save files to Downloads/Files first. See /guides/{slug}.",
                "Use HTTPS with clear retention policy; avoid uploading highly sensitive docs on public Wi-Fi.",
            ]
        );

        private static (string[], string[]) RegionalFaqs(string slug) =>
        (
            [
                "How do I reduce PDF size for visa portal upload?",
                "Should I merge PDFs before uploading to government portal?",
                "Will compression blur bank statement text?",
            ],
            [
                "Use Compress PDF with Recommended — verify MRZ and amounts at 100% zoom after. See portal-specific compress guides.",
                $"Merge only if the portal allows one file slot — otherwise compress each document separately. Details in /guides/{slug}.",
                "Less or Recommended preserves most statement lines — re-export from bank if illegible after compress.",
            ]
        );

        private static (string[], string[]) GlossaryFaqs(string slug) =>
        (
            [
                "What is this PDF term?",
                "Does RatPDF have a tool for this?",
                "Where is the full step-by-step guide?",
            ],
            [
                $"This glossary page defines the term and when it applies — see /guides/{slug} for the definition and examples.",
                "Most glossary entries link to a matching RatPDF tool (compress, merge, OCR, sign, etc.) — check the CTA on the page.",
                "Follow the linked pillar guide on the same page for click-by-click workflows — glossary pages are definitions, not tutorials.",
            ]
        );

        private static (string[], string[]) CompareFaqs(string slug) =>
        (
            [
                "Is RatPDF a free alternative to paid PDF tools?",
                "How do I switch from another PDF site to RatPDF?",
                "Where is the side-by-side feature comparison?",
            ],
            [
                "RatPDF offers a free tier with daily limits per tool — merge, compress, convert, OCR, and sign without desktop install.",
                "Bookmark the tools you use most, run a one-week parallel test on sample files, then cancel redundant subscriptions — see the migration checklist on this page.",
                "Use the compare link at the top of this guide, or browse all vendors at /compare.",
            ]
        );

        private static int Hash(string s)
        {
            unchecked
            {
                var h = 17;
                foreach (var ch in s) h = h * 31 + ch;
                return h;
            }
        }
    }
}
