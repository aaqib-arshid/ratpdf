using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ratpdf.Data.Entities
{
    public class UsageLog
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }          // null for guest actions

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required, MaxLength(100)]
        public string Action { get; set; } = string.Empty;  // 'generate_invoice', 'download_pdf'

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
