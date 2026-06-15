using ratpdf.Models;

namespace ratpdf.Services
{
    /// <summary>Backward-compatible entry point — delegates to <see cref="PdfToTxtSeoEngine"/>.</summary>
    public static class PdfToTxtContentGenerator
    {
        public static string GenerateSlug(string keyword) => PdfToTxtSeoEngine.GenerateSlug(keyword);

        public static bool IsBlockedSlug(string slug) => PdfToTxtSeoEngine.IsHardBlocked(slug);

        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath) =>
            PdfToTxtSeoEngine.BuildPage(slug, webRootPath);

        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath) =>
            PdfToTxtSeoEngine.AllSitemapPaths(webRootPath);
    }
}
