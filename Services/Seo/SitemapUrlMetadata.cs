using System.Globalization;

namespace ratpdf.Services.Seo
{
    /// <summary>Sitemap changefreq/priority rules (protocol: priority 0.0–1.0).</summary>
    public static class SitemapUrlMetadata
    {
        public static string GetChangeFreq(string path) => path switch
        {
            "/" => "daily",
            "/pdf/compress" or "/compress-pdf" => "weekly",
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "weekly",
            var p when IsCompressLanding(p) => "monthly",
            _ => "weekly",
        };

        public static string GetPriority(string path) =>
            FormatPriority(GetRawPriority(path));

        private static double GetRawPriority(string path) => path switch
        {
            "/" => 1.0,
            "/pdf/compress" => 1.0,
            "/compress-pdf" => 0.98,
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => 0.9,
            var p when IsCompressLanding(p) => 0.75,
            _ => 0.7,
        };

        /// <summary>Clamp and format for sitemaps.org (Google rejects values &gt; 1.0).</summary>
        public static string FormatPriority(double value) =>
            Math.Clamp(value, 0.0, 1.0).ToString("0.0#", CultureInfo.InvariantCulture);

        public static bool IsCompressLanding(string path) =>
            path.StartsWith("/compress-pdf", StringComparison.OrdinalIgnoreCase)
            || path.StartsWith("/pdf-under-", StringComparison.OrdinalIgnoreCase)
            || path.EndsWith("-pdf-compressor-alternative", StringComparison.OrdinalIgnoreCase)
            || path.StartsWith("/lossless-pdf", StringComparison.OrdinalIgnoreCase)
            || path is "/pdf-optimization-guide" or "/optimize-pdf-for-web";
    }
}
