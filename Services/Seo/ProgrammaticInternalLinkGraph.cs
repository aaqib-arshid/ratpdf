using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    /// <summary>Hub → spoke internal linking for intent-classified programmatic pages.</summary>
    public static class ProgrammaticInternalLinkGraph
    {
        private const string PdfToTxtHub = "/guides/pdf-txt-guide";
        private const string PdfToTxtTool = "/pdf/pdftotext";
        private const string OcrTool = "/pdf/ocrpdf";

        public static string GetHubPath(PdfToolVertical vertical, SearchIntent intent) => vertical switch
        {
            PdfToolVertical.PdfToText when intent is SearchIntent.TaskBased or SearchIntent.ErrorRecovery => PdfToTxtHub,
            PdfToolVertical.PdfToText => PdfToTxtHub,
            _ => PdfToTxtHub,
        };

        public static IReadOnlyList<(string Label, string Path)> GetPdfToTxtRelatedPages(
            string slug,
            IntentClassification intent)
        {
            (string Label, string Path)[] spokes = intent.Intent switch
            {
                SearchIntent.DeviceBased =>
                [
                    ("PDF to Text on iPhone", "/pdf-to-txt/pdf-to-text-iphone"),
                    ("PDF to Text on Android", "/pdf-to-txt/pdf-to-text-android"),
                    ("PDF to Text on Windows", "/pdf-to-txt/pdf-to-text-windows"),
                    ("PDF to Text online", "/pdf-to-txt/pdf-to-text-online"),
                ],
                SearchIntent.TaskBased =>
                [
                    ("How to convert PDF to text", "/pdf-to-txt/how-do-i-convert-pdf-to-text"),
                    ("PDF to Text online", "/pdf-to-txt/pdf-to-text-online"),
                    ("Extract text from PDF", "/pdf-to-txt/extract-text-from-pdf"),
                    ("PDF to Text from image", "/pdf-to-txt/pdf-to-text-from-image"),
                ],
                SearchIntent.ErrorRecovery =>
                [
                    ("Scanned PDF to text", "/pdf-to-txt/how-scanned-pdf-to-text"),
                    ("OCR PDF to Text", "/pdf-to-txt/ocr-pdf-to-text"),
                    ("PDF to Text OCR guide", "/pdf-to-txt/pdf-to-text-ocr"),
                    ("OCR PDF tool", OcrTool),
                ],
                _ =>
                [
                    ("PDF to Text online", "/pdf-to-txt/pdf-to-text-online"),
                    ("How to convert PDF to text", "/pdf-to-txt/how-do-i-convert-pdf-to-text"),
                    ("Extract text from PDF", "/pdf-to-txt/extract-text-from-pdf"),
                    ("PDF to Text OCR", "/pdf-to-txt/pdf-to-text-ocr"),
                ],
            };

            if ((intent.Intent is SearchIntent.TaskBased or SearchIntent.ErrorRecovery)
                && (slug.Contains("ocr", StringComparison.Ordinal) || slug.Contains("scan", StringComparison.Ordinal)))
            {
                spokes =
                [
                    ("Scanned PDF to text", "/pdf-to-txt/how-scanned-pdf-to-text"),
                    ("OCR PDF to Text", "/pdf-to-txt/ocr-pdf-to-text"),
                    ("Online OCR PDF to Text", "/pdf-to-txt/online-ocr-pdf-to-text"),
                    ("OCR PDF tool", OcrTool),
                ];
            }

            return spokes
                .Where(s => !s.Path.EndsWith(slug, StringComparison.OrdinalIgnoreCase))
                .Take(4)
                .ToList();
        }

        public static IReadOnlyList<(string Name, string Url)> GetRelatedTools(SearchIntent intent) =>
            intent switch
            {
                SearchIntent.ErrorRecovery or SearchIntent.TaskBased =>
                [
                    ("PDF to Text", PdfToTxtTool),
                    ("OCR PDF", OcrTool),
                    ("PDF to Word", "/pdf/pdftodoc"),
                    ("PDF to Excel", "/pdf/pdftoexcel"),
                ],
                SearchIntent.DeviceBased =>
                [
                    ("PDF to Text", PdfToTxtTool),
                    ("Compress PDF", "/pdf/compress"),
                    ("Merge PDF", "/pdf/merge"),
                    ("OCR PDF", OcrTool),
                ],
                _ =>
                [
                    ("PDF to Text", PdfToTxtTool),
                    ("OCR PDF", OcrTool),
                    ("PDF to Word", "/pdf/pdftodoc"),
                    ("Compress PDF", "/pdf/compress"),
                ],
            };
    }
}
