using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    public enum OfficeConversionKind
    {
        DocxToPdf,
        PdfToXlsx,
        XlsxToPdf,
    }

    public class PdfOfficeProcessor
    {
        private readonly string _pythonScriptPath;
        private readonly string _pythonExecutable;
        private readonly int _timeoutSeconds;
        private readonly ILogger<PdfOfficeProcessor> _logger;

        public PdfOfficeProcessor(
            ILogger<PdfOfficeProcessor> logger,
            IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _logger = logger;
            _pythonScriptPath = Path.Combine(env.ContentRootPath, "Pdf-Engine", "office_converter.py");
            _pythonExecutable = PythonRuntime.ResolveExecutable(configuration, env);
            _timeoutSeconds = configuration.GetValue("PdfToDocx:ConversionTimeoutSeconds", 600);
        }

        public async Task<byte[]> ConvertAsync(
            OfficeConversionKind kind,
            Stream inputStream,
            string originalFileName,
            CancellationToken ct = default)
        {
            if (!File.Exists(_pythonScriptPath))
                throw new FileNotFoundException($"Office converter not found at {_pythonScriptPath}");

            var command = kind switch
            {
                OfficeConversionKind.DocxToPdf => "docx2pdf",
                OfficeConversionKind.PdfToXlsx => "pdf2xlsx",
                OfficeConversionKind.XlsxToPdf => "xlsx2pdf",
                _ => throw new ArgumentOutOfRangeException(nameof(kind)),
            };

            var inputExt = kind switch
            {
                OfficeConversionKind.DocxToPdf => ".docx",
                OfficeConversionKind.PdfToXlsx => ".pdf",
                OfficeConversionKind.XlsxToPdf => ".xlsx",
                _ => ".bin",
            };

            var outputExt = kind switch
            {
                OfficeConversionKind.DocxToPdf => ".pdf",
                OfficeConversionKind.PdfToXlsx => ".xlsx",
                OfficeConversionKind.XlsxToPdf => ".pdf",
                _ => ".out",
            };

            string? tempInput = null;
            string? tempOutput = null;

            try
            {
                tempInput = Path.GetTempFileName() + inputExt;
                tempOutput = Path.Combine(Path.GetTempPath(), $"ratpdf_office_{Guid.NewGuid():N}{outputExt}");

                await using (var fs = new FileStream(tempInput, FileMode.Create, FileAccess.Write))
                {
                    inputStream.Position = 0;
                    await inputStream.CopyToAsync(fs, ct);
                }

                var psi = PythonRuntime.CreateStartInfo(
                    _pythonExecutable,
                    $"\"{_pythonScriptPath}\" {command} \"{tempInput}\" \"{tempOutput}\"",
                    Path.GetDirectoryName(_pythonScriptPath));

                using var process = Process.Start(psi)
                    ?? throw new InvalidOperationException("Failed to start office conversion process.");

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
                    throw new TimeoutException($"Office conversion timed out after {_timeoutSeconds}s.");
                }

                var stderr = await stderrTask;
                await stdoutTask;

                if (process.ExitCode != 0 || !File.Exists(tempOutput) || new FileInfo(tempOutput).Length == 0)
                {
                    _logger.LogError("Office conversion failed for {File}: {Stderr}", originalFileName, stderr);
                    throw new InvalidOperationException(
                        string.IsNullOrWhiteSpace(stderr)
                            ? "Office conversion failed."
                            : stderr.Trim());
                }

                return await File.ReadAllBytesAsync(tempOutput, ct);
            }
            finally
            {
                if (tempInput != null) try { if (File.Exists(tempInput)) File.Delete(tempInput); } catch { }
                if (tempOutput != null) try { if (File.Exists(tempOutput)) File.Delete(tempOutput); } catch { }
            }
        }
    }
}
