using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Xobject;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using System.Text;
using UglyToad.PdfPig.Content;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
namespace ratpdf.Services
{
    public class PdfConversionService
    {
        private readonly PdfToDocxProcessor _pdfToDocxProcessor;
        private readonly PdfOfficeProcessor _pdfOfficeProcessor;
        private readonly PdfTextProcessor _pdfTextProcessor;
        private readonly ILogger<PdfConversionService> _logger;

        public PdfConversionService(
            PdfToDocxProcessor pdfToDocxProcessor,
            PdfOfficeProcessor pdfOfficeProcessor,
            PdfTextProcessor pdfTextProcessor,
            ILogger<PdfConversionService> logger)
        {
            _pdfToDocxProcessor = pdfToDocxProcessor;
            _pdfOfficeProcessor = pdfOfficeProcessor;
            _pdfTextProcessor = pdfTextProcessor;
            _logger = logger;
        }

        private static iText.Kernel.Pdf.PdfReader OpenPermissiveReader(Stream stream)
        {
            var reader = new iText.Kernel.Pdf.PdfReader(stream);
            reader.SetUnethicalReading(true);
            return reader;
        }

        public byte[] ConvertImagesToPdf(List<IFormFile> images)
        {
            if (images == null || images.Count == 0)
                throw new ArgumentException("No images provided.");

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            using var document = new iText.Layout.Document(pdf, iText.Kernel.Geom.PageSize.A4);
            document.SetMargins(36, 36, 36, 36);

            var maxW = iText.Kernel.Geom.PageSize.A4.GetWidth() - 72;
            var maxH = iText.Kernel.Geom.PageSize.A4.GetHeight() - 72;

            for (var i = 0; i < images.Count; i++)
            {
                using var stream = images[i].OpenReadStream();
                byte[] imgBytes;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imgBytes = memoryStream.ToArray();
                }

                var imgData = ImageDataFactory.Create(imgBytes);
                var img = new iText.Layout.Element.Image(imgData);
                img.ScaleToFit(maxW, maxH);
                img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                document.Add(img);

                if (i < images.Count - 1)
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            }

            document.Close();
            return ms.ToArray();
        }
        public byte[] MergePdfFiles(List<IFormFile> files)
        {
            if (files == null || files.Count < 2)
                throw new ArgumentException("Select at least 2 PDF files to merge.");

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer);

            foreach (var file in files)
            {
                using var inputStream = file.OpenReadStream();
                using var pdfReader = OpenPermissiveReader(inputStream);
                using var readerPdf = new iText.Kernel.Pdf.PdfDocument(pdfReader);
                readerPdf.CopyPagesTo(1, readerPdf.GetNumberOfPages(), pdfDoc);
            }

