using System.ComponentModel.DataAnnotations;

namespace ratpdf.Models.Invoice
{
    public class InvoiceItemViewModel
    {
        [Required, Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; } = 1;

        [Required, Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        // Computed read-only amount for display; may be set in js, but not submitted
        public decimal Amount => Quantity * UnitPrice;
    }
}
