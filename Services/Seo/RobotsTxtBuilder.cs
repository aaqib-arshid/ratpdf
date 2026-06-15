using System.Text;
using ratpdf.Constants;

namespace ratpdf.Services.Seo
{
    public static class RobotsTxtBuilder
    {
        public static string Build()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User-agent: *");
            sb.AppendLine("Allow: /");
            sb.AppendLine("Disallow: /account/");
            sb.AppendLine("Disallow: /invoicedashboard/");
            sb.AppendLine("Disallow: /subscription/");
            sb.AppendLine("Disallow: /api/");
            sb.AppendLine("Disallow: /error/");
            sb.AppendLine("Disallow: /*-keywords.txt");
            sb.AppendLine();
            sb.AppendLine("# AI search & answer engine crawlers (discoverability)");
            foreach (var bot in new[] { "GPTBot", "ChatGPT-User", "Google-Extended", "PerplexityBot", "ClaudeBot", "anthropic-ai", "Applebot-Extended", "cohere-ai" })
            {
                sb.AppendLine($"User-agent: {bot}");
                sb.AppendLine("Allow: /");
                sb.AppendLine();
            }

            sb.AppendLine($"Sitemap: {PdfToolSeo.SiteUrl}/sitemap.xml");
            sb.AppendLine();
            sb.AppendLine("# LLM site guide: https://ratpdf.com/llms.txt");
            return sb.ToString();
        }

        public static void WriteToWwwRoot(string webRootPath)
        {
            var path = Path.Combine(webRootPath, "robots.txt");
            File.WriteAllText(path, Build(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }
    }
}
