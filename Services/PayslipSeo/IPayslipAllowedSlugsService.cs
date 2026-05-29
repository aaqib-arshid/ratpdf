using System.Text;
using System.Text.Json;

namespace ratpdf.Services.PayslipSeo
{
    public interface IPayslipAllowedSlugsService
    {
        bool IsValidSlug(string slug);
        List<string> GetAllSlugs();
    }
    public class PayslipAllowedSlugsService : IPayslipAllowedSlugsService
    {
        private readonly HashSet<string> _slugs;
        private readonly List<string> _slugList;
        public PayslipAllowedSlugsService(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "SeoData", "payslip_keywords_slugs.txt");
            var lines = File.Exists(filePath)
                ? File.ReadAllLines(filePath, Encoding.UTF8)
                : new[] { "salary-slip-generator", "create-pay-slip", "pay-slip-generator" };

            _slugs = new HashSet<string>(lines.Where(l => !string.IsNullOrWhiteSpace(l))
                                              .Select(l => l.Trim()),
                                         StringComparer.OrdinalIgnoreCase);
            _slugList = _slugs.ToList();
        }
        public bool IsValidSlug(string slug) => _slugs.Contains(slug);
        public List<string> GetAllSlugs() => _slugList;
    }
}
