using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ratpdf.Data.Entities
{
    public class BrandingSettings
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [MaxLength(500)]
        public string? LogoUrl { get; set; }

        [MaxLength(7)]
        public string PrimaryColor { get; set; } = "#1A73E8";

        [MaxLength(7)]
        public string? AccentColor { get; set; }

        [MaxLength(200)]
        public string? CompanyName { get; set; }

        public string? CompanyAddress { get; set; }

        [MaxLength(500)]
        public string? FooterText { get; set; }
        public string? UpiQrUrl { get; set; }
    }
}
