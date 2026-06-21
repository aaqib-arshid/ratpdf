namespace ratpdf.Services.Seo
{
    /// <summary>Excludes noindex programmatic thin pages from sitemaps.</summary>
    public static class SitemapExclusion
    {
        /// <summary>Route prefixes for pages that emit noindex (Tasks 2–10 thin landings).</summary>
        private static readonly string[] NoIndexPrefixes =
        [
            "/medical-tools/",
            "/calculator-tools/",
            "/unlock-pdf/",
            "/flatten-pdf/",
            "/pdf-to-images/",
            "/extract-images-from-pdf/",
            "/ocr-pdf/",
            "/add-page-numbers-to-pdf/",
            "/pdf-metadata/",
            "/merge-pdf/",
            "/split-pdf/",
            "/word-to-pdf/",
            "/pdf-to-excel/",
            "/sign-pdf/",
            "/watermark-pdf/",
            "/salary-slip/",
            "/ring-size/",
            "/my-ip/",
            "/content-decay-detector/",
        ];

        public static bool IsExcluded(string? path)
        {
            if (string.IsNullOrWhiteSpace(path)) return true;
            path = path.Trim();
            if (path.Length > 1 && path.EndsWith('/'))
                path = path.TrimEnd('/');

            foreach (var prefix in NoIndexPrefixes)
            {
                if (path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        public static IReadOnlyList<string> Filter(IEnumerable<string> paths) =>
            paths.Where(p => !IsExcluded(p)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
    }
}
