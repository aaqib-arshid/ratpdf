using ratpdf.Models;
using ratpdf.Models.ProgrammaticSeo;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    public static class EditPdfSeoEngine
    {
        private static readonly string[] Blocked =
        [
            "rv-kbb", "apk-mod", "amazon-fire", "torrent", "cracked",
        ];

        private static readonly ProgrammaticVerticalConfig Config = new(
            PdfToolVertical.EditPdf,
            "edit-pdf",
            "/pdf/editpdf",
            "Edit PDF",
            "/guides/edit-pdf",
            "edit_pdf_urls_100k.txt",
            Blocked,
            EditPdfPillarCatalog.Catalog,
            RelatedPages);

        public static string GenerateSlug(string keyword) => ProgrammaticSlugHelper.GenerateSlug(keyword);

        public static bool IsHardBlocked(string slug) =>
            GenericProgrammaticSeoEngine.IsHardBlocked(slug, Blocked);

        public static SEOPageModel? BuildPage(string slug, string webRootPath) =>
            GenericProgrammaticSeoEngine.BuildPage(Config, slug, webRootPath);

        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath) =>
            GenericProgrammaticSeoEngine.AllSitemapPaths(Config, webRootPath,
                (slug, phrase) => ProgrammaticSitemapFilter.IsEligible(PdfToolVertical.EditPdf, slug, phrase, EditPdfPillarCatalog.Catalog));

        private static IReadOnlyList<(string Label, string Path)> RelatedPages(SearchIntent intent) =>
        [
            ("Edit PDF online", "/edit-pdf/edit-pdf-online"),
            ("Edit PDF free", "/edit-pdf/edit-pdf-free"),
            ("Add text to PDF", "/edit-pdf/edit-pdf-add-text"),
            ("Add signature to PDF", "/edit-pdf/edit-pdf-add-signature"),
        ];
    }
}
