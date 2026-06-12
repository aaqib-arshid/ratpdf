using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using System.Text.Json;

namespace ratpdf.Services.Invoice
{
    public class TemplateService
    {
        private readonly RatPDFDbContext _db;

        public TemplateService(RatPDFDbContext db) => _db = db;

        public async Task<List<Template>> GetUserTemplatesAsync(Guid userId)
        {
            return await _db.Templates
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Template?> GetTemplateAsync(Guid templateId)
        {
            return await _db.Templates.FindAsync(templateId);
        }

        public async Task<Template> SaveTemplateAsync(Guid userId, string name, object invoiceData)
        {
            var template = new Template
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = name,
                InvoiceData = JsonSerializer.Serialize(invoiceData),
                CreatedAt = DateTime.UtcNow
            };
            _db.Templates.Add(template);
            await _db.SaveChangesAsync();
            return template;
        }

        public async Task DeleteTemplateAsync(Guid templateId)
        {
            var template = await _db.Templates.FindAsync(templateId);
            if (template != null)
            {
                _db.Templates.Remove(template);
                await _db.SaveChangesAsync();
            }
        }
    }
}
