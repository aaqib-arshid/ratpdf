using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using ratpdf.Models.PaySlip;

namespace ratpdf.Services.PaySlip
{
    public class PayslipPdfService
    {
        private readonly IWebHostEnvironment _env;

        public PayslipPdfService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public byte[] GeneratePdf(PayslipModel model)
        {
            using var stream = new MemoryStream();

            // PDF Writer
            var writer = new PdfWriter(stream);

            // PDF Document
            var pdf = new PdfDocument(writer);

            // Document
            var document = new Document(pdf);
            var fontPath = Path.Combine(
                _env.ContentRootPath,
                "fonts",
                "NotoSans-Regular.ttf"
            );

            PdfFont font = PdfFontFactory.CreateFont(
                fontPath,
                PdfEncodings.IDENTITY_H,
                PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED
            );
            // PAGE MARGIN
            document.SetMargins(30, 30, 30, 30);

            // =====================================================
            // HEADER
            // =====================================================

            var headerTable = new Table(2)
                .UseAllAvailableWidth();

            headerTable.SetBorder(Border.NO_BORDER);

            // LOGO CELL
            var logoCell = new Cell()
                .SetBorder(Border.NO_BORDER);

            if (model.CompanyLogo != null &&
                model.CompanyLogo.Length > 0)
            {
                using var logoStream =
                    model.CompanyLogo.OpenReadStream();

                var memoryStream = new MemoryStream();

                logoStream.CopyTo(memoryStream);

                var imageData =
                    ImageDataFactory.Create(
                        memoryStream.ToArray()
                    );

                var logo = new Image(imageData)
                    .ScaleToFit(80, 80);

                logoCell.Add(logo);
            }

            headerTable.AddCell(logoCell);

            // TITLE CELL
            var titleCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            titleCell.Add(
                new Paragraph("PAYSLIP")
                    .SetFontSize(26)
                    .SimulateBold()
            );

            titleCell.Add(
                new Paragraph(model.PayPeriod ?? "")
                    .SetFontSize(11)
                    .SetFontColor(ColorConstants.GRAY)
            );

            headerTable.AddCell(titleCell);

            document.Add(headerTable);

            // SPACING
            document.Add(new Paragraph(" "));

            // =====================================================
            // COMPANY + EMPLOYEE INFO
            // =====================================================

            var infoTable = new Table(2)
                .UseAllAvailableWidth();

            infoTable.SetMarginTop(10);

            // LEFT SECTION
            var companyCell = new Cell()
                .SetPadding(10);

            companyCell.Add(
                new Paragraph("Company Details")
                    .SimulateBold()
                    .SetFontSize(14)
            );

            companyCell.Add(
                new Paragraph(model.CompanyName ?? "")
                    .SetFontSize(12)
            );

            infoTable.AddCell(companyCell);

            // RIGHT SECTION
            var employeeCell = new Cell()
                .SetPadding(10);

            employeeCell.Add(
                new Paragraph("Employee Details")
                    .SimulateBold()
                    .SetFontSize(14)
            );

            employeeCell.Add(
                new Paragraph($"Employee: {model.EmployeeName}")
            );

            employeeCell.Add(
                new Paragraph($"Employee ID: {model.EmployeeId}")
            );

            employeeCell.Add(
                new Paragraph($"Designation: {model.Designation}")
            );

            infoTable.AddCell(employeeCell);

            document.Add(infoTable);

            // =====================================================
            // SALARY TABLE
            // =====================================================

            document.Add(
                new Paragraph("Salary Breakdown")
                    .SimulateBold()
                    .SetFontSize(16)
                    .SetMarginTop(25)
                    .SetMarginBottom(10)
            );

            var salaryTable = new Table(2)
                .UseAllAvailableWidth();

            // HEADER
            salaryTable.AddHeaderCell(
                new Cell()
                    .Add(new Paragraph("Description")
                    .SimulateBold()
                    .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetPadding(8)
            );

            salaryTable.AddHeaderCell(
                new Cell()
                    .Add(new Paragraph("Amount")
                    .SimulateBold()
                    .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // BASIC SALARY
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Basic Salary"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"{FormatMoney(model.BasicSalary, model.Currency)}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // BONUS
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Bonus"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"{FormatMoney(model.Bonus, model.Currency)}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // DEDUCTIONS
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Deductions"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"{FormatMoney(model.Deductions,model.Currency)}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.RED)
            );

            // NET SALARY
            salaryTable.AddCell(
                new Cell()
                    .Add(
                        new Paragraph("Net Salary")
                            .SimulateBold()
                    )
                    .SetPadding(10)
                    .SetBackgroundColor(
                        ColorConstants.LIGHT_GRAY
                    )
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(
                        new Paragraph($"{FormatMoney(model.NetSalary,model.Currency)}")
                            .SimulateBold()
                    )
                    .SetPadding(10)
                    .SetBackgroundColor(
                        ColorConstants.LIGHT_GRAY
                    )
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.BLUE)
            );

            document.Add(salaryTable);

            // =====================================================
            // FOOTER
            // =====================================================

            document.Add(
                new Paragraph(" ")
                    .SetMarginTop(20)
            );

            document.Add(
                new Paragraph(
                    "This is a computer-generated payslip and does not require a signature."
                )
                .SetFontSize(9)
                .SetFontColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
            );

            document.Add(
                new Paragraph("Generated by RatPDF.com")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.GRAY)
            );

