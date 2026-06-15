using ratpdf.Constants;
using ratpdf.Helpers;
using ratpdf.Models;
using ratpdf.Models.ProgrammaticSeo;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    /// <summary>
    /// 3-layer PDF-to-text SEO engine: pillars (L1), intent templates (L2), controlled long-tail (L3).
    /// </summary>
    public static class PdfToTxtSeoEngine
    {
        public const string ToolPath = "/pdf/pdftotext";
        public const string RoutePrefix = "pdf-to-txt";

        private static readonly string[] HardBlockedFragments =
        [
            "pycryptodome", "failed-to-extract", "chatgpt-extract", "english-file-intermediate-pdf-vk",
            "convert-hyp-to", "convert-mht-to", "img-to-pdf", "hyp-to-pdf", "txt-zpl-to-pdf",
            "pdf-den-txt-ye", "pdf-yi-txt-ye", "pdf-zu-txt-konvertieren", "pdf-zhuan-txt",
            "rv-kbb", "kbb-value", "rv-values-kbb",
        ];

        public static bool IsHardBlocked(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return true;
            var lower = slug.ToLowerInvariant();
            return HardBlockedFragments.Any(f => lower.Contains(f, StringComparison.Ordinal));
        }

        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        public static Dictionary<string, string> LoadKeywordMap(string webRootPath)
        {
            var path = Path.Combine(webRootPath, "pdf-to-txt-keywords.txt");
            if (!File.Exists(path)) return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            return File.ReadAllLines(path)
                .Where(k => !string.IsNullOrWhiteSpace(k))
                .Select(k => k.Trim())
                .GroupBy(k => GenerateSlug(k), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);
        }

        public static SEOPageModel? BuildPage(string slug, string webRootPath)
        {
            if (IsHardBlocked(slug)) return null;

            var keywordMap = LoadKeywordMap(webRootPath);
            if (!keywordMap.ContainsKey(slug) && !PdfToTxtPillarCatalog.IsPillar(slug))
                return null;

            keywordMap.TryGetValue(slug, out var keywordPhrase);

            // Layer 1 — authority pillar
            var pillar = PdfToTxtPillarCatalog.Get(slug);
            if (pillar != null)
                return BuildFromPillar(slug, pillar);

            // Layer 2/3 — intent-classified programmatic
            var intent = IntentClassifier.Classify(PdfToolVertical.PdfToText, slug, keywordPhrase);
            var disposition = IntentClassifier.GetDisposition(intent);
            if (disposition == IndexDisposition.NotFound)
                return null;

            return BuildFromIntent(slug, keywordPhrase, intent, disposition);
        }

        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath)
        {
            var map = LoadKeywordMap(webRootPath);
            var paths = map.Keys
                .Where(slug => ProgrammaticSitemapFilter.IsEligible(PdfToolVertical.PdfToText, slug, map[slug], null)
                    || PdfToTxtPillarCatalog.IsPillar(slug))
                .Select(slug => $"/pdf-to-txt/{slug}")
                .ToList();

            foreach (var pillar in PdfToTxtPillarCatalog.AllSlugs)
            {
                var p = $"/pdf-to-txt/{pillar}";
                if (!paths.Contains(p, StringComparer.OrdinalIgnoreCase))
                    paths.Add(p);
            }

            return paths.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static SEOPageModel BuildFromPillar(string slug, PdfToTxtPillarCatalog.PillarPage pillar)
        {
            var intent = new IntentClassification(SearchIntent.Navigational, 1.0, PdfToolVertical.PdfToText, IsPillar: true);
            var hubPath = ProgrammaticInternalLinkGraph.GetHubPath(PdfToolVertical.PdfToText, intent.Intent);
            var related = pillar.RelatedSlugs
                .Select(s => (Label: SlugTitleHelper.FromSlug(s), Path: $"/pdf-to-txt/{s}"))
                .ToList();

            return new SEOPageModel
            {
                Title = $"{pillar.H1} | RatPDF",
                DisplayTitle = pillar.H1,
                Description = pillar.MetaDescription,
                Slug = slug,
                RoutePrefix = RoutePrefix,
                ToolUrl = ToolPath,
                ToolLinkText = "PDF to Text",
                HubPath = hubPath,
                CanonicalUrl = ProgrammaticMetadataService.BuildCanonical(RoutePrefix, slug),
                Category = ProgrammaticToolCategory.PdfTool,
                Intent = intent.Intent,
                IntentConfidence = intent.Confidence,
                IsPillar = true,
                NoIndex = false,
                SchemaApplicationCategory = "UtilitiesApplication",
                FullContentHtml = pillar.ContentHtml,
                FAQ = pillar.Faqs.ToList(),
                HowToSteps = pillar.HowToSteps.ToList(),
                RelatedPages = related,
                RelatedTools = ProgrammaticInternalLinkGraph.GetRelatedTools(intent.Intent).ToList(),
            };
        }

        private static SEOPageModel BuildFromIntent(
            string slug,
            string? keywordPhrase,
            IntentClassification intent,
            IndexDisposition disposition)
        {
            var displayTitle = PdfToTxtIntentContentBuilder.BuildDisplayTitle(slug, keywordPhrase, intent);
            var toolHref = PdfToolSeo.Canonical(ToolPath);
            var hubPath = ProgrammaticInternalLinkGraph.GetHubPath(PdfToolVertical.PdfToText, intent.Intent);
            var noIndex = disposition == IndexDisposition.NoIndex;

            return new SEOPageModel
            {
                Title = ProgrammaticMetadataService.BuildTitle(displayTitle, intent, isPillar: false),
                DisplayTitle = displayTitle,
                Description = ProgrammaticMetadataService.BuildDescription(displayTitle, intent),
                Slug = slug,
                RoutePrefix = RoutePrefix,
                ToolUrl = ToolPath,
                ToolLinkText = "PDF to Text",
                HubPath = hubPath,
                CanonicalUrl = ProgrammaticMetadataService.BuildCanonical(RoutePrefix, slug),
                Category = ProgrammaticToolCategory.PdfTool,
                Intent = intent.Intent,
                IntentConfidence = intent.Confidence,
                IsPillar = false,
                NoIndex = noIndex,
                SchemaApplicationCategory = "UtilitiesApplication",
                FullContentHtml = PdfToTxtIntentContentBuilder.BuildContent(intent, displayTitle, slug, toolHref),
                FAQ = PdfToTxtIntentContentBuilder.BuildFaqs(intent, displayTitle, toolHref, slug).ToList(),
                HowToSteps = BuildHowToSteps(intent),
                RelatedPages = ProgrammaticInternalLinkGraph.GetPdfToTxtRelatedPages(slug, intent).ToList(),
                RelatedTools = ProgrammaticInternalLinkGraph.GetRelatedTools(intent.Intent).ToList(),
            };
        }

        private static List<(string Name, string Text)> BuildHowToSteps(IntentClassification intent) =>
            intent.Intent switch
            {
                SearchIntent.ErrorRecovery => ErrorHowTo(),
                SearchIntent.TaskBased when intent.Confidence >= 0.6 => ErrorHowTo(),
                _ => StandardHowTo(),
            };

        private static List<(string Name, string Text)> StandardHowTo() =>
        [
            ("Open tool", "Go to PDF to Text on RatPDF."),
            ("Upload", "Select or drag your PDF file."),
            ("Extract", "Click extract and wait for processing."),
            ("Download", "Save the plain-text .txt file."),
        ];

        private static List<(string Name, string Text)> ErrorHowTo() =>
        [
            ("Diagnose", "Check if text is selectable in a PDF viewer."),
            ("OCR if needed", "Run OCR PDF for scanned documents."),
            ("Extract", "Upload to PDF to Text and download .txt."),
            ("Verify", "Spot-check numbers and names in the output."),
        ];
    }
}
