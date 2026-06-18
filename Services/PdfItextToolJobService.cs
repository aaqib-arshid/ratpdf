using System.Text;
using ratpdf.Models;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services;

public class PdfItextToolJobService
{
    private readonly PdfConversionFileOps _fileOps;
    private readonly IJobResultStore _jobStore;
    private readonly AzureBlobService _blobService;
    private readonly PdfJobStorageService _jobStorage;
    private readonly ILogger<PdfItextToolJobService> _logger;

    public PdfItextToolJobService(
        PdfConversionFileOps fileOps,
        IJobResultStore jobStore,
        AzureBlobService blobService,
        PdfJobStorageService jobStorage,
        ILogger<PdfItextToolJobService> logger)
    {
        _fileOps = fileOps;
        _jobStore = jobStore;
        _blobService = blobService;
        _jobStorage = jobStorage;
        _logger = logger;
    }

    public async Task RunMergeJobAsync(
        string jobId,
        IReadOnlyList<(string StagingBlobName, string OriginalName, long Size)> inputs,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "merge", jobId);
        var tempInputs = new List<string>();
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 10, "Preparing files…");
            foreach (var input in inputs)
                tempInputs.Add(await _jobStorage.MaterializeToTempFileAsync(input.StagingBlobName, ".pdf", ct));

            _jobStore.SetProgress(jobId, 40, "Merging PDFs…");
            outputPath = PdfTempPaths.NewOutput(".pdf");
            var result = _fileOps.MergePdfFilesFromPaths(tempInputs, outputPath);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "merge", result.FilePath, "merged.pdf", "application/pdf",
                inputs.Sum(x => x.Size), result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputs.Sum(x => x.Size), result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Merge job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInputs, outputPath, inputs.Select(i => i.StagingBlobName), ct);
        }
    }

    public async Task RunSplitJobAsync(
        string jobId,
        string stagingBlob,
        string originalName,
        long inputSize,
        int startPage,
        int endPage,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "split", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);

            _jobStore.SetProgress(jobId, 45, "Splitting pages…");
            var result = _fileOps.SplitPdfFromPath(tempInput, startPage, endPage);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "split", result.FilePath, "split.pdf", "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Split job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, new[] { stagingBlob }, ct);
        }
    }

    public async Task RunWatermarkJobAsync(
        string jobId, string stagingBlob, string originalName, long inputSize,
        WatermarkOptions options, string? imageStagingBlob, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "watermark", jobId);
        string? tempInput = null;
        string? tempImage = null;
        string? outputPath = null;
        var stagingBlobs = new List<string> { stagingBlob };
        if (imageStagingBlob != null) stagingBlobs.Add(imageStagingBlob);

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            if (options.Mode == "image" && imageStagingBlob != null)
            {
                tempImage = await _jobStorage.MaterializeToTempFileAsync(imageStagingBlob, ".png", ct);
                options = new WatermarkOptions
                {
                    Mode = options.Mode,
                    Text = options.Text,
                    ImagePath = tempImage,
                    Opacity = options.Opacity,
                    FontSize = options.FontSize,
                    RotationDegrees = options.RotationDegrees,
                    Pages = options.Pages,
                    PageStart = options.PageStart,
                    PageEnd = options.PageEnd,
                    Layout = options.Layout,
                };
            }

            _jobStore.SetProgress(jobId, 50, "Applying watermark…");
            var result = _fileOps.AddWatermarkFromPath(tempInput, options);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "watermark", result.FilePath, "watermarked.pdf", "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "watermark job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            if (tempImage != null) PdfJobStorageService.TryDeleteLocalFile(tempImage);
            Cleanup(tempInput != null ? new[] { tempInput } : Array.Empty<string>(),
                outputPath, stagingBlobs, ct);
        }
    }

    public async Task RunWatermarkJobAsync(
        string jobId, string stagingBlob, string originalName, long inputSize, string watermarkText, CancellationToken ct)
        => await RunWatermarkJobAsync(jobId, stagingBlob, originalName, inputSize,
            new WatermarkOptions { Mode = "text", Text = watermarkText }, null, ct);

    public async Task RunPasswordJobAsync(
        string jobId, string stagingBlob, long inputSize, string password, CancellationToken ct)
        => await RunSinglePdfTransformAsync(jobId, "password", stagingBlob, inputSize, "protected.pdf",
            "Encrypting PDF…", ct,
            path => _fileOps.AddPasswordFromPath(path, password));

    public async Task RunSignJobAsync(
        string jobId, string stagingBlob, long inputSize,
        SignPdfOptions options, string? signatureImageStagingBlob, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "signpdf", jobId);
        string? tempInput = null;
        string? tempImage = null;
        string? outputPath = null;
        var stagingBlobs = new List<string> { stagingBlob };
        if (signatureImageStagingBlob != null) stagingBlobs.Add(signatureImageStagingBlob);

        try
        {
            _jobStore.SetProgress(jobId, 15, "Preparing file…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            if (options.Mode != "typed" && signatureImageStagingBlob != null)
            {
                var ext = Path.GetExtension(signatureImageStagingBlob);
                if (string.IsNullOrEmpty(ext)) ext = ".png";
                tempImage = await _jobStorage.MaterializeToTempFileAsync(signatureImageStagingBlob, ext, ct);
                options = new SignPdfOptions
                {
                    Mode = options.Mode,
                    Name = options.Name,
                    ImagePath = tempImage,
                    PageTarget = options.PageTarget,
                    PageNumber = options.PageNumber,
                    Position = options.Position,
                    FontStyle = options.FontStyle,
                    IncludeDate = options.IncludeDate,
                };
            }

            _jobStore.SetProgress(jobId, 50, "Adding signature…");
            var result = _fileOps.SignPdfFromPath(tempInput, options);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "signpdf", result.FilePath, "signed.pdf", "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "signpdf job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            if (tempImage != null) PdfJobStorageService.TryDeleteLocalFile(tempImage);
            Cleanup(tempInput != null ? new[] { tempInput } : Array.Empty<string>(),
                outputPath, stagingBlobs, ct);
        }
    }

    public async Task RunSignJobAsync(
        string jobId, string stagingBlob, long inputSize, string name, CancellationToken ct)
        => await RunSignJobAsync(jobId, stagingBlob, inputSize,
            new SignPdfOptions { Mode = "typed", Name = name }, null, ct);

    public async Task RunRotateJobAsync(
        string jobId, string stagingBlob, long inputSize, int pageNumber, int degree, CancellationToken ct)
        => await RunSinglePdfTransformAsync(jobId, "rotate", stagingBlob, inputSize, "rotated.pdf",
            "Rotating page…", ct,
            path => _fileOps.RotatePageFromPath(path, pageNumber, degree));

    public async Task RunRemovePageJobAsync(
        string jobId, string stagingBlob, long inputSize, int pageNumber, CancellationToken ct)
        => await RunSinglePdfTransformAsync(jobId, "rotate", stagingBlob, inputSize, "edited.pdf",
            "Removing page…", ct,
            path => _fileOps.RemovePageFromPath(path, pageNumber));

    public async Task RunCropJobAsync(
        string jobId,
        string stagingBlob,
        long inputSize,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft,
        CancellationToken ct)
        => await RunSinglePdfTransformAsync(jobId, "crop", stagingBlob, inputSize, "cropped.pdf",
            "Cropping PDF…", ct,
            path => _fileOps.CropPdfFromPath(path, marginTop, marginRight, marginBottom, marginLeft));

    public async Task RunOrganizeJobAsync(
        string jobId,
        string stagingBlob,
        long inputSize,
        IReadOnlyList<int> pageOrder,
        CancellationToken ct)
        => await RunSinglePdfTransformAsync(jobId, "organize", stagingBlob, inputSize, "organized.pdf",
            "Organizing pages…", ct,
            path => _fileOps.ReorderPagesFromPath(path, pageOrder));

    public async Task RunConvertImagesJobAsync(
        string jobId,
        IReadOnlyList<(string StagingBlobName, string OriginalName, long Size)> inputs,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "convertimages", jobId);
        var tempInputs = new List<string>();
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 10, "Preparing images…");
            foreach (var input in inputs)
            {
                var ext = Path.GetExtension(input.OriginalName);
                if (string.IsNullOrEmpty(ext)) ext = ".img";
                tempInputs.Add(await _jobStorage.MaterializeToTempFileAsync(input.StagingBlobName, ext, ct));
            }

            _jobStore.SetProgress(jobId, 50, "Building PDF…");
            var result = _fileOps.ConvertImagesToPdfFromPaths(tempInputs);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "convertimages", result.FilePath, "images.pdf", "application/pdf",
                inputs.Sum(x => x.Size), result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputs.Sum(x => x.Size), result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Convert images job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInputs, outputPath, inputs.Select(i => i.StagingBlobName), ct);
        }
    }

    public async Task RunTextToPdfJobAsync(
        string jobId,
        string? stagingBlob,
        long inputSize,
        string? typedHtml,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "texttopdf", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 20, "Creating PDF…");
            PdfConversionFileResult result;

            if (!string.IsNullOrEmpty(stagingBlob))
            {
                tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".txt", ct);
                var text = await File.ReadAllTextAsync(tempInput, ct);
                result = _fileOps.ConvertTextToPdfFile(text);
            }
            else
            {
                result = _fileOps.ConvertHtmlToPdfFile(typedHtml ?? "<p></p>");
            }

            outputPath = result.FilePath;
            await UploadResultAsync(jobId, "texttopdf", result.FilePath, "document.pdf", "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Text to PDF job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            var staging = stagingBlob == null ? Enumerable.Empty<string>() : new[] { stagingBlob };
            Cleanup(tempInput, outputPath, staging, ct);
        }
    }

    public async Task RunHtmlToPdfJobAsync(
        string jobId,
        string? stagingBlob,
        long inputSize,
        string? htmlContent,
        CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "htmltopdf", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 20, "Rendering HTML to PDF…");
            string html;
            if (!string.IsNullOrEmpty(stagingBlob))
            {
                tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".html", ct);
                html = await File.ReadAllTextAsync(tempInput, ct);
            }
            else
            {
                html = htmlContent ?? "<p></p>";
            }

            if (!html.Contains("<html", StringComparison.OrdinalIgnoreCase))
                html = $"<html><head><meta charset=\"utf-8\"/></head><body>{html}</body></html>";

            var result = _fileOps.ConvertHtmlToPdfFile(html);
            outputPath = result.FilePath;
            await UploadResultAsync(jobId, "htmltopdf", result.FilePath, "document.pdf", "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HTML to PDF job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            var staging = stagingBlob == null ? Enumerable.Empty<string>() : new[] { stagingBlob };
            Cleanup(tempInput, outputPath, staging, ct);
        }
    }

    public async Task RunPdfToTextJobAsync(
        string jobId, string stagingBlob, string originalName, long inputSize, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "pdftotext", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Extracting text…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            var result = await _fileOps.ExtractTextToFileAsync(tempInput, originalName, ct: ct);
            outputPath = result.FilePath;

            await UploadResultAsync(jobId, "pdftotext", result.FilePath, "extracted.txt", "text/plain",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "PDF to text job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, new[] { stagingBlob }, ct);
        }
    }

    public async Task RunPdfToMarkdownJobAsync(
        string jobId, string stagingBlob, string originalName, long inputSize, CancellationToken ct)
    {
        using var metrics = PdfProcessingMetrics.Start(_logger, "pdftomarkdown", jobId);
        string? tempInput = null;
        string? outputPath = null;

        try
        {
            _jobStore.SetProgress(jobId, 15, "Extracting text…");
            tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
            var textResult = await _fileOps.ExtractTextToFileAsync(tempInput, originalName, ct: ct);
            var rawText = await File.ReadAllTextAsync(textResult.FilePath, ct);
            var markdown = PdfMarkdownConverter.FromExtractedText(rawText, Path.GetFileNameWithoutExtension(originalName));

            outputPath = PdfTempPaths.NewOutput(".md");
            await File.WriteAllTextAsync(outputPath, markdown, Encoding.UTF8, ct);
            var size = new FileInfo(outputPath).Length;

            await UploadResultAsync(jobId, "pdftomarkdown", outputPath, "document.md", "text/markdown",
                inputSize, size, ct);
            metrics.Checkpoint("completed", inputSize, size);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "PDF to Markdown job {JobId} failed", jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, new[] { stagingBlob }, ct);
        }
    }

    private async Task RunSinglePdfTransformAsync(
        string jobId,
        string jobKind,
        string stagingBlob,
        long inputSize,
        string outputFileName,
        string progressMessage,
        CancellationToken ct,
        Func<string, PdfConversionFileResult> transform)
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

            await UploadResultAsync(jobId, jobKind, result.FilePath, outputFileName, "application/pdf",
                inputSize, result.SizeBytes, ct);
            metrics.Checkpoint("completed", inputSize, result.SizeBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{JobKind} job {JobId} failed", jobKind, jobId);
            _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
        }
        finally
        {
            Cleanup(tempInput, outputPath, new[] { stagingBlob }, ct);
        }
    }

    private async Task UploadResultAsync(
        string jobId,
        string jobKind,
        string localPath,
        string outputFileName,
        string mimeType,
        long inputSize,
        long outputSize,
        CancellationToken ct)
    {
        _jobStore.SetProgress(jobId, 90, "Uploading result…");
        var blobName = $"{jobKind}/{jobId}/{outputFileName}";
        await _blobService.UploadFromFileAsync(localPath, blobName, ct);
        _jobStore.SetFileJobCompleted(jobId, blobName, mimeType, outputFileName, inputSize, outputSize, jobKind);
    }

    private void Cleanup(
        IEnumerable<string> localPaths,
        string? outputPath,
        IEnumerable<string> stagingBlobs,
        CancellationToken ct)
    {
        foreach (var path in localPaths)
            PdfJobStorageService.TryDeleteLocalFile(path);
        PdfJobStorageService.TryDeleteLocalFile(outputPath);
        foreach (var blob in stagingBlobs)
        {
            try { _jobStorage.DeleteStagingAsync(blob, ct).GetAwaiter().GetResult(); }
            catch { }
        }
    }

    private void Cleanup(
        string? localPath,
        string? outputPath,
        IEnumerable<string> stagingBlobs,
        CancellationToken ct)
        => Cleanup(localPath == null ? Array.Empty<string>() : new[] { localPath }, outputPath, stagingBlobs, ct);
}
