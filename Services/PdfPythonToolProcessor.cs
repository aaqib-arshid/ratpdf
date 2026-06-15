using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services;

/// <summary>Runs Pdf-Engine CLI scripts with file paths (no in-memory PDF buffering).</summary>
public class PdfPythonToolProcessor
{
    private readonly string _engineRoot;
    private readonly string _pythonExecutable;
    private readonly int _timeoutSeconds;
    private readonly ILogger<PdfPythonToolProcessor> _logger;

    public PdfPythonToolProcessor(
        ILogger<PdfPythonToolProcessor> logger,
        IWebHostEnvironment env,
        IConfiguration configuration)
    {
        _logger = logger;
        _engineRoot = Path.Combine(env.ContentRootPath, "Pdf-Engine");
        _pythonExecutable = PythonRuntime.ResolveExecutable(configuration, env);
        _timeoutSeconds = configuration.GetValue("PdfToDocx:ConversionTimeoutSeconds", 600);
    }

    public Task RunScriptAsync(
        string scriptName,
        string arguments,
        string? expectedOutputPath = null,
        CancellationToken ct = default)
        => RunScriptAsync(scriptName, arguments, expectedOutputPath, null, null, ct);

    public Task RunScriptAsync(
        string scriptName,
        string arguments,
        string? expectedOutputPath,
        string? expectedOutputDirectory,
        CancellationToken ct = default)
        => RunScriptAsync(scriptName, arguments, expectedOutputPath, expectedOutputDirectory, null, ct);

    public async Task RunScriptAsync(
        string scriptName,
        string arguments,
        string? expectedOutputPath,
        string? expectedOutputDirectory,
        string? inputPathForTimeout,
        CancellationToken ct = default)
    {
        var scriptPath = Path.Combine(_engineRoot, scriptName);
        if (!File.Exists(scriptPath))
        {
            _logger.LogError("PDF script missing: {ScriptPath}", scriptPath);
            throw new InvalidOperationException(UserFacingErrorMapper.ServiceUnavailable);
        }

        var psi = PythonRuntime.CreateStartInfo(
            _pythonExecutable,
            $"\"{scriptPath}\" {arguments}",
            _engineRoot);

        using var process = Process.Start(psi)
            ?? throw new InvalidOperationException($"Failed to start {scriptName}");

        var stdoutTask = process.StandardOutput.ReadToEndAsync(ct);
        var stderrTask = process.StandardError.ReadToEndAsync(ct);

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        var timeoutSeconds = ConversionTimeoutHelper.ResolveSeconds(inputPathForTimeout, _timeoutSeconds);
        cts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

        try
        {
            await process.WaitForExitAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            try { process.Kill(entireProcessTree: true); } catch { }
            throw new TimeoutException(UserFacingErrorMapper.Timeout);
        }

        var stdout = await stdoutTask;
        var stderr = await stderrTask;

        if (process.ExitCode != 0)
        {
            _logger.LogError("{Script} failed: {Stderr}", scriptName, stderr);
            throw new InvalidOperationException(
                UserFacingErrorMapper.FromPythonStderr(stderr, scriptName.Replace(".py", "").Replace('_', ' ')));
        }

        if (expectedOutputPath != null && (!File.Exists(expectedOutputPath) || new FileInfo(expectedOutputPath).Length == 0))
            throw new InvalidOperationException(UserFacingErrorMapper.ProcessingFailed);

        if (expectedOutputDirectory != null && !Directory.EnumerateFileSystemEntries(expectedOutputDirectory).Any())
            throw new InvalidOperationException(UserFacingErrorMapper.ProcessingFailed);

        _logger.LogDebug("{Script} OK: {Stdout}", scriptName, stdout.Trim());
    }
}