            // CLOSE DOCUMENT
            document.Close();

            // RETURN PDF BYTES
            return stream.ToArray();
        }
        private string FormatMoney(decimal amount, string currency)
        {
            return currency switch
            {
                "ALL" => $"Lek {amount:N2}",
                "AOA" => $"Kz {amount:N2}",
                "ARS" => $"$ {amount:N2}",
                "AMD" => $"֏ {amount:N2}",
                "AUD" => $"A$ {amount:N2}",
                "AZN" => $"₼ {amount:N2}",
                "BDT" => $"৳ {amount:N2}",
                "BYN" => $"Br {amount:N2}",
                "BZD" => $"BZ$ {amount:N2}",
                "BOB" => $"Bs. {amount:N2}",
                "BAM" => $"KM {amount:N2}",
                "BWP" => $"P {amount:N2}",
                "BRL" => $"R$ {amount:N2}",
                "GBP" => $"£ {amount:N2}",
                "BND" => $"B$ {amount:N2}",
                "BGN" => $"лв {amount:N2}",
                "KHR" => $"៛ {amount:N2}",
                "CAD" => $"C$ {amount:N2}",
                "CLP" => $"$ {amount:N2}",
                "CNY" => $"¥ {amount:N2}",
                "COP" => $"$ {amount:N2}",
                "CRC" => $"₡ {amount:N2}",
                "HRK" => $"kn {amount:N2}",
                "CUP" => $"₱ {amount:N2}",
                "CZK" => $"Kč {amount:N2}",
                "DKK" => $"kr {amount:N2}",
                "DOP" => $"RD$ {amount:N2}",
                "EGP" => $"£ {amount:N2}",
                "ETB" => $"Br {amount:N2}",
                "EUR" => $"€ {amount:N2}",
                "FJD" => $"FJ$ {amount:N2}",
                "GEL" => $"₾ {amount:N2}",
                "GHS" => $"₵ {amount:N2}",
                "GTQ" => $"Q {amount:N2}",
                "HKD" => $"HK$ {amount:N2}",
                "HUF" => $"Ft {amount:N2}",
                "ISK" => $"kr {amount:N2}",
                "INR" => $"₹ {amount:N2}",
                "IDR" => $"Rp {amount:N2}",
                "ILS" => $"₪ {amount:N2}",
                "JMD" => $"J$ {amount:N2}",
                "JPY" => $"¥ {amount:N2}",
                "KZT" => $"₸ {amount:N2}",
                "KES" => $"KSh {amount:N2}",
                "KRW" => $"₩ {amount:N2}",
                "LAK" => $"₭ {amount:N2}",
                "MYR" => $"RM {amount:N2}",
                "MVR" => $"ރ {amount:N2}",
                "MXN" => $"$ {amount:N2}",
                "MNT" => $"₮ {amount:N2}",
                "MMK" => $"Ks {amount:N2}",
                "NPR" => $"₨ {amount:N2}",
                "NZD" => $"NZ$ {amount:N2}",
                "NGN" => $"₦ {amount:N2}",
                "NOK" => $"kr {amount:N2}",
                "PKR" => $"₨ {amount:N2}",
                "PAB" => $"B/. {amount:N2}",
                "PEN" => $"S/ {amount:N2}",
                "PHP" => $"₱ {amount:N2}",
                "PLN" => $"zł {amount:N2}",
                "RON" => $"lei {amount:N2}",
                "RUB" => $"₽ {amount:N2}",
                "RSD" => $"дин. {amount:N2}",
                "SGD" => $"S$ {amount:N2}",
                "ZAR" => $"R {amount:N2}",
                "LKR" => $"Rs {amount:N2}",
                "SEK" => $"kr {amount:N2}",
                "CHF" => $"Fr {amount:N2}",
                "SYP" => $"£ {amount:N2}",
                "TWD" => $"NT$ {amount:N2}",
                "THB" => $"฿ {amount:N2}",
                "TRY" => $"₺ {amount:N2}",
                "UAH" => $"₴ {amount:N2}",
                "USD" => $"$ {amount:N2}",
                "UYU" => $"$U {amount:N2}",
                "UZS" => $"so'm {amount:N2}",
                "VEF" => $"Bs {amount:N2}",
                "VND" => $"₫ {amount:N2}",
                "ZMW" => $"ZK {amount:N2}",
                _ => $"{currency} {amount:N2}"
            };
        }
    }
}
