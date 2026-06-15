using Microsoft.Extensions.Hosting;

namespace ratpdf.Services
{
    /// <summary>Periodically removes stale in-memory PDF edit sessions and temp files.</summary>
    public sealed class PdfEditSessionCleanupHostedService : BackgroundService
    {
        private static readonly TimeSpan Interval = TimeSpan.FromMinutes(30);
        private static readonly TimeSpan MaxAge = TimeSpan.FromHours(2);

        private readonly IPdfEditSessionStore _sessions;
        private readonly ILogger<PdfEditSessionCleanupHostedService> _logger;

        public PdfEditSessionCleanupHostedService(
            IPdfEditSessionStore sessions,
            ILogger<PdfEditSessionCleanupHostedService> logger)
        {
            _sessions = sessions;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(Interval, stoppingToken);
                    _sessions.Cleanup(MaxAge);
                    _logger.LogDebug("PDF edit session cleanup completed (max age {Hours}h)", MaxAge.TotalHours);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "PDF edit session cleanup failed");
                }
            }
        }
    }
}
