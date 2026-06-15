namespace ratpdf.Services.Seo
{
    public static class EditPdfPillarCatalog
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
                "edit-pdf-online",
                "Edit PDF Online",
                "Edit PDF files online with RatPDF — add text, signatures, and annotations in the browser. Free tier, secure HTTPS upload.",
                """
                <h2>Browser PDF editing</h2>
                <p>Fix typos, fill forms, and add signatures without desktop software. Works on Windows, Mac, iPhone, and Android browsers.</p>
                <h2>Use cases</h2>
                <ul>
                <li>Correct dates on published PDFs</li>
                <li>Fill government or HR forms</li>
                <li>Sign NDAs and contracts</li>
                </ul>
                """,
                ["edit-pdf-free", "edit-pdf-add-text", "edit-pdf-add-signature"]);

            yield return Pillar(
                "edit-pdf-free",
                "Edit PDF Free",
                "Free online PDF editor on RatPDF — 3 uses/day, 200 MB per file. Add text, sign, and annotate without signup.",
                """
                <h2>Free tier</h2>
                <p>Edit PDFs in the browser at no cost for occasional use. Pro removes daily limits and raises upload size to 4 GB.</p>
                """,
                ["edit-pdf-online", "edit-pdf-file"]);

            yield return Pillar(
                "edit-pdf-add-text",
                "Add Text to PDF",
                "Add text to PDF online — type anywhere on the page with RatPDF's browser editor.",
                """
                <h2>Adding text</h2>
                <p>Click to place text boxes, match font size to surrounding content, and download the updated PDF. For scanned pages, run <a href="/pdf/ocrpdf">OCR</a> first.</p>
                """,
                ["edit-pdf-online", "edit-pdf-add-signature"]);

            yield return Pillar(
                "edit-pdf-add-signature",
                "Add Signature to PDF",
                "Sign PDF documents online — draw, type, or upload a signature image with RatPDF.",
                """
                <h2>Signing workflow</h2>
                <p>Place your signature on the signature line, flatten if needed, and download. For typed signature blocks see also <a href="/pdf/signtext">Sign PDF</a>.</p>
                """,
                ["edit-pdf-online", "edit-pdf-add-text"]);

            yield return Pillar(
                "edit-pdf-file",
                "Edit PDF File Online",
                "Edit any PDF file online — upload, modify text or forms, download. RatPDF browser editor.",
                """
                <h2>File types</h2>
                <p>Standard PDF 1.x files from any source. Password-protected PDFs require the password before editing.</p>
                """,
                ["edit-pdf-online", "edit-pdf-free"]);
        }

        private static ProgrammaticPillarPage Pillar(string slug, string h1, string meta, string html, string[] related) => new(
            slug, h1, meta, html,
            [
                ("Is editing free?", "Yes — free tier with daily limits."),
                ("Need an app?", "No — works in the browser."),
                ("Scanned PDFs?", "OCR first for image-only scans."),
                ("Secure?", "Files deleted after processing."),
            ],
            [
                ("Open editor", "Go to Edit PDF on RatPDF."),
                ("Upload", "Select your PDF."),
                ("Edit", "Add text, sign, or annotate."),
                ("Download", "Save the updated PDF."),
            ],
            related);
    }
}
