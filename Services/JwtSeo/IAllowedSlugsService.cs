using System.Text;

namespace ratpdf.Services.JwtSeo;

public interface IAllowedSlugsService
{
    bool IsValidSlug(string slug);
    IReadOnlyList<string> GetAllSlugs();
}
public class AllowedSlugsService : IAllowedSlugsService
{
    private readonly HashSet<string> _slugs;
    private readonly List<string> _slugList;

    public AllowedSlugsService(IWebHostEnvironment env)
    {
        var filePath = Path.Combine(env.ContentRootPath, "SeoData", "jwt_keywords_slugs.txt");

        List<string> lines = new();
        if (File.Exists(filePath))
            lines = File.ReadAllLines(filePath, Encoding.UTF8)
                        .Where(l => !string.IsNullOrWhiteSpace(l))
                        .Select(l => l.Trim())
                        .ToList();
        else
            Console.WriteLine($"Warning: Slug file not found at {filePath}");

        _slugs = new HashSet<string>(lines, StringComparer.OrdinalIgnoreCase);
        _slugList = lines;
    }

    public bool IsValidSlug(string slug) => _slugs.Contains(slug);
    public IReadOnlyList<string> GetAllSlugs() => _slugList;
}