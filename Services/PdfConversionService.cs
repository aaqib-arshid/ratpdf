using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Html2pdf;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using System.Text;
using UglyToad.PdfPig.Content;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Linq;
using SixLabors.ImageSharp;         
using SixLabors.ImageSharp.Formats.Png;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
namespace ratpdf.Services
{
    public class PdfConversionService
    {
        public byte[] ConvertImagesToPdf(List<IFormFile> images)
        {
            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            var document = new iText.Layout.Document(pdf);

            foreach (var imageFile in images)
            {
                using var stream = imageFile.OpenReadStream();

                byte[] imgBytes;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imgBytes = memoryStream.ToArray();
                }

                var imgData = ImageDataFactory.Create(imgBytes);
                var img = new iText.Layout.Element.Image(imgData);

                img.SetAutoScale(true);

                document.Add(img);
                document.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
            }

            document.Close();
            return ms.ToArray();
        }
        public byte[] MergePdfFiles(List<IFormFile> files)
        {
            if (files == null || files.Count < 2)
                throw new ArgumentException("Select at least 2 PDF files to merge.");

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer);

            foreach (var file in files)
            {
                using var inputStream = file.OpenReadStream();
                using var readerPdf = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(inputStream));
                readerPdf.CopyPagesTo(1, readerPdf.GetNumberOfPages(), pdfDoc);
                readerPdf.Close();
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
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(new PdfWriter(ms));

