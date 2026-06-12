namespace ratpdf.Services.Seo
{
    public sealed class SeoIndexingOptions
    {
        public const string SectionName = "SeoIndexing";

        /// <summary>IndexNow API key (8–128 chars). Must match wwwroot/{key}.txt.</summary>
        public string IndexNowKey { get; set; } = "ratpdf2026indexnowkey";

        /// <summary>Submit compress URLs to IndexNow when the app starts (production only).</summary>
        public bool SubmitOnStartup { get; set; } = true;

        /// <summary>Minimum hours between full IndexNow re-submissions (avoids spam on frequent restarts).</summary>
        public int MinHoursBetweenSubmissions { get; set; } = 24;

        /// <summary>URLs per IndexNow POST (max 10,000).</summary>
        public int SubmitUrlBatchSize { get; set; } = 10_000;
    }
}
