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
            sb.AppendLine("Disallow: /Account/");
            sb.AppendLine("Disallow: /InvoiceDashboard/");
            sb.AppendLine("Disallow: /Error/");
            sb.AppendLine("Disallow: /*-keywords.txt");
            sb.AppendLine($"Sitemap: {PdfToolSeo.SiteUrl}/sitemap.xml");
            return sb.ToString();
        }

        public static void WriteToWwwRoot(string webRootPath)
        {
            var path = Path.Combine(webRootPath, "robots.txt");
            File.WriteAllText(path, Build(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }
    }
}
