using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ratpdf.Data.Entities;
using ratpdf.Services.Invoice.Contract;
using ratpdf.Services.Invoice.Feature;

namespace ratpdf.Services.Invoice
{
    public class InvoicePdfService
    {
        private readonly BrandingService _brandingService;
        private readonly FeatureAccessor _featureAccessor;
        private readonly ILogoStorageService _logoStorage;
        private readonly ILogger<InvoicePdfService> _logger;

        public InvoicePdfService(
            BrandingService brandingService,
            FeatureAccessor featureAccessor,
            ILogoStorageService logoStorage,
            ILogger<InvoicePdfService> logger)
        {
            _brandingService = brandingService;
            _featureAccessor = featureAccessor;
            _logoStorage = logoStorage;
            _logger = logger;
        }

        public async Task<byte[]> GenerateInvoicePdfAsync(Data.Entities.Invoice invoice, Guid? userId)
        {
            var canCustomize = userId.HasValue && await _featureAccessor.CanRemoveWatermarkAsync(userId.Value);
            BrandingSettings? branding = null;

            if (userId.HasValue)
                branding = await _brandingService.GetBrandingAsync(userId.Value);

            // Free users always get a watermark; Pro/Business watermark removed
            bool applyWatermark = !canCustomize;

            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);
            document.SetMargins(36, 36, 36, 36);
            var fontPath = System.IO.Path.Combine(
                Directory.GetCurrentDirectory(),
                "fonts",
                "NotoSans-Regular.ttf"
            );
            PdfFont unicodeFont = PdfFontFactory.CreateFont(
               fontPath,
               PdfEncodings.IDENTITY_H,
               PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED
           );
            // Colors
            var primaryColor = ParseHexColor(branding?.PrimaryColor ?? "#1A73E8");
            var accentColor = branding?.AccentColor != null ? ParseHexColor(branding.AccentColor) : null;

            // --- Header ---
            if (canCustomize && branding?.LogoUrl != null)
            {
                try
                {
                    var logoBytes = await _logoStorage.GetLogoBytesAsync(branding.LogoUrl);
                    if (logoBytes != null)
                    {
                        var logoImage = new Image(ImageDataFactory.Create(logoBytes));
                        logoImage.SetHeight(40);
                        document.Add(logoImage);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to load logo for user {UserId}", userId);
                }
            }

            var companyName = branding?.CompanyName;
            if (string.IsNullOrWhiteSpace(companyName))
            {
                if (!string.IsNullOrWhiteSpace(invoice.From))
                {
                    companyName = $"{invoice.From} • Invoice generated with RatPDF";
                }
                else
                {
                    companyName = "Invoice generated with RatPDF";
                }
            }
            document.Add(new Paragraph(companyName)
                .SetFontSize(20)
                .SetFontColor(primaryColor));

            if (!string.IsNullOrWhiteSpace(branding?.CompanyAddress))
                document.Add(new Paragraph(branding.CompanyAddress).SetFontSize(10));

            // Invoice info (right aligned)
            document.Add(new Paragraph($"Invoice: {invoice.InvoiceNumber}")
                .SetTextAlignment(TextAlignment.RIGHT));
            document.Add(new Paragraph($"Date: {invoice.IssueDate:dd MMM yyyy}")
                .SetTextAlignment(TextAlignment.RIGHT));
            document.Add(new Paragraph($"Due Date: {invoice.DueDate:dd MMM yyyy}")
                .SetTextAlignment(TextAlignment.RIGHT));
            // --- Customer ---
            document.Add(new Paragraph("Bill To:").SimulateBold());
            document.Add(new Paragraph(invoice.CustomerName));
            if (!string.IsNullOrWhiteSpace(invoice.CustomerAddress))
                document.Add(new Paragraph(invoice.CustomerAddress));
            if (!string.IsNullOrWhiteSpace(invoice.CustomerEmail))
                document.Add(new Paragraph(invoice.CustomerEmail));

            // --- Items Table ---
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 1, 1, 1 })).UseAllAvailableWidth();
            Cell headerCell(string text) =>
                new Cell().Add(new Paragraph(text))
                    .SetFontColor(ColorConstants.WHITE)
                    .SetBackgroundColor(primaryColor)
                    .SetPadding(5);
            table.AddHeaderCell(headerCell("Description"));
            table.AddHeaderCell(headerCell("Qty"));
            table.AddHeaderCell(headerCell("Unit Price"));
            table.AddHeaderCell(headerCell("Amount"));

            foreach (var item in invoice.Items)
            {
                table.AddCell(new Cell().Add(new Paragraph(item.Description)).SetPadding(3));
                table.AddCell(new Cell().Add(new Paragraph(item.Quantity.ToString("N2"))).SetPadding(3));
                table.AddCell(new Cell().Add(new Paragraph(FormatMoney(item.UnitPrice,invoice.Currency))).SetPadding(3).SetFont(unicodeFont));
                table.AddCell(new Cell().Add(new Paragraph(FormatMoney(item.Amount,invoice.Currency))).SetPadding(3).SetFont(unicodeFont));
            }

            document.Add(table);

            // --- Totals ---
            document.Add(new Paragraph($"Subtotal: {FormatMoney(invoice.Subtotal,invoice.Currency)}").SetFont(unicodeFont)
                .SetTextAlignment(TextAlignment.RIGHT));
            if (invoice.TaxRate > 0)
            {
                document.Add(new Paragraph($"{invoice.TaxName} ({invoice.TaxRate}%): {FormatMoney(invoice.TaxAmount,invoice.Currency)}").SetFont(unicodeFont)
                    .SetTextAlignment(TextAlignment.RIGHT));
            }
            document.Add(new Paragraph($"Total: {FormatMoney(invoice.Total, invoice.Currency)}")
                .SetTextAlignment(TextAlignment.RIGHT)
                .SimulateBold()).SetFont(unicodeFont);

            // --- Notes / Footer ---
            if (!string.IsNullOrWhiteSpace(invoice.Notes))
                document.Add(new Paragraph(invoice.Notes).SetFontSize(9));

            if (!string.IsNullOrWhiteSpace(branding?.FooterText))
                document.Add(new Paragraph(branding.FooterText).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER));

            // --- Watermark for free users ---
            if (applyWatermark)
            {
                var watermark = new Paragraph("Powered by Rat PDF Invoice Generator")
                    .SetFontColor(new DeviceRgb(210, 210, 210))
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFixedPosition(120, 280, 350);
                document.Add(watermark);
            }

            document.Close();
            return ms.ToArray();
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
        private static DeviceRgb ParseHexColor(string hex)
        {
            hex = hex.TrimStart('#');
            return new DeviceRgb(
                Convert.ToInt32(hex.Substring(0, 2), 16),
                Convert.ToInt32(hex.Substring(2, 2), 16),
                Convert.ToInt32(hex.Substring(4, 2), 16));
        }
    }
}
