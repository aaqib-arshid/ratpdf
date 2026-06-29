namespace ratpdf.Constants
{
    /// <summary>Supported guide locales for multilingual SEO (hreflang + /{prefix}/guides routes).</summary>
    public static class GuideLocales
    {
        public const string EnglishHreflang = "en";
        public const string DefaultHreflang = "x-default";

        public static readonly GuideLocale[] All =
        [
            new("pt", "pt-BR", "Portuguese (Brazil)", "Português"),
            new("es", "es", "Spanish (Latin America)", "Español"),
            new("de", "de", "German", "Deutsch"),
            new("id", "id", "Indonesian", "Bahasa Indonesia"),
            new("fr", "fr", "French", "Français"),
        ];

        public static GuideLocale? FromUrlPrefix(string? urlPrefix) =>
            string.IsNullOrWhiteSpace(urlPrefix)
                ? null
                : All.FirstOrDefault(l => l.UrlPrefix.Equals(urlPrefix, StringComparison.OrdinalIgnoreCase));

        public static GuideLocale? FromHreflang(string? hreflang) =>
            string.IsNullOrWhiteSpace(hreflang)
                ? null
                : All.FirstOrDefault(l => l.Hreflang.Equals(hreflang, StringComparison.OrdinalIgnoreCase));

        public static string LocalizedGuidePath(string urlPrefix, string slug) =>
            $"/{urlPrefix.Trim('/')}/guides/{slug.Trim('/')}";

        public static string EnglishGuidePath(string slug) => $"/guides/{slug.Trim('/')}";
    }

    public sealed record GuideLocale(
        string UrlPrefix,
        string Hreflang,
        string EnglishName,
        string NativeName);
}
