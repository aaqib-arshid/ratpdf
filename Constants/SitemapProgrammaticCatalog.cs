using ratpdf.Services;

namespace ratpdf.Constants
{
    /// <summary>Fifty curated programmatic SEO pages (compress hub + link assets).</summary>
    public static class SitemapProgrammaticCatalog
    {
        private static readonly string[] SupplementalPaths =
        [
            "/compress-pdf",
            "/pdf-size-checker",
            "/pdf-tools-for-lawyers",
            "/pdf-tools-for-students",
            "/freelance-rate-calculator",
        ];

        public static IReadOnlyList<string> Paths()
        {
            var paths = PdfCompressProgrammaticSeoGenerator.CuratedLandingPaths()
                .Concat(SupplementalPaths)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (paths.Count != 50)
                throw new InvalidOperationException(
                    $"SitemapProgrammaticCatalog expected 50 URLs, found {paths.Count}.");

            return paths;
        }
    }
}
