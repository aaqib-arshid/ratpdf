using ratpdf.Data.Entities;

namespace ratpdf.Models.Invoice
{
    public class DashboardViewModel
    {
        public List<Data.Entities.Invoice> Invoices { get; set; } = new();
        public List<Template> Templates { get; set; } = new();
        public bool IsPremium { get; set; }
        public string PlanName { get; set; } = "Free";
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalInvoices { get; set; }
    }
}
