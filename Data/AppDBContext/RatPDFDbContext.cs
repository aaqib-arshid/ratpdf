using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.Entities;
using Razorpay.Api;

namespace ratpdf.Data.AppDBContext
{
    public class RatPDFDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public RatPDFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Entities.Subscription> Subscriptions { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<BrandingSettings> BrandingSettings { get; set; }
        public DbSet<UsageLog> UsageLogs { get; set; }
        public DbSet<ImgBgUserUsage> ImgBgUserUsages { get; set; }

        public DbSet<ImgBgUserSubscription> ImgBgUserSubscriptions { get; set; }

        public DbSet<ImgBgPayment> ImgBgPayments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 

            // --- User ---
            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.FullName).HasMaxLength(200);
                entity.HasIndex(u => u.Email).IsUnique();
            });

            // --- Subscription ---
            builder.Entity<Entities.Subscription>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.PlanId).HasMaxLength(100).IsRequired();
                entity.Property(s => s.Status).HasMaxLength(50).IsRequired();
                entity.Property(s => s.RazorpaySubscriptionId).HasMaxLength(200);

                entity.HasOne(s => s.User)
                      .WithOne(u => u.Subscription)
                      .HasForeignKey<Entities.Subscription>(s => s.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // one active subscription per user (enforced by unique index or application logic)
                // Using a filtered index for active subscriptions only (SQL Server)
                entity.HasIndex(s => s.UserId)
                      .IsUnique()
                      .HasFilter("[Status] = 'active'");
            });

            // --- Invoice ---
            builder.Entity<Entities.Invoice>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.InvoiceNumber).HasMaxLength(50).IsRequired();
                entity.Property(i => i.CustomerName).HasMaxLength(200).IsRequired();
                entity.Property(i => i.CustomerEmail).HasMaxLength(200);
                entity.Property(i => i.Currency).HasMaxLength(10).HasDefaultValue("INR");
                entity.Property(i => i.Subtotal).HasColumnType("decimal(18,2)");
                entity.Property(i => i.TaxAmount).HasColumnType("decimal(18,2)");
                entity.Property(i => i.Total).HasColumnType("decimal(18,2)");
                entity.Property(i => i.TaxRate).HasColumnType("decimal(5,2)");

                entity.HasOne(i => i.User)
                      .WithMany(u => u.Invoices)
                      .HasForeignKey(i => i.UserId)
                      .IsRequired(false)   // nullable for guest invoices
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(i => i.InvoiceNumber);
                entity.HasIndex(i => i.UserId);
            });

            // --- InvoiceItem ---
            builder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(ii => ii.Id);
                entity.Property(ii => ii.Description).HasMaxLength(500).IsRequired();
                entity.Property(ii => ii.Quantity).HasColumnType("decimal(10,2)");
                entity.Property(ii => ii.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(ii => ii.Amount).HasColumnType("decimal(18,2)");

                entity.HasOne(ii => ii.Invoice)
                      .WithMany(i => i.Items)
                      .HasForeignKey(ii => ii.InvoiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // --- Template ---
            builder.Entity<Template>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).HasMaxLength(200).IsRequired();
                entity.Property(t => t.InvoiceData).IsRequired(); // will store as nvarchar(max)

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Templates)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // --- BrandingSettings ---
            builder.Entity<BrandingSettings>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.PrimaryColor).HasMaxLength(7).HasDefaultValue("#1A73E8");
                entity.Property(b => b.AccentColor).HasMaxLength(7);
                entity.Property(b => b.CompanyName).HasMaxLength(200);
                entity.Property(b => b.FooterText).HasMaxLength(500);
                entity.Property(b => b.LogoUrl).HasMaxLength(500);

                entity.HasOne(b => b.User)
                      .WithOne(u => u.BrandingSettings)
                      .HasForeignKey<BrandingSettings>(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Only one branding settings per user
                entity.HasIndex(b => b.UserId).IsUnique();
            });

            // --- UsageLog ---
            builder.Entity<UsageLog>(entity =>
            {
                entity.HasKey(ul => ul.Id);
                entity.Property(ul => ul.Action).HasMaxLength(100).IsRequired();

                entity.HasOne(ul => ul.User)
                      .WithMany(u => u.UsageLogs)
                      .HasForeignKey(ul => ul.UserId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(ul => ul.UserId);
                entity.HasIndex(ul => new { ul.UserId, ul.Action });
            });
        }
    }
}
