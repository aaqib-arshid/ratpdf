using QRCoder;
using System.Drawing.Imaging;


namespace ratpdf.Helpers
{
    public  static class QRCodeGenerationService
    {
        public static byte[] GenerateUpiQr(string upiId, string name, decimal amount = 0)
        {
            string upiUrl = $"upi://pay?pa={upiId}&pn={name}&cu=INR";

            using var qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(upiUrl, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new QRCode(qrData);
            using var qrImage = qrCode.GetGraphic(20);

            using var ms = new MemoryStream();
            qrImage.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
    }
}
