using ratpdf.Models;
using ratpdf.Models.ProgrammaticSeo;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    public static class PdfToWordSeoEngine
    {
        private static readonly string[] Blocked =
        [
            "rv-kbb", "kbb-value", "motorhome", "apk-mod", "torrent",
        ];

        private static readonly ProgrammaticVerticalConfig Config = new(
            PdfToolVertical.PdfToWord,
            "pdf-to-word",
            "/pdf/pdftodoc",
            "PDF to Word",
            "/guides/pdf-to-word",
            "pdftodocx_urls.txt",
            Blocked,
            PdfToWordPillarCatalog.Catalog,
            RelatedPages);

        public static string GenerateSlug(string keyword) => ProgrammaticSlugHelper.GenerateSlug(keyword);

        public static bool IsHardBlocked(string slug) =>
            GenericProgrammaticSeoEngine.IsHardBlocked(slug, Blocked);

        public static SEOPageModel? BuildPage(string slug, string webRootPath) =>
            GenericProgrammaticSeoEngine.BuildPage(Config, slug, webRootPath);

        public static IReadOnlyList<string> AllSitemapPaths(string webRootPath) =>
            GenericProgrammaticSeoEngine.AllSitemapPaths(Config, webRootPath,
                (slug, phrase) => ProgrammaticSitemapFilter.IsEligible(PdfToolVertical.PdfToWord, slug, phrase, PdfToWordPillarCatalog.Catalog));

        private static IReadOnlyList<(string Label, string Path)> RelatedPages(SearchIntent intent) =>
        [
            ("Convert PDF to Word", "/pdf-to-word/pdf-to-word"),
            ("How to convert PDF to Word", "/pdf-to-word/how-to-convert-pdf-to-word"),
            ("PDF to Word guide", "/pdf-to-word/convert-pdf-to-word"),
            ("PDF to Word on iPhone", "/pdf-to-word/pdf-to-word-iphone"),
            ("PDF to Text", "/pdf-to-txt/pdf-to-text-online"),
        ];
    }
}
