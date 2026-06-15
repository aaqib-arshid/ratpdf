using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    /// <summary>Programmatic SEO landing pages: long-tail, comparison, alternative, use-case, and location intents.</summary>
    public static class PdfToolSeoLandingGenerator
    {
        public sealed record LandingConfig(
            string RoutePrefix,
            string ToolUrl,
            string ToolLinkText,
            string VerbPhrase,
            string[] Keywords);

        private static readonly LandingConfig[] Configs =
        [
            UnlockPdf(),
            FlattenPdf(),
            PdfToImages(),
            ExtractImages(),
            OcrPdf(),
            PageNumbers(),
            PdfMetadata(),
            MergePdf(),
            SplitPdf(),
            WordToPdf(),
            PdfToExcel(),
            SignPdf(),
            WatermarkPdf(),
        ];

        private static readonly Dictionary<string, LandingConfig> ByPrefix =
            Configs.ToDictionary(c => c.RoutePrefix, StringComparer.OrdinalIgnoreCase);

        public static IReadOnlyList<string> AllLandingPaths()
        {
            var paths = new List<string>(Configs.Sum(c => c.Keywords.Length));
            foreach (var cfg in Configs)
            {
                foreach (var kw in cfg.Keywords)
                    paths.Add($"/{cfg.RoutePrefix}/{GenerateSlug(kw)}");
            }
            return paths;
        }

        public static string? GetRoutePrefixForToolUrl(string toolUrl)
        {
            if (string.IsNullOrWhiteSpace(toolUrl)) return null;
            toolUrl = toolUrl.Trim().TrimEnd('/');
            foreach (var cfg in Configs)
            {
                if (string.Equals(cfg.ToolUrl.TrimEnd('/'), toolUrl, StringComparison.OrdinalIgnoreCase))
                    return cfg.RoutePrefix;
            }
            return null;
        }

        public static IReadOnlyList<(string Label, string Href)> GetSiblingClusterLinks(
            string routePrefix, string? slug, int max = 3)
        {
            if (!ByPrefix.TryGetValue(routePrefix, out var cfg))
                return Array.Empty<(string, string)>();

            return cfg.Keywords
                .Select(kw => (Label: CapitalizeKeyword(kw), Href: $"/{routePrefix}/{GenerateSlug(kw)}"))
                .Where(x => slug == null || !x.Href.EndsWith($"/{slug}", StringComparison.OrdinalIgnoreCase))
                .Take(max)
                .ToList();
        }

        private static string CapitalizeKeyword(string keyword) =>
            string.IsNullOrEmpty(keyword) ? keyword : char.ToUpper(keyword[0]) + keyword[1..];

        public static SEOPageModel? Populate(string routePrefix, string slug)
        {
            if (!ByPrefix.TryGetValue(routePrefix, out var cfg))
                return null;

            var keyword = cfg.Keywords.FirstOrDefault(k => GenerateSlug(k) == slug);
            return keyword == null ? null : GeneratePage(cfg, keyword);
        }

        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        private static SEOPageModel GeneratePage(LandingConfig cfg, string keyword)
        {
            var slug = GenerateSlug(keyword);
            var pageType = ProgrammaticSeoTemplates.DetectType(keyword);
            var category = ProgrammaticToolMetaCatalog.ResolveCategory(cfg.RoutePrefix, cfg.ToolUrl);
            var displayTitle = ProgrammaticSeoTemplates.BuildDisplayTitle(keyword, slug);
            var toolHref = PdfToolSeo.Canonical(cfg.ToolUrl);
            var toolLink = $"<a href=\"{toolHref}\">{cfg.ToolLinkText}</a>";
            var hubHref = PdfToolSeo.Canonical($"/{cfg.RoutePrefix}");

            return new SEOPageModel
            {
                Title = ProgrammaticSeoTemplates.BuildTitle(keyword, pageType, cfg.ToolLinkText, slug),
                DisplayTitle = displayTitle,
                Description = ProgrammaticSeoTemplates.BuildDescription(category, displayTitle, cfg.ToolLinkText),
                Slug = slug,
                RoutePrefix = cfg.RoutePrefix,
                ToolUrl = cfg.ToolUrl,
                ToolLinkText = cfg.ToolLinkText,
                Category = category,
                NoIndex = true,
                SchemaApplicationCategory = ProgrammaticToolMetaCatalog.SchemaApplicationCategory(category),
                FullContentHtml = ProgrammaticSeoTemplates.BuildContentHtml(
                    category, pageType, keyword, displayTitle, toolLink, toolHref, cfg.VerbPhrase, hubHref, cfg.ToolLinkText),
                FAQ = ProgrammaticSeoTemplates.BuildFaqs(category, pageType, displayTitle, cfg.ToolLinkText, cfg.ToolUrl, cfg.VerbPhrase),
            };
        }

        private static LandingConfig UnlockPdf() => new(
            "unlock-pdf", "/pdf/unlockpdf", "Unlock PDF tool", "unlock a password-protected PDF",
            [
                "unlock pdf online", "remove pdf password", "decrypt pdf online",
                "pdf password remover free", "unlock protected pdf", "remove pdf encryption",
                "pdf unlock without software", "open password protected pdf", "strip pdf password",
                "pdf decryption online free", "unlock pdf for printing", "remove owner password pdf",
                "unlock pdf file online free", "how to unlock pdf password", "pdf password unlock tool",
                "adobe unlock pdf alternative", "ilovepdf unlock pdf alternative",
            ]);

        private static LandingConfig FlattenPdf() => new(
            "flatten-pdf", "/pdf/flattenpdf", "Flatten PDF tool", "flatten a PDF form",
            [
                "flatten pdf online", "flatten pdf forms", "merge form fields pdf",
                "make pdf non editable", "flatten annotations pdf", "pdf flatten tool free",
                "flatten fillable pdf", "lock pdf form fields", "flatten pdf for submission",
                "flatten interactive pdf", "pdf form flatten online", "flatten signed pdf",
                "flatten pdf acrobat alternative", "flatten pdf before email", "how to flatten a pdf form",
            ]);

        private static LandingConfig PdfToImages() => new(
            "pdf-to-images", "/pdf/pdftoimages", "PDF to Images tool", "convert PDF pages to PNG images",
            [
                "pdf to png online", "convert pdf to images", "pdf to jpg converter free",
                "export pdf pages as images", "pdf to image converter online", "save pdf as png",
                "pdf page to image", "pdf to pictures online", "convert pdf to png zip",
                "pdf to image free no signup",                 "pdf to high resolution images", "pdf to png 300 dpi",
                "pdf to jpg converter free", "pdf to jpg online", "convert pdf to jpg",
                "extract pdf pages as images", "pdf to image batch", "pdf to png converter online free",
            ]);

        private static LandingConfig ExtractImages() => new(
            "extract-images-from-pdf", "/pdf/extractimages", "Extract Images from PDF tool", "extract images from a PDF",
            [
                "extract images from pdf", "get pictures from pdf", "pdf image extractor online",
                "save images from pdf", "pull photos out of pdf", "extract embedded images pdf",
                "pdf photo extractor free", "download images from pdf online", "extract all images pdf zip",
                "pdf to images embedded", "grab images from pdf file", "extract logos from pdf",
                "pdf image ripper online", "export images from pdf free", "how to extract pictures from pdf",
            ]);

        private static LandingConfig OcrPdf() => new(
            "ocr-pdf", "/pdf/ocrpdf", "OCR PDF tool", "OCR a scanned PDF",
            [
                "ocr pdf online", "make pdf searchable", "ocr scanned pdf free", "pdf ocr converter",
                "searchable pdf online", "ocr pdf to text layer", "tesseract pdf ocr online",
                "ocr image pdf", "scan pdf ocr free", "add text layer to pdf", "ocr pdf document online",
                "make scanned pdf searchable free", "pdf ocr no download", "ocr pdf english online",
                "convert scanned pdf searchable", "adobe ocr pdf alternative",
            ]);

        private static LandingConfig PageNumbers() => new(
            "add-page-numbers-to-pdf", "/pdf/pagenumbers", "Add Page Numbers tool", "add page numbers to a PDF",
            [
                "add page numbers to pdf", "number pdf pages online", "pdf page numbering tool",
                "insert page numbers pdf free", "pdf footer page numbers", "paginate pdf online",
                "add page number footer pdf", "number pages in pdf document", "pdf bates numbering alternative",
                "page numbers pdf online free", "stamp page numbers pdf", "add page count to pdf",
                "pdf pagination online", "how to number pdf pages", "add page numbers pdf without acrobat",
            ]);

        private static LandingConfig PdfMetadata() => new(
            "pdf-metadata", "/pdf/pdfmetadata", "PDF Metadata Viewer", "view PDF metadata",
            [
                "pdf metadata viewer", "read pdf properties online", "pdf document info extractor",
                "check pdf author and title", "pdf metadata extractor", "view pdf file information",
                "pdf properties viewer online", "extract pdf metadata json", "pdf info reader free",
                "see pdf creation date", "pdf document details online", "inspect pdf metadata",
                "pdf xmp viewer online", "pdf file info tool", "how to view pdf metadata",
            ]);

        private static LandingConfig MergePdf() => new(
            "merge-pdf", "/pdf/merge", "Merge PDF tool", "merge PDF files into one document",
            [
                "merge pdf online free", "combine pdf files online", "join pdf files",
                "merge multiple pdfs into one", "pdf combiner online", "merge pdf without watermark",
                "merge pdf vs ilovepdf", "merge pdf vs adobe acrobat", "ratpdf vs smallpdf merge",
                "adobe merge pdf alternative", "ilovepdf merge alternative free", "smallpdf merge alternative",
                "merge pdf for job application", "merge pdf for university application",
                "merge pdf for legal documents", "merge pdf for accounting",
                "merge pdf online india", "merge pdf online uk", "merge pdf online usa",
                "how to merge pdf files on mac", "merge pdf on iphone",
                "organize pdf online", "rearrange pdf pages", "combine pdf files free",
                "organize pdf pages online", "pdf combiner no watermark",
                "ilovepdf merge alternative", "smallpdf merge alternative", "pdf24 merge alternative",
            ]);

        private static LandingConfig SplitPdf() => new(
            "split-pdf", "/pdf/split", "Split PDF tool", "split a PDF into separate files",
            [
                "split pdf online free", "extract pages from pdf", "separate pdf pages online",
                "pdf splitter free", "split pdf by page range", "split large pdf into parts",
                "split pdf vs adobe", "split pdf ilovepdf alternative", "smallpdf split alternative",
                "split pdf for email attachments", "split pdf for printing", "split pdf for archiving",
                "split pdf online india", "split pdf online uk",
                "how to split pdf without acrobat", "split pdf on mac online",
            ]);

        private static LandingConfig WordToPdf() => new(
            "word-to-pdf", "/pdf/doctopdf", "Word to PDF converter", "convert Word to PDF",
            [
                "word to pdf converter free", "docx to pdf online", "convert word document to pdf",
                "word to pdf no signup", "doc to pdf online free", "word to pdf high quality",
                "word to pdf vs adobe", "word to pdf ilovepdf alternative", "smallpdf word to pdf alternative",
                "word to pdf for resume", "word to pdf for contract submission",
                "word to pdf online india", "word to pdf online uk",
                "how to convert word to pdf on mac", "batch word to pdf online",
            ]);

        private static LandingConfig PdfToExcel() => new(
            "pdf-to-excel", "/pdf/pdftoexcel", "PDF to Excel converter", "convert PDF tables to Excel",
            [
                "pdf to excel converter free", "convert pdf to xlsx online", "pdf table to excel",
                "pdf to spreadsheet online", "extract pdf data to excel", "pdf to excel no signup",
                "pdf to excel vs adobe", "pdf to excel ilovepdf alternative",
                "pdf to excel for invoices", "pdf to excel for financial statements",
                "pdf to excel online india", "pdf to excel online uk",
                "how to convert pdf to excel without software",
            ]);

        private static LandingConfig SignPdf() => new(
            "sign-pdf", "/pdf/signtext", "Sign PDF tool", "add a signature to a PDF",
            [
                "sign pdf online free", "add signature to pdf", "electronic sign pdf document",
                "type name on pdf online", "pdf signature tool free", "sign pdf without adobe",
                "sign pdf vs docusign", "adobe sign pdf alternative", "docusign alternative sign pdf free",
                "sign pdf for contract", "sign pdf for offer letter", "sign pdf for nda",
                "sign pdf online india", "sign pdf online uk",
                "how to sign pdf on iphone",
            ]);

        private static LandingConfig WatermarkPdf() => new(
            "watermark-pdf", "/pdf/watermark", "Watermark PDF tool", "add a watermark to a PDF",
            [
                "add watermark to pdf online", "pdf watermark tool free", "stamp draft on pdf",
                "text watermark pdf online", "confidential watermark pdf", "watermark pdf before sharing",
                "watermark pdf adobe alternative", "ilovepdf watermark alternative",
                "watermark pdf for legal review", "watermark pdf for client preview",
                "watermark pdf online india", "watermark pdf online uk",
                "how to watermark pdf without acrobat",
            ]);
    }
}
