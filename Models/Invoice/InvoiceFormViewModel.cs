using System.ComponentModel.DataAnnotations;

namespace ratpdf.Models.Invoice
{
    public class InvoiceFormViewModel
    {
        public string? From { get; set; }
        [Required, Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress, Display(Name = "Customer Email")]
        public string? CustomerEmail { get; set; }

        [Display(Name = "Customer Address")]
        public string? CustomerAddress { get; set; }

        // Invoice details
        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Currency")]
        public string? Currency { get; set; } = "INR";

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        // Tax
        [Display(Name = "Tax Name")]
        public string? TaxName { get; set; } = "GST";

        [Range(0, 100)]
        public decimal TaxRate { get; set; } = 0;

        // Items (at least one)
        public List<InvoiceItemViewModel> Items { get; set; } = new() { new InvoiceItemViewModel() };
    }
}
