namespace ratpdf.Constants
{
    /// <summary>Child sitemaps referenced by /sitemap.xml index.</summary>
    public static class SitemapCatalog
    {
        /// <summary>Dynamically generated urlsets (served by SeoController).</summary>
        public static readonly string[] DynamicChildren =
        [
            "/sitemaps/site.xml",
            "/sitemaps/pdf-tool-landings.xml",
        ];

        /// <summary>Legacy static urlsets in wwwroot/sitemaps/.</summary>
        public static readonly string[] StaticChildren =
        [
            "/sitemaps/sitemaptools.xml",
            "/sitemaps/sitemap_compress_pdf.xml",
            "/sitemaps/sitemap-pdf-to-word.xml",
            "/sitemaps/sitemap_pdf_to_txt.xml",
            "/sitemaps/sitemap-editpdf.xml",
            "/sitemaps/sitemap_bgremove.xml",
            "/sitemaps/sitemap_wordcounterseo.xml",
            "/sitemaps/sitemap_ring_converter.xml",
            "/sitemaps/sitemap_my_ip.xml",
            "/sitemaps/sitemap_content_decay_detector.xml",
            "/sitemaps/sitemap-invoice.xml",
            "/sitemaps/html_sitemap.xml",
            "/sitemaps/json_sitemap.xml",
            "/sitemaps/jwt_sitemap.xml",
            "/sitemaps/payslip_sitemap.xml",
        ];

        public static IEnumerable<string> AllChildPaths() =>
            DynamicChildren.Concat(StaticChildren);
    }
}
