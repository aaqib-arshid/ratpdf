using PuppeteerSharp;

namespace ratpdf.Services
{
    public class PuppeteerBrowserService : IAsyncDisposable
    {
        private IBrowser? _browser;
        private readonly ILogger<PuppeteerBrowserService> _logger;

        public PuppeteerBrowserService(ILogger<PuppeteerBrowserService> logger)
        {
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            _logger.LogInformation("Downloading Chromium...");
            var fetcher = new BrowserFetcher();
            await fetcher.DownloadAsync();   

            _logger.LogInformation("Launching browser...");
            _browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] {
                "--no-sandbox",
                "--disable-setuid-sandbox",
                "--disable-dev-shm-usage"   
            }
            });
        }

        public async Task<IBrowser> GetBrowserAsync()
        {
            if (_browser == null || !_browser.IsConnected)
            {
                await InitializeAsync();
            }
            return _browser;
        }

        public async ValueTask DisposeAsync()
        {
            if (_browser != null)
                await _browser.CloseAsync();
        }
    }
}
