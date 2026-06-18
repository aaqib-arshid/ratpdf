using System.IO.Compression;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services;

/// <summary>Background jobs for extended PDF tools (OCR, images, unlock, flatten, metadata).</summary>
public class PdfExtendedToolJobService
{
    private readonly PdfConversionFileOps _fileOps;
    private readonly PdfPythonToolProcessor _python;
    private readonly IJobResultStore _jobStore;
    private readonly AzureBlobService _blobService;
    private readonly PdfJobStorageService _jobStorage;
    private readonly ILogger<PdfExtendedToolJobService> _logger;

    public PdfExtendedToolJobService(
        PdfConversionFileOps fileOps,
        PdfPythonToolProcessor python,
        IJobResultStore jobStore,
        AzureBlobService blobService,
        PdfJobStorageService jobStorage,
        ILogger<PdfExtendedToolJobService> logger)
    {
        _fileOps = fileOps;
        _python = python;
        _jobStore = jobStore;
        _blobService = blobService;
        _jobStorage = jobStorage;
        _logger = logger;
    }

    public Task RunUnlockJobAsync(string jobId, string stagingBlob, long inputSize, string? password, CancellationToken ct)
        => RunSingleOutputAsync(jobId, "unlockpdf", stagingBlob, inputSize, "unlocked.pdf", "application/pdf",
            "Removing password…", path => _fileOps.UnlockPdfFromPath(path, password), ct);

    public Task RunFlattenJobAsync(string jobId, string stagingBlob, long inputSize, CancellationToken ct)
        => RunSingleOutputAsync(jobId, "flattenpdf", stagingBlob, inputSize, "flattened.pdf", "application/pdf",
            "Flattening forms…", path => _fileOps.FlattenPdfFromPath(path), ct);

    public async Task RunRepairJobAsync(string jobId, string stagingBlob, long inputSize, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "repairpdf", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);

            _jobStore.SetProgress(jobId, 45, "Repairing structure…");
            try
            {
                var result = _fileOps.RepairPdfFromPath(tempInput);
                outputPath = result.FilePath;
                await UploadAsync(jobId, "repairpdf", outputPath, "repaired.pdf", "application/pdf",
                    inputSize, result.SizeBytes, ct);
                metrics.Checkpoint("completed", inputSize, result.SizeBytes);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "iText repair failed for job {JobId}, trying PyMuPDF", jobId);
                outputPath = PdfTempPaths.NewOutput(".pdf");
                _jobStore.SetProgress(jobId, 60, "Deep repair pass…");
                await _python.RunScriptAsync(
                    "pdf_repair.py",
                    $"\"{tempInput}\" \"{outputPath}\"",
                    outputPath,
                    expectedOutputDirectory: null,
                    inputPathForTimeout: tempInput,
                    ct: ct);

                var size = new FileInfo(outputPath).Length;
                await UploadAsync(jobId, "repairpdf", outputPath, "repaired.pdf", "application/pdf", inputSize, size, ct);
                metrics.Checkpoint("completed", inputSize, size);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Repair job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    public async Task RunSummarizeJobAsync(
        string jobId, string stagingBlob, long inputSize, int sentenceCount, int maxPages, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "summarizepdf", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            outputPath = PdfTempPaths.NewOutput(".json");

            _jobStore.SetProgress(jobId, 40, "Extracting text…");
            await _python.RunScriptAsync(
                "pdf_summarize.py",
                $"\"{tempInput}\" \"{outputPath}\" --sentences {sentenceCount} --max-pages {maxPages}",
                outputPath,
                expectedOutputDirectory: null,
                inputPathForTimeout: tempInput,
                ct: ct);

            var size = new FileInfo(outputPath).Length;
            await UploadAsync(jobId, "summarizepdf", outputPath, "summary.json", "application/json", inputSize, size, ct);
            metrics.Checkpoint("completed", inputSize, size);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Summarize job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    public async Task RunPdfAJobAsync(
        string jobId, string stagingBlob, long inputSize, string level, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "pdfa", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            var pdfA2 = level.StartsWith("2", StringComparison.OrdinalIgnoreCase);

            _jobStore.SetProgress(jobId, 45, "Converting to PDF/A…");
            long outputSize;
            try
            {
                var result = _fileOps.ConvertToPdfAFromPath(tempInput, pdfA2);
                outputPath = result.FilePath;
                outputSize = result.SizeBytes;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "iText PDF/A conversion failed for job {JobId}, trying Python", jobId);
                outputPath = PdfTempPaths.NewOutput(".pdf");
                var gsLevel = pdfA2 ? "2b" : "1b";
                await _python.RunScriptAsync(
                    "pdf_pdfa.py",
                    $"\"{tempInput}\" \"{outputPath}\" --level {gsLevel}",
                    outputPath,
                    expectedOutputDirectory: null,
                    inputPathForTimeout: tempInput,
                    ct: ct);
                outputSize = new FileInfo(outputPath).Length;
            }

            await UploadAsync(jobId, "pdfa", outputPath, "pdfa.pdf", "application/pdf", inputSize, outputSize, ct);
            metrics.Checkpoint("completed", inputSize, outputSize);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "PDF/A job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    public async Task RunComparePdfJobAsync(
        string jobId,
        string stagingBlobA,
        string stagingBlobB,
        long inputSizeA,
        long inputSizeB,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "comparepdf", jobId);
        string? tempA = null;
        string? tempB = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing files…");
            tempA = await _jobStorage.MaterializeToTempFileAsync(stagingBlobA, ".pdf", ct);
            tempB = await _jobStorage.MaterializeToTempFileAsync(stagingBlobB, ".pdf", ct);
            outputPath = PdfTempPaths.NewOutput(".json");

