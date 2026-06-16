using ratpdf.Models;

namespace ratpdf.Content
{
    /// <summary>Cluster- and roadmap-aware related guide resolution for article sidebars.</summary>
    internal static class ContentRelatedGuides
    {
        public static IReadOnlyList<ContentEntry> Resolve(ContentEntry current, int max = 6)
        {
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { current.Slug };
            var results = new List<ContentEntry>();

            void TryAdd(ContentEntry? entry)
            {
                if (entry == null || !seen.Add(entry.Slug)) return;
                results.Add(entry);
            }

            foreach (var linkSlug in ContentRoadmapIndex.GetInternalLinks(current.Slug))
            {
                if (results.Count >= max) break;
                TryAdd(ContentLibrary.GetGuide(linkSlug));
            }

            var cluster = current.Cluster ?? ContentRoadmapIndex.GetCluster(current.Slug);
            if (!string.IsNullOrWhiteSpace(cluster))
            {
                foreach (var peer in ContentRoadmapIndex.GetClusterSlugs(cluster, current.Slug)
                             .OrderBy(s => s, StringComparer.OrdinalIgnoreCase))
                {
                    if (results.Count >= max) break;
                    TryAdd(ContentLibrary.GetGuide(peer));
                }
            }

            if (results.Count < max)
            {
                foreach (var g in ContentLibrary.Guides
                             .Where(x => x.Category == current.Category && x.Slug != current.Slug)
                             .OrderBy(x => x.Title, StringComparer.OrdinalIgnoreCase))
                {
                    if (results.Count >= max) break;
                    TryAdd(g);
                }
            }

            return results;
        }
    }
}
