using iText.IO.Image;
using iText.Forms;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using ratpdf.Models;
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
        => AddWatermarkFromPath(inputPath, new WatermarkOptions { Mode = "text", Text = watermarkText }, outputPath);

    public PdfConversionFileResult AddWatermarkFromPath(
        string inputPath, WatermarkOptions options, string? outputPath = null)
    {
        if (options.Mode == "image")
        {
            if (string.IsNullOrWhiteSpace(options.ImagePath))
                throw new ArgumentException("Watermark image is required.");
        }
        else if (string.IsNullOrWhiteSpace(options.Text))
        {
            throw new ArgumentException("Watermark text is required.");
        }

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var wmStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(wmStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        var opacity = Math.Clamp(options.Opacity, 0.05f, 1f);
        foreach (var pageNum in ResolveWatermarkPages(pdfDoc, options))
        {
            var page = pdfDoc.GetPage(pageNum);
            var pageSize = page.GetPageSize();

            if (options.Mode == "image")
                ApplyImageWatermark(pdfDoc, page, pageSize, options.ImagePath!, opacity, options.Layout);
            else
                ApplyTextWatermark(pdfDoc, page, pageSize, options.Text!, opacity, options);
        }

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    private static IEnumerable<int> ResolveWatermarkPages(PdfDocument pdfDoc, WatermarkOptions options)
    {
        var total = pdfDoc.GetNumberOfPages();
        return options.Pages?.ToLowerInvariant() switch
        {
            "first" => [1],
            "range" =>
            [
                ..Enumerable.Range(
                    Math.Clamp(options.PageStart, 1, total),
                    Math.Max(1, Math.Clamp(options.PageEnd, options.PageStart, total)
                        - Math.Clamp(options.PageStart, 1, total) + 1))
            ],
            _ => Enumerable.Range(1, total),
        };
    }

    private static void ApplyTextWatermark(
        PdfDocument pdfDoc, PdfPage page, Rectangle pageSize,
        string text, float opacity, WatermarkOptions options)
    {
        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        var fontSize = Math.Clamp(options.FontSize, 12f, 120f);
        var rotation = options.RotationDegrees;
        var layout = options.Layout?.ToLowerInvariant() ?? "diagonal";

        if (layout == "tile")
        {
            var canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
            canvas.SaveState();
            canvas.SetFillColor(new DeviceGray(0.75f));
            var gs = new iText.Kernel.Pdf.Extgstate.PdfExtGState().SetFillOpacity(opacity);
            canvas.SetExtGState(gs);
            canvas.BeginText();
            canvas.SetFontAndSize(font, fontSize * 0.65f);
            var stepX = fontSize * 4.5f;
            var stepY = fontSize * 3.5f;
            var angleRad = rotation * Math.PI / 180;
            var cos = (float)Math.Cos(angleRad);
            var sin = (float)Math.Sin(angleRad);
            for (var y = -pageSize.GetHeight(); y < pageSize.GetHeight() * 2; y += stepY)
            {
                for (var x = -pageSize.GetWidth(); x < pageSize.GetWidth() * 2; x += stepX)
                {
                    canvas.SetTextMatrix(cos, sin, -sin, cos, x, y);
                    canvas.ShowText(text);
                }
            }
            canvas.EndText();
            canvas.RestoreState();
            return;
        }

        var pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
        using var layoutCanvas = new iText.Layout.Canvas(pdfCanvas, pageSize);
        layoutCanvas.SetOpacity(opacity);
        var paragraph = new Paragraph(text)
            .SetFont(font)
            .SetFontSize(fontSize)
            .SetFontColor(ColorConstants.LIGHT_GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetRotationAngle(rotation);

        if (layout == "horizontal")
        {
            layoutCanvas.ShowTextAligned(
                paragraph, pageSize.GetWidth() / 2, pageSize.GetHeight() / 2,
                TextAlignment.CENTER, VerticalAlignment.MIDDLE);
        }
        else
        {
            layoutCanvas.ShowTextAligned(
                paragraph, pageSize.GetWidth() / 2, pageSize.GetHeight() / 2,
                TextAlignment.CENTER, VerticalAlignment.MIDDLE);
        }
    }

    private static void ApplyImageWatermark(
        PdfDocument pdfDoc, PdfPage page, Rectangle pageSize,
        string imagePath, float opacity, string layout)
    {
        var imgData = ImageDataFactory.Create(imagePath);
        var canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
        canvas.SaveState();
        var gs = new iText.Kernel.Pdf.Extgstate.PdfExtGState().SetFillOpacity(opacity);
        canvas.SetExtGState(gs);

        var maxW = pageSize.GetWidth() * 0.35f;
        var maxH = pageSize.GetHeight() * 0.35f;
        var scale = Math.Min(maxW / imgData.GetWidth(), maxH / imgData.GetHeight());
        var drawW = imgData.GetWidth() * scale;
        var drawH = imgData.GetHeight() * scale;

        if (layout?.ToLowerInvariant() == "tile")
        {
            var stepX = drawW * 1.4f;
            var stepY = drawH * 1.4f;
            for (var y = 0f; y < pageSize.GetHeight(); y += stepY)
            {
                for (var x = 0f; x < pageSize.GetWidth(); x += stepX)
                    canvas.AddImageFittedIntoRectangle(imgData, new Rectangle(x, y, drawW, drawH), false);
            }
        }
        else
        {
            var x = (pageSize.GetWidth() - drawW) / 2;
            var y = (pageSize.GetHeight() - drawH) / 2;
            canvas.AddImageFittedIntoRectangle(imgData, new Rectangle(x, y, drawW, drawH), false);
        }

        canvas.RestoreState();
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
        => SignPdfFromPath(inputPath, new SignPdfOptions { Mode = "typed", Name = name }, outputPath);

    public PdfConversionFileResult SignPdfFromPath(
        string inputPath, SignPdfOptions options, string? outputPath = null)
    {
        if (options.Mode == "typed" && string.IsNullOrWhiteSpace(options.Name))
            throw new ArgumentException("Name cannot be empty.");
        if (options.Mode != "typed" && string.IsNullOrWhiteSpace(options.ImagePath))
            throw new ArgumentException("Signature image is required.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var pdfStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(pdfStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        var pages = ResolveSignPages(pdfDoc, options).ToList();
        if (options.Mode == "typed")
        {
            using var document = new iText.Layout.Document(pdfDoc);
            foreach (var pageNum in pages)
                ApplyTypedSignature(document, pdfDoc, pageNum, options);
        }
        else
        {
            foreach (var pageNum in pages)
                ApplyImageSignature(pdfDoc, pageNum, options);
            pdfDoc.Close();
        }

        return ToResult(outputPath);
    }

    private static IEnumerable<int> ResolveSignPages(PdfDocument pdfDoc, SignPdfOptions options)
    {
        var total = pdfDoc.GetNumberOfPages();
        return options.PageTarget?.ToLowerInvariant() switch
        {
            "first" => [1],
            "all" => Enumerable.Range(1, total),
            "page" => [Math.Clamp(options.PageNumber, 1, total)],
            _ => [total],
        };
    }

    private static void ApplyImageSignature(PdfDocument pdfDoc, int pageNum, SignPdfOptions options)
    {
        var page = pdfDoc.GetPage(pageNum);
        var pageSize = page.GetPageSize();
        const float margin = 48f;

        var imgData = ImageDataFactory.Create(options.ImagePath!);
        var maxWidth = Math.Min(220f, pageSize.GetWidth() * 0.45f);
        var maxHeight = Math.Min(90f, pageSize.GetHeight() * 0.18f);
        var scale = Math.Min(maxWidth / imgData.GetWidth(), maxHeight / imgData.GetHeight());
        if (scale <= 0) scale = 1f;
        var drawW = imgData.GetWidth() * scale;
        var drawH = imgData.GetHeight() * scale;
        var (x, y) = ResolveSignCoords(pageSize, options.Position, drawW, drawH, margin);

        var canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
        canvas.AddImageFittedIntoRectangle(imgData, new Rectangle(x, y, drawW, drawH), false);

        if (options.IncludeDate)
            StampDateLine(pdfDoc, pageNum, x, y - 16f, drawW);
    }

    private static void ApplyTypedSignature(
        iText.Layout.Document document, PdfDocument pdfDoc, int pageNum, SignPdfOptions options)
    {
        var pageSize = pdfDoc.GetPage(pageNum).GetPageSize();
        const float margin = 48f;
        var (font, fontSize) = ResolveSignFont(options.FontStyle);
        var sigWidth = Math.Min(260f, pageSize.GetWidth() * 0.55f);
        var name = options.Name!.Trim();
        var textHeight = fontSize * 1.4f;
        var (sigX, sigY) = ResolveSignCoords(pageSize, options.Position, sigWidth, textHeight, margin);

        var signature = new Paragraph(name)
            .SetFont(font)
            .SetFontSize(fontSize)
            .SetFontColor(ColorConstants.DARK_GRAY)
            .SetTextAlignment(options.Position == "bottom-left" ? TextAlignment.LEFT : TextAlignment.RIGHT)
            .SetFixedPosition(pageNum, sigX, sigY, sigWidth);
        document.Add(signature);

        if (options.IncludeDate)
            StampDateLine(pdfDoc, pageNum, sigX, sigY - 14f, sigWidth);
    }

    private static (PdfFont font, float size) ResolveSignFont(string style) =>
        style?.ToLowerInvariant() switch
        {
            "classic" => (PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC), 22f),
            "modern" => (PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 20f),
            _ => (PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE), 24f),
        };

    private static (float x, float y) ResolveSignCoords(
        Rectangle pageSize, string position, float width, float height, float margin) =>
        position?.ToLowerInvariant() switch
        {
            "bottom-left" => (margin, margin),
            "center" => ((pageSize.GetWidth() - width) / 2, (pageSize.GetHeight() - height) / 2),
            _ => (pageSize.GetWidth() - width - margin, margin),
        };

    private static void StampDateLine(PdfDocument pdfDoc, int pageNum, float x, float y, float width)
    {
        var page = pdfDoc.GetPage(pageNum);
        var dateText = DateTime.UtcNow.ToString("MMMM d, yyyy");
        var pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
        var rect = new Rectangle(x, Math.Max(12f, y), width, 14);
        using var layoutCanvas = new iText.Layout.Canvas(pdfCanvas, rect);
        layoutCanvas.Add(new Paragraph(dateText)
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
            .SetFontSize(10)
            .SetFontColor(ColorConstants.GRAY)
            .SetMargin(0)
            .SetPadding(0));
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

    public PdfConversionFileResult CropPdfFromPath(
        string inputPath,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft,
        string? outputPath = null)
    {
        if (marginTop < 0 || marginRight < 0 || marginBottom < 0 || marginLeft < 0)
            throw new ArgumentException("Margins cannot be negative.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var cropStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(cropStream);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);

        for (var i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
        {
            var page = pdfDoc.GetPage(i);
            var pageSize = page.GetPageSize();
            var width = pageSize.GetWidth() - marginLeft - marginRight;
            var height = pageSize.GetHeight() - marginTop - marginBottom;

            if (width <= 1 || height <= 1)
                throw new ArgumentException("Crop margins are too large for one or more pages.");

            var rect = new Rectangle(marginLeft, marginBottom, width, height);
            page.SetMediaBox(rect);
            page.SetCropBox(rect);
        }

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    public PdfConversionFileResult ReorderPagesFromPath(
        string inputPath, IReadOnlyList<int> pageOrderZeroBased, string? outputPath = null)
    {
        if (pageOrderZeroBased == null || pageOrderZeroBased.Count == 0)
            throw new ArgumentException("Select at least one page.");

        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var srcStream = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(srcStream);
        using var src = new PdfDocument(reader);
        var total = src.GetNumberOfPages();

        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var dest = new PdfDocument(writer);

        foreach (var idx in pageOrderZeroBased)
        {
            if (idx < 0 || idx >= total)
                throw new ArgumentException($"Invalid page index: {idx}.");
            var pageNum = idx + 1;
            src.CopyPagesTo(pageNum, pageNum, dest);
        }

        dest.Close();
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
        var notoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "NotoSans-Regular.ttf");
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

    /// <summary>Rebuild PDF for archival use — copies pages into a self-contained file with PDF/A-friendly version.</summary>
    public PdfConversionFileResult ConvertToPdfAFromPath(string inputPath, bool pdfA2 = false, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var src = new PdfDocument(reader);
        var pageCount = src.GetNumberOfPages();
        if (pageCount == 0)
            throw new InvalidOperationException("PDF has no readable pages.");

        var writerProps = new WriterProperties()
            .UseSmartMode()
            .SetPdfVersion(pdfA2 ? PdfVersion.PDF_1_7 : PdfVersion.PDF_1_4);

        using var writer = new PdfWriter(outputPath, writerProps);
        using var dest = new PdfDocument(writer);
        src.CopyPagesTo(1, pageCount, dest);

        var info = dest.GetDocumentInfo();
        info.SetProducer("RatPDF PDF/A Converter");
        info.SetKeywords($"PDF/A-{(pdfA2 ? "2" : "1")}b");

        dest.Close();
        return ToResult(outputPath);
    }

    /// <summary>Rebuild PDF by copying pages into a fresh file — fixes many xref/structure errors.</summary>
    public PdfConversionFileResult RepairPdfFromPath(string inputPath, string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var src = new PdfDocument(reader);
        var pageCount = src.GetNumberOfPages();
        if (pageCount == 0)
            throw new InvalidOperationException("PDF has no readable pages.");

        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var dest = new PdfDocument(writer);
        src.CopyPagesTo(1, pageCount, dest);
        dest.Close();
        return ToResult(outputPath);
    }

    public sealed record PdfFormFieldInfo(string Name, string Type, string? Value);

    public IReadOnlyList<PdfFormFieldInfo> ListFormFieldsFromPath(string inputPath)
    {
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var pdfDoc = new PdfDocument(reader);
        var form = PdfAcroForm.GetAcroForm(pdfDoc, false);
        if (form == null)
            return Array.Empty<PdfFormFieldInfo>();

        var fields = new List<PdfFormFieldInfo>();
        foreach (var entry in form.GetAllFormFields())
        {
            var field = entry.Value;
            fields.Add(new PdfFormFieldInfo(
                entry.Key,
                field.GetFormType().ToString(),
                field.GetValueAsString()));
        }

        return fields;
    }

    public PdfConversionFileResult FillPdfFormFromPath(
        string inputPath,
        IReadOnlyDictionary<string, string> values,
        bool flatten = false,
        string? outputPath = null)
    {
        outputPath ??= PdfTempPaths.NewOutput(".pdf");
        using var fs = OpenReadStream(inputPath);
        using var reader = OpenPermissiveReader(fs);
        using var writer = new PdfWriter(outputPath, new WriterProperties().UseSmartMode());
        using var pdfDoc = new PdfDocument(reader, writer);
        var form = PdfAcroForm.GetAcroForm(pdfDoc, true)
            ?? throw new InvalidOperationException("This PDF has no fillable form fields.");

        foreach (var kv in values)
        {
            var field = form.GetField(kv.Key);
            if (field != null)
                field.SetValue(kv.Value ?? string.Empty);
        }

        if (flatten)
            form.FlattenFields();

        pdfDoc.Close();
        return ToResult(outputPath);
    }

    private static PdfConversionFileResult ToResult(string path) =>
        new(path, new FileInfo(path).Length);
}
