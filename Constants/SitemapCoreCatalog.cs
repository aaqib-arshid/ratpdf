namespace ratpdf.Constants
{
    /// <summary>Ten canonical marketing URLs for sitemap-core.xml.</summary>
    public static class SitemapCoreCatalog
    {
        public static readonly SitemapCoreEntry[] Entries =
        [
            new("/", 1.0),
            new("/about", 0.6),
            new("/pricing", 0.6),
            new("/blog", 0.6),
            new("/guides", 0.6),
            new(SiteEntity.TrustHubPath, 0.6),
            new(SiteEntity.HelpPath, 0.6),
            new("/compare", 0.6),
            new("/tools", 0.6),
            new("/invoice/create", 0.6),
        ];

        public static IReadOnlyList<string> Paths() =>
            Entries.Select(e => e.Path).ToList();
    }

    public sealed record SitemapCoreEntry(string Path, double Priority);
}
