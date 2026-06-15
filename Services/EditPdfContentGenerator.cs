using ratpdf.Models;

namespace ratpdf.Services
{
    public static class EditPdfContentGenerator
    {
        public static string GenerateSlug(string keyword) => EditPdfSeoEngine.GenerateSlug(keyword);
        public static bool IsBlockedSlug(string slug) => EditPdfSeoEngine.IsHardBlocked(slug);
        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath) =>
            EditPdfSeoEngine.BuildPage(slug, webRootPath);
        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath) =>
            EditPdfSeoEngine.AllSitemapPaths(webRootPath);
    }
}
