using ratpdf.Constants;
using ratpdf.Helpers;
using ratpdf.Models;
using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    public sealed record ProgrammaticVerticalConfig(
        PdfToolVertical Vertical,
        string RoutePrefix,
        string ToolPath,
        string ToolLinkText,
        string HubPath,
        string KeywordsFile,
        string[] HardBlockedFragments,
        IProgrammaticPillarCatalog Pillars,
        Func<SearchIntent, IReadOnlyList<(string Label, string Path)>> RelatedPages);

    public static class GenericProgrammaticSeoEngine
    {
        public static bool IsHardBlocked(string slug, string[] fragments)
        {
            if (string.IsNullOrWhiteSpace(slug)) return true;
            var lower = slug.ToLowerInvariant();
            return fragments.Any(f => lower.Contains(f, StringComparison.Ordinal));
        }

        public static SEOPageModel? BuildPage(ProgrammaticVerticalConfig cfg, string slug, string webRootPath)
        {
            if (IsHardBlocked(slug, cfg.HardBlockedFragments)) return null;

            var keywordMap = ProgrammaticSlugHelper.LoadKeywordMap(webRootPath, cfg.KeywordsFile);
            if (!keywordMap.ContainsKey(slug) && !cfg.Pillars.IsPillar(slug)) return null;

            keywordMap.TryGetValue(slug, out var keywordPhrase);

            var pillar = cfg.Pillars.Get(slug);
            if (pillar != null) return BuildFromPillar(cfg, slug, pillar);

            var intent = IntentClassifier.Classify(cfg.Vertical, slug, keywordPhrase);
            var disposition = IntentClassifier.GetDisposition(intent);
            if (disposition == IndexDisposition.NotFound) return null;

            return BuildFromIntent(cfg, slug, keywordPhrase, intent, disposition);
        }

        public static IReadOnlyList<string> AllSitemapPaths(ProgrammaticVerticalConfig cfg, string webRootPath, Func<string, string?, bool> isEligible)
        {
            var map = ProgrammaticSlugHelper.LoadKeywordMap(webRootPath, cfg.KeywordsFile);
            var paths = map.Keys
                .Where(slug => isEligible(slug, map.GetValueOrDefault(slug)))
                .Select(slug => $"/{cfg.RoutePrefix.Trim('/')}/{slug}")
                .ToList();

            foreach (var pillar in cfg.Pillars.AllSlugs)
            {
                var p = $"/{cfg.RoutePrefix.Trim('/')}/{pillar}";
                if (!paths.Contains(p, StringComparer.OrdinalIgnoreCase)) paths.Add(p);
            }

            return paths.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static SEOPageModel BuildFromPillar(ProgrammaticVerticalConfig cfg, string slug, ProgrammaticPillarPage pillar)
        {
            var intent = new IntentClassification(SearchIntent.Navigational, 1.0, cfg.Vertical, IsPillar: true);
            var related = pillar.RelatedSlugs
                .Select(s => (Label: SlugTitleHelper.FromSlug(s), Path: $"/{cfg.RoutePrefix.Trim('/')}/{s}"))
                .ToList();

            return BaseModel(cfg, slug, pillar.H1, pillar.H1, pillar.MetaDescription, intent, false,
                pillar.ContentHtml, pillar.Faqs.ToList(), pillar.HowToSteps.ToList(), related, isPillar: true);
        }

        private static SEOPageModel BuildFromIntent(
            ProgrammaticVerticalConfig cfg,
            string slug,
            string? keywordPhrase,
            IntentClassification intent,
            IndexDisposition disposition)
        {
            var displayTitle = VerticalIntentContentBuilder.BuildDisplayTitle(cfg.Vertical, slug, keywordPhrase, intent);
            var toolHref = PdfToolSeo.Canonical(cfg.ToolPath);
            var noIndex = disposition == IndexDisposition.NoIndex;

            return BaseModel(
                cfg, slug, displayTitle,
                ProgrammaticMetadataService.BuildTitle(displayTitle, intent, false),
                ProgrammaticMetadataService.BuildDescription(displayTitle, intent),
                intent, noIndex,
                VerticalIntentContentBuilder.BuildContent(cfg.Vertical, intent, displayTitle, slug, toolHref),
                VerticalIntentContentBuilder.BuildFaqs(cfg.Vertical, intent, toolHref, slug).ToList(),
                StandardHowTo(cfg.Vertical),
                cfg.RelatedPages(intent.Intent).Where(p => !p.Path.EndsWith(slug, StringComparison.OrdinalIgnoreCase)).Take(4).ToList(),
                isPillar: false);
        }

        private static SEOPageModel BaseModel(
            ProgrammaticVerticalConfig cfg,
            string slug,
            string displayTitle,
            string title,
            string description,
            IntentClassification intent,
            bool noIndex,
            string contentHtml,
            List<(string Question, string Answer)> faqs,
            List<(string Name, string Text)> howTo,
            List<(string Label, string Path)> related,
            bool isPillar)
        {
            return new SEOPageModel
            {
                Title = isPillar ? $"{displayTitle} | RatPDF" : title,
                DisplayTitle = displayTitle,
                Description = description,
                Slug = slug,
                RoutePrefix = cfg.RoutePrefix,
                ToolUrl = cfg.ToolPath,
                ToolLinkText = cfg.ToolLinkText,
                HubPath = cfg.HubPath,
                CanonicalUrl = ProgrammaticMetadataService.BuildCanonical(cfg.RoutePrefix, slug),
                Category = ProgrammaticToolCategory.PdfTool,
                Intent = intent.Intent,
                IntentConfidence = intent.Confidence,
                IsPillar = isPillar,
                NoIndex = noIndex,
                SchemaApplicationCategory = "UtilitiesApplication",
                FullContentHtml = contentHtml,
                FAQ = faqs,
                HowToSteps = howTo,
                RelatedPages = related,
                RelatedTools = DefaultRelatedTools(cfg.Vertical),
            };
        }

        private static List<(string Name, string Text)> StandardHowTo(PdfToolVertical vertical) => vertical switch
        {
            PdfToolVertical.PdfToWord =>
            [
                ("Open tool", "Go to PDF to Word on RatPDF."),
                ("Upload", "Select your PDF file."),
                ("Convert", "Click convert and wait for processing."),
                ("Download", "Save the DOCX file."),
            ],
            PdfToolVertical.EditPdf =>
            [
                ("Open editor", "Go to Edit PDF on RatPDF."),
                ("Upload", "Select the PDF to modify."),
                ("Edit", "Add text, signatures, or annotations."),
                ("Download", "Save the updated PDF."),
            ],
            _ =>
            [
                ("Open tool", "Go to the RatPDF tool page."),
                ("Upload", "Select your PDF."),
                ("Process", "Run the tool action."),
                ("Download", "Save the result."),
            ],
        };

        private static List<(string Name, string Url)> DefaultRelatedTools(PdfToolVertical vertical) => vertical switch
        {
            PdfToolVertical.PdfToWord =>
            [
                ("PDF to Word", "/pdf/pdftodoc"),
                ("PDF to Text", "/pdf/pdftotext"),
                ("OCR PDF", "/pdf/ocrpdf"),
                ("Compress PDF", "/pdf/compress"),
            ],
            PdfToolVertical.EditPdf =>
            [
                ("Edit PDF", "/pdf/editpdf"),
                ("Sign PDF", "/pdf/signtext"),
                ("Watermark PDF", "/pdf/watermark"),
                ("Compress PDF", "/pdf/compress"),
            ],
            _ => ProgrammaticInternalLinkGraph.GetRelatedTools(SearchIntent.Navigational).ToList(),
        };
    }
}
