namespace ratpdf.Services
{
    public class BackgroundJobProcessor : BackgroundService
    {
        private readonly IJobQueue _queue;
        private readonly ILogger<BackgroundJobProcessor> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public BackgroundJobProcessor(IJobQueue queue, ILogger<BackgroundJobProcessor> logger, IServiceScopeFactory scopeFactory)
        {
            _queue = queue;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background job processor started.");
            await _queue.ProcessAsync(stoppingToken);
        }
    }
}