            using var reader = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(file.OpenReadStream()));
            int totalPages = reader.GetNumberOfPages();

            if (startPage < 1 || endPage > totalPages || startPage > endPage)
                throw new ArgumentException("Invalid page range.");

            reader.CopyPagesTo(startPage, endPage, pdfDoc);

            pdfDoc.Close();
            reader.Close();

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
        public byte[] ConvertHtmlToPdf(string htmlContent)
        {
            string fullHtml = $$"""
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset="UTF-8"/>
                <style>
                    body { font-family: Arial, sans-serif; margin: 40px; font-size: 14px; line-height: 1.6; }
                    h1, h2, h3 { color: #222; }
                    ul, ol { padding-left: 20px; }
                </style>
            </head>
            <body>{{htmlContent}}</body>
            </html>
            """;

            using var ms = new MemoryStream();
            HtmlConverter.ConvertToPdf(fullHtml, ms);
            return ms.ToArray();
        }
        public string ExtractTextFromPdf(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No PDF file provided.");

            using var reader = new iText.Kernel.Pdf.PdfReader(file.OpenReadStream());
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader);
            var sb = new StringBuilder();

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                var page = pdfDoc.GetPage(i);
                var text = PdfTextExtractor.GetTextFromPage(page);
                sb.AppendLine(text);
            }

            pdfDoc.Close();
            return sb.ToString();
        }
        // Add text watermark to every page
        public byte[] AddWatermark(IFormFile file, string watermarkText)
        {
            if (file == null) throw new ArgumentException("No PDF provided.");

            using var reader = new iText.Kernel.Pdf.PdfReader(file.OpenReadStream());
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);

            int totalPages = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= totalPages; i++)
            {
                var page = pdfDoc.GetPage(i);
                var canvas = new PdfCanvas(page);
                var pageSize = page.GetPageSize();

                // Add semi-transparent text in the center
                canvas.SaveState();
                canvas.SetFillColor(ColorConstants.LIGHT_GRAY);
                canvas.BeginText();
                canvas.SetFontAndSize(iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD), 20);
                canvas.MoveText(pageSize.GetWidth() / 4, pageSize.GetHeight() / 2);
                canvas.ShowText(watermarkText);
                canvas.EndText();
                canvas.RestoreState();
            }

            pdfDoc.Close();
            return ms.ToArray();
        }

        // Add password protection
        public byte[] AddPassword(IFormFile file, string password)
        {
            if (file == null) throw new ArgumentException("No PDF provided.");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be empty.");

            using var reader = new iText.Kernel.Pdf.PdfReader(file.OpenReadStream());
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
        public byte[] ConvertDocxToPdf(IFormFile file)
        {
            if (file == null)
                throw new ArgumentException("No DOCX file provided.");

            using var ms = new MemoryStream();
            using var wordDoc = WordprocessingDocument.Open(file.OpenReadStream(), false);
            using var pdfMs = new MemoryStream();
            using var writer = new PdfWriter(pdfMs);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDoc);

            var paragraphs = wordDoc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
            foreach (var p in paragraphs)
            {
                var text = string.Concat(p.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Select(t => t.Text));
                document.Add(new iText.Layout.Element.Paragraph(text));
            }

            document.Close();
            return pdfMs.ToArray();
        }
        public byte[] ConvertPdfToDoc(IFormFile file)
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
            using var reader = new iText.Kernel.Pdf.PdfReader(pdfStream);
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader, writer);
            var document = new iText.Layout.Document(pdfDoc);


            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

            var lastPage = pdfDoc.GetNumberOfPages();
            document.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);

            var signature = new iText.Layout.Element.Paragraph(name)
                .SetFont(font)
                .SetFontSize(24)
                .SetFontColor(ColorConstants.BLUE)
                .SetFixedPosition(lastPage, 400, 50, 200); 

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
            using var ms = new MemoryStream();
            using var inputStream = pdfFile.OpenReadStream();
            var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(inputStream, PdfDocumentOpenMode.Modify);

            pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
            if (rotationDegree % 90 != 0)
                throw new ArgumentException("Rotation degree must be a multiple of 90 (90, 180, 270).");
            var page = pdfDoc.Pages[pageNumber];
            page.Rotate = (page.Rotate + rotationDegree) % 360;

            pdfDoc.Save(ms, false);
            return ms.ToArray();
        }

        public byte[] RemovePage(IFormFile pdfFile, int pageNumber = 0)
        {
            using var ms = new MemoryStream();
            using var inputStream = pdfFile.OpenReadStream();
            var pdfDoc = PdfSharpCore.Pdf.IO.PdfReader.Open(inputStream, PdfDocumentOpenMode.Modify);

            pageNumber = Math.Clamp(pageNumber, 0, pdfDoc.PageCount - 1);
            pdfDoc.Pages.RemoveAt(pageNumber);

            pdfDoc.Save(ms, false);
            return ms.ToArray();
        }
        public byte[] ConvertPdfToExcel(IFormFile pdfFile)
        {
            if (pdfFile == null)
                throw new ArgumentException("No PDF provided.");

            using var pdfStream = pdfFile.OpenReadStream();
            using var pdfReader = new iText.Kernel.Pdf.PdfReader(pdfStream);
            using var pdfDoc = new iText.Kernel.Pdf.PdfDocument(pdfReader);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");

            int currentRow = 1;

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                var page = pdfDoc.GetPage(i);
                var text = PdfTextExtractor.GetTextFromPage(page);

                var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    worksheet.Cell(currentRow, 1).Value = line;
                    currentRow++;
                }
                currentRow++;
            }

            using var ms = new MemoryStream();
            workbook.SaveAs(ms);
            return ms.ToArray();
        }
        public byte[] ConvertExcelToPdf(IFormFile excelFile)
        {
            if (excelFile == null)
                throw new ArgumentException("No Excel file uploaded.");

            using var excelStream = excelFile.OpenReadStream();
            using var workbook = new XLWorkbook(excelStream);

            using var memoryStream = new MemoryStream();
            using var writer = new PdfWriter(memoryStream);
            using var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            using var document = new iText.Layout.Document(pdf);

            foreach (var worksheet in workbook.Worksheets)
            {
                document.Add(new iText.Layout.Element.Paragraph($"Sheet: {worksheet.Name}")
                    .SetFontSize(16));

                var range = worksheet.RangeUsed();
                if (range == null) continue;

                int columnCount = range.ColumnCount();
                var table = new iText.Layout.Element.Table(columnCount);

                foreach (var row in range.Rows())
                {
                    foreach (var cell in row.Cells())
                    {
                        table.AddCell(new Cell().Add(new iText.Layout.Element.Paragraph(cell.GetFormattedString())));
                    }
                }

                document.Add(table);
                document.Add(new AreaBreak()); 
            }

            document.Close();
            return memoryStream.ToArray();
        }
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
            using var stream = file.OpenReadStream();
            using var pdf = UglyToad.PdfPig.PdfDocument.Open(stream);

            var sb = new StringBuilder();

            sb.Append("<div class='document'>");

            foreach (var page in pdf.GetPages())
            {
                var words = page.GetWords()
                    .OrderByDescending(w => w.BoundingBox.Top)
                    .ToList();

                var lines = GroupLines(words);

                foreach (var line in lines)
                {
                    var text = string.Join(" ", line.Select(w => w.Text)).Trim();

                    if (string.IsNullOrWhiteSpace(text))
                        continue;

                    var style = InferStyle(line);

                    sb.Append($"<{style.Tag} style='{style.Css}'>");
                    sb.Append(text);
                    sb.Append($"</{style.Tag}>");
                }
            }

            sb.Append("</div>");

            return sb.ToString();
        }

        private List<List<WordWrapper>> GroupLines(List<Word> words)
        {
            var lines = new List<List<WordWrapper>>();
            const double threshold = 2.5;

            foreach (var word in words)
            {
                var line = lines.FirstOrDefault(l =>
                    Math.Abs(l[0].Top - word.BoundingBox.Top) < threshold);

                if (line == null)
                {
                    lines.Add(new List<WordWrapper>
                    {
                        new WordWrapper(word)
                    });
                }
                else
                {
                    line.Add(new WordWrapper(word));
                }
            }

            return lines;
        }
        private (string Tag, string Css) InferStyle(List<WordWrapper> line)
        {
            var avgFontSize = line.Average(w => w.FontSize);

            var text = string.Join(" ", line.Select(l => l.Text));

            bool isLikelyBold = avgFontSize > 14;

            if (avgFontSize > 18)
            {
                return ("h1", $"font-size:{avgFontSize}px; font-weight:bold;");
            }

            if (avgFontSize > 14)
            {
                return ("h2", $"font-size:{avgFontSize}px; font-weight:bold;");
            }

            if (isLikelyBold)
            {
                return ("p", "font-weight:bold;");
            }

            return ("p", $"font-size:{avgFontSize}px;");
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
    /// <summary>
    /// Listens to iText7 render events and collects text chunks with full formatting.
    /// </summary>
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

}

