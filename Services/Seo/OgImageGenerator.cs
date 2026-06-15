using ratpdf.Constants;
using SkiaSharp;

namespace ratpdf.Services.Seo
{
    /// <summary>Renders 1200×630 PNG Open Graph images for PDF tools.</summary>
    public static class OgImageGenerator
    {
        public const int Width = 1200;
        public const int Height = 630;

        public static OgImageGenerationResult GenerateAll(string webRootPath)
        {
            var outDir = Path.Combine(webRootPath, "images", "og");
            Directory.CreateDirectory(outDir);
            var files = new List<string>();

            foreach (var tool in PdfToolSchemaCatalog.AllToolIds())
            {
                var catalog = PdfToolSchemaCatalog.Get(tool);
                var name = catalog?.ToolName ?? tool;
                var path = Path.Combine(outDir, $"{tool.ToLowerInvariant()}.png");
                File.WriteAllBytes(path, RenderPng(name));
                files.Add(path);
            }

            var defaultPath = Path.Combine(outDir, "default.png");
            File.WriteAllBytes(defaultPath, RenderPng("Free PDF Tools"));
            files.Add(defaultPath);

            return new OgImageGenerationResult(files.Count, outDir, files);
        }

        public static byte[] RenderPng(string toolName)
        {
            using var surface = SKSurface.Create(new SKImageInfo(Width, Height));
            var canvas = surface.Canvas;

            using var bgPaint = new SKPaint();
            bgPaint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(0, 0),
                new SKPoint(Width, Height),
                new[] { SKColor.Parse("#4a90e2"), SKColor.Parse("#667eea") },
                null,
                SKShaderTileMode.Clamp);
            canvas.DrawRect(0, 0, Width, Height, bgPaint);

            using var titlePaint = new SKPaint
            {
                Color = SKColors.White,
                IsAntialias = true,
                TextSize = 56,
                Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyle.Bold)
                    ?? SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold),
            };

            using var subPaint = new SKPaint
            {
                Color = SKColor.Parse("#e8f0ff"),
                IsAntialias = true,
                TextSize = 32,
                Typeface = SKTypeface.FromFamilyName("Segoe UI")
                    ?? SKTypeface.FromFamilyName("Arial"),
            };

            var display = Truncate(toolName, 32);
            canvas.DrawText(display, 80, 280, titlePaint);
            canvas.DrawText("Free online — ratpdf.com", 80, 350, subPaint);

            using var pillPaint = new SKPaint { Color = SKColors.White.WithAlpha(240), IsAntialias = true };
            canvas.DrawRoundRect(new SKRect(80, 410, 420, 470), 28, 28, pillPaint);

            using var pillText = new SKPaint
            {
                Color = SKColor.Parse("#4a5568"),
                IsAntialias = true,
                TextSize = 26,
                Typeface = SKTypeface.FromFamilyName("Segoe UI", SKFontStyle.Bold)
                    ?? SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold),
            };
            canvas.DrawText("No install · Secure · Fast", 110, 448, pillText);

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }

        private static string Truncate(string text, int maxLen) =>
            text.Length <= maxLen ? text : text[..(maxLen - 1)] + "…";
    }

    public sealed record OgImageGenerationResult(int Count, string OutputDirectory, IReadOnlyList<string> Files);
}
