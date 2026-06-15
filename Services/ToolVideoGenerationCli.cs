using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using ratpdf.Constants;

namespace ratpdf.Services
{
    /// <summary>CLI entry for --generate-tool-videos (no DI).</summary>
    public static class ToolVideoGenerationCli
    {
        public static int Run(string contentRoot, string webRoot, bool force = false, int? limit = null)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var python = PythonRuntime.ResolveExecutable(config, null);
            var engineDir = Path.Combine(contentRoot, "Pdf-Engine");
            var gen = new FreeToolVideoGenerator(python, engineDir, webRoot, contentRoot);

            Console.WriteLine("Free tool videos — Edge TTS + ffmpeg (no API key, no paid services)");
            var exitCode = gen.GenerateAll(force: force, limit: limit);
            Console.WriteLine(exitCode == 0 ? "All requested videos generated." : "Some videos failed — see errors above.");
            return exitCode;
        }

        public static int CaptureScreenshots(string contentRoot, string webRoot, string baseUrl, int? limit = null, string? only = null)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var python = PythonRuntime.ResolveExecutable(config, null);
            var engineDir = Path.Combine(contentRoot, "Pdf-Engine");
            var gen = new FreeToolVideoGenerator(python, engineDir, webRoot, contentRoot);

            Console.WriteLine($"Capturing tool screenshots from {baseUrl} (Playwright)…");
            var exitCode = gen.CaptureScreenshots(baseUrl, limit: limit, only: only);
            Console.WriteLine(exitCode == 0 ? "Screenshots captured." : "Some screenshots failed — see errors above.");
            return exitCode;
        }
    }
}
