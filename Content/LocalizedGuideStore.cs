using System.Text.Json;
using System.Text.Json.Serialization;
using ratpdf.Constants;
using ratpdf.Models;

namespace ratpdf.Content
{
    /// <summary>Loads localized guide JSON from Content/LocalizedGuides/{urlPrefix}/{slug}.json.</summary>
    public static class LocalizedGuideStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        };

        private static readonly Lazy<Dictionary<string, Dictionary<string, LocalizedGuideEntry>>> Index = new(LoadIndex);

        public static IReadOnlyCollection<GuideLocale> SupportedLocales => GuideLocales.All;

        public static LocalizedGuideEntry? Get(string urlPrefix, string slug)
        {
            if (string.IsNullOrWhiteSpace(urlPrefix) || string.IsNullOrWhiteSpace(slug))
                return null;

            var prefix = urlPrefix.Trim().ToLowerInvariant();
            var key = slug.Trim().ToLowerInvariant();
            return Index.Value.TryGetValue(prefix, out var bySlug) && bySlug.TryGetValue(key, out var entry)
                ? entry
                : null;
        }

        public static bool Exists(string urlPrefix, string slug) => Get(urlPrefix, slug) != null;

        public static IEnumerable<LocalizedGuideEntry> AllForLocale(string urlPrefix)
        {
            var prefix = urlPrefix.Trim().ToLowerInvariant();
            if (!Index.Value.TryGetValue(prefix, out var bySlug))
                yield break;

            foreach (var entry in bySlug.Values.OrderByDescending(e => e.SearchScore).ThenBy(e => e.Slug, StringComparer.OrdinalIgnoreCase))
                yield return entry;
        }

        public static IEnumerable<LocalizedGuideEntry> AllLocalized()
        {
            foreach (var bySlug in Index.Value.Values)
            foreach (var entry in bySlug.Values)
                yield return entry;
        }

        public static IEnumerable<string> LocalizedSlugs(string urlPrefix) =>
            AllForLocale(urlPrefix).Select(g => g.Slug);

        public static IReadOnlyList<HreflangAlternate> GetHreflangAlternates(string slug)
        {
            var normalized = slug.Trim().ToLowerInvariant();
            var alternates = new List<HreflangAlternate>
            {
                new(GuideLocales.EnglishHreflang, GuideLocales.EnglishGuidePath(normalized)),
                new(GuideLocales.DefaultHreflang, GuideLocales.EnglishGuidePath(normalized)),
            };

            foreach (var locale in GuideLocales.All)
            {
                if (Exists(locale.UrlPrefix, normalized))
                {
                    alternates.Add(new HreflangAlternate(
                        locale.Hreflang,
                        GuideLocales.LocalizedGuidePath(locale.UrlPrefix, normalized)));
                }
            }

            return alternates;
        }

        public static IReadOnlyList<(string Slug, int SearchScore)> SlugsBySearchPriority()
        {
            var scores = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var entry in AllLocalized())
            {
                if (!scores.TryGetValue(entry.SourceSlug, out var current) || entry.SearchScore > current)
                    scores[entry.SourceSlug] = entry.SearchScore;
            }

            return scores
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                .Select(kv => (kv.Key, kv.Value))
                .ToList();
        }

        private static string ResolveRoot()
        {
            var candidates = new[]
            {
                Path.Combine(AppContext.BaseDirectory, "Content", "LocalizedGuides"),
                Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Content", "LocalizedGuides")),
                Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Content", "LocalizedGuides")),
            };

            foreach (var path in candidates)
            {
                if (Directory.Exists(path))
                    return path;
            }

            var fallback = candidates[^1];
            Directory.CreateDirectory(fallback);
            return fallback;
        }

        private static Dictionary<string, Dictionary<string, LocalizedGuideEntry>> LoadIndex()
        {
            var root = ResolveRoot();
            var index = new Dictionary<string, Dictionary<string, LocalizedGuideEntry>>(StringComparer.OrdinalIgnoreCase);

            foreach (var locale in GuideLocales.All)
            {
                var localeDir = Path.Combine(root, locale.UrlPrefix);
                if (!Directory.Exists(localeDir))
                    continue;

                var bySlug = new Dictionary<string, LocalizedGuideEntry>(StringComparer.OrdinalIgnoreCase);
                foreach (var file in Directory.EnumerateFiles(localeDir, "*.json", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        var json = File.ReadAllText(file);
                        var entry = JsonSerializer.Deserialize<LocalizedGuideEntry>(json, JsonOptions);
                        if (entry == null || string.IsNullOrWhiteSpace(entry.Slug))
                            continue;

                        entry.UrlPrefix = locale.UrlPrefix;
                        entry.Locale = locale.Hreflang;
                        if (string.IsNullOrWhiteSpace(entry.SourceSlug))
                            entry.SourceSlug = entry.Slug;

                        bySlug[entry.Slug] = entry;
                    }
                    catch
                    {
                        // Skip malformed files — pipeline can re-generate.
                    }
                }

                if (bySlug.Count > 0)
                    index[locale.UrlPrefix] = bySlug;
            }

            return index;
        }
    }
}
