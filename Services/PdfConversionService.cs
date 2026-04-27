using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using iText.Html2pdf;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using System.Text;
using Paragraph = iText.Layout.Element.Paragraph;

namespace ratpdf.Services
{
    public class PdfConversionService
    {
        public byte[] ConvertImagesToPdf(List<IFormFile> images)
        {
            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new PdfDocument(writer);
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
                var img = new Image(imgData);

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
            using var pdfDoc = new PdfDocument(writer);

            foreach (var file in files)
            {
                using var inputStream = file.OpenReadStream();
                using var readerPdf = new PdfDocument(new iText.Kernel.Pdf.PdfReader(inputStream));
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
            using var pdfDoc = new PdfDocument(new PdfWriter(ms));

            using var reader = new PdfDocument(new iText.Kernel.Pdf.PdfReader(file.OpenReadStream()));
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

            using var pdfDoc = new PdfDocument(reader, writer);

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
            using var pdfDoc = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDoc);

            // Add text as paragraphs
            foreach (var line in text.Split("\n"))
            {
                document.Add(new Paragraph(line));
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
            using var pdfDoc = new PdfDocument(reader);
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
            using var pdfDoc = new PdfDocument(reader, writer);

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
            using var pdfDoc = new PdfDocument(reader, writer);

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
            using var pdfDoc = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdfDoc);

            var paragraphs = wordDoc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
            foreach (var p in paragraphs)
            {
                var text = string.Concat(p.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>().Select(t => t.Text));
                document.Add(new Paragraph(text));
            }

            document.Close();
            return pdfMs.ToArray();
        }
        public byte[] ConvertPdfToDoc(IFormFile file)
        {
            if (file == null)
                throw new System.ArgumentException("No PDF file provided.");

            using var pdfStream = file.OpenReadStream();
            using var reader = new iText.Kernel.Pdf.PdfReader(pdfStream);
            using var pdfDoc = new PdfDocument(reader);

            using var ms = new MemoryStream();
            using (var wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(
                ms, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document(
                    new DocumentFormat.OpenXml.Wordprocessing.Body());
                var body = mainPart.Document.Body;

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    var page = pdfDoc.GetPage(i);
                    string text = PdfTextExtractor.GetTextFromPage(page);

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        foreach (var line in text.Split('\n'))
                        {
                            var trimmedLine = line.Trim();
                            if (!string.IsNullOrEmpty(trimmedLine))
                            {
                                // Fully qualified OpenXML types
                                var run = new DocumentFormat.OpenXml.Wordprocessing.Run(
                                    new DocumentFormat.OpenXml.Wordprocessing.Text(trimmedLine));
                                var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(run);
                                body.Append(paragraph);
                            }
                        }
                    }

                    // Add a page break after each PDF page
                    if (i < pdfDoc.GetNumberOfPages())
                    {
                        var pageBreak = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(
                            new DocumentFormat.OpenXml.Wordprocessing.Run(
                                new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = DocumentFormat.OpenXml.Wordprocessing.BreakValues.Page }
                            )
                        );
                        body.Append(pageBreak);
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
            using var pdfDoc = new PdfDocument(reader, writer);
            var document = new Document(pdfDoc);


            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

            var lastPage = pdfDoc.GetNumberOfPages();
            document.SetTextAlignment(TextAlignment.RIGHT);

            var signature = new Paragraph(name)
                .SetFont(font)
                .SetFontSize(24)
                .SetFontColor(ColorConstants.BLUE)
                .SetFixedPosition(lastPage, 400, 50, 200); // x, y, width

            document.Add(signature);
            document.Close();

            return ms.ToArray();
        }
        // Add text overlay
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

        // Add image overlay
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

        // Rotate a page
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

        // Remove a page
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
            using var pdfDoc = new PdfDocument(pdfReader);

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
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf);

            foreach (var worksheet in workbook.Worksheets)
            {
                document.Add(new Paragraph($"Sheet: {worksheet.Name}")
                    .SetFontSize(16));

                var range = worksheet.RangeUsed();
                if (range == null) continue;

                int columnCount = range.ColumnCount();
                var table = new Table(columnCount);

                foreach (var row in range.Rows())
                {
                    foreach (var cell in row.Cells())
                    {
                        table.AddCell(new Cell().Add(new Paragraph(cell.GetFormattedString())));
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
    }
}