            pdfDoc.Close();
            return ms.ToArray();
        }
        /// <summary>
        /// Splits a PDF into a new PDF containing the specified page range.
        /// </summary>
        /// <param name="file">Uploaded PDF file</param>
        /// <param name="startPage">1-based start page</param>
        /// <param name="endPage">1-based end page</param>
        /// <returns>Byte array of the split PDF</returns>
        public byte[] SplitPdf(IFormFile file, int startPage, int endPage)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer);

            using var splitStream = file.OpenReadStream();
            using var splitReader = OpenPermissiveReader(splitStream);
            using var reader = new iText.Kernel.Pdf.PdfDocument(splitReader);
            int totalPages = reader.GetNumberOfPages();

            if (startPage < 1 || endPage > totalPages || startPage > endPage)
                throw new ArgumentException("Invalid page range.");

            reader.CopyPagesTo(startPage, endPage, pdfDoc);
            pdfDoc.Close();
            return ms.ToArray();
        }
        /// <summary>
        /// Compress a PDF by reducing image quality and removing unnecessary objects.
        /// </summary>
        public byte[] CompressPdf(IFormFile file, int imageQuality = 50)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            using var inputStream = file.OpenReadStream();
            using var reader = new iText.Kernel.Pdf.PdfReader(inputStream);
            using var ms = new MemoryStream();
            var writerProperties = new WriterProperties()
                .SetCompressionLevel(9)
                .UseSmartMode();
            using var writer = new PdfWriter(ms, writerProperties);

            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                var page = pdfDoc.GetPage(i);
                var resources = page.GetResources();
                var xObjects = resources.GetResourceNames();
            }

            pdfDoc.Close();
            return ms.ToArray();
        }
        public byte[] ConvertTextToPdf(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text content is empty.");

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDoc);

            // Add text as paragraphs
            foreach (var line in text.Split("\n"))
            {
                document.Add(new iText.Layout.Element.Paragraph(line));
            }

            document.Close();
            return ms.ToArray();
        }
        public byte[] ConvertTextFileToPdf(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var text = reader.ReadToEnd();
            return ConvertTextToPdf(text);
        }
        public byte[] ConvertHtmlToPdf(string html)
        {
            using var outputStream = new MemoryStream();

            var writerProperties = new WriterProperties();
            using var pdfWriter = new PdfWriter(outputStream, writerProperties);
            using var pdfDocument = new PdfDocument(pdfWriter);

            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);

            var converterProperties = new ConverterProperties();

            var fontProvider = new DefaultFontProvider(
                registerStandardPdfFonts: true,
                registerShippedFonts: true,
                registerSystemFonts: true
            );
            var notoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "NotoSans-Regular.ttf");
            if (File.Exists(notoPath))
                fontProvider.AddFont(notoPath);
            converterProperties.SetFontProvider(fontProvider);
            converterProperties.SetBaseUri(AppDomain.CurrentDomain.BaseDirectory);

            HtmlConverter.ConvertToPdf(html, pdfDocument, converterProperties);

            pdfDocument.Close();

            return outputStream.ToArray();
        }
        public async Task<string> ExtractTextFromPdfAsync(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            try
            {
                await using var stream = file.OpenReadStream();
                return await _pdfTextProcessor.ExtractTextAsync(stream, file.FileName);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Python text extraction failed for {File}, falling back to iText", file.FileName);
                return ExtractTextFromPdfLegacy(file);
            }
        }

        public string ExtractTextFromPdf(IFormFile file) =>
            ExtractTextFromPdfAsync(file).GetAwaiter().GetResult();

        private static string ExtractTextFromPdfLegacy(IFormFile file)
        {
            using var legacyStream = file.OpenReadStream();
            using var reader = OpenPermissiveReader(legacyStream);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader);
            var sb = new StringBuilder();

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                sb.AppendLine($"--- Page {i} ---");
                sb.AppendLine(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public byte[] AddWatermark(IFormFile file, string watermarkText)
        {
            if (file == null) throw new ArgumentException("No PDF provided.");
            if (string.IsNullOrWhiteSpace(watermarkText))
                throw new ArgumentException("Watermark text is required.");

            using var wmStream = file.OpenReadStream();
            using var reader = OpenPermissiveReader(wmStream);
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

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
            return ms.ToArray();
        }

        public byte[] AddPassword(IFormFile file, string password)
        {
            if (file == null) throw new ArgumentException("No PDF provided.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be empty.");

            using var pwStream = file.OpenReadStream();
            using var reader = OpenPermissiveReader(pwStream);
            var writerProperties = new WriterProperties()
                .SetStandardEncryption(
                    Encoding.UTF8.GetBytes(password),
                    null,
                    EncryptionConstants.ALLOW_PRINTING,
                    EncryptionConstants.ENCRYPTION_AES_128 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA);

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, writerProperties);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

            pdfDoc.Close();
            return ms.ToArray();
        }

        public async Task<byte[]> ConvertDocxToPdfAsync(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No DOCX file provided.");

            await using var stream = file.OpenReadStream();
            return await _pdfOfficeProcessor.ConvertAsync(
                OfficeConversionKind.DocxToPdf, stream, file.FileName);
        }

        public byte[] ConvertDocxToPdf(IFormFile file) =>
            ConvertDocxToPdfAsync(file).GetAwaiter().GetResult();

        [Obsolete("Legacy iText path — use LibreOffice via ConvertDocxToPdfAsync")]
        private byte[] ConvertDocxToPdfLegacy(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No DOCX file provided.");

            using var pdfMs = new MemoryStream();
            using var writer = new PdfWriter(pdfMs);
            using var pdfDoc = new PdfDocument(writer);
            using var doc = new iText.Layout.Document(pdfDoc, iText.Kernel.Geom.PageSize.A4);
            doc.SetMargins(40, 40, 40, 40);

            using var wordStream = file.OpenReadStream();
            using var wordDoc = WordprocessingDocument.Open(wordStream, false);

            var body = wordDoc.MainDocumentPart.Document.Body;
            var mainPart = wordDoc.MainDocumentPart;

            var styleMap = BuildStyleMap(mainPart);

            foreach (var element in body.Elements())
            {
                switch (element)
                {
                    case DocumentFormat.OpenXml.Wordprocessing.Paragraph para:
                        var iTextPara = ProcessParagraph(para, mainPart, styleMap, doc);
                        if (iTextPara != null)
                            doc.Add(iTextPara);
                        break;

                    case DocumentFormat.OpenXml.Wordprocessing.Table table:
                        var iTextTable = ProcessTable(table, mainPart, styleMap, doc);
                        if (iTextTable != null)
                            doc.Add(iTextTable);
                        break;
                }
            }

            doc.Close();
            return pdfMs.ToArray();
        }
        private iText.Layout.Element.Paragraph ProcessParagraph(
        DocumentFormat.OpenXml.Wordprocessing.Paragraph para,
        MainDocumentPart mainPart,
        Dictionary<string, ResolvedStyle> styleMap, iText.Layout.Document doc)
        {
            var iTextPara = new iText.Layout.Element.Paragraph();
            iTextPara.SetMultipliedLeading(1.2f);

            var pPr = para.ParagraphProperties;
            ResolvedStyle baseStyle = new();

            string? styleId = pPr?.ParagraphStyleId?.Val?.Value;
            if (styleId != null && styleMap.TryGetValue(styleId, out var namedStyle))
                baseStyle = namedStyle;

            var jc = pPr?.Justification?.Val;
            if (jc != null)
            {
                iText.Layout.Properties.TextAlignment alignment;
                if (jc.Value == DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center)
                    alignment = iText.Layout.Properties.TextAlignment.CENTER;
                else if (jc.Value == DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right)
                    alignment = iText.Layout.Properties.TextAlignment.RIGHT;
                else if (jc.Value == DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Both)
                    alignment = iText.Layout.Properties.TextAlignment.JUSTIFIED;
                else if (jc.Value == DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Distribute)
                    alignment = iText.Layout.Properties.TextAlignment.JUSTIFIED;
                else
                    alignment = iText.Layout.Properties.TextAlignment.LEFT;

                iTextPara.SetTextAlignment(alignment);
            }

            var spacing = pPr?.SpacingBetweenLines;
            if (spacing?.Before?.Value is string before && int.TryParse(before, out int bTwips))
                iTextPara.SetMarginTop(bTwips / 20f);
            if (spacing?.After?.Value is string after && int.TryParse(after, out int aTwips))
                iTextPara.SetMarginBottom(aTwips / 20f);

            var ind = pPr?.Indentation;
            if (ind?.Left?.Value is string leftStr && int.TryParse(leftStr, out int leftTwips))
                iTextPara.SetMarginLeft(leftTwips / 20f);
            if (ind?.FirstLine?.Value is string flStr && int.TryParse(flStr, out int flTwips))
                iTextPara.SetFirstLineIndent(flTwips / 20f);

            bool hasContent = false;

            foreach (var child in para.Elements())
            {
                List<ILeafElement>? leaves = child switch
                {
                    Run run => ProcessRun(run, mainPart, baseStyle),
                    DocumentFormat.OpenXml.Wordprocessing.Hyperlink hlink => hlink.Elements<Run>()
                                               .SelectMany(r => ProcessRun(r, mainPart, baseStyle, isHyperlink: true))
                                               .ToList(),
                    _ => null
                };

                if (leaves == null) continue;

                foreach (var leaf in leaves)
                {
                    switch (leaf)
                    {
                        case ImageLeaf imgLeaf:
                            if (hasContent)
                            {
                                doc.Add(iTextPara);
                                iTextPara = new iText.Layout.Element.Paragraph();
                                iTextPara.SetMultipliedLeading(1.2f);
                                hasContent = false;
                            }
                            doc.Add(imgLeaf.Image);
                            break;

                        case PageBreakLeaf:
                            doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                            break;

                        default:
                            iTextPara.Add(leaf);
                            hasContent = true;
                            break;
                    }
                }
            }

            if (!hasContent)
            {
                iTextPara.Add(new iText.Layout.Element.Text(" "));
                iTextPara.SetMarginBottom(6f);
            }

            return iTextPara;
        }
        private List<ILeafElement> ProcessRun(
        Run run,
        MainDocumentPart mainPart,
        ResolvedStyle baseStyle,
        bool isHyperlink = false)
        {
            var result = new List<ILeafElement>();
            var rPr = run.RunProperties;

            string fontName = rPr?.RunFonts?.Ascii?.Value
                           ?? rPr?.RunFonts?.HighAnsi?.Value
                           ?? baseStyle.FontName
                           ?? "Helvetica";

            float fontSize = 11f;
            if (rPr?.FontSize?.Val?.Value is string fsStr && int.TryParse(fsStr, out int fsHp))
                fontSize = fsHp / 2f;
            else if (baseStyle.FontSize > 0)
                fontSize = baseStyle.FontSize;

            bool isBold = (rPr?.Bold != null && rPr.Bold.Val?.Value != false)
                         || baseStyle.Bold;
            bool isItalic = (rPr?.Italic != null && rPr.Italic.Val?.Value != false)
                         || baseStyle.Italic;
            bool isUnderline = rPr?.Underline != null
                            && rPr.Underline.Val?.Value != UnderlineValues.None;
            bool isStrike = rPr?.Strike != null && rPr.Strike.Val?.Value != false;

            string? hexColor = rPr?.Color?.Val?.Value;
            if (hexColor == "auto" || hexColor == "AUTO") hexColor = null;
            if (isHyperlink) hexColor ??= "0563C1";

            var highlightVal = rPr?.Highlight?.Val;

            PdfFont pdfFont = ResolvePdfFont(fontName, isBold, isItalic);

            foreach (var drawing in run.Elements<Drawing>())
            {
                var blip = drawing.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().FirstOrDefault();
                if (blip?.Embed?.Value == null) continue;

                var imgPart = (ImagePart)mainPart.GetPartById(blip.Embed.Value);
                using var imgStream = imgPart.GetStream();
                using var imgMs = new MemoryStream();
                imgStream.CopyTo(imgMs);

                try
                {
                    var imgData = ImageDataFactory.Create(imgMs.ToArray());
                    var iTextImg = new iText.Layout.Element.Image(imgData);

                    var extent = drawing.Descendants<DocumentFormat.OpenXml.Drawing.Wordprocessing.Extent>()
                                        .FirstOrDefault();
                    if (extent != null)
                    {
                        float wPt = extent.Cx / 12700f;
                        float hPt = extent.Cy / 12700f;
                        iTextImg.SetWidth(wPt).SetHeight(hPt);
                    }
                    else
                    {
                        iTextImg.SetAutoScale(true);
                    }

                    result.Add(new ImageLeaf(iTextImg));
                }
                catch { /* skip unreadable images */ }
            }

            foreach (var textEl in run.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
            {
                string raw = textEl.Text;
                if (string.IsNullOrEmpty(raw)) continue;

                var iTextText = new iText.Layout.Element.Text(raw);
                iTextText.SetFont(pdfFont);
                iTextText.SetFontSize(fontSize);

                if (hexColor != null)
                {
                    try
                    {
                        var color = new DeviceRgb(
                            Convert.ToInt32(hexColor.Substring(0, 2), 16) / 255f,
                            Convert.ToInt32(hexColor.Substring(2, 2), 16) / 255f,
                            Convert.ToInt32(hexColor.Substring(4, 2), 16) / 255f);
                        iTextText.SetFontColor(color);
                    }
                    catch { }
                }

                if (isUnderline) iTextText.SetUnderline();
                if (isStrike) iTextText.SetLineThrough();

                if (highlightVal != null)
                {
                    var bgColor = HighlightToColor(highlightVal.Value);
                    if (bgColor is not null) iTextText.SetBackgroundColor(bgColor);
                }

                result.Add(iTextText);
            }

            foreach (var br in run.Elements<Break>())
            {
                if (br.Type?.Value == BreakValues.Page)
                    result.Add(new PageBreakLeaf());
                else
                    result.Add(new iText.Layout.Element.Text("\n"));
            }

            return result;
        }
        private iText.Layout.Element.Table? ProcessTable(
        DocumentFormat.OpenXml.Wordprocessing.Table table,
        MainDocumentPart mainPart,
        Dictionary<string, ResolvedStyle> styleMap,
        iText.Layout.Document doc)
        {
            var rows = table.Elements<TableRow>().ToList();
            if (rows.Count == 0) return null;

            int colCount = rows.Max(r => r.Elements<TableCell>().Count());
            var iTextTable = new iText.Layout.Element.Table(colCount).UseAllAvailableWidth();
            foreach (var row in rows)
            {
                foreach (var cell in row.Elements<TableCell>())
                {
                    var cellParagraphs = cell.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                    var cellContent = new iText.Layout.Element.Cell();

                    foreach (var cp in cellParagraphs)
                    {
                        var p = ProcessParagraph(cp, mainPart, styleMap, doc);
                        if (p != null) cellContent.Add(p);
                    }

                    var shading = cell.TableCellProperties?.Shading;
                    if (shading?.Fill?.Value is string fill && fill != "auto" && fill.Length == 6)
                    {
                        try
                        {
                            var bg = new DeviceRgb(
                                Convert.ToInt32(fill.Substring(0, 2), 16) / 255f,
                                Convert.ToInt32(fill.Substring(2, 2), 16) / 255f,
                                Convert.ToInt32(fill.Substring(4, 2), 16) / 255f);
                            cellContent.SetBackgroundColor(bg);
                        }
                        catch { }
                    }

                    iTextTable.AddCell(cellContent);
                }
            }

            return iTextTable;
        }
        private static readonly Dictionary<string, PdfFont> _fontCache = new();

        private static PdfFont ResolvePdfFont(string name, bool bold, bool italic)
        {
            string key = $"{name}|{bold}|{italic}";
            if (_fontCache.TryGetValue(key, out var cached)) return cached;

            PdfFont font;
            try
            {
                // iText7 will search system fonts by name
                string style = (bold, italic) switch
                {
                    (true, true) => "BoldItalic",
                    (true, false) => "Bold",
                    (false, true) => "Italic",
                    _ => "Normal"
                };
                font = PdfFontFactory.CreateFont(
                    name, PdfEncodings.IDENTITY_H,
                    PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
            }
            catch
            {
                string stdFont = (bold, italic) switch
                {
                    (true, true) => StandardFonts.HELVETICA_BOLDOBLIQUE,
                    (true, false) => StandardFonts.HELVETICA_BOLD,
                    (false, true) => StandardFonts.HELVETICA_OBLIQUE,
                    _ => StandardFonts.HELVETICA,
                };
                font = PdfFontFactory.CreateFont(stdFont);
            }

            _fontCache[key] = font;
            return font;
        }

        private static Dictionary<string, ResolvedStyle> BuildStyleMap(MainDocumentPart mainPart)
        {
            var map = new Dictionary<string, ResolvedStyle>(StringComparer.OrdinalIgnoreCase);
            var stylesPart = mainPart.StyleDefinitionsPart;
            if (stylesPart == null) return map;

            foreach (var style in stylesPart.Styles.Elements<DocumentFormat.OpenXml.Wordprocessing.Style>())
            {
                string? id = style.StyleId?.Value;
                if (id == null) continue;

                var rs = new ResolvedStyle();
                var rPr = style.StyleRunProperties;
                var pPr = style.StyleParagraphProperties;

                rs.FontName = rPr?.RunFonts?.Ascii?.Value;
                rs.Bold = rPr?.Bold != null && rPr.Bold.Val?.Value != false;
                rs.Italic = rPr?.Italic != null && rPr.Italic.Val?.Value != false;
                if (rPr?.FontSize?.Val?.Value is string s && int.TryParse(s, out int hp))
                    rs.FontSize = hp / 2f;

                map[id] = rs;
            }
            return map;
        }

        private iText.Kernel.Colors.Color? HighlightToColor(
        DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues v)
        {
            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Yellow)
                return new iText.Kernel.Colors.DeviceRgb(1f, 1f, 0f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Cyan)
                return new iText.Kernel.Colors.DeviceRgb(0f, 1f, 1f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Green)
                return new iText.Kernel.Colors.DeviceRgb(0f, 1f, 0f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Magenta)
                return new iText.Kernel.Colors.DeviceRgb(1f, 0f, 1f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Red)
                return new iText.Kernel.Colors.DeviceRgb(1f, 0f, 0f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.Blue)
                return new iText.Kernel.Colors.DeviceRgb(0f, 0f, 1f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.DarkYellow)
                return new iText.Kernel.Colors.DeviceRgb(0.5f, 0.5f, 0f);

            if (v == DocumentFormat.OpenXml.Wordprocessing.HighlightColorValues.DarkGreen)
                return new iText.Kernel.Colors.DeviceRgb(0f, 0.5f, 0f);

            return null;
        }

        public async Task<byte[]> ConvertPdfToDocAsync(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            await using var stream = file.OpenReadStream();
            return await _pdfToDocxProcessor.ConvertPdfToDocxAsync(stream, file.FileName);
        }

        /// <summary>
        /// Legacy iText text-stream conversion (fallback when Python pipeline is unavailable).
        /// </summary>
        private byte[] ConvertPdfToDocLegacy(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            using var pdfStream = file.OpenReadStream();
            using var reader = new iText.Kernel.Pdf.PdfReader(pdfStream);
            using var pdfDoc = new PdfDocument(reader);
            using var ms = new MemoryStream();

            using (var wordDoc = WordprocessingDocument.Create(
                       ms, WordprocessingDocumentType.Document, true))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document(new Body());
                var body = mainPart.Document.Body;

                int imageCounter = 0;

                for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                {
                    var page = pdfDoc.GetPage(pageNum);

                    // ── Extracting IMAGES ──────────────────────────────────────────
                    var xObjects = page.GetResources().GetResource(iText.Kernel.Pdf.PdfName.XObject);
                    if (xObjects != null)
                    {
                        foreach (var entry in xObjects.EntrySet())
                        {
                            var xObj = xObjects.GetAsStream(entry.Key);
                            if (xObj == null) continue;

                            var pdfObj = PdfXObject.MakeXObject(xObj);
                            if (pdfObj is PdfImageXObject imageXObj)
                            {
                                try
                                {
                                    byte[] imgBytes = imageXObj.GetImageBytes(true);
                                    if (imgBytes == null || imgBytes.Length == 0) continue;

                                    byte[] pngBytes = NormalizeToPng(imgBytes);

                                    var imagePart = mainPart.AddImagePart(ImagePartType.Png);
                                    using var imgMs = new MemoryStream(pngBytes);
                                    imagePart.FeedData(imgMs);

                                    string relationshipId = mainPart.GetIdOfPart(imagePart);
                                    imageCounter++;

                                    float widthPt = imageXObj.GetWidth();
                                    float heightPt = imageXObj.GetHeight();

                                    float maxWidthPt = 451f;
                                    if (widthPt > maxWidthPt)
                                    {
                                        float scale = maxWidthPt / widthPt;
                                        widthPt *= scale;
                                        heightPt *= scale;
                                    }
                                    long widthEmu = (long)(widthPt * 12700);
                                    long heightEmu = (long)(heightPt * 12700);

                                    var imgParagraph = BuildImageParagraph(
                                        relationshipId, imageCounter, widthEmu, heightEmu);
                                    body.Append(imgParagraph);
                                }
                                catch { /* skip corrupt images */ }
                            }
                        }
                    }

                    var strategy = new FormattedTextExtractionStrategy();
                    var processor = new PdfCanvasProcessor(strategy);
                    processor.ProcessPageContent(page);

                    foreach (var line in strategy.GetLines())
                    {
                        var para = new Paragraph();

                        foreach (var chunk in line)
                        {
                            var run = new Run();
                            var rpr = new RunProperties();

                            if (!string.IsNullOrEmpty(chunk.FontName))
                            {
                                string cleanFont = CleanFontName(chunk.FontName);
                                rpr.Append(new RunFonts { Ascii = cleanFont, HighAnsi = cleanFont });
                            }

                            if (chunk.FontSize > 0)
                                rpr.Append(new FontSize { Val = ((int)Math.Round(chunk.FontSize * 2)).ToString() });

                            if (chunk.IsBold) rpr.Append(new Bold());
                            if (chunk.IsItalic) rpr.Append(new Italic());

                            if (chunk.HexColor != "000000")
                                rpr.Append(new DocumentFormat.OpenXml.Wordprocessing.Color
                                { Val = chunk.HexColor });

                            if (rpr.HasChildren) run.Append(rpr);

                            string text = chunk.Text;
                            run.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(text) { Space = SpaceProcessingModeValues.Preserve });
                            para.Append(run);
                        }

                        body.Append(para);
                    }
                    strategy.Reset();

                    if (pageNum < pdfDoc.GetNumberOfPages())
                    {
                        body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                            new Run(new Break { Type = BreakValues.Page })));
                    }
                }

                mainPart.Document.Save();
            }

            return ms.ToArray();
        }
        public byte[] SignPdfWithName(IFormFile file, string name)
        {
            if (file == null)
                throw new ArgumentException("No PDF provided.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            using var pdfStream = file.OpenReadStream();
            using var reader = OpenPermissiveReader(pdfStream);
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);
            using var document = new iText.Layout.Document(pdfDoc);


            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

            var lastPage = pdfDoc.GetNumberOfPages();
            var pageSize = pdfDoc.GetPage(lastPage).GetPageSize();
            var sigWidth = Math.Min(220f, pageSize.GetWidth() * 0.45f);
            var sigX = pageSize.GetWidth() - sigWidth - 48f;

            var signature = new iText.Layout.Element.Paragraph(name)
                .SetFont(font)
                .SetFontSize(22)
                .SetFontColor(ColorConstants.DARK_GRAY)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .SetFixedPosition(lastPage, sigX, 56f, sigWidth);

            document.Add(signature);
            document.Close();

            return ms.ToArray();
        }
        public byte[] AddText(IFormFile pdfFile, string text, int pageNumber = 0, float x = 50, float y = 50)
        {
            using var ms = new MemoryStream();
            using var inputStream = pdfFile.OpenReadStream();
            var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(inputStream, PdfDocumentOpenMode.Modify);

            pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
            var page = pdfDoc.Pages[pageNumber];

            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Helvetica Oblique", 24, XFontStyle.Italic);
            gfx.DrawString(text, font, XBrushes.Black, new XPoint(x, y));

            pdfDoc.Save(ms, false);
            return ms.ToArray();
        }

        public byte[] AddImage(IFormFile pdfFile, IFormFile imageFile, int pageNumber = 0, float x = 50, float y = 50, float width = 200, float height = 200)
        {
            using var ms = new MemoryStream();
            using var inputStream = pdfFile.OpenReadStream();
            var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(inputStream, PdfDocumentOpenMode.Modify);

            pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
            var page = pdfDoc.Pages[pageNumber];

            var gfx = XGraphics.FromPdfPage(page);
            using var imgStream = imageFile.OpenReadStream();
            var img = XImage.FromStream(() => imgStream);

            gfx.DrawImage(img, x, y, width, height);

            pdfDoc.Save(ms, false);
            return ms.ToArray();
        }

        public byte[] RotatePage(IFormFile pdfFile, int pageNumber = 0, int rotationDegree = 90)
        {
            if (rotationDegree % 90 != 0)
                throw new ArgumentException("Rotation degree must be a multiple of 90 (90, 180, 270).");

            using var ms = new MemoryStream();
            using var rotStream = pdfFile.OpenReadStream();
            using var reader = OpenPermissiveReader(rotStream);
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

            pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.GetNumberOfPages() - 1);
            var page = pdfDoc.GetPage(pageNumber + 1);
            page.SetRotation((page.GetRotation() + rotationDegree) % 360);

            pdfDoc.Close();
            return ms.ToArray();
        }

        public byte[] RemovePage(IFormFile pdfFile, int pageNumber = 0)
        {
            using var rmStream = pdfFile.OpenReadStream();
            using var reader = OpenPermissiveReader(rmStream);
            using var src = new iText.Kernel.Pdf.PdfDocument(reader);
            var total = src.GetNumberOfPages();
            pageNumber = Math.Clamp(pageNumber, 0, total - 1);

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            using var dest = new iText.Kernel.Pdf.PdfDocument(writer);

            var pagesToCopy = Enumerable.Range(1, total).Where(p => p != pageNumber + 1).ToList();
            if (pagesToCopy.Count == 0)
                throw new ArgumentException("Cannot remove the only page in the document.");

            foreach (var p in pagesToCopy)
                src.CopyPagesTo(p, p, dest);

            dest.Close();
            return ms.ToArray();
        }

        public async Task<byte[]> ConvertPdfToExcelAsync(IFormFile pdfFile)
        {
            if (pdfFile == null)
                throw new ArgumentException("No PDF provided.");

            await using var stream = pdfFile.OpenReadStream();
            return await _pdfOfficeProcessor.ConvertAsync(
                OfficeConversionKind.PdfToXlsx, stream, pdfFile.FileName);
        }

        public byte[] ConvertPdfToExcel(IFormFile pdfFile) =>
            ConvertPdfToExcelAsync(pdfFile).GetAwaiter().GetResult();

        public async Task<byte[]> ConvertExcelToPdfAsync(IFormFile excelFile)
        {
            if (excelFile == null)
                throw new ArgumentException("No Excel file uploaded.");

            await using var stream = excelFile.OpenReadStream();
            return await _pdfOfficeProcessor.ConvertAsync(
                OfficeConversionKind.XlsxToPdf, stream, excelFile.FileName);
        }

        public byte[] ConvertExcelToPdf(IFormFile excelFile) =>
            ConvertExcelToPdfAsync(excelFile).GetAwaiter().GetResult();
        public async Task<string> ConvertImageToBase64(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No image file provided.");

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64 = Convert.ToBase64String(bytes);
            var mimeType = file.ContentType;
            return $"data:{mimeType};base64,{base64}";
        }
        public async Task<string> ConvertPdfToHtml(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Position = 0;

            var sb = new StringBuilder();
            sb.Append("<div style=\"font-family:Arial,sans-serif;\">");

            using var reader = new iText.Kernel.Pdf.PdfReader(ms);
            using var doc = new PdfDocument(reader);

            for (int i = 1; i <= doc.GetNumberOfPages(); i++)
            {
                var page = doc.GetPage(i);

                var pageSize = page.GetPageSize();

                var strategy = new StyledTextExtractionStrategy();
                strategy.SetPageSize(pageSize.GetWidth(), pageSize.GetHeight());

                var processor = new PdfCanvasProcessor(strategy);
                processor.ProcessPageContent(page);
                sb.Append(strategy.GetResultantHtml());

                var resources = page.GetResources();
                var xObjects = resources.GetResource(PdfName.XObject);

                if (xObjects != null)
                {
                    foreach (var key in xObjects.KeySet())
                    {
                        try
                        {
                            var xObjRef = xObjects.Get(key);
                            if (xObjRef == null) continue;

                            var xObjStream = xObjects.GetAsStream(key);
                            if (xObjStream == null) continue;

                            var subtype = xObjStream.GetAsName(PdfName.Subtype);
                            if (!PdfName.Image.Equals(subtype)) continue;

                            var colorSpaceObj = xObjStream.Get(PdfName.ColorSpace);
                            var filter = xObjStream.Get(PdfName.Filter);

                            bool isJpx = PdfName.JPXDecode.Equals(filter) ||
                                         (filter is PdfArray fa &&
                                          fa.Contains(PdfName.JPXDecode));

                            if (colorSpaceObj == null && !isJpx)
                            {
                                continue;
                            }

                            var imgXObj = new PdfImageXObject(xObjStream);

                            byte[]? imgBytes = null;
                            string mime = "image/jpeg";

                            try
                            {
                                imgBytes = imgXObj.GetImageBytes(decoded: true);
                                var ext = imgXObj.IdentifyImageFileExtension();
                                mime = ext == "png" ? "image/png"
                                         : ext == "bmp" ? "image/bmp"
                                         : "image/jpeg";
                            }
                            catch
                            {
                                try
                                {
                                    imgBytes = imgXObj.GetImageBytes(decoded: false);
                                    mime = "image/jpeg";
                                }
                                catch
                                {
                                    continue;
                                }
                            }

                            if (imgBytes == null || imgBytes.Length < 16) continue;

                            if (imgBytes.Length > 8 &&
                                imgBytes[0] == 0x89 && imgBytes[1] == 0x50)
                            {
                                mime = "image/png";
                            }
                            else if (imgBytes[0] == 0xFF && imgBytes[1] == 0xD8)
                            {
                                mime = "image/jpeg";
                            }
                            else if (imgBytes[0] == 0x47 && imgBytes[1] == 0x49)
                            {
                                mime = "image/gif";
                            }

                            var b64 = Convert.ToBase64String(imgBytes);
                            sb.Append($"<img src=\"data:{mime};base64,{b64}\" " +
                                       "style=\"max-width:100%;height:auto;display:block;margin:8px 0;\" />");
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                if (i < doc.GetNumberOfPages())
                    sb.Append("<hr style=\"border:none;border-top:2px dashed #ccc;margin:32px 0;\" />");
            }

            sb.Append("</div>");
            return sb.ToString();
        }
        private static string CleanFontName(string raw)
        {
            if (raw.Length > 7 && raw[6] == '+')
                raw = raw.Substring(7);
            return raw.Split('-', ',')[0].Trim();
        }

        private static byte[] NormalizeToPng(byte[] input)
        {
            try
            {
                using var img = SixLabors.ImageSharp.Image.Load(input);
                using var outMs = new MemoryStream();
                img.Save(outMs, new PngEncoder());
                return outMs.ToArray();
            }
            catch
            {
                return input;
            }
        }

        private static Paragraph BuildImageParagraph(
            string relId, int imgId, long widthEmu, long heightEmu)
        {
            return new Paragraph(new Run(
                new Drawing(
                    new DW.Inline(
                        new DW.Extent { Cx = widthEmu, Cy = heightEmu },
                        new DW.EffectExtent { LeftEdge = 0, TopEdge = 0, RightEdge = 0, BottomEdge = 0 },
                        new DW.DocProperties { Id = (uint)imgId, Name = $"Image{imgId}" },
                        new DW.NonVisualGraphicFrameDrawingProperties(
                            new A.GraphicFrameLocks { NoChangeAspect = true }),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties
                                        { Id = (uint)imgId, Name = $"img{imgId}.png" },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                    new PIC.BlipFill(
                                        new A.Blip { Embed = relId },
                                        new A.Stretch(new A.FillRectangle())),
                                    new PIC.ShapeProperties(
                                        new A.Transform2D(
                                            new A.Offset { X = 0, Y = 0 },
                                            new A.Extents { Cx = widthEmu, Cy = heightEmu }),
                                        new A.PresetGeometry(new A.AdjustValueList())
                                        { Preset = A.ShapeTypeValues.Rectangle })))
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }))
                    {
                        DistanceFromTop = 0,
                        DistanceFromBottom = 0,
                        DistanceFromLeft = 0,
                        DistanceFromRight = 0
                    })));
        }
    }
    public class FormattedTextExtractionStrategy : IEventListener
    {
        private readonly List<PositionedChunk> _rawChunks = new();

        public void EventOccurred(IEventData data, EventType type)
        {
            if (type != EventType.RENDER_TEXT) return;
            var info = (TextRenderInfo)data;

            string text = info.GetText();
            if (string.IsNullOrWhiteSpace(text)) return;

            var font = info.GetFont();
            float fontSize = Math.Abs(
                info.GetFontSize() * info.GetTextMatrix().Get(iText.Kernel.Geom.Matrix.I11));
            if (fontSize < 1) fontSize = 11;

            string fontName = font?.GetFontProgram()?.GetFontNames()?.GetFontName() ?? "";
            bool isBold = fontName.IndexOf("Bold", StringComparison.OrdinalIgnoreCase) >= 0
                         || (font?.GetFontProgram()?.GetFontNames()?.GetFontWeight() ?? 0) >= 700;
            bool isItalic = fontName.IndexOf("Italic", StringComparison.OrdinalIgnoreCase) >= 0
                         || fontName.IndexOf("Oblique", StringComparison.OrdinalIgnoreCase) >= 0;

            string hex = "000000";
            var fillColor = info.GetFillColor();
            if (fillColor?.GetColorValue() is { Length: >= 3 } c)
                hex = $"{(int)(c[0] * 255):X2}{(int)(c[1] * 255):X2}{(int)(c[2] * 255):X2}";

            var start = info.GetBaseline().GetStartPoint();
            float x = start.Get(0);
            float y = start.Get(1);

            _rawChunks.Add(new PositionedChunk
            {
                Text = text,
                X = x,
                Y = y,
                FontName = fontName,
                FontSize = fontSize,
                IsBold = isBold,
                IsItalic = isItalic,
                HexColor = hex,
            });
        }

        public List<List<PositionedChunk>> GetLines()
        {
            if (_rawChunks.Count == 0) return new();

            var sorted = _rawChunks
                .OrderByDescending(c => c.Y)
                .ThenBy(c => c.X)
                .ToList();

            var lines = new List<List<PositionedChunk>>();
            var curLine = new List<PositionedChunk> { sorted[0] };
            float lineY = sorted[0].Y;
            float lineTol = 3f;

            for (int i = 1; i < sorted.Count; i++)
            {
                if (Math.Abs(sorted[i].Y - lineY) <= lineTol)
                {
                    curLine.Add(sorted[i]);
                }
                else
                {
                    lines.Add(curLine);
                    curLine = new List<PositionedChunk> { sorted[i] };
                    lineY = sorted[i].Y;
                }
            }
            lines.Add(curLine);

            return lines;
        }
        public void Reset() => _rawChunks.Clear();

        public ICollection<EventType> GetSupportedEvents() =>
            new[] { EventType.RENDER_TEXT };
    }
    public class WordWrapper
    {
        public string Text { get; }
        public double Top { get; }
        public double FontSize { get; }

        public WordWrapper(Word word)
        {
            Text = word.Text;
            Top = word.BoundingBox.Top;
            FontSize = word.BoundingBox.Height;
        }
    }
    public class PositionedChunk
    {
        public string Text { get; set; } = "";
        public float X { get; set; }
        public float Y { get; set; }
        public string FontName { get; set; } = "";
        public float FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public string HexColor { get; set; } = "000000";
    }

    public class ImageLeaf : iText.Layout.Element.Text
    {
        public iText.Layout.Element.Image Image { get; }
        public ImageLeaf(iText.Layout.Element.Image img) : base("") => Image = img;
    }
    public class PageBreakLeaf : iText.Layout.Element.Text
    {
        public PageBreakLeaf() : base("") { }
    }

    public class ResolvedStyle
    {
        public string? FontName { get; set; }
        public float FontSize { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
    }

    public class StyledTextExtractionStrategy : IEventListener
    {
        private class TextChunk
        {
            public string Text { get; set; } = "";
            public float X { get; set; }
            public float Y { get; set; }
            public float EndX { get; set; }
            public float FontSize { get; set; }
            public string FontName { get; set; } = "Arial";
            public bool IsBold { get; set; }
            public bool IsItalic { get; set; }
            public string Color { get; set; } = "#000000";
        }

        private readonly List<TextChunk> _chunks = new();
        private float _pageWidth = 595f;
        private float _pageHeight = 842f;

        public void SetPageSize(float width, float height)
        {
            _pageWidth = width;
            _pageHeight = height;
        }

        public void EventOccurred(IEventData data, EventType type)
        {
            if (type != EventType.RENDER_TEXT) return;
            var info = (TextRenderInfo)data;

            var text = info.GetText();
            if (string.IsNullOrEmpty(text)) return;


            var baseline = info.GetBaseline();
            var startPoint = baseline.GetStartPoint();
            var endPoint = baseline.GetEndPoint();

            var tm = info.GetTextMatrix();
            var scaleY = MathF.Sqrt(tm.Get(Matrix.I12) * tm.Get(Matrix.I12)
                                     + tm.Get(Matrix.I22) * tm.Get(Matrix.I22));
            var fontSize = Math.Abs(info.GetFontSize() * scaleY);
            if (fontSize < 1f) fontSize = 10f;

            var font = info.GetFont();
            var fontName = "Arial";
            bool isBold = false, isItalic = false;

            if (font != null)
            {
                fontName = font.GetFontProgram()?.GetFontNames()?.GetFontName() ?? "Arial";

                if (fontName.Contains('+'))
                    fontName = fontName[(fontName.IndexOf('+') + 1)..];

                isBold = fontName.Contains("Bold", StringComparison.OrdinalIgnoreCase);
                isItalic = fontName.Contains("Italic", StringComparison.OrdinalIgnoreCase)
                        || fontName.Contains("Oblique", StringComparison.OrdinalIgnoreCase);
            }


            string color = "#000000";
            var fillColor = info.GetFillColor();
            if (fillColor != null)
            {
                try
                {
                    var rgb = fillColor.GetColorValue();
                    int r = (int)Math.Round(rgb[0] * 255);
                    int g = (int)Math.Round(rgb[1] * 255);
                    int b = (int)Math.Round(rgb[2] * 255);
                    if (r != 0 || g != 0 || b != 0)
                        color = $"#{r:X2}{g:X2}{b:X2}";
                }
                catch { /* leave black */ }
            }

            _chunks.Add(new TextChunk
            {
                Text = text,
                X = startPoint.Get(Vector.I1),
                Y = startPoint.Get(Vector.I2),
                EndX = endPoint.Get(Vector.I1),
                FontSize = fontSize,
                FontName = fontName,
                IsBold = isBold,
                IsItalic = isItalic,
                Color = color
            });
        }

        public string GetResultantHtml()
        {
            if (_chunks.Count == 0) return string.Empty;

            const float Y_TOLERANCE = 2.5f;
            const float SPACE_RATIO = 0.4f;

            var lines = new List<List<TextChunk>>();


            foreach (var chunk in _chunks.OrderByDescending(c => c.Y).ThenBy(c => c.X))
            {
                var line = lines.FirstOrDefault(l =>
                    Math.Abs(l[0].Y - chunk.Y) <= Y_TOLERANCE);

                if (line != null)
                    line.Add(chunk);
                else
                    lines.Add(new List<TextChunk> { chunk });
            }


            foreach (var line in lines)
                line.Sort((a, b) => a.X.CompareTo(b.X));

            float contentLeft = _chunks.Min(c => c.X);
            float contentRight = _chunks.Max(c => c.EndX);
            float pageCenter = _pageWidth / 2f;
            float contentSpan = contentRight - contentLeft;

            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.Count == 0) continue;

                string rawText = string.Concat(line.Select(c => c.Text));
                if (string.IsNullOrWhiteSpace(rawText))
                {
                    sb.Append("<p style=\"margin:0;line-height:0.8em;\">&nbsp;</p>");
                    continue;
                }

                float lineLeft = line.First().X;
                float lineRight = line.Last().EndX;
                float lineMid = (lineLeft + lineRight) / 2f;
                float lineWidth = lineRight - lineLeft;

                float gapLeft = lineLeft - contentLeft;
                float gapRight = contentRight - lineRight;
                float centerDiff = Math.Abs(lineMid - pageCenter);

                string alignment;

                if (lineWidth >= contentSpan * 0.85f)
                {
                    alignment = "justify";
                }
                else if (centerDiff <= contentSpan * 0.06f
                      && gapLeft > contentSpan * 0.10f
                      && gapRight > contentSpan * 0.10f)
                {
                    alignment = "center";
                }
                else if (gapRight < contentSpan * 0.08f
                      && gapLeft > contentSpan * 0.15f)
                {
                    alignment = "right";
                }
                else
                {
                    alignment = "left";
                }

                float avgSize = line.Average(c => c.FontSize);
                float marginPx = MathF.Round(avgSize * 0.15f, 1);

                sb.Append($"<p style=\"margin:0 0 {marginPx}pt 0;" +
                          $"text-align:{alignment};line-height:1.4;\">");

                for (int i = 0; i < line.Count; i++)
                {
                    var chunk = line[i];

                    if (i > 0)
                    {
                        float gap = chunk.X - line[i - 1].EndX;
                        float spaceRef = chunk.FontSize * SPACE_RATIO;
                        if (gap > spaceRef)
                            sb.Append(' ');
                    }

                    var style = new StringBuilder();
                    style.Append($"font-family:'{chunk.FontName}',Arial,sans-serif;");
                    style.Append($"font-size:{chunk.FontSize:F1}pt;");
                    if (chunk.IsBold) style.Append("font-weight:bold;");
                    if (chunk.IsItalic) style.Append("font-style:italic;");
                    if (chunk.Color != "#000000") style.Append($"color:{chunk.Color};");

                    sb.Append($"<span style=\"{style}\">" +
                              $"{System.Net.WebUtility.HtmlEncode(chunk.Text)}</span>");
                }

                sb.Append("</p>");
            }

            _chunks.Clear();
            return sb.ToString();
        }

        public ICollection<EventType> GetSupportedEvents() =>
            new HashSet<EventType> { EventType.RENDER_TEXT };
    }
}

