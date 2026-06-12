using System.Threading.Channels;
using Microsoft.Extensions.Options;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services;

public interface IJobQueue
{
    void Queue(Func<CancellationToken, Task> work);
    Task ProcessAsync(CancellationToken ct);
}

public class JobQueue : IJobQueue
{
    private readonly Channel<Func<CancellationToken, Task>> _channel;
    private readonly int _maxConcurrent;
    private readonly ILogger<JobQueue> _logger;

    public JobQueue(IOptions<PdfProcessingOptions> options, ILogger<JobQueue> logger)
    {
        _logger = logger;
        var opts = options.Value;
        _maxConcurrent = Math.Max(1, opts.MaxConcurrentJobs);

        _channel = Channel.CreateBounded<Func<CancellationToken, Task>>(
            new BoundedChannelOptions(Math.Max(1, opts.MaxQueuedJobs))
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleReader = false,
                SingleWriter = false,
            });
    }

    public void Queue(Func<CancellationToken, Task> work)
    {
        _ = _channel.Writer.WriteAsync(work);
    }

    public async Task ProcessAsync(CancellationToken ct)
    {
        _logger.LogInformation(
            "Job queue started with {Workers} concurrent worker(s).",
            _maxConcurrent);

        var workers = Enumerable.Range(0, _maxConcurrent)
            .Select(i => RunWorkerAsync(i, ct))
            .ToArray();

        await Task.WhenAll(workers);
    }

    private async Task RunWorkerAsync(int workerId, CancellationToken ct)
    {
        await foreach (var work in _channel.Reader.ReadAllAsync(ct))
        {
            using var metrics = PdfProcessingMetrics.Start(_logger, "background-job", $"worker-{workerId}");
            try
            {
                await work(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Background job failed on worker {WorkerId}", workerId);
            }
        }
    }
}
