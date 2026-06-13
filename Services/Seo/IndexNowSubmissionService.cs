using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ratpdf.Constants;
using ratpdf.Services;

namespace ratpdf.Services.Seo
{
    /// <summary>Notifies Bing/Yandex via IndexNow and pings sitemaps for faster discovery.</summary>
    public sealed class IndexNowSubmissionService
    {
        private static readonly Uri[] IndexNowEndpoints =
        [
            new("https://api.indexnow.org/indexnow"),
            new("https://www.bing.com/indexnow"),
            new("https://yandex.com/indexnow"),
        ];

        private static readonly Uri BingSitemapPing =
            new("https://www.bing.com/ping?sitemap=");

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<IndexNowSubmissionService> _logger;
        private readonly SeoIndexingOptions _options;

        public IndexNowSubmissionService(
            IHttpClientFactory httpClientFactory,
            IWebHostEnvironment env,
            IOptions<SeoIndexingOptions> options,
            ILogger<IndexNowSubmissionService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _env = env;
            _logger = logger;
            _options = options.Value;
        }

        public async Task SubmitCompressCorpusAsync(CancellationToken cancellationToken = default)
        {
            if (!_options.SubmitOnStartup || string.IsNullOrWhiteSpace(_options.IndexNowKey))
                return;

            if (!ShouldSubmitNow())
            {
                _logger.LogInformation("IndexNow: skipped — last submission within {Hours}h cooldown.",
                    _options.MinHoursBetweenSubmissions);
                return;
            }

            EnsureKeyFileExists();

            PdfCompressProgrammaticSeoGenerator.Initialize(_env.WebRootPath);
            var paths = PdfCompressProgrammaticSeoGenerator.AllSitemapPaths();
            var urls = paths.Select(PdfToolSeo.Canonical).ToList();

            _logger.LogInformation("IndexNow: submitting {Count} compress URLs.", urls.Count);

            var batchSize = Math.Clamp(_options.SubmitUrlBatchSize, 1, 10_000);
            for (var i = 0; i < urls.Count; i += batchSize)
            {
                var batch = urls.Skip(i).Take(batchSize).ToList();
                await SubmitUrlBatchAsync(batch, cancellationToken);
            }

            await PingSitemapsAsync(cancellationToken);
            RecordSubmissionTime();
        }

        private bool ShouldSubmitNow()
        {
            var statePath = GetStateFilePath();
            if (!File.Exists(statePath))
                return true;

            if (!DateTime.TryParse(File.ReadAllText(statePath), out var last))
                return true;

            return DateTime.UtcNow - last.ToUniversalTime() >=
                   TimeSpan.FromHours(_options.MinHoursBetweenSubmissions);
        }

        private void RecordSubmissionTime()
        {
            var dir = Path.GetDirectoryName(GetStateFilePath())!;
            Directory.CreateDirectory(dir);
            File.WriteAllText(GetStateFilePath(), DateTime.UtcNow.ToString("O"));
        }

        private string GetStateFilePath() =>
            Path.Combine(_env.ContentRootPath, "App_Data", "seo-indexnow-state.txt");

        private void EnsureKeyFileExists()
        {
            var key = _options.IndexNowKey.Trim();
            var path = Path.Combine(_env.WebRootPath, $"{key}.txt");
            if (!File.Exists(path))
                File.WriteAllText(path, key);
        }

        private async Task SubmitUrlBatchAsync(IReadOnlyList<string> urls, CancellationToken cancellationToken)
        {
            var key = _options.IndexNowKey.Trim();
            var host = new Uri(PdfToolSeo.SiteUrl).Host;
            var payload = new
            {
                host,
                key,
                keyLocation = $"{PdfToolSeo.SiteUrl}/{key}.txt",
                urlList = urls,
            };

            var json = JsonSerializer.Serialize(payload);

            var client = _httpClientFactory.CreateClient(nameof(IndexNowSubmissionService));
            client.Timeout = TimeSpan.FromMinutes(2);

            foreach (var endpoint in IndexNowEndpoints)
            {
                try
                {
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");
                    using var response = await client.PostAsync(endpoint, content, cancellationToken);
                    _logger.LogInformation(
                        "IndexNow POST {Endpoint}: {Status} ({Count} URLs)",
                        endpoint.Host, (int)response.StatusCode, urls.Count);

                    if (response.StatusCode is HttpStatusCode.TooManyRequests or HttpStatusCode.ServiceUnavailable)
                        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "IndexNow POST failed for {Endpoint}.", endpoint);
                }
            }
        }

        private async Task PingSitemapsAsync(CancellationToken cancellationToken)
        {
            var sitemaps = new[]
            {
                $"{PdfToolSeo.SiteUrl}/sitemap.xml",
            };

            var client = _httpClientFactory.CreateClient(nameof(IndexNowSubmissionService));
            client.Timeout = TimeSpan.FromSeconds(30);

            foreach (var sitemap in sitemaps)
            {
                try
                {
                    var uri = new Uri(BingSitemapPing + Uri.EscapeDataString(sitemap));
                    using var response = await client.GetAsync(uri, cancellationToken);
                    _logger.LogInformation("Bing sitemap ping {Sitemap}: {Status}", sitemap, (int)response.StatusCode);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Bing sitemap ping failed for {Sitemap}.", sitemap);
                }
            }
        }
    }
}
