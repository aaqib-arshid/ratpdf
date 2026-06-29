using ratpdf.Constants;

namespace ratpdf.Services.Seo
{
    /// <summary>Warm sitemap caches and notify search engines on startup.</summary>
    public sealed class SeoIndexingHostedService : IHostedService
    {
        private readonly IServiceProvider _services;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<SeoIndexingHostedService> _logger;

        public SeoIndexingHostedService(
            IServiceProvider services,
            IWebHostEnvironment env,
            ILogger<SeoIndexingHostedService> logger)
        {
            _services = services;
            _env = env;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(8), cancellationToken);
                    await WarmCachesAsync(cancellationToken);

                    if (_env.IsProduction())
                        await SubmitToSearchEnginesAsync(cancellationToken);
                    else
                        _logger.LogInformation("IndexNow skipped (non-production environment).");
                }
                catch (OperationCanceledException) { }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "SEO indexing bootstrap failed.");
                }
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private async Task WarmCachesAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var sitemaps = scope.ServiceProvider.GetRequiredService<SitemapCacheService>();
            var seo = scope.ServiceProvider.GetRequiredService<CachedPdfCompressSeoService>();
            var ttl = TimeSpan.FromHours(1);

            PdfCompressProgrammaticSeoGenerator.Initialize(_env.WebRootPath);

            _ = sitemaps.GetOrBuildSitemapIndex(
                "sitemap:main:index:v2:warm",
                SitemapCatalog.BuildMainIndexChildren(),
                TimeSpan.FromHours(6));
            _ = sitemaps.GetOrBuildCoreSitemap(ttl);
            _ = sitemaps.GetOrBuildToolsSitemap(ttl);
            _ = sitemaps.GetOrBuildBlogSitemap(ttl);
            _ = sitemaps.GetOrBuildProgrammaticSitemap(ttl);
            foreach (var locale in new[] { (string?)null, "pt", "es", "de", "id", "fr" })
                _ = sitemaps.GetOrBuildGuideLocaleSitemap(locale, ttl);

            seo.WarmCuratedPages(_env.WebRootPath);

            _logger.LogInformation(
                "SEO cache warmed: main sitemap index ({ChildCount} children, ~7,906 URLs).",
                SitemapCatalog.MainIndexChildren.Length);
            await Task.CompletedTask;
        }

        private async Task SubmitToSearchEnginesAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var indexNow = scope.ServiceProvider.GetRequiredService<IndexNowSubmissionService>();
            await indexNow.SubmitCompressCorpusAsync(cancellationToken);
        }
    }
}
