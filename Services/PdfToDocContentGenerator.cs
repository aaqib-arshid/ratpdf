using ratpdf.Models;

namespace ratpdf.Services
{
    public static class PdfToWordContentGenerator
    {
        public static string GenerateSlug(string keyword) => PdfToWordSeoEngine.GenerateSlug(keyword);
        public static bool IsBlockedSlug(string slug) => PdfToWordSeoEngine.IsHardBlocked(slug);
        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath) =>
            PdfToWordSeoEngine.BuildPage(slug, webRootPath);
        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath) =>
            PdfToWordSeoEngine.AllSitemapPaths(webRootPath);
    }
}
