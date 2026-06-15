namespace ratpdf.Services.Seo
{
    /// <summary>
    /// Layer 1 authority pillars for PDF-to-text — deep curated content, not keyword templates.
    /// </summary>
    public static class PdfToTxtPillarCatalog
    {
        public sealed record PillarPage(
            string Slug,
            string H1,
            string MetaDescription,
            string ContentHtml,
            IReadOnlyList<(string Question, string Answer)> Faqs,
            IReadOnlyList<(string Name, string Text)> HowToSteps,
            string[] RelatedSlugs);

        private static readonly Dictionary<string, PillarPage> BySlug = Build().ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        public static bool IsPillar(string slug) => BySlug.ContainsKey(slug);

        public static PillarPage? Get(string slug) =>
            BySlug.TryGetValue(slug, out var p) ? p : null;

        public static IReadOnlyList<string> AllSlugs => BySlug.Keys.ToList();

        private static IEnumerable<PillarPage> Build()
        {
            yield return new PillarPage(
                "pdf-to-text-online",
                "PDF to Text Online",
                "Convert PDF to plain text online with RatPDF. Free browser tool — digital PDFs extract in seconds; scanned files need OCR first. HTTPS upload, files deleted after download.",
                """
                <h2>What PDF to Text does</h2>
                <p>PDF to Text extraction reads the <strong>text layer</strong> embedded in a PDF and exports it as a UTF-8 <code>.txt</code> file. Digital PDFs (from Word, Google Docs, LaTeX, or InDesign) usually contain selectable text — extraction is fast and faithful. Scanned PDFs store pages as images; you must run <a href="/pdf/ocrpdf">OCR</a> first to create a searchable text layer.</p>
                <h2>Real-world use cases</h2>
                <ul>
                <li><strong>Visa &amp; immigration forms</strong> — copy field labels and instructions into a checklist before filling PDFs offline.</li>
                <li><strong>Job applications</strong> — pull bullet points from a PDF resume or job description into your cover letter draft.</li>
                <li><strong>Banking &amp; KYC uploads</strong> — verify account numbers or addresses extracted from statement PDFs before retyping into portals.</li>
                <li><strong>Research</strong> — quote passages from papers without retyping; paste into Zotero, Notion, or Python notebooks.</li>
                <li><strong>Accessibility audits</strong> — confirm a PDF has a text layer after OCR for screen-reader compliance.</li>
                </ul>
                <h2>How extraction works technically</h2>
                <p>RatPDF reads PDF content streams and decodes character glyphs into Unicode text. Encoding (WinAnsi, UTF-16, custom fonts) is normalized to UTF-8 output. Tables may lose column alignment — for structured data use <a href="/pdf/pdftoexcel">PDF to Excel</a>. Images and vector graphics are skipped; only text operators are exported.</p>
                <h2>Limits &amp; quality</h2>
                <p>Password-protected PDFs must be unlocked first. Multi-column layouts may merge lines — proofread before publishing. Free tier: 3 uses/day, 200 MB per file. Pro: unlimited daily use, 4 GB uploads.</p>
                """,
                FaqsOnline(),
                HowToStandard(),
                ["how-do-i-convert-pdf-to-text", "extract-text-from-pdf", "pdf-to-text-ocr"]);

            yield return new PillarPage(
                "how-do-i-convert-pdf-to-text",
                "How to Convert PDF to Text",
                "Step-by-step guide to convert PDF to text with RatPDF. Upload, extract, download .txt — works on desktop and mobile browsers. Free tier included.",
                """
                <h2>Before you start</h2>
                <p>Check whether your PDF is <strong>digital</strong> (you can select words with the cursor) or <strong>scanned</strong> (pages behave like photos). Digital PDFs go straight to PDF to Text. Scans need OCR first.</p>
                <h2>Step-by-step (digital PDF)</h2>
                <ol>
                <li>Open <a href="/pdf/pdftotext">PDF to Text</a> in Chrome, Safari, Edge, or Firefox.</li>
                <li>Upload the file — drag-and-drop or pick from Files / Drive / iCloud.</li>
                <li>Click extract. Processing typically finishes in seconds for files under 50 MB.</li>
                <li>Download the <code>.txt</code> file or copy the preview text.</li>
                </ol>
                <h2>Step-by-step (scanned PDF)</h2>
                <ol>
                <li>Run <a href="/pdf/ocrpdf">OCR PDF</a> to add a searchable text layer.</li>
                <li>Download the OCR'd PDF, then upload it to PDF to Text.</li>
                <li>Review output — OCR may misread low-contrast scans or handwriting.</li>
                </ol>
                <h2>When to choose Word instead</h2>
                <p>If you need headings, bold, and tables preserved, use <a href="/pdf/pdftodoc">PDF to Word</a>. Plain text is best for search, scripting, and LLM prompts.</p>
                """,
                FaqsHowTo(),
                HowToStandard(),
                ["pdf-to-text-online", "extract-text-from-pdf", "pdf-to-text-ocr"]);

            yield return new PillarPage(
                "pdf-to-text-ocr",
                "PDF to Text with OCR",
                "Extract text from scanned PDFs using OCR then PDF to Text on RatPDF. Explains when OCR is required, quality tips, and free workflow limits.",
                """
                <h2>Why OCR matters</h2>
                <p>Scanned PDFs contain bitmap images of pages — there is no text to extract until OCR (Optical Character Recognition) recognizes characters and writes a hidden text layer. RatPDF's <a href="/pdf/ocrpdf">OCR PDF</a> tool creates that layer; PDF to Text then exports it.</p>
                <h2>Common scanned sources</h2>
                <ul>
                <li>Phone photos of contracts or receipts</li>
                <li>Library book chapters scanned to PDF</li>
                <li>Fax-to-PDF archives</li>
                <li>Government forms uploaded as image-only PDFs</li>
                </ul>
                <h2>OCR quality factors</h2>
                <p>300 DPI+, straight alignment, and high contrast improve accuracy. Skewed pages, handwriting, and watermarks increase errors. Always spot-check numbers (IBAN, dates, amounts) after extraction.</p>
                <h2>Language &amp; encoding</h2>
                <p>RatPDF outputs UTF-8 plain text. For Arabic, Hindi, or mixed scripts, verify a few lines manually — complex scripts may need dedicated OCR engines for production archives.</p>
                """,
                FaqsOcr(),
                HowToOcr(),
                ["how-scanned-pdf-to-text", "pdf-to-text-from-image", "pdf-to-text-online"]);

            yield return new PillarPage(
                "extract-text-from-pdf",
                "Extract Text from PDF",
                "Extract text from PDF documents online — digital and OCR-ready workflows. Free RatPDF tool with secure upload and automatic file deletion.",
                """
                <h2>Definition</h2>
                <p><strong>Text extraction</strong> means reading embedded character data from a PDF and saving it outside the document — usually as <code>.txt</code>, CSV, or into another app. It is not the same as converting the whole layout to Word or images.</p>
                <h2>Extraction vs conversion</h2>
                <ul>
                <li><strong>PDF to Text</strong> — plain Unicode output, smallest file, best for search and code.</li>
                <li><strong>PDF to Word</strong> — preserves paragraphs and some styling.</li>
                <li><strong>PDF to Excel</strong> — table structure for spreadsheets.</li>
                </ul>
                <h2>Workflow examples</h2>
                <p><strong>Legal review:</strong> extract testimony paragraphs into a diff tool.<br/>
                <strong>Finance:</strong> pull line items from digital invoice PDFs into Excel scripts.<br/>
                <strong>Education:</strong> copy bibliography entries from journal PDFs.</p>
                """,
                FaqsExtract(),
                HowToStandard(),
                ["pdf-to-text-online", "how-do-i-convert-pdf-to-text", "pdf-to-text-ocr"]);

            yield return new PillarPage(
                "pdf-to-text-from-image",
                "PDF to Text from Image",
                "Convert image-based PDF pages to editable text. OCR workflow for photo scans and image-only PDFs on RatPDF — free online.",
                """
                <h2>Image PDFs vs digital PDFs</h2>
                <p>Some PDFs are built entirely from JPG/PNG pages — common with mobile scanners. There is no native text layer. Run OCR, then extract text.</p>
                <h2>Embedded images inside digital PDFs</h2>
                <p>Digital PDFs may contain photos with captions; extraction returns caption text but not text inside the photo itself. OCR the full page if the photo contains words you need.</p>
                """,
                FaqsOcr(),
                HowToOcr(),
                ["pdf-to-text-ocr", "how-scanned-pdf-to-text", "pdf-to-text-online"]);

            yield return new PillarPage(
                "how-scanned-pdf-to-text",
                "How to Convert Scanned PDF to Text",
                "Convert scanned PDFs to editable text: OCR first, then extract. RatPDF walkthrough for photo scans, faxes, and image-only documents.",
                """
                <h2>Diagnose your file</h2>
                <p>Try selecting text in a PDF viewer. If you cannot highlight words, the file is image-based — follow the OCR path below.</p>
                <h2>Recommended pipeline</h2>
                <ol>
                <li>OCR the PDF (<a href="/pdf/ocrpdf">OCR PDF tool</a>).</li>
                <li>Extract text (<a href="/pdf/pdftotext">PDF to Text</a>).</li>
                <li>Proofread — especially numbers and names.</li>
                </ol>
                """,
                FaqsOcr(),
                HowToOcr(),
                ["pdf-to-text-ocr", "extract-text-from-pdf", "pdf-to-text-online"]);

            yield return OcrPillar(
                "ocr-pdf-to-text",
                "OCR PDF to Text",
                "Run OCR on scanned PDFs, then extract plain text with RatPDF. Full workflow for image-only documents, faxes, and phone scans.",
                """
                <h2>Two-step pipeline</h2>
                <p><strong>OCR PDF to Text</strong> is a two-stage process on RatPDF:</p>
                <ol>
                <li><a href="/pdf/ocrpdf">OCR PDF</a> — adds a hidden searchable text layer to image pages using OCR.</li>
                <li><a href="/pdf/pdftotext">PDF to Text</a> — reads that layer and exports UTF-8 plain text.</li>
                </ol>
                <h2>When you need this workflow</h2>
                <ul>
                <li>Passport or visa document scans uploaded as image PDFs</li>
                <li>Signed contract scans where you need editable clauses</li>
                <li>Medical record PDFs from fax or flatbed scanners</li>
                <li>Bank KYC packets photographed on a phone</li>
                </ul>
                <h2>OCR accuracy on RatPDF</h2>
                <p>Clean 300 DPI scans with straight alignment produce the best results. Skew, handwriting, stamps, and low contrast reduce accuracy — always verify account numbers, dates, and names manually before reuse.</p>
                <p>Read the full <a href="/guides/ocr-pdf">OCR PDF guide</a> for scan preparation tips.</p>
                """);

            yield return OcrPillar(
                "online-ocr-pdf-to-text",
                "Online OCR PDF to Text",
                "OCR and extract text from scanned PDFs online — no install. RatPDF browser workflow: OCR first, then PDF to Text.",
                """
                <h2>Online vs desktop OCR</h2>
                <p>RatPDF runs OCR in the browser — upload a scan, download a searchable PDF, then extract text. No Acrobat or command-line Tesseract install required.</p>
                <h2>Typical online workflow</h2>
                <ol>
                <li>Upload the scanned PDF to <a href="/pdf/ocrpdf">OCR PDF</a>.</li>
                <li>Download the OCR'd PDF (now searchable).</li>
                <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a> and save the .txt file.</li>
                </ol>
                <h2>Limits</h2>
                <p>Free tier: 3 uses per tool per day, 200 MB per file. Very large books may take longer — split with <a href="/pdf/split">Split PDF</a> if needed.</p>
                """);

            yield return OcrPillar(
                "free-ocr-pdf-to-text",
                "Free OCR PDF to Text",
                "Free OCR and text extraction for scanned PDFs on RatPDF. Browser-based, HTTPS upload, files deleted after processing.",
                """
                <h2>What's included free</h2>
                <p>RatPDF's free tier covers both OCR PDF and PDF to Text — 3 uses per tool per day. No signup required for basic extraction.</p>
                <h2>Free workflow for scans</h2>
                <ol>
                <li>OCR the scan (free tier) at <a href="/pdf/ocrpdf">OCR PDF</a>.</li>
                <li>Extract text (free tier) at <a href="/pdf/pdftotext">PDF to Text</a>.</li>
                </ol>
                <h2>When Pro helps</h2>
                <p>High-volume teams needing unlimited daily runs or 4 GB uploads benefit from Pro. Single-document users can usually stay on free tier.</p>
                """);

            yield return OcrPillar(
                "ocr-pdf-text-extraction",
                "OCR PDF Text Extraction",
                "Extract text from OCR'd PDFs — definition, workflow, and quality tips. RatPDF tools for scans, archives, and compliance review.",
                """
                <h2>Definition</h2>
                <p><strong>OCR text extraction</strong> means recognizing characters in page images and storing them as selectable Unicode text inside the PDF. <strong>Text extraction</strong> then exports that layer to plain .txt.</p>
                <h2>Compliance &amp; audit use cases</h2>
                <ul>
                <li>Verify OCR quality before e-discovery production</li>
                <li>Search archived scans for keywords after OCR</li>
                <li>Feed extracted text into redaction review workflows</li>
                </ul>
                <h2>After extraction</h2>
                <p>For structured tables, try <a href="/pdf/pdftoexcel">PDF to Excel</a>. For editable layout, use <a href="/pdf/pdftodoc">PDF to Word</a> on the OCR'd PDF.</p>
                """);

            yield return DevicePillar("pdf-to-text-iphone", "iPhone", "Safari and Files app");
            yield return DevicePillar("pdf-to-text-android", "Android", "Chrome and Google Drive");
            yield return DevicePillar("pdf-to-text-windows", "Windows", "Edge or Chrome on Windows 10/11");
        }

        private static PillarPage OcrPillar(
            string slug,
            string h1,
            string metaDescription,
            string contentHtml) => new(
            slug,
            h1,
            metaDescription,
            contentHtml,
            FaqsOcr(),
            HowToOcr(),
            ["pdf-to-text-ocr", "how-scanned-pdf-to-text", "ocr-pdf-to-text", "extract-text-from-pdf"]);

        private static PillarPage DevicePillar(string slug, string device, string browserHint) => new(
            slug,
            $"PDF to Text on {device}",
            $"Extract text from PDF files on {device} with RatPDF — no app install. Upload via {browserHint}, download .txt in seconds.",
            $"""
            <h2>Using PDF to Text on {device}</h2>
            <p>RatPDF runs in your mobile or desktop browser — no App Store download required. Open <a href="/pdf/pdftotext">PDF to Text</a>, upload from Files, Drive, or iCloud, and download the result.</p>
            <h2>Tips for {device}</h2>
            <ul>
            <li>Use {browserHint} for the most reliable upload dialog.</li>
            <li>Large scans may take longer — Wi-Fi recommended.</li>
            <li>For image-only scans, run <a href="/pdf/ocrpdf">OCR PDF</a> on desktop first if mobile OCR limits apply.</li>
            </ul>
            <h2>Privacy on shared devices</h2>
            <p>Files are deleted after processing, but clear downloads from the device folder if others use the same phone or PC.</p>
            """,
            FaqsDevice(device),
            HowToStandard(),
            ["pdf-to-text-online", "how-do-i-convert-pdf-to-text", "pdf-to-text-ocr"]);

        private static IReadOnlyList<(string Name, string Text)> HowToStandard() =>
        [
            ("Open PDF to Text", "Go to ratpdf.com/pdf/pdftotext in your browser."),
            ("Upload your PDF", "Drag-and-drop or choose a file from your device."),
            ("Extract", "Click extract and wait for processing to finish."),
            ("Download", "Save the .txt file or copy the text output."),
        ];

        private static IReadOnlyList<(string Name, string Text)> HowToOcr() =>
        [
            ("Check text selection", "If you cannot highlight text, the PDF is scanned."),
            ("Run OCR", "Use OCR PDF to add a searchable text layer."),
            ("Extract text", "Upload the OCR'd PDF to PDF to Text."),
            ("Verify output", "Spot-check numbers and names before reuse."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> FaqsOnline() =>
        [
            ("What is PDF to Text?", "It exports the embedded text layer from a PDF into a plain .txt file — useful for search, editing, and data pipelines."),
            ("Is it free?", "Yes — 3 uses per tool per day on the free tier. Pro removes daily limits and raises upload size to 4 GB."),
            ("Are my files stored?", "No long-term storage — files are processed over HTTPS and deleted after download."),
            ("Does it work on scanned PDFs?", "Scanned files need OCR first. Use OCR PDF, then PDF to Text."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> FaqsHowTo() =>
        [
            ("How long does conversion take?", "Digital PDFs usually finish in seconds. Large OCR'd scans depend on page count."),
            ("Can I convert on mobile?", "Yes — the tool works in mobile browsers on iOS and Android."),
            ("Will formatting be preserved?", "Plain text drops bold, columns, and images. Use PDF to Word for layout."),
            ("What encoding is used?", "Output is UTF-8 plain text."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> FaqsOcr() =>
        [
            ("Why is my extracted text empty?", "The PDF likely has no text layer — run OCR first."),
            ("How accurate is OCR?", "Clean 300 DPI scans are highly accurate; handwriting and low contrast reduce quality."),
            ("Can OCR read multiple languages?", "Results vary by script — verify critical fields manually."),
            ("Should I use Word instead?", "Use Word when you need headings and tables; use Text for scripts and search."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> FaqsExtract() =>
        [
            ("What's the difference between extract and convert?", "Extract means plain text output; convert often implies Word or Excel formats."),
            ("Can I extract tables?", "Tables become tab-separated lines — PDF to Excel preserves structure better."),
            ("Is extraction lossless?", "Character content is preserved; layout and styling are not."),
            ("Can I automate extraction?", "Download .txt and pipe into your scripts — API access is not offered on free tier."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> FaqsDevice(string device) =>
        [
            ($"Do I need an app on {device}?", "No — RatPDF works in the browser without installing software."),
            ("Can I upload from cloud storage?", "Yes — pick files from Drive, iCloud, or local storage in the file dialog."),
            ("Are scans supported?", "Yes after OCR — image-only PDFs need the OCR step first."),
            ("Is mobile upload secure?", "Transfers use HTTPS; files are deleted after processing."),
        ];
    }
}
