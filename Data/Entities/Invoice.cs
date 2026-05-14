using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ratpdf.Data.Entities
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }               // null for guest invoices

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required, MaxLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? DueDate { get; set; }

        [Required, MaxLength(200)]
        public string CustomerName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? CustomerEmail { get; set; }

        public string? CustomerAddress { get; set; }

        public string? Notes { get; set; }

        [MaxLength(50)]
        public string? TaxName { get; set; }            // e.g., 'GST', 'VAT'

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TaxRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [MaxLength(10)]
        public string Currency { get; set; } = "INR";

        public bool IsPaid { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<InvoiceItem>? Items { get; set; }
        public string? From { get; set; }
    }
}
