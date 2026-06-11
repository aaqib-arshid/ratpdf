namespace ratpdf.Content
{
    internal static class BlogBodies
    {
        public static string? Get(string slug) => slug switch
        {
            "send-large-pdf-email" => SendLargePdf,
            "pdf-vs-word-when-to-convert" => PdfVsWord,
            "small-business-pdf-workflow" => SmallBusiness,
            "scanned-documents-office-tips" => ScannedDocs,
            "gst-invoice-pdf-checklist" => GstInvoice,
            "secure-pdf-password-best-practices" => SecurePdf,
            "choose-pdf-compression-level" => CompressionLevel,
            "merge-pdf-without-quality-loss" => MergeQuality,
            _ => null
        };

        private const string SendLargePdf = """
            <p>Most email providers limit attachments to 10–25 MB. When your quarterly report or scanned dossier exceeds that, you have three practical options — not all are equal.</p>
            <h2>Option 1: Compress the PDF</h2>
            <p>Start with <a href="/guides/compress-pdf-guide">medium compression</a>. Image-heavy scans often shrink 50–70% with readable text. RatPDF uses Ghostscript — the same engine behind many print shops.</p>
            <h2>Option 2: Split into parts</h2>
            <p>If compression is not enough, <a href="/guides/split-pdf">split by chapter or date range</a> and send numbered parts (Part 1 of 3) in separate emails.</p>
            <h2>Option 3: Cloud links</h2>
            <p>Drive and Dropbox work, but corporate recipients often block external links. PDF compression keeps everything inside email workflow.</p>
            <h2>Checklist before hitting send</h2>
            <ul>
            <li>Open the compressed PDF on your phone — text still readable?</li>
            <li>File name descriptive: <code>Acme_Q3_Report_compressed.pdf</code></li>
            <li>Password-protect if the content is confidential</li>
            </ul>
            """;

        private const string PdfVsWord = """
            <p>Teams argue about PDF vs Word every day. The answer depends on whether the recipient must <em>edit</em> or only <em>view/print</em>.</p>
            <h2>Stay in PDF when</h2>
            <ul>
            <li>Layout must not shift (contracts, tenders, brochures)</li>
            <li>You distribute to many readers who should not change figures</li>
            <li>Print colour and pagination are fixed</li>
            </ul>
            <h2>Convert to Word when</h2>
            <ul>
            <li>Legal counsel will redline clauses</li>
            <li>Marketing will localise copy per region</li>
            <li>You need to reuse tables in Excel after <a href="/guides/pdf-to-word">PDF to Word</a></li>
            </ul>
            <h2>Round-trip warning</h2>
            <p>PDF → Word → PDF rarely matches the original pixel-perfect. Keep the source PDF archived.</p>
            """;

        private const string SmallBusiness = """
            <p>Small businesses without IT departments still move dozens of PDFs weekly — invoices, quotes, vendor statements. A simple toolchain beats expensive suites.</p>
            <h2>Recommended RatPDF stack</h2>
            <ol>
            <li><strong>Create</strong> — <a href="/guides/invoice-generator-guide">invoices</a> and <a href="/guides/word-to-pdf">Word to PDF</a> for proposals</li>
            <li><strong>Combine</strong> — <a href="/guides/merge-pdf">merge</a> signed pages onto contracts</li>
            <li><strong>Shrink</strong> — <a href="/guides/compress-pdf-guide">compress</a> before client email</li>
            <li><strong>Protect</strong> — <a href="/guides/password-protect-pdf">password</a> on payroll PDFs</li>
            </ol>
            <h2>Free tier limits</h2>
            <p>Three uses per tool per day covers occasional freelancers. Agencies hitting limits should plan for Pro at $8.99/mo — 4 GB uploads and unlimited conversions.</p>
            """;

        private const string ScannedDocs = """
            <p>Scanning is not dead — receipts, signed forms, and legacy paper still land on your desk. Quality at capture time saves hours of OCR cleanup.</p>
            <h2>Scanner settings</h2>
            <ul>
            <li>300 DPI for text documents; 200 DPI acceptable for email-only archives</li>
            <li>Grayscale for text — smaller files than colour</li>
            <li>Deskew and blank-page detection if your app supports it</li>
            </ul>
            <h2>After scanning</h2>
            <p>Run <a href="/guides/compress-pdf-guide">compression</a>, then <a href="/guides/pdf-to-word">PDF to Word</a> if you need editable text. Expect page-image Word output for pure scans — that is normal.</p>
            """;

        private const string GstInvoice = """
            <p>GST-compliant invoices in India must show specific fields for input tax credit. A pretty PDF is useless if the tax breakdown is wrong.</p>
            <h2>Mandatory elements</h2>
            <ul>
            <li>GSTIN of supplier and recipient (B2B)</li>
            <li>HSN/SAC codes per line where required</li>
            <li>Taxable value, CGST/SGST or IGST split</li>
            <li>Place of supply for inter-state IGST</li>
            </ul>
            <h2>PDF delivery</h2>
            <p>Export PDF from your <a href="/Invoice/Create">invoice generator</a>, email to client, and retain a copy for 6+ years per statutory guidance. Compress archived years annually.</p>
            """;

        private const string SecurePdf = """
            <p>Password-protecting PDFs is easy; doing it safely is harder. Weak passwords fall to offline cracking within hours.</p>
            <h2>Do</h2>
            <ul>
            <li>12+ random characters or long passphrases</li>
            <li>Share password on a different channel than email</li>
            <li>Rotate passwords when staff leave</li>
            </ul>
            <h2>Do not</h2>
            <ul>
            <li>Put the password in the email subject line</li>
            <li>Use client name + 123</li>
            <li>Assume watermark alone equals security</li>
            </ul>
            <p><a href="/guides/password-protect-pdf">Protect PDF guide →</a></p>
            """;

        private const string CompressionLevel = """
            <p>Choosing the wrong compression level either wastes megabytes or blurs fine print. Here is a decision tree used by document teams.</p>
            <h2>Low compression</h2>
            <p>Legal agreements, engineering drawings with thin lines, PDFs destined for print.</p>
            <h2>Medium compression</h2>
            <p>Default for business email — brochures, slide exports, mixed text and photos.</p>
            <h2>High compression</h2>
            <p>Portal uploads with 2 MB caps, mobile preview copies, internal drafts where sharp photos are not critical.</p>
            <p>Test on one page first if unsure — open zoomed to 100% and read footnotes.</p>
            """;

        private const string MergeQuality = """
            <p>Bad merge tools rasterize pages into low-DPI JPEGs — logos blur and text looks hollow. Quality merge <em>copies page objects</em> without re-encoding.</p>
            <h2>Signs your merge tool is low quality</h2>
            <ul>
            <li>File size jumps unpredictably</li>
            <li>Text is not selectable after merge</li>
            <li>Vector logos look jagged</li>
            </ul>
            <h2>RatPDF approach</h2>
            <p>iText smart mode preserves vectors. After merge, run <a href="/guides/compress-pdf-guide">compression</a> only if size requires it — not by default.</p>
            """;
    }
}
