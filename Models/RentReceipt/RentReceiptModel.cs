namespace ratpdf.Models.RentReceipt
{
    public class RentReceiptModel
    {
        public string LandlordName { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;

        public string PropertyAddress { get; set; } = string.Empty;

        public string RentMonth { get; set; } = string.Empty;
        public string Currency { get; set; } = "INR";
        public decimal RentAmount { get; set; }

        public decimal Maintenance { get; set; }

        public decimal Total =>
            RentAmount + Maintenance;
    }
}
