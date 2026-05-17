namespace ratpdf.Models.Invoice
{
    public class BulkInvoiceRow
    {
        public string ClientName { get; set; }
        public string ClientGstin { get; set; }
        public string YourGstin { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string HsnSac { get; set; }
        public string TaxType { get; set; }          // "CGST/SGST" or "IGST"
        public string PlaceOfSupply { get; set; }
        public string Notes { get; set; }
    }
}
