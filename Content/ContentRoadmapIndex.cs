using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace ratpdf.Content
{
    /// <summary>Runtime index of content-roadmap.csv for cluster linking and internal link metadata.</summary>
    internal static class ContentRoadmapIndex
    {
        private static readonly Lazy<Dictionary<string, RoadmapRow>> BySlug = new(Load);

        public static RoadmapRow? Get(string slug) =>
            BySlug.Value.TryGetValue(slug, out var row) ? row : null;

        public static IEnumerable<RoadmapRow> All => BySlug.Value.Values;

        public static string? GetCluster(string slug) => Get(slug)?.Cluster;

        public static IReadOnlyList<string> GetInternalLinks(string slug) =>
            Get(slug)?.InternalGuideLinks ?? Array.Empty<string>();

        public static IEnumerable<string> GetClusterSlugs(string cluster, string? excludeSlug = null)
        {
            if (string.IsNullOrWhiteSpace(cluster)) yield break;
            foreach (var (slug, row) in BySlug.Value)
            {
                if (!string.Equals(row.Cluster, cluster, StringComparison.OrdinalIgnoreCase)) continue;
                if (excludeSlug != null && slug.Equals(excludeSlug, StringComparison.OrdinalIgnoreCase)) continue;
                yield return slug;
            }
        }

        private static Dictionary<string, RoadmapRow> Load()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "content-roadmap.csv");
            if (!File.Exists(path))
                path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "content-roadmap.csv"));

            var map = new Dictionary<string, RoadmapRow>(StringComparer.OrdinalIgnoreCase);
            if (!File.Exists(path)) return map;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.Trim().Trim('\uFEFF', '"'),
            };
            using var reader = new StreamReader(path, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), detectEncodingFromByteOrderMarks: true);
            using var csv = new CsvReader(reader, config);
            foreach (var row in csv.GetRecords<RoadmapCsvRow>())
            {
                if (string.IsNullOrWhiteSpace(row.RecommendedURL) || !row.RecommendedURL.StartsWith("/guides/", StringComparison.OrdinalIgnoreCase))
                    continue;
                var slug = row.RecommendedURL["/guides/".Length..].Trim('/');
                if (string.IsNullOrEmpty(slug) || slug.StartsWith("ratpdf-vs-", StringComparison.OrdinalIgnoreCase))
                    continue;
                if (string.Equals(row.Status, "Merged", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(row.Status, "Deferred", StringComparison.OrdinalIgnoreCase))
                    continue;

                var links = ParseInternalLinks(row.InternalLinks);
                map[slug] = new RoadmapRow(
                    slug,
                    row.Cluster?.Trim() ?? "",
                    row.PrimaryKeyword?.Trim() ?? "",
                    row.Priority?.Trim() ?? "",
                    row.TrafficPotential?.Trim() ?? "",
                    string.IsNullOrWhiteSpace(row.ToolURL) ? null : row.ToolURL.Trim(),
                    links);
            }
            return map;
        }

        private static IReadOnlyList<string> ParseInternalLinks(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return Array.Empty<string>();
            return raw.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(l => l.StartsWith("/guides/", StringComparison.OrdinalIgnoreCase))
                .Select(l => l["/guides/".Length..].Trim('/'))
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private sealed class RoadmapCsvRow
        {
            public string Cluster { get; set; } = "";
            public string PrimaryKeyword { get; set; } = "";
            public string RecommendedURL { get; set; } = "";
            public string InternalLinks { get; set; } = "";
            public string Priority { get; set; } = "";
            public string TrafficPotential { get; set; } = "";
            public string ToolURL { get; set; } = "";
            public string Status { get; set; } = "";
        }
    }

    internal sealed record RoadmapRow(
        string Slug,
        string Cluster,
        string PrimaryKeyword,
        string Priority,
        string TrafficPotential,
        string? ToolUrl,
        IReadOnlyList<string> InternalGuideLinks);
}
