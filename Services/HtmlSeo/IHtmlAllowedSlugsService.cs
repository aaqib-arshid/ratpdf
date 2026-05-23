using System.Text;

namespace ratpdf.Services.HtmlSeo
{
    public interface IHtmlAllowedSlugsService
    {
        bool IsValidSlug(string slug);
        IReadOnlyList<string> GetAllSlugs();
    }
    public class HtmlAllowedSlugsService : IHtmlAllowedSlugsService
    {
        private readonly HashSet<string> _slugs;
        private readonly List<string> _slugList;

        public HtmlAllowedSlugsService(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "SeoData", "html_keywords_slugs.txt");
            var lines = File.Exists(filePath)
                ? File.ReadAllLines(filePath, Encoding.UTF8)
                : new[] { "html-formatter", "beautify-html", "minify-html" }; 

            _slugs = new HashSet<string>(lines.Where(l => !string.IsNullOrWhiteSpace(l))
                                              .Select(l => l.Trim()),
                                         StringComparer.OrdinalIgnoreCase);
            _slugList = _slugs.ToList();
        }

        public bool IsValidSlug(string slug) => _slugs.Contains(slug);
        public IReadOnlyList<string> GetAllSlugs() => _slugList;
    }
}
