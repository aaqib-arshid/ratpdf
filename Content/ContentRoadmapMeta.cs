using System.Globalization;

namespace ratpdf.Content
{
    /// <summary>Loads editorial meta from content-roadmap.csv for guides not defined in static BuildGuides tuples.</summary>
    internal static class ContentRoadmapMeta
    {
        public static IEnumerable<RoadmapGuideMeta> GetMissingFrom(HashSet<string> existingSlugs)
        {
            foreach (var row in ContentRoadmapIndex.All)
            {
                if (existingSlugs.Contains(row.Slug)) continue;
                var title = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(
                    row.PrimaryKeyword.Length > 0 ? row.PrimaryKeyword : row.Slug.Replace('-', ' '));
                yield return new RoadmapGuideMeta(
                    row.Slug,
                    title,
                    $"Practical guide: {row.PrimaryKeyword}. Step-by-step workflow with RatPDF tools, limits, and related resources.",
                    MapCategory(row.Cluster),
                    row.ToolUrl,
                    row.Cluster);
            }
        }

        private static string MapCategory(string? cluster)
        {
            var c = cluster?.ToLowerInvariant() ?? "";
            if (c.Contains("invoice") || c.Contains("business")) return "Business";
            if (c.Contains("developer")) return "Developer";
            return "PDF";
        }
    }

    internal sealed record RoadmapGuideMeta(string Slug, string Title, string Desc, string Cat, string? Tool, string? Cluster);
}
