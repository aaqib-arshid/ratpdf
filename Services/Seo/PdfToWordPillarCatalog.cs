namespace ratpdf.Services.Seo
{
    public static class PdfToWordPillarCatalog
    {
        private static readonly Dictionary<string, ProgrammaticPillarPage> BySlug = Build().ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        public static IProgrammaticPillarCatalog Catalog { get; } = new CatalogImpl();

        private sealed class CatalogImpl : IProgrammaticPillarCatalog
        {
            public bool IsPillar(string slug) => BySlug.ContainsKey(slug);
            public ProgrammaticPillarPage? Get(string slug) => BySlug.GetValueOrDefault(slug);
            public IReadOnlyList<string> AllSlugs => BySlug.Keys.ToList();
        }

        private static IEnumerable<ProgrammaticPillarPage> Build()
        {
            yield return Pillar(
                "pdf-to-word",
                "Convert PDF to Word Online",
                "Convert PDF to editable Word (DOCX) online with RatPDF. Digital PDFs preserve layout; scans need OCR first. Free browser tool.",
                """
                <h2>What PDF to Word does</h2>
                <p>Converts PDF pages into an editable DOCX file — headings, paragraphs, tables, and images where possible. Best for contracts, reports, and résumés you need to revise in Word or Google Docs.</p>
                <h2>Real use cases</h2>
                <ul>
                <li><strong>Legal</strong> — redline contract clauses with track changes</li>
                <li><strong>HR</strong> — edit résumés submitted as PDF</li>
                <li><strong>Academic</strong> — reuse paper sections in thesis chapters</li>
                </ul>
                <h2>Scanned PDFs</h2>
                <p>Run <a href="/pdf/ocrpdf">OCR PDF</a> first so text is selectable before conversion.</p>
                """,
                ["convert-pdf-to-word", "pdf-to-word-iphone"]);

            yield return Pillar(
                "convert-pdf-to-word",
                "Convert PDF to Word",
                "Step-by-step: convert PDF to Word (DOCX) with RatPDF. Upload, convert, download — free online, no install.",
                """
                <h2>Quick steps</h2>
                <ol>
                <li>Open <a href="/pdf/pdftodoc">PDF to Word</a></li>
                <li>Upload the PDF</li>
                <li>Download DOCX</li>
                <li>Review tables and fonts in Word</li>
                </ol>
                <p>For plain text only, use <a href="/pdf/pdftotext">PDF to Text</a>.</p>
                """,
                ["pdf-to-word", "pdf-to-word-iphone"]);

            yield return Pillar(
                "pdf-to-word-iphone",
                "PDF to Word on iPhone",
                "Convert PDF to Word on iPhone with RatPDF — Safari upload, DOCX download, no App Store install.",
                """
                <h2>On iPhone</h2>
                <p>Open PDF to Word in Safari, upload from Files or iCloud, download DOCX to Files. Wi-Fi recommended for large scans.</p>
                """,
                ["pdf-to-word", "convert-pdf-to-word"]);

            yield return Pillar(
                "how-to-convert-pdf-to-word",
                "How to Convert PDF to Word",
                "Step-by-step tutorial: convert PDF to editable Word (DOCX) with RatPDF. Digital PDFs, scans with OCR, and quality checks.",
                """
                <h2>Before you convert</h2>
                <p>Try selecting text in your PDF viewer. If words highlight, the file is digital — go straight to PDF to Word. If not, run <a href="/pdf/ocrpdf">OCR PDF</a> first.</p>
                <h2>Step-by-step</h2>
                <ol>
                <li>Open <a href="/pdf/pdftodoc">PDF to Word</a></li>
                <li>Upload the PDF (unlock password-protected files first)</li>
                <li>Download DOCX when processing completes</li>
                <li>Open in Word or Google Docs — check tables and headers on page 1</li>
                </ol>
                <h2>Editorial depth</h2>
                <p>Full guide: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Scans: <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> · Formatting: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a>.</p>
                """,
                ["pdf-to-word", "convert-pdf-to-word", "pdf-to-word-iphone"]);
        }

        private static ProgrammaticPillarPage Pillar(string slug, string h1, string meta, string html, string[] related) => new(
            slug, h1, meta, html,
            [
                ("Is conversion free?", "Yes — 3 uses/day on free tier."),
                ("DOCX output?", "RatPDF outputs modern DOCX for Word and Google Docs."),
                ("Scanned files?", "Use OCR PDF before converting."),
                ("Privacy?", "HTTPS upload; files deleted after processing."),
            ],
            [
                ("Open tool", "Go to PDF to Word on RatPDF."),
                ("Upload", "Pick PDF from Files or cloud storage."),
                ("Convert", "Wait for processing to finish."),
                ("Download", "Open DOCX in Word or Google Docs."),
            ],
            related);
    }
}
