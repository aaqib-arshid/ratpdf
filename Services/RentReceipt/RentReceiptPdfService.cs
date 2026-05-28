using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ratpdf.Models.RentReceipt;

namespace ratpdf.Services.RentReceipt
{
    public class RentReceiptPdfService
    {
        private readonly IWebHostEnvironment _env;

        public RentReceiptPdfService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public byte[] Generate(RentReceiptModel model)
        {
            using var stream = new MemoryStream();

            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);

            doc.SetMargins(30, 30, 30, 30);

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

            doc.SetFont(font);

            // =====================================================
            // HEADER
            // =====================================================

            var header = new Paragraph("RENT RECEIPT")
                .SetFontSize(24)
                .SimulateBold()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(5);

            doc.Add(header);

            doc.Add(
                new Paragraph("ratpdf.com")
                    .SetFontSize(10)
                    .SetFontColor(ColorConstants.GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20)
            );

            // =====================================================
            // INFO BOX (CARD STYLE TABLE)
            // =====================================================

            var infoTable = new Table(2)
                .UseAllAvailableWidth();

            StyleCell(infoTable, "Landlord Name", model.LandlordName);
            StyleCell(infoTable, "Tenant Name", model.TenantName);
            StyleCell(infoTable, "Property Address", model.PropertyAddress);
            StyleCell(infoTable, "Rent Month", model.RentMonth);

            doc.Add(infoTable);

            doc.Add(new Paragraph(" "));

            // =====================================================
            // AMOUNT SECTION (MODERN STYLE)
            // =====================================================

            var amountTable = new Table(2)
                .UseAllAvailableWidth();

            amountTable.SetMarginTop(10);

            AddAmountRow(amountTable, "Rent Amount", model.RentAmount, model.Currency);
            AddAmountRow(amountTable, "Maintenance", model.Maintenance, model.Currency);

            // TOTAL HIGHLIGHTED ROW
            var totalCellLabel = new Cell()
                .Add(new Paragraph("TOTAL AMOUNT")
                .SimulateBold())
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetPadding(10);

            var totalCellValue = new Cell()
                .Add(new Paragraph(FormatMoney(model.Total, model.Currency))
                .SimulateBold()
                .SetFontSize(14))
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetPadding(10);

            amountTable.AddCell(totalCellLabel);
            amountTable.AddCell(totalCellValue);

            doc.Add(amountTable);

            doc.Add(new Paragraph(" "));

            // =====================================================
            // FOOTER NOTE
            // =====================================================

            doc.Add(
                new Paragraph("This is a computer-generated rent receipt and does not require a signature.")
                    .SetFontSize(9)
                    .SetFontColor(ColorConstants.GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(20)
            );

            doc.Close();

            return stream.ToArray();
        }
        private void StyleCell(Table table, string label, string value)
        {
            table.AddCell(
                new Cell()
                    .Add(new Paragraph(label).SimulateBold())
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetPadding(8)
            );

            table.AddCell(
                new Cell()
                    .Add(new Paragraph(value ?? ""))
                    .SetPadding(8)
                    .SetBackgroundColor(ColorConstants.WHITE)
            );
        }
        private void AddAmountRow(Table table, string label, decimal amount, string currency)
        {
            table.AddCell(
                new Cell()
                    .Add(new Paragraph(label))
                    .SetPadding(8)
            );

            table.AddCell(
                new Cell()
                    .Add(new Paragraph(FormatMoney(amount, currency)))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );
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
