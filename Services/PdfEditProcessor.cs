using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    public class PdfEditProcessor
    {
        private readonly string _pythonScriptPath;
        private readonly string _pythonExecutable;
        private readonly int _timeoutSeconds;
        private readonly ILogger<PdfEditProcessor> _logger;

        public PdfEditProcessor(
            ILogger<PdfEditProcessor> logger,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _logger = logger;
            _pythonScriptPath = Path.Combine(env.ContentRootPath, "Pdf-Engine", "pdf_edit_engine.py");
            _pythonExecutable = PythonRuntime.ResolveExecutable(configuration);
            _timeoutSeconds = configuration.GetValue("PdfEdit:TimeoutSeconds", 600);
        }

        public async Task<string> ExtractEditableModelJsonAsync(string pdfPath, CancellationToken ct = default)
        {
            return await RunPythonAsync($"extract \"{pdfPath}\"", ct);
        }

        public async Task ApplyEditsAsync(string pdfPath, string editsJsonPath, string outputPdfPath, CancellationToken ct = default)
        {
            await RunPythonAsync(
                $"apply \"{pdfPath}\" \"{editsJsonPath}\" \"{outputPdfPath}\"",
                ct,
                expectOutputFile: outputPdfPath);
        }

        private async Task<string> RunPythonAsync(
            string arguments,
            CancellationToken ct,
            string? expectOutputFile = null)
        {
            if (!File.Exists(_pythonScriptPath))
                throw new FileNotFoundException($"PDF edit engine not found at {_pythonScriptPath}");

            var psi = new ProcessStartInfo
            {
                FileName = _pythonExecutable,
                Arguments = $"\"{_pythonScriptPath}\" {arguments}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(_pythonScriptPath)!,
            };

            using var process = Process.Start(psi)
                ?? throw new InvalidOperationException("Failed to start PDF edit Python process.");

            var stdoutTask = process.StandardOutput.ReadToEndAsync(ct);
            var stderrTask = process.StandardError.ReadToEndAsync(ct);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(TimeSpan.FromSeconds(_timeoutSeconds));

            try
            {
                await process.WaitForExitAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                try { process.Kill(entireProcessTree: true); } catch { }
                throw new TimeoutException($"PDF edit operation timed out after {_timeoutSeconds}s.");
            }

            var stdout = await stdoutTask;
            var stderr = await stderrTask;

            if (process.ExitCode != 0)
            {
                _logger.LogError("PDF edit engine failed: {Stderr}", stderr);
                throw new InvalidOperationException($"PDF edit engine failed: {stderr.Trim()}");
            }

            if (expectOutputFile != null)
            {
                if (!File.Exists(expectOutputFile) || new FileInfo(expectOutputFile).Length == 0)
                    throw new InvalidOperationException("PDF edit engine produced no output.");
                return expectOutputFile;
            }

            return stdout.Trim();
        }
    }
}
