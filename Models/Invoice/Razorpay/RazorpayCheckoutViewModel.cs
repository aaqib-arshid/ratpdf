namespace ratpdf.Models.Invoice.Razorpay
{
    public class RazorpayCheckoutViewModel
    {
        public string Key { get; set; } = string.Empty;
        public string SubscriptionId { get; set; } = string.Empty;
        public string Name { get; set; } = "Rat Pdf Invoice IQ";
        public string Description { get; set; } = string.Empty;
        public string? PrefillEmail { get; set; }
        public string? PrefillContact { get; set; }
        public Dictionary<string, string> Notes { get; set; } = new();
    }
}
