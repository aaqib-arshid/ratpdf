using System.Text.Json;
using System.Text.Json.Serialization;
using ratpdf.Content;
using ratpdf.Models;

namespace ratpdf.Services.Seo
{
    /// <summary>Exports published English guides to JSON for the localization pipeline.</summary>
    public static class GuideManifestExporter
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static GuideManifestExportResult Export(string outputPath)
        {
            var guides = ContentLibrary.Guides
                .Select(g =>
                {
                    var roadmap = ContentRoadmapIndex.Get(g.Slug);
                    return new GuideManifestEntry
                    {
                        Slug = g.Slug,
                        Title = g.Title,
                        Description = g.Description,
                        Category = g.Category,
                        ToolUrl = g.ToolUrl,
                        Cluster = g.Cluster,
                        PrimaryKeyword = roadmap?.PrimaryKeyword ?? g.Title,
                        TrafficPotential = roadmap?.TrafficPotential,
                        Priority = roadmap?.Priority,
                        SearchScore = ContentGuideSearchScore.Estimate(g.Slug),
                        BodyHtml = g.BodyHtml,
                        FaqQuestions = g.FaqQuestions,
                        FaqAnswers = g.FaqAnswers,
                        HowToSteps = g.HowToSteps,
                    };
                })
                .OrderByDescending(g => g.SearchScore)
                .ThenBy(g => g.Slug, StringComparer.OrdinalIgnoreCase)
                .ToList();

            var manifest = new GuideManifest
            {
                ExportedAt = DateTime.UtcNow,
                Count = guides.Count,
                Guides = guides,
            };

            var dir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(outputPath, JsonSerializer.Serialize(manifest, JsonOptions));
            return new GuideManifestExportResult(outputPath, guides.Count);
        }
    }

    public sealed record GuideManifestExportResult(string OutputPath, int Count);

    public sealed class GuideManifest
    {
        public DateTime ExportedAt { get; set; }
        public int Count { get; set; }
        public List<GuideManifestEntry> Guides { get; set; } = [];
    }

    public sealed class GuideManifestEntry
    {
        public string Slug { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public string? ToolUrl { get; set; }
        public string? Cluster { get; set; }
        public string PrimaryKeyword { get; set; } = "";
        public string? TrafficPotential { get; set; }
        public string? Priority { get; set; }
        public int SearchScore { get; set; }
        public string BodyHtml { get; set; } = "";
        public string[]? FaqQuestions { get; set; }
        public string[]? FaqAnswers { get; set; }
        public string[]? HowToSteps { get; set; }
    }
}
