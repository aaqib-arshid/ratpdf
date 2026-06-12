using System.Diagnostics;

namespace ratpdf.Services.PdfProcessing;

/// <summary>Logs elapsed time and process memory for PDF pipeline operations.</summary>
public sealed class PdfProcessingMetrics : IDisposable
{
    private readonly ILogger _logger;
    private readonly string _operation;
    private readonly string? _context;
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    private readonly long _startWorkingSet = Process.GetCurrentProcess().WorkingSet64;

    private PdfProcessingMetrics(ILogger logger, string operation, string? context)
    {
        _logger = logger;
        _operation = operation;
        _context = context;
    }

    public static PdfProcessingMetrics Start(ILogger logger, string operation, string? context = null)
    {
        var metrics = new PdfProcessingMetrics(logger, operation, context);
        metrics.Log("started");
        return metrics;
    }

    public void Checkpoint(string phase, long? bytesProcessed = null, long? outputBytes = null)
        => Log(phase, bytesProcessed, outputBytes);

    public void Dispose() => Log("completed");

    private void Log(string phase, long? bytesProcessed = null, long? outputBytes = null)
    {
        var proc = Process.GetCurrentProcess();
        var gcMb = GC.GetTotalMemory(forceFullCollection: false) / (1024.0 * 1024.0);
        var wsMb = proc.WorkingSet64 / (1024.0 * 1024.0);
        var deltaMb = (proc.WorkingSet64 - _startWorkingSet) / (1024.0 * 1024.0);

        _logger.LogInformation(
            "PDF pipeline [{Operation}] {Phase} job={Context} elapsedMs={ElapsedMs} workingSetMb={WorkingSetMb:F1} wsDeltaMb={WsDeltaMb:+#0.0;-#0.0;0} gcMb={GcMb:F1} bytesIn={BytesIn} bytesOut={BytesOut}",
            _operation,
            phase,
            _context ?? "-",
            _stopwatch.ElapsedMilliseconds,
            wsMb,
            deltaMb,
            gcMb,
            bytesProcessed,
            outputBytes);
    }
}
