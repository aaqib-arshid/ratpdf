using iText.Forms;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using ratpdf.Services.PdfProcessing;
using System.Text;
using System.Text.Json;

namespace ratpdf.Services;

/// <summary>Disk-based PDF operations — constant memory regardless of file size.</summary>
public class PdfConversionFileOps
{
    private readonly PdfTextProcessor _pdfTextProcessor;
    private readonly ILogger<PdfConversionFileOps> _logger;

    public PdfConversionFileOps(PdfTextProcessor pdfTextProcessor, ILogger<PdfConversionFileOps> logger)
    {
        _pdfTextProcessor = pdfTextProcessor;
        _logger = logger;
    }

    private static iText.Kernel.Pdf.PdfReader OpenPermissiveReader(Stream stream)
    {
        var reader = new iText.Kernel.Pdf.PdfReader(stream);
        reader.SetUnethicalReading(true);
        return reader;
    }

    public PdfConversionFileResult MergePdfFilesFromPaths(
        IReadOnlyList<string> inputPaths, string? outputPath = null)
    {
        if (inputPaths.Count < 2)
            throw new ArgumentException("Select at least 2 PDF files to merge.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(writer);

        foreach (var path in inputPaths)
        {
            using var inputStream = OpenReadStream(path);
            using var pdfReader = OpenPermissiveReader(inputStream);
            using var readerPdf = new PdfDocument(pdfReader);
            readerPdf.CopyPagesTo(1, readerPdf.GetNumberOfPages(), pdfDoc);
        }

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult SplitPdfFromPath(
        string inputPath, int startPage, int endPage, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(writer);

        using var splitStream = OpenReadStream(inputPath);
        using var splitReader = OpenPermissiveReader(splitStream);
        using var reader = new PdfDocument(splitReader);
        var totalPages = reader.GetNumberOfPages();

        if (startPage < 1 || endPage > totalPages || startPage > endPage)
            throw new ArgumentException("Invalid page range.");

        reader.CopyPagesTo(startPage, endPage, pdfDoc);
        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult AddWatermarkFromPath(
        string inputPath, string watermarkText, string? outputPath = null)
    {
        if (string.IsNullOrWhiteSpace(watermarkText))
            throw new ArgumentException("Watermark text is required.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var wmStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(wmStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        const float fontSize = 42f;
        var angle = (float)(-Math.PI / 4);

        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
        {
            var page = pdfDoc.GetPage(i);
            var canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
            var pageSize = page.GetPageSize();

            canvas.SaveState();
            canvas.SetFillColor(new DeviceGray(0.82f));
            canvas.BeginText();
            canvas.SetFontAndSize(font, fontSize);

            var cx = pageSize.GetWidth() / 2;
            var cy = pageSize.GetHeight() / 2;
            canvas.SetTextMatrix(
                (float)Math.Cos(angle), (float)Math.Sin(angle),
                -(float)Math.Sin(angle), (float)Math.Cos(angle),
                cx, cy);
            canvas.ShowText(watermarkText);
            canvas.EndText();
            canvas.RestoreState();
        }

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult AddPasswordFromPath(
        string inputPath, string password, string? outputPath = null)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be empty.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pwStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(pwStream);
        var writerProperties = new WriterProperties()
            .SetStandardEncryption(
                Encoding.UTF8.GetBytes(password),
                null,
                EncryptionConstants.ALLOW_PRINTING,
                EncryptionConstants.ENCRYPTION_AES_128 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA);

        using var writer = new PdfWriter(outputPath, writerProperties);
        using var pdfDoc = new PdfDocument(reader, writer);
        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult SignPdfFromPath(
        string inputPath, string name, string? outputPath = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pdfStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(pdfStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);
        using var document = new iText.Layout.Document(pdfDoc);

        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);
        var lastPage = pdfDoc.GetNumberOfPages();
        var pageSize = pdfDoc.GetPage(lastPage).GetPageSize();
        var sigWidth = Math.Min(220f, pageSize.GetWidth() * 0.45f);
        var sigX = pageSize.GetWidth() - sigWidth - 48f;

        var signature = new Paragraph(name)
            .SetFont(font)
            .SetFontSize(22)
            .SetFontColor(ColorConstants.DARK_GRAY)
            .SetTextAlignment(TextAlignment.RIGHT)
            .SetFixedPosition(lastPage, sigX, 56f, sigWidth);

        document.Add(signature);
        document.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult RotatePageFromPath(
        string inputPath, int pageNumber, int rotationDegree, string? outputPath = null)
    {
        if (rotationDegree % 90 != 0)
            throw new ArgumentException("Rotation degree must be a multiple of 90.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var rotStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(rotStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.GetNumberOfPages() - 1);
        var page = pdfDoc.GetPage(pageNumber + 1);
        page.SetRotation((page.GetRotation() + rotationDegree) % 360);

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult RemovePageFromPath(
        string inputPath, int pageNumber, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var rmStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(rmStream);
        using var src = new PdfDocument(reader);
        var total = src.GetNumberOfPages();
        pageNumber = Math.Clamp(pageNumber, 0, total - 1);

        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var dest = new PdfDocument(writer);

        var pagesToCopy = Enumerable.Range(1, total).Where(p => p != pageNumber + 1).ToList();
        if (pagesToCopy.Count == 0)
            throw new ArgumentException("Cannot remove the only page in the document.");

        foreach (var p in pagesToCopy)
            src.CopyPagesTo(p, p, dest);

        dest.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult ConvertImagesToPdfFromPaths(
        IReadOnlyList<string> imagePaths, string? outputPath = null)
    {
        if (imagePaths.Count == 0)
            throw new ArgumentException("No images provided.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdf = new PdfDocument(writer);
        using var document = new iText.Layout.Document(pdf, iText.Kernel.Geom.PageSize.A4);
        document.SetMargins(36, 36, 36, 36);

        var maxW = iText.Kernel.Geom.PageSize.A4.GetWidth() - 72;
        var maxH = iText.Kernel.Geom.PageSize.A4.GetHeight() - 72;

        for (var i = 0; i < imagePaths.Count; i++)
        {
            var imgData = iText.IO.Image.ImageDataFactory.Create(imagePaths[i]);
            var img = new Image(imgData);
            img.ScaleToFit(maxW, maxH);
            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            document.Add(img);

            if (i < imagePaths.Count - 1)
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
        }

        document.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult ConvertTextToPdfFile(string text, string? outputPath = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text content is empty.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var writer = new PdfWriter(outputPath);
        using var pdfDoc = new PdfDocument(writer);
        var document = new iText.Layout.Document(pdfDoc);

        foreach (var line in text.Split('\n'))
            document.Add(new Paragraph(line));

        document.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult ConvertHtmlToPdfFile(string html, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pdfWriter = new PdfWriter(outputPath);
        using var pdfDocument = new PdfDocument(pdfWriter);
        pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);

        var converterProperties = new ConverterProperties();
        var fontProvider = new DefaultFontProvider(true, true, true);
        var notoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "NotoSans-Regular.ttf");
        if (File.Exists(notoPath))
            fontProvider.AddFont(notoPath);
        converterProperties.SetFontProvider(fontProvider);
        converterProperties.SetBaseUri(AppDomain.CurrentDomain.BaseDirectory);

        HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);
        pdfDocument.Close();
        return ToResult(outputPath);
    }

    public async Task<PdfConversionFileResult> ExtractTextToFileAsync(
        string inputPath, string originalName, string? outputPath = null, CancellationToken ct = default)
    {
        outputPath ??= PdfTempPaths.NewOutput(".txt");
        string text;

        try
        {
            await using var stream = OpenReadStream(inputPath);
            text = await _pdfTextProcessor.ExtractTextAsync(stream, originalName, ct);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Python text extraction failed for {File}, falling back to iText", originalName);
            text = ExtractTextLegacy(inputPath);
        }

        await File.WriteAllTextAsync(outputPath, text, Encoding.UTF8, ct);
        return ToResult(outputPath);
    }

    private static string ExtractTextLegacy(string inputPath)
    {
        using var legacyStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(legacyStream);
        using var pdfDoc = new PdfDocument(reader);
        var sb = new StringBuilder();

        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
        {
            sb.AppendLine($"--- Page {i} ---");
            sb.AppendLine(iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static FileStream OpenReadStream(string path) =>
        new(path, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.Asynchronous);

    public PdfConversionFileResult AddTextFromPath(
        string pdfPath, string text, int pageNumber = 0, float x = 50, float y = 50, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);

        pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
        var page = pdfDoc.Pages[pageNumber];
        using var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Helvetica Oblique", 24, XFontStyle.Italic);
        gfx.DrawString(text, font, XBrushes.Black, new XPoint(x, y));

        pdfDoc.Save(outputPath);
        return ToResult(outputPath);
    }

    public PdfConversionFileResult AddImageFromPath(
        string pdfPath, string imagePath, int pageNumber = 0,
        float x = 50, float y = 50, float width = 200, float height = 200, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);

        pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
        var page = pdfDoc.Pages[pageNumber];
        using var gfx = XGraphics.FromPdfPage(page);
        using var imgStream = OpenReadStream(imagePath);
        var img = XImage.FromStream(() => imgStream);
        gfx.DrawImage(img, x, y, width, height);

        pdfDoc.Save(outputPath);
        return ToResult(outputPath);
    }

    public PdfConversionFileResult UnlockPdfFromPath(
        string inputPath, string? password, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        var readerProps = new ReaderProperties();
        if (!string.IsNullOrEmpty(password))
            readerProps.SetPassword(Encoding.UTF8.GetBytes(password));

        using var fs = OpenReadStream(inputPath);
        using var reader = new iText.Kernel.Pdf.PdfReader(fs, readerProps);
        reader.SetUnethicalReading(true);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);
        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult FlattenPdfFromPath(string inputPath, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        var form = PdfAcroForm.GetAcroForm(pdfDoc, false);
        if (form != null)
            form.FlattenFields();

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult AddPageNumbersFromPath(
        string inputPath, string? outputPath = null, string format = "{page}")
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        var total = pdfDoc.GetNumberOfPages();

        for (int i = 1; i <= total; i++)
        {
            var page = pdfDoc.GetPage(i);
            var pageSize = page.GetPageSize();
            var label = format.Replace("{page}", i.ToString()).Replace("{total}", total.ToString());
            var canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
            canvas.BeginText();
            canvas.SetFontAndSize(font, 10);
            canvas.MoveText(pageSize.GetWidth() / 2 - (label.Length * 3), 24);
            canvas.ShowText(label);
            canvas.EndText();
        }

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public async Task<PdfConversionFileResult> ExportMetadataToFileAsync(
        string inputPath, string? outputPath = null, CancellationToken ct = default)
    {
        outputPath ??= PdfTempPaths.NewOutput(".json");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var pdfDoc = new PdfDocument(reader);

        var info = pdfDoc.GetDocumentInfo();
        var meta = new
        {
            pageCount = pdfDoc.GetNumberOfPages(),
            title = info.GetTitle(),
            author = info.GetAuthor(),
            subject = info.GetSubject(),
            keywords = info.GetKeywords(),
            creator = info.GetCreator(),
            producer = info.GetProducer(),
            fileSizeBytes = new FileInfo(inputPath).Length,
        };

        await File.WriteAllTextAsync(
            outputPath,
            JsonSerializer.Serialize(meta, new JsonSerializerOptions { WriteIndented = true }),
            ct);
        return ToResult(outputPath);
    }

    private static PdfConversionFileResult ToResult(string path) =>
        new(path, new FileInfo(path).Length);
}
