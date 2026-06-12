using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    /// <summary>
    /// Invokes the Python high-fidelity PDF→DOCX converter (pdf2docx + hybrid fallback).
    /// </summary>
    public class PdfToDocxProcessor
    {
        private readonly string _pythonScriptPath;
        private readonly string _pythonExecutable;
        private readonly int _timeoutSeconds;
        private readonly ILogger<PdfToDocxProcessor> _logger;

        public PdfToDocxProcessor(
            ILogger<PdfToDocxProcessor> logger,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _logger = logger;
            _pythonScriptPath = Path.Combine(env.ContentRootPath, "Pdf-Engine", "pdf_to_docx_converter.py");
            _pythonExecutable = PythonRuntime.ResolveExecutable(configuration, env);
            _timeoutSeconds = configuration.GetValue("PdfToDocx:ConversionTimeoutSeconds", 600);
        }

        private static string ExtractConversionError(string stderr)
        {
            if (string.IsNullOrWhiteSpace(stderr))
                return "PDF to DOCX conversion failed. Please try a different file or upgrade to Pro.";

            var lines = stderr.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var errorLine = lines.LastOrDefault(l =>
                l.StartsWith("ERROR:", StringComparison.OrdinalIgnoreCase));
            if (errorLine != null)
            {
                var msg = errorLine["ERROR:".Length..].Trim();
                return msg.Length > 500 ? msg[..500] + "…" : msg;
            }

            // Surface Python tracebacks and OCR/tesseract hints from stderr
            var relevant = lines
                .Where(l =>
                    l.Contains("ModuleNotFoundError", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("RuntimeError", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("Tesseract", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("tesseract", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("OCR hybrid", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("conversion failed", StringComparison.OrdinalIgnoreCase)
                    || l.Contains("Attempts:", StringComparison.OrdinalIgnoreCase))
                .TakeLast(6)
                .ToList();

            if (relevant.Count > 0)
            {
                var msg = string.Join(" ", relevant);
                return msg.Length > 500 ? msg[..500] + "…" : msg;
            }

            var tail = string.Join(" ", lines.TakeLast(4));
            return string.IsNullOrWhiteSpace(tail)
                ? "PDF to DOCX conversion failed."
                : (tail.Length > 500 ? tail[..500] + "…" : tail);
        }

        public async Task<byte[]> ConvertPdfToDocxAsync(Stream pdfStream, string? originalFileName = null)
        {
            if (pdfStream == null || pdfStream.Length == 0)
                throw new ArgumentException("PDF stream is empty or null.");

            if (!File.Exists(_pythonScriptPath))
                throw new FileNotFoundException($"PDF to DOCX script not found at {_pythonScriptPath}");

            string? tempPdfPath = null;
            string? tempDocxPath = null;

            try
            {
                tempPdfPath = Path.GetTempFileName() + ".pdf";
                pdfStream.Position = 0;
                await using (var fileStream = new FileStream(tempPdfPath, FileMode.Create, FileAccess.Write))
                {
                    await pdfStream.CopyToAsync(fileStream);
                }

                tempDocxPath = Path.Combine(
                    Path.GetTempPath(),
                    $"ratpdf_{Guid.NewGuid():N}.docx");

                var processStartInfo = PythonRuntime.CreateStartInfo(
                    _pythonExecutable,
                    $"\"{_pythonScriptPath}\" \"{tempPdfPath}\" \"{tempDocxPath}\"",
                    Path.GetDirectoryName(_pythonScriptPath));

                using var process = Process.Start(processStartInfo)
                    ?? throw new InvalidOperationException("Failed to start Python PDF to DOCX process.");

                var stdoutTask = process.StandardOutput.ReadToEndAsync();
                var stderrTask = process.StandardError.ReadToEndAsync();

                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(_timeoutSeconds));
                try
                {
                    await process.WaitForExitAsync(cts.Token);
                }
                catch (OperationCanceledException)
                {
                    try { process.Kill(entireProcessTree: true); } catch { /* best effort */ }
                    throw new TimeoutException(
                        $"PDF to DOCX conversion timed out after {_timeoutSeconds} seconds.");
                }

                var stdout = await stdoutTask;
                var stderr = await stderrTask;

                if (process.ExitCode != 0)
                {
                    _logger.LogError(
                        "PDF to DOCX Python process exited with code {ExitCode}. stderr: {Stderr}",
                        process.ExitCode, stderr);
                    throw new InvalidOperationException(ExtractConversionError(stderr));
                }

                if (!File.Exists(tempDocxPath) || new FileInfo(tempDocxPath).Length == 0)
                    throw new InvalidOperationException(
                        "PDF to DOCX conversion produced no output file.");

                _logger.LogInformation(
                    "PDF to DOCX conversion succeeded for {FileName}. stdout: {Stdout}",
                    originalFileName ?? "upload", stdout.Trim());

                return await File.ReadAllBytesAsync(tempDocxPath);
            }
            finally
            {
                if (tempPdfPath != null)
                {
                    try { if (File.Exists(tempPdfPath)) File.Delete(tempPdfPath); } catch { }
                }
                if (tempDocxPath != null)
                {
                    try { if (File.Exists(tempDocxPath)) File.Delete(tempDocxPath); } catch { }
                }
            }
        }
    }
}
