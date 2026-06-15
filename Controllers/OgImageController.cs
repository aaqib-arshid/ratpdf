using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    /// <summary>Dynamic Open Graph images (1200×630) for tool pages.</summary>
    [Route("og")]
    public class OgImageController : Controller
    {
        [HttpGet("tool/{toolId}.png")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
        public FileContentResult ToolPng(string toolId)
        {
            var catalog = PdfToolSchemaCatalog.Get(toolId);
            var meta = PdfToolSeoMeta.Get(toolId);
            var name = catalog?.ToolName ?? meta?.AppName ?? "PDF Tool";
            var bytes = OgImageGenerator.RenderPng(name);
            return File(bytes, "image/png");
        }

        [HttpGet("tool/{toolId}.svg")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
        public ContentResult ToolSvg(string toolId)
        {
            var catalog = PdfToolSchemaCatalog.Get(toolId);
            var meta = PdfToolSeoMeta.Get(toolId);
            var name = System.Net.WebUtility.HtmlEncode(catalog?.ToolName ?? meta?.AppName ?? "PDF Tool");
            var svg = $"""
                <svg xmlns="http://www.w3.org/2000/svg" width="1200" height="630" viewBox="0 0 1200 630">
                  <defs>
                    <linearGradient id="bg" x1="0%" y1="0%" x2="100%" y2="100%">
                      <stop offset="0%" style="stop-color:#4a90e2"/>
                      <stop offset="100%" style="stop-color:#667eea"/>
                    </linearGradient>
                  </defs>
                  <rect width="1200" height="630" fill="url(#bg)"/>
                  <text x="80" y="280" fill="#ffffff" font-family="Segoe UI, Arial, sans-serif" font-size="64" font-weight="700">{name}</text>
                  <text x="80" y="360" fill="#e8f0ff" font-family="Segoe UI, Arial, sans-serif" font-size="36">Free online — ratpdf.com</text>
                </svg>
                """;
            return Content(svg, "image/svg+xml", System.Text.Encoding.UTF8);
        }
    }
}
