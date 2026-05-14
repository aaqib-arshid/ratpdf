using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;

namespace ratpdf.Services.Invoice
{
    public class UsageTracker
    {
        private readonly RatPDFDbContext _db;

        public UsageTracker(RatPDFDbContext db) => _db = db;

        public async Task LogAsync(Guid? userId, string action)
        {
            _db.UsageLogs.Add(new UsageLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Action = action,
                CreatedAt = DateTime.UtcNow
            });
            await _db.SaveChangesAsync();
        }
    }
}
