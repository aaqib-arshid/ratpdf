namespace ratpdf.Data.Entities
{
    public class ImgBgPayment
    {
        public int Id { get; set; }

        public string UserKey { get; set; } = string.Empty;

        public string RazorpayOrderId { get; set; } = string.Empty;

        public string RazorpayPaymentId { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
