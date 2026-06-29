namespace ratpdf.Constants
{
    /// <summary>Child sitemaps referenced by /sitemap.xml index (~7,906 URLs total).</summary>
    public static class SitemapCatalog
    {
        /// <summary>Nine clean child sitemaps (no compress keyword chunks or legacy verticals).</summary>
        public static readonly string[] MainIndexChildren =
        [
            "/sitemaps/sitemap-core.xml",
            "/sitemaps/sitemap-tools.xml",
            "/sitemaps/sitemap-blog.xml",
            "/sitemaps/sitemap-programmatic.xml",
            "/sitemaps/sitemap-guides-en.xml",
            "/sitemaps/sitemap-guides-pt.xml",
            "/sitemaps/sitemap-guides-es.xml",
            "/sitemaps/sitemap-guides-de.xml",
            "/sitemaps/sitemap-guides-id.xml",
            "/sitemaps/sitemap-guides-fr.xml",
        ];

        public static List<string> BuildMainIndexChildren() =>
            MainIndexChildren.ToList();

        /// <summary>Legacy paths kept as 301 redirects in SeoController.</summary>
        public static readonly string[] LegacyRedirectPaths =
        [
            "/sitemaps/site.xml",
            "/sitemaps/guides.xml",
            "/sitemaps/sitemap-guides.xml",
            "/sitemaps/blog.xml",
            "/sitemaps/sitemaptools.xml",
            "/sitemaps/sitemap-compare.xml",
            "/sitemaps/sitemap-guides-localized.xml",
            "/sitemaps/guides-localized.xml",
            "/sitemaps/pdf-tool-landings.xml",
            "/sitemaps/category-tool-landings.xml",
            "/sitemaps/sitemap_pdf_to_txt.xml",
            "/sitemaps/sitemap-compress-seo.xml",
            "/sitemaps/compress-pdf-programmatic.xml",
        ];
    }
}
