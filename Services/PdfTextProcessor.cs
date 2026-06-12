using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    /// <summary>
    /// High-fidelity PDF text extraction via PyMuPDF (reading-order blocks).
    /// </summary>
    public class PdfTextProcessor
    {
        private readonly string _pythonScriptPath;
        private readonly string _pythonExecutable;
        private readonly int _timeoutSeconds;
        private readonly ILogger<PdfTextProcessor> _logger;

        public PdfTextProcessor(
            ILogger<PdfTextProcessor> logger,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _logger = logger;
            _pythonScriptPath = Path.Combine(env.ContentRootPath, "Pdf-Engine", "pdf_text_extractor.py");
            _pythonExecutable = PythonRuntime.ResolveExecutable(configuration, env);
            _timeoutSeconds = configuration.GetValue("PdfToDocx:ConversionTimeoutSeconds", 600);
        }

        public async Task<string> ExtractTextAsync(Stream pdfStream, string? originalFileName = null, CancellationToken ct = default)
        {
            if (!File.Exists(_pythonScriptPath))
            {
                _logger.LogError("PDF text extractor missing: {Path}", _pythonScriptPath);
                throw new InvalidOperationException(UserFacingErrorMapper.ServiceUnavailable);
            }

            string? tempInput = null;
            string? tempOutput = null;

            try
            {
                tempInput = Path.GetTempFileName() + ".pdf";
                tempOutput = Path.Combine(Path.GetTempPath(), $"ratpdf_txt_{Guid.NewGuid():N}.txt");

                await using (var fs = new FileStream(tempInput, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.Position = 0;
                    await pdfStream.CopyToAsync(fs, ct);
                }

                var psi = PythonRuntime.CreateStartInfo(
                    _pythonExecutable,
                    $"\"{_pythonScriptPath}\" \"{tempInput}\" \"{tempOutput}\"",
                    Path.GetDirectoryName(_pythonScriptPath));

                using var process = Process.Start(psi)
                    ?? throw new InvalidOperationException("Failed to start PDF text extraction process.");

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
                    throw new TimeoutException(UserFacingErrorMapper.Timeout);
                }

                var stderr = await stderrTask;
                if (process.ExitCode != 0 || !File.Exists(tempOutput))
                {
                    _logger.LogError("PDF text extraction failed for {File}: {Stderr}", originalFileName, stderr);
                    throw new InvalidOperationException(
                        UserFacingErrorMapper.FromPythonStderr(stderr, "text extraction"));
                }

                return await File.ReadAllTextAsync(tempOutput, Encoding.UTF8, ct);
            }
            finally
            {
                if (tempInput != null) try { if (File.Exists(tempInput)) File.Delete(tempInput); } catch { }
                if (tempOutput != null) try { if (File.Exists(tempOutput)) File.Delete(tempOutput); } catch { }
            }
        }
    }
}
