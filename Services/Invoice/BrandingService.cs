using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;

namespace ratpdf.Services.Invoice
{
    public class BrandingService
    {
        private readonly RatPDFDbContext _db;

        public BrandingService(RatPDFDbContext db) => _db = db;

        public async Task<BrandingSettings?> GetBrandingAsync(Guid userId)
        {
            return await _db.BrandingSettings
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task SaveBrandingAsync(Guid userId, BrandingSettings settings)
        {
            var existing = await _db.BrandingSettings.FirstOrDefaultAsync(b => b.UserId == userId);
            if (existing == null)
            {
                settings.Id = Guid.NewGuid();
                settings.UserId = userId;
                _db.BrandingSettings.Add(settings);
            }
            else
            {
                existing.LogoUrl = settings.LogoUrl;
                existing.PrimaryColor = settings.PrimaryColor;
                existing.AccentColor = settings.AccentColor;
                existing.CompanyName = settings.CompanyName;
                existing.CompanyAddress = settings.CompanyAddress;
                existing.FooterText = settings.FooterText;
            }
            await _db.SaveChangesAsync();
        }
    }
}
