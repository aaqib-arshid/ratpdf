namespace ratpdf.Services.Seo
{
    public static class ProgrammaticSlugHelper
    {
        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        public static Dictionary<string, string> LoadKeywordMap(string webRootPath, string fileName)
        {
            var path = Path.Combine(webRootPath, fileName);
            if (!File.Exists(path))
                return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            return File.ReadAllLines(path)
                .Where(k => !string.IsNullOrWhiteSpace(k))
                .Select(k => k.Trim())
                .GroupBy(k => GenerateSlug(k), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);
        }
    }
}
