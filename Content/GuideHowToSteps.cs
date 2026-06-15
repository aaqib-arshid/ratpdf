namespace ratpdf.Content
{
    /// <summary>HowTo schema steps for guide articles (slug → steps).</summary>
    public static class GuideHowToSteps
    {
        private static readonly Dictionary<string, string[]> BySlug = new(StringComparer.OrdinalIgnoreCase)
        {
            ["compress-pdf-guide"] =
            [
                "Open the Compress PDF tool and upload your document.",
                "Choose Low, Medium, or High compression based on your quality needs.",
                "Start processing and wait for the optimized file.",
                "Download the result and verify file size before emailing or uploading.",
            ],
            ["merge-pdf"] =
            [
                "Open Merge PDF and upload two or more PDF files.",
                "Drag files to reorder the final document sequence.",
                "Click Merge and wait for processing to finish.",
                "Download the combined PDF and spot-check page order.",
            ],
            ["split-pdf"] =
            [
                "Upload the PDF you want to split.",
                "Enter page ranges or choose split options for each section.",
                "Run the split job and wait for output files.",
                "Download individual PDFs or a ZIP archive.",
            ],
            ["pdf-to-word"] =
            [
                "Upload a digital PDF (scanned files may need OCR first).",
                "Choose conversion mode if prompted for complex layouts.",
                "Wait for pdf2docx processing to complete.",
                "Download DOCX and review tables and headings in Word.",
            ],
            ["word-to-pdf"] =
            [
                "Upload a DOCX file from your device.",
                "Wait for LibreOffice export to finish.",
                "Download the print-ready PDF.",
                "Open once to confirm fonts, margins, and page breaks.",
            ],
            ["watermark-pdf"] =
            [
                "Upload the PDF that needs a draft or confidential mark.",
                "Enter watermark text (e.g. DRAFT or CONFIDENTIAL).",
                "Apply the watermark and download the marked PDF.",
                "Share the watermarked copy for review cycles.",
            ],
            ["password-protect-pdf"] =
            [
                "Upload the PDF you want to encrypt.",
                "Enter a strong password (share it on a separate channel).",
                "Apply encryption and download the protected file.",
                "Test opening the PDF with the password before sending externally.",
            ],
            ["sign-pdf"] =
            [
                "Upload the PDF requiring approval.",
                "Place a typed signature block on the signature line.",
                "Download the signed PDF for your records.",
                "Email the signed copy or archive it in your document system.",
            ],
            ["pdf-to-images"] =
            [
                "Upload the PDF you want to export as images.",
                "Select DPI if the tool offers quality options.",
                "Run export and wait for page rendering.",
                "Download the ZIP of JPG/PNG page images.",
            ],
            ["ocr-pdf"] =
            [
                "Upload a scanned image PDF.",
                "Run OCR to add a searchable text layer.",
                "Download the searchable PDF.",
                "Test search (Ctrl+F) to confirm text is findable.",
            ],
            ["invoice-generator-guide"] =
            [
                "Open the invoice generator and enter your business details.",
                "Add line items, tax rates, and payment terms.",
                "Preview the invoice layout on screen.",
                "Download the PDF invoice and send it to your client.",
            ],
            ["pdf-to-powerpoint"] =
            [
                "Upload the PDF presentation or report.",
                "Wait for slide conversion (one slide per page).",
                "Download the PPTX file.",
                "Open in PowerPoint and adjust speaker notes or order.",
            ],
            ["powerpoint-to-pdf"] =
            [
                "Upload your PPTX or PPT file.",
                "Wait for LibreOffice Impress export.",
                "Download the print-ready PDF.",
                "Verify slide layout and compress if emailing.",
            ],
            ["html-to-pdf"] =
            [
                "Paste HTML or upload an .html file.",
                "Review markup in the editor if needed.",
                "Click Convert HTML to PDF.",
                "Download and spot-check fonts and page breaks.",
            ],
            ["pdf-to-markdown"] =
            [
                "Upload a digital or OCR-processed PDF.",
                "Run text extraction per page.",
                "Download the .md file.",
                "Edit headings and links in your Markdown editor.",
            ],
            ["pdf-redaction"] =
            [
                "Upload the PDF containing sensitive content.",
                "Mark regions for permanent removal.",
                "Apply redaction and download the file.",
                "Search the PDF to confirm hidden text is gone.",
            ],
            ["compress-pdf-email-limits"] =
            [
                "Check your PDF size against the destination limit.",
                "Run medium compression on the Compress PDF tool.",
                "Re-check size with the PDF size checker if needed.",
                "Split into parts only if compression is insufficient.",
            ],
            ["background-remover"] =
            [
                "Open the background remover tool in your browser.",
                "Select or drag a JPG, PNG, WEBP, or BMP image — it stays on your device.",
                "Wait for on-device AI segmentation to finish.",
                "Download the transparent PNG at the same resolution as your original.",
            ],
            ["bmi-calculator-guide"] =
            [
                "Open the BMI calculator.",
                "Enter height and weight in your preferred units.",
                "Read your BMI value and WHO category.",
                "Document the result in clinical notes if applicable.",
            ],
            ["egfr-calculator-guide"] =
            [
                "Enter serum creatinine, age, and sex.",
                "Review the calculated eGFR in mL/min/1.73m².",
                "Note the CKD stage band if shown.",
                "Correlate with urinalysis and trend over time.",
            ],
            ["json-formatter-guide"] =
            [
                "Paste minified JSON into the formatter.",
                "Review pretty-printed output and syntax errors.",
                "Fix any highlighted issues in your source.",
                "Copy formatted JSON or compare with text comparer.",
            ],
            ["jwt-decoder-guide"] =
            [
                "Paste the JWT token (header.payload.signature).",
                "Inspect decoded header and payload JSON.",
                "Check exp, iss, aud, and scope claims.",
                "Verify signatures in your backend — decoding alone is not verification.",
            ],
            ["developer-tools-guide"] =
            [
                "Browse the developer tools hub for your task.",
                "Open JSON formatter, JWT decoder, or HTML formatter as needed.",
                "Use text comparer to diff before/after output.",
                "Bookmark frequently used utilities for daily debugging.",
            ],
        };

        public static IReadOnlyList<string>? Get(string slug) =>
            BySlug.TryGetValue(slug, out var steps) ? steps : null;
    }
}
