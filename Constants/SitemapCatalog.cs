namespace ratpdf.Constants
{
    /// <summary>Child sitemaps referenced by /sitemap.xml index.</summary>
    public static class SitemapCatalog
    {
        /// <summary>Dynamically generated urlsets (SeoController).</summary>
        public static readonly string[] DynamicChildren =
        [
            "/sitemaps/sitemap-core.xml",
            "/sitemaps/sitemap-guides.xml",
            "/sitemaps/sitemap-blog.xml",
            "/sitemaps/sitemap-compare.xml",
        ];

        /// <summary>Static urlsets in wwwroot/sitemaps/.</summary>
        public static readonly string[] StaticChildren =
        [
            "/sitemaps/sitemaptools.xml",
            "/sitemaps/sitemap-pdf-to-word.xml",
            "/sitemaps/sitemap-pdftotxt-seo.xml",
            "/sitemaps/sitemap-editpdf.xml",
            "/sitemaps/sitemap_bgremove.xml",
            "/sitemaps/sitemap-invoice.xml",
            "/sitemaps/html_sitemap.xml",
            "/sitemaps/json_sitemap.xml",
            "/sitemaps/jwt_sitemap.xml",
        ];

        /// <summary>Compress programmatic chunks (urlsets, up to 10k URLs each).</summary>
        public static IEnumerable<string> CompressChunkPaths(IReadOnlyList<string> chunks) => chunks;

        public static List<string> BuildMainIndexChildren(IReadOnlyList<string> compressSitemapChunks) =>
            DynamicChildren
                .Concat(StaticChildren)
                .Concat(compressSitemapChunks.Select((p, i) => i == 0 && compressSitemapChunks.Count == 1
                    ? "/sitemaps/sitemap-compress-seo.xml"
                    : p))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

        /// <summary>Legacy paths kept as 301 redirects in SeoController.</summary>
        public static readonly string[] LegacyRedirectPaths =
        [
            "/sitemaps/site.xml",
            "/sitemaps/guides.xml",
            "/sitemaps/blog.xml",
            "/sitemaps/pdf-tool-landings.xml",
            "/sitemaps/category-tool-landings.xml",
            "/sitemaps/sitemap_pdf_to_txt.xml",
        ];
    }
}
