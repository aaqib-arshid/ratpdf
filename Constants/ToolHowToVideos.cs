using Microsoft.AspNetCore.Hosting;

namespace ratpdf.Constants
{
    public sealed record ToolHowToVideo(string ToolUrl, string ToolName, string FileName, int DurationSeconds)
    {
        public const string LearningHubPath = "/learn";

        public string VideoPath => $"/videos/how-to/{FileName}";
        public string PosterPath => $"/videos/how-to/{System.IO.Path.GetFileNameWithoutExtension(FileName)}.jpg";
        public string SlidesDirectory => $"/images/tutorials/{Slug}";
        public string Slug => ToolHowToVideos.SlugFromUrl(ToolUrl);
        public string Title => $"How to use {ToolName}";
        public string LearnPath => $"{LearningHubPath}/{Slug}";

        public IReadOnlyList<string> GetSlidePaths(IWebHostEnvironment env)
        {
            var dir = Path.Combine(env.WebRootPath, "images", "tutorials", Slug);
            if (!Directory.Exists(dir)) return Array.Empty<string>();
            return Directory.GetFiles(dir, "step-*.jpg")
                .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
                .Select(f => $"{SlidesDirectory}/{Path.GetFileName(f)}")
                .ToList();
        }
    }

    public static class ToolHowToVideos
    {
        private static readonly Lazy<IReadOnlyDictionary<string, ToolHowToVideo>> Cache = new(Build);

        public static ToolHowToVideo? Get(string? toolPath)
        {
            if (string.IsNullOrWhiteSpace(toolPath)) return null;
            return Cache.Value.TryGetValue(Normalize(toolPath), out var v) ? v : null;
        }

        public static IEnumerable<ToolHowToVideo> All =>
            Cache.Value.Values.Where(v => !MedicalToolsRemoval.IsRemovedPath(v.ToolUrl));

        public static bool FileExists(ToolHowToVideo video, string webRootPath) =>
            File.Exists(Path.Combine(webRootPath, "videos", "how-to", video.FileName));

        private static IReadOnlyDictionary<string, ToolHowToVideo> Build()
        {
            var dict = new Dictionary<string, ToolHowToVideo>(StringComparer.OrdinalIgnoreCase);

            foreach (var t in PdfToolSeo.AllTools)
                Add(dict, t.Url, t.Name);

            foreach (var t in SiteToolNavigation.DeveloperTools)
                Add(dict, t.Url, t.Name);
            foreach (var t in SiteToolNavigation.ImageTools)
                Add(dict, t.Url, t.Name);
            foreach (var t in SiteToolNavigation.Utilities)
                Add(dict, t.Url, t.Name);
            foreach (var t in SiteToolNavigation.BusinessTools)
                Add(dict, t.Url, t.Name);
            foreach (var t in SiteToolNavigation.Calculators)
                Add(dict, t.Url, t.Name);

            Add(dict, "/pdf-redaction", "PDF Redaction");
            Add(dict, "/invoice/create", "Invoice Generator");
            Add(dict, "/tools/imgbackgroundremove", "Background Remover");

            return dict;
        }

        private static void Add(Dictionary<string, ToolHowToVideo> dict, string url, string name)
        {
            var key = Normalize(url);
            if (dict.ContainsKey(key)) return;
            dict[key] = new ToolHowToVideo(url, name, $"{SlugFromUrl(url)}.mp4", 45);
        }

        public static string SlugFromUrl(string url)
        {
            url = url.Trim().TrimEnd('/').ToLowerInvariant();
            if (url.StartsWith("/pdf/", StringComparison.Ordinal))
                return url["/pdf/".Length..].Replace('/', '-');
            if (url.StartsWith("/tools/", StringComparison.Ordinal))
                return url["/tools/".Length..].Replace('/', '-');
            return url.TrimStart('/').Replace('/', '-');
        }

        private static string Normalize(string path)
        {
            path = path.Trim();
            if (path.Length > 1 && path.EndsWith('/'))
                path = path.TrimEnd('/');
            return path.Length == 0 ? "/" : path;
        }
    }
}
