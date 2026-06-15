using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    public static class ProgrammaticSitemapFilter
    {
        public static bool IsPdfToTxtEligible(string slug, string? keywordPhrase = null) =>
            PdfToTxtPillarCatalog.IsPillar(slug)
            || IsEligible(PdfToolVertical.PdfToText, slug, keywordPhrase, null);

        public static bool IsEligible(
            PdfToolVertical vertical,
            string slug,
            string? keywordPhrase,
            IProgrammaticPillarCatalog? pillars)
        {
            if (pillars?.IsPillar(slug) == true) return true;

            var intent = IntentClassifier.Classify(vertical, slug, keywordPhrase);
            return IntentClassifier.IsSitemapEligible(intent);
        }

        public static IReadOnlyList<string> FilterPaths(
            PdfToolVertical vertical,
            IEnumerable<string> paths,
            string webRootPath,
            string keywordsFile,
            IProgrammaticPillarCatalog? pillars = null)
        {
            var map = ProgrammaticSlugHelper.LoadKeywordMap(webRootPath, keywordsFile);
            return paths
                .Where(p =>
                {
                    var slug = p.Trim('/').Split('/').LastOrDefault() ?? "";
                    map.TryGetValue(slug, out var kw);
                    return IsEligible(vertical, slug, kw, pillars);
                })
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
    }
}
