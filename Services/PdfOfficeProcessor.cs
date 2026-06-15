using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services
{
    public enum OfficeConversionKind
    {
        DocxToPdf,
        PdfToXlsx,
        XlsxToPdf,
        PdfToPptx,
        PptxToPdf,
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

        public async Task<PdfConversionFileResult> ConvertToFileAsync(
            OfficeConversionKind kind,
            Stream inputStream,
            string outputPath,
            string originalFileName,
            CancellationToken ct = default)
        {
            var (inputExt, _) = GetExtensions(kind);
            string? tempInput = null;

            try
            {
                tempInput = Path.GetTempFileName() + inputExt;
                await PdfStreamCopy.CopyToFileAsync(inputStream, tempInput, 4 * 1024 * 1024, ct);
                return await ConvertFileAsync(kind, tempInput, outputPath, originalFileName, ct);
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(tempInput);
            }
        }

        public async Task<PdfConversionFileResult> ConvertFileAsync(
            OfficeConversionKind kind,
            string inputPath,
            string outputPath,
            string originalFileName,
            CancellationToken ct = default)
        {
            if (!File.Exists(_pythonScriptPath))
            {
                _logger.LogError("Office converter missing: {Path}", _pythonScriptPath);
                throw new InvalidOperationException(UserFacingErrorMapper.ServiceUnavailable);
            }

            if (!File.Exists(inputPath))
                throw new FileNotFoundException(UserFacingErrorMapper.ProcessingFailed);

            var command = kind switch
            {
                OfficeConversionKind.DocxToPdf => "docx2pdf",
                OfficeConversionKind.PdfToXlsx => "pdf2xlsx",
                OfficeConversionKind.XlsxToPdf => "xlsx2pdf",
                OfficeConversionKind.PdfToPptx => "pdf2pptx",
                OfficeConversionKind.PptxToPdf => "pptx2pdf",
                _ => throw new ArgumentOutOfRangeException(nameof(kind)),
            };

            var psi = PythonRuntime.CreateStartInfo(
                _pythonExecutable,
                $"\"{_pythonScriptPath}\" {command} \"{inputPath}\" \"{outputPath}\"",
                Path.GetDirectoryName(_pythonScriptPath));

            using var process = Process.Start(psi)
                ?? throw new InvalidOperationException("Failed to start office conversion process.");

            var stdoutTask = process.StandardOutput.ReadToEndAsync(ct);
            var stderrTask = process.StandardError.ReadToEndAsync(ct);

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var timeoutSeconds = ConversionTimeoutHelper.ResolveSeconds(inputPath, _timeoutSeconds);
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

            var stderr = await stderrTask;
            await stdoutTask;

            if (process.ExitCode != 0 || !File.Exists(outputPath) || new FileInfo(outputPath).Length == 0)
            {
                _logger.LogError("Office conversion failed for {File}: {Stderr}", originalFileName, stderr);
                throw new InvalidOperationException(
                    UserFacingErrorMapper.FromPythonStderr(stderr, "office conversion"));
            }

            return new PdfConversionFileResult(outputPath, new FileInfo(outputPath).Length);
        }

        /// <summary>Legacy API — loads output into memory. Prefer ConvertToFileAsync for large files.</summary>
        public async Task<byte[]> ConvertAsync(
            OfficeConversionKind kind,
            Stream inputStream,
            string originalFileName,
            CancellationToken ct = default)
        {
            var (_, outputExt) = GetExtensions(kind);
            var outputPath = Path.Combine(Path.GetTempPath(), $"ratpdf_office_{Guid.NewGuid():N}{outputExt}");
            try
            {
                var result = await ConvertToFileAsync(kind, inputStream, outputPath, originalFileName, ct);
                return await File.ReadAllBytesAsync(result.FilePath, ct);
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(outputPath);
            }
        }

        private static (string InputExt, string OutputExt) GetExtensions(OfficeConversionKind kind) =>
            kind switch
            {
                OfficeConversionKind.DocxToPdf => (".docx", ".pdf"),
                OfficeConversionKind.PdfToXlsx => (".pdf", ".xlsx"),
                OfficeConversionKind.XlsxToPdf => (".xlsx", ".pdf"),
                OfficeConversionKind.PdfToPptx => (".pdf", ".pptx"),
                OfficeConversionKind.PptxToPdf => (".pptx", ".pdf"),
                _ => (".bin", ".out"),
            };
    }
}