            _jobStore.SetProgress(jobId, 40, "Extracting and comparing text…");
            await _python.RunScriptAsync(
                "pdf_compare.py",
                $"\"{tempA}\" \"{tempB}\" \"{outputPath}\"",
                outputPath,
                expectedOutputDirectory: null,
                inputPathForTimeout: tempA,
                ct: ct);

            var size = new FileInfo(outputPath).Length;
            var totalInput = inputSizeA + inputSizeB;
            await UploadAsync(jobId, "comparepdf", outputPath, "comparison.json", "application/json", totalInput, size, ct);
            metrics.Checkpoint("completed", totalInput, size);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Compare PDF job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            PdfJobStorageService.TryDeleteLocalFile(tempA);
            PdfJobStorageService.TryDeleteLocalFile(tempB);
            PdfJobStorageService.TryDeleteLocalFile(outputPath);
            try { _jobStorage.DeleteStagingAsync(stagingBlobA, ct).GetAwaiter().GetResult(); } catch { }
            try { _jobStorage.DeleteStagingAsync(stagingBlobB, ct).GetAwaiter().GetResult(); } catch { }
        }
    }

    public Task RunFillFormJobAsync(
        string jobId,
        string stagingBlob,
        long inputSize,
        IReadOnlyDictionary<string, string> values,
        bool flatten,
        CancellationToken ct)
        => RunSingleOutputAsync(jobId, "fillform", stagingBlob, inputSize, "filled.pdf", "application/pdf",
            "Filling form fields…",
            path => _fileOps.FillPdfFormFromPath(path, values, flatten),
            ct);

    public Task RunPageNumbersJobAsync(string jobId, string stagingBlob, long inputSize, string format, CancellationToken ct)
        => RunSingleOutputAsync(jobId, "pagenumbers", stagingBlob, inputSize, "numbered.pdf", "application/pdf",
            "Adding page numbers…", path => _fileOps.AddPageNumbersFromPath(path, format: format), ct);

    public async Task RunMetadataJobAsync(string jobId, string stagingBlob, long inputSize, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "pdfmetadata", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 20, "Reading metadata…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            var result = await _fileOps.ExportMetadataToFileAsync(tempInput, ct: ct);
            outputPath = result.FilePath;

            await UploadAsync(jobId, "pdfmetadata", result.FilePath, "metadata.json", "application/json",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Metadata job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    public async Task RunOcrJobAsync(string jobId, string stagingBlob, long inputSize, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "ocrpdf", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing OCR…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            outputPath = PdfTempPaths.NewOutput(".pdf");

            _jobStore.SetProgress(jobId, 40, "Running OCR (page-by-page)…");
            await _python.RunScriptAsync(
                "pdf_ocr_searchable.py",
                $"\"{tempInput}\" \"{outputPath}\"",
                outputPath,
                expectedOutputDirectory: null,
                inputPathForTimeout: tempInput,
                ct: ct);

            var size = new FileInfo(outputPath).Length;
            await UploadAsync(jobId, "ocrpdf", outputPath, "searchable.pdf", "application/pdf", inputSize, size, ct);
            metrics.Checkpoint("completed", inputSize, size);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "OCR job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    public async Task RunPdfToImagesJobAsync(
        string jobId,
        string stagingBlob,
        long inputSize,
        int dpi,
        string format = "jpg",
        int jpegQuality = 90,
        CancellationToken ct = default)
        => await RunDirectoryZipJobAsync(jobId, "pdftoimages", stagingBlob, inputSize, "pages.zip", "application/zip",
            "Rendering pages…", async (input, workDir) =>
            {
                await _python.RunScriptAsync(
                    "pdf_to_images.py",
                    $"\"{input}\" \"{workDir}\" --dpi {dpi} --format {format} --quality {jpegQuality}",
                    expectedOutputPath: null,
                    expectedOutputDirectory: workDir,
                    inputPathForTimeout: input,
                    ct: ct);
            }, ct);

    public async Task RunExtractImagesJobAsync(string jobId, string stagingBlob, long inputSize, CancellationToken ct)
        => await RunDirectoryZipJobAsync(jobId, "extractimages", stagingBlob, inputSize, "images.zip", "application/zip",
            "Extracting images…", async (input, workDir) =>
            {
                await _python.RunScriptAsync(
                    "pdf_extract_images.py",
                    $"\"{input}\" \"{workDir}\"",
                    expectedOutputPath: null,
                    expectedOutputDirectory: workDir,
                    inputPathForTimeout: input,
                    ct: ct);
            }, ct);

    private async Task RunSingleOutputAsync(
        string jobId,
        string jobKind,
        string stagingBlob,
        long inputSize,
        string outputFileName,
        string mimeType,
        string progressMessage,
        Func<string, PdfConversionFileResult> transform,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, jobKind, jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);

            _jobStore.SetProgress(jobId, 50, progressMessage);
            var result = transform(tempInput);
            outputPath = result.FilePath;

            await UploadAsync(jobId, jobKind, result.FilePath, outputFileName, mimeType, inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{JobKind} job {JobId} failed", jobKind, jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, stagingBlob, ct);
        }
    }

    private async Task RunDirectoryZipJobAsync(
        string jobId,
        string jobKind,
        string stagingBlob,
        long inputSize,
        string zipName,
        string mimeType,
        string progressMessage,
        Func<string, string, Task> processToDirectory,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, jobKind, jobId);
        string? tempInput = null;
        string? workDir = null;
        string? zipPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            workDir = Path.Combine(Path.GetTempPath(), $"ratpdf_{Guid.NewGuid():N}");
            Directory.CreateDirectory(workDir);

            _jobStore.SetProgress(jobId, 45, progressMessage);
            await processToDirectory(tempInput, workDir);

            _jobStore.SetProgress(jobId, 80, "Packaging ZIP…");
            zipPath = Path.Combine(Path.GetTempPath(), $"ratpdf_{jobId}.zip");
            await CreateZipFromDirectoryAsync(workDir, zipPath, ct);

            var zipSize = new FileInfo(zipPath).Length;
            await UploadAsync(jobId, jobKind, zipPath, zipName, mimeType, inputSize, zipSize, ct);
            metrics.Checkpoint("completed", inputSize, zipSize);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{JobKind} job {JobId} failed", jobKind, jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, zipPath, stagingBlob, ct);
            if (workDir != null)
            {
                try
                {
                    if (Directory.Exists(workDir))
                        Directory.Delete(workDir, recursive: true);
                }
                catch { }
            }
        }
    }

    private async Task UploadAsync(
        string jobId, string jobKind, string localPath, string outputFileName, string mimeType,
        long inputSize, long outputSize, CancellationToken ct)
    {
        _jobStore.SetProgress(jobId, 90, "Uploading result…");
        var blobName = $"{jobKind}/{jobId}/{outputFileName}";
        await _blobService.UploadFromFileAsync(localPath, blobName, ct);
        _jobStore.SetFileJobCompleted(jobId, blobName, mimeType, outputFileName, inputSize, outputSize, jobKind);
    }

    private static async Task CreateZipFromDirectoryAsync(string sourceDir, string zipPath, CancellationToken ct)
    {
        if (File.Exists(zipPath))
            File.Delete(zipPath);

        await using var zipStream = new FileStream(zipPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 65536, useAsync: true);
        using var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true);

        foreach (var file in Directory.GetFiles(sourceDir))
        {
            ct.ThrowIfCancellationRequested();
            var entry = archive.CreateEntry(Path.GetFileName(file), CompressionLevel.Fastest);
            await using var entryStream = entry.Open();
            await using var source = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, useAsync: true);
            await source.CopyToAsync(entryStream, 65536, ct);
        }
    }

    private void Cleanup(string? localPath, string? outputPath, string stagingBlob, CancellationToken ct)
    {
        PdfJobStorageService.TryDeleteLocalFile(localPath);
        PdfJobStorageService.TryDeleteLocalFile(outputPath);
        try { _jobStorage.DeleteStagingAsync(stagingBlob, ct).GetAwaiter().GetResult(); }
        catch { }
    }
}
