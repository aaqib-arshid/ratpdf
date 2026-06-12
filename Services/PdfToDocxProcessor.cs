using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ratpdf.Constants;
using ratpdf.Services.PdfProcessing;

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

        private static string ExtractConversionError(string stderr) =>
            UserFacingErrorMapper.FromPythonStderr(stderr, "PDF to Word conversion");

        /// <summary>
        /// Converts PDF to DOCX on disk. Caller owns output path cleanup.
        /// </summary>
        public async Task<PdfConversionFileResult> ConvertPdfToDocxToFileAsync(
            Stream pdfStream,
            string outputDocxPath,
            string? originalFileName = null,
            CancellationToken ct = default)
        {
            if (pdfStream == null)
                throw new ArgumentException("PDF stream is null.");

            if (!File.Exists(_pythonScriptPath))
            {
                _logger.LogError("PDF to DOCX script missing: {Path}", _pythonScriptPath);
                throw new InvalidOperationException(UserFacingErrorMapper.ServiceUnavailable);
            }

            string? tempPdfPath = null;

            try
            {
                tempPdfPath = Path.GetTempFileName() + ".pdf";
                await PdfStreamCopy.CopyToFileAsync(pdfStream, tempPdfPath, 4 * 1024 * 1024, ct);

                await RunPythonConversionAsync(tempPdfPath, outputDocxPath, originalFileName, ct);

                var size = new FileInfo(outputDocxPath).Length;
                if (size == 0)
                    throw new InvalidOperationException("PDF to DOCX conversion produced no output file.");

                return new PdfConversionFileResult(outputDocxPath, size);
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(tempPdfPath);
            }
        }

        /// <summary>
        /// Converts when input is already on disk (avoids re-copying multi-GB files).
        /// </summary>
        public async Task<PdfConversionFileResult> ConvertPdfFileToDocxAsync(
            string inputPdfPath,
            string outputDocxPath,
            string? originalFileName = null,
            CancellationToken ct = default)
        {
            if (!File.Exists(inputPdfPath))
                throw new FileNotFoundException("Input PDF not found.", inputPdfPath);

            await RunPythonConversionAsync(inputPdfPath, outputDocxPath, originalFileName, ct);

            var size = new FileInfo(outputDocxPath).Length;
            if (size == 0)
                throw new InvalidOperationException("PDF to DOCX conversion produced no output file.");

            return new PdfConversionFileResult(outputDocxPath, size);
        }

        /// <summary>Legacy API — loads output into memory. Prefer ConvertPdfToDocxToFileAsync for large files.</summary>
        public async Task<byte[]> ConvertPdfToDocxAsync(Stream pdfStream, string? originalFileName = null)
        {
            var outputPath = Path.Combine(Path.GetTempPath(), $"ratpdf_{Guid.NewGuid():N}.docx");
            try
            {
                var result = await ConvertPdfToDocxToFileAsync(pdfStream, outputPath, originalFileName);
                return await File.ReadAllBytesAsync(result.FilePath);
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(outputPath);
            }
        }

        private async Task RunPythonConversionAsync(
            string inputPdfPath,
            string outputDocxPath,
            string? originalFileName,
            CancellationToken ct)
        {
            var processStartInfo = PythonRuntime.CreateStartInfo(
                _pythonExecutable,
                $"\"{_pythonScriptPath}\" \"{inputPdfPath}\" \"{outputDocxPath}\"",
                Path.GetDirectoryName(_pythonScriptPath));

            using var process = Process.Start(processStartInfo)
                ?? throw new InvalidOperationException("Failed to start Python PDF to DOCX process.");

            var stdoutTask = process.StandardOutput.ReadToEndAsync(ct);
            var stderrTask = process.StandardError.ReadToEndAsync(ct);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var timeoutSeconds = ResolveTimeoutSeconds(inputPdfPath);
            cts.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            try
            {
                await process.WaitForExitAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                try { process.Kill(entireProcessTree: true); } catch { }
                throw new TimeoutException(
                    $"PDF to DOCX conversion timed out after {timeoutSeconds} seconds.");
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

            if (!File.Exists(outputDocxPath))
                throw new InvalidOperationException("PDF to DOCX conversion produced no output file.");

            _logger.LogInformation(
                "PDF to DOCX conversion succeeded for {FileName}. stdout: {Stdout}",
                originalFileName ?? "upload", stdout.Trim());
        }

        private int ResolveTimeoutSeconds(string inputPdfPath)
        {
            try
            {
                var sizeMb = Math.Max(1, (int)(new FileInfo(inputPdfPath).Length / (1024 * 1024)));
                return Math.Min(3600, Math.Max(_timeoutSeconds, sizeMb * 45));
            }
            catch
            {
                return _timeoutSeconds;
            }
        }
    }
}
