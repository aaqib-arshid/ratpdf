namespace ratpdf.Constants
{
    /// <summary>Medical calculator tools removed from site — paths return HTTP 410 Gone.</summary>
    public static class MedicalToolsRemoval
    {
        public static readonly string[] PathPrefixes =
        [
            "/medical-tools/",
        ];

        public static readonly HashSet<string> ExactPaths = new(StringComparer.OrdinalIgnoreCase)
        {
            "/tools/medical",
            "/guides/medical-tools",
            "/bmi-calculator",
            "/egfr-calculator",
            "/heart-score",
            "/cha2ds2-vasc-score",
            "/wells-score",
            "/gcs-calculator",
            "/map-calculator",
            "/has-bled-score",
            "/parkland-formula",
            "/nihss-calculator",
            "/guides/bmi-calculator-guide",
            "/guides/egfr-calculator-guide",
            "/guides/heart-score-guide",
            "/guides/cha2ds2-vasc-guide",
            "/guides/wells-score-guide",
            "/guides/medical-calculators-guide",
            "/blog/medical-calculator-clinical-documentation",
            "/learn/bmi-calculator",
            "/learn/egfr-calculator",
            "/learn/heart-score",
            "/learn/cha2ds2-vasc-score",
            "/learn/wells-score",
            "/learn/gcs-calculator",
            "/learn/map-calculator",
            "/learn/has-bled-score",
            "/learn/parkland-formula",
            "/learn/nihss-calculator",
        };

        public static bool IsRemovedPath(string? path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;
            path = path.Trim();
            if (path.Length > 1 && path.EndsWith('/'))
                path = path.TrimEnd('/');

            if (ExactPaths.Contains(path)) return true;
            return PathPrefixes.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsRemovedLearnSlug(string slug)
        {
            var path = $"/learn/{slug.Trim().Trim('/')}";
            return ExactPaths.Contains(path);
        }
    }
}
