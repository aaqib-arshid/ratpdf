using System.Text.RegularExpressions;

namespace ratpdf.Services.Seo
{
    /// <summary>One-time fixer: removes duplicate head tags from invoice landing views.</summary>
    public static class InvoiceSeoHeadFixer
    {
        private static readonly Regex CanonicalRegex = new(@"var canonicalUrl = ""([^""]+)"";", RegexOptions.Compiled);
        private static readonly Regex KeywordsRegex = new(@"<meta name=""keywords"" content=""([^""]*)""", RegexOptions.Compiled);
        private static readonly Regex GeoRegionRegex = new(@"<meta name=""geo\.region"" content=""([^""]*)""", RegexOptions.Compiled);
        private static readonly Regex GeoCountryRegex = new(@"<meta name=""geo\.country"" content=""([^""]*)""", RegexOptions.Compiled);
        private static readonly Regex OgLocaleRegex = new(@"<meta property=""og:locale"" content=""([^""]*)""", RegexOptions.Compiled);
        private static readonly Regex DuplicateHeadRegex = new(
            @"@section Head \{\s*<meta charset=""utf-8"" />\s*<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />\s*<meta name=""viewport"" content=""width=device-width, initial-scale=1\.0"" />\s*<title>[^<]*</title>\s*<meta name=""title""[^>]*/>\s*<meta name=""description""[^>]*/>\s*<meta name=""keywords""[^>]*/>\s*<meta name=""author""[^>]*/>\s*<meta name=""robots""[^>]*/>\s*<meta name=""language""[^>]*/>\s*<meta name=""geo\.region""[^>]*/>\s*<meta name=""geo\.country""[^>]*/>\s*<link rel=""canonical""[^>]*/>\s*<!-- Open Graph -->.*?<!-- Twitter -->.*?(?=<!-- Structured Data -->)",
            RegexOptions.Compiled | RegexOptions.Singleline);

        private static readonly Regex AggregateRatingBlockRegex = new(
            @",?\s*""aggregateRating""\s*:\s*\{[\s\S]*?\}",
            RegexOptions.Compiled);

        private static readonly Regex TrailingCommaBeforeBraceRegex = new(
            @",(\s*\})",
            RegexOptions.Compiled);

        public static int FixInvoiceViews(string viewsRoot)
        {
            var invoiceDir = Path.Combine(viewsRoot, "Invoice");
            if (!Directory.Exists(invoiceDir)) return 0;

            var count = 0;
            foreach (var file in Directory.EnumerateFiles(invoiceDir, "*.cshtml"))
            {
                var content = File.ReadAllText(file);
                if (!content.Contains("@section Head") || !content.Contains("var canonicalUrl"))
                    continue;

                var canonical = CanonicalRegex.Match(content).Groups[1].Value;
                if (string.IsNullOrEmpty(canonical)) continue;

                content = CanonicalRegex.Replace(content, "");
                var insert = $"""
                    ViewData["CanonicalUrl"] = "{canonical}";
                        ViewData["OgImage"] = "https://ratpdf.com/images/hero-invoice.svg";
                    """;

                if (KeywordsRegex.Match(content) is { Success: true } kw)
                    insert += $"\n    ViewData[\"Keywords\"] = \"{kw.Groups[1].Value}\";";
                if (GeoRegionRegex.Match(content) is { Success: true } gr)
                    insert += $"\n    ViewData[\"GeoRegion\"] = \"{gr.Groups[1].Value}\";";
                if (GeoCountryRegex.Match(content) is { Success: true } gc)
                    insert += $"\n    ViewData[\"GeoCountry\"] = \"{gc.Groups[1].Value}\";";
                if (OgLocaleRegex.Match(content) is { Success: true } ol)
                    insert += $"\n    ViewData[\"OgLocale\"] = \"{ol.Groups[1].Value}\";";

                content = content.Replace(
                    "Layout = \"~/Views/Shared/_Layout.cshtml\";",
                    "Layout = \"~/Views/Shared/_Layout.cshtml\";\n    " + insert.TrimEnd());

                var updated = DuplicateHeadRegex.Replace(content, "@section Head {\n    ");
                if (updated == content) continue;

                File.WriteAllText(file, updated);
                count++;
                Console.WriteLine($"  Fixed: {Path.GetFileName(file)}");
            }

            return count;
        }

        public static int FixPdfToolH1(string viewsRoot)
        {
            var pdfDir = Path.Combine(viewsRoot, "PDF");
            if (!Directory.Exists(pdfDir)) return 0;

            var count = 0;
            foreach (var file in Directory.EnumerateFiles(pdfDir, "*.cshtml"))
            {
                var lines = File.ReadAllLines(file);
                for (var i = 0; i < lines.Length; i++)
                {
                    if (!lines[i].Contains("<h2 class=\"fw-bold")) continue;
                    lines[i] = lines[i].Replace("<h2 ", "<h1 ").Replace("</h2>", "</h1>");
                    File.WriteAllLines(file, lines);
                    count++;
                    Console.WriteLine($"  Fixed H1: {Path.GetFileName(file)}");
                    break;
                }
            }

            return count;
        }

        public static int FixStaticSitemapCasing(string webRoot)
        {
            var sitemapDir = Path.Combine(webRoot, "sitemaps");
            if (!Directory.Exists(sitemapDir)) return 0;

            var replacements = new (string Old, string New)[]
            {
                ("https://ratpdf.com/PDF/", "https://ratpdf.com/pdf/"),
                ("https://ratpdf.com/Tools/", "https://ratpdf.com/tools/"),
                ("https://ratpdf.com/Home/", "https://ratpdf.com/home/"),
                ("https://ratpdf.com/Calculators/", "https://ratpdf.com/calculators/"),
                ("https://ratpdf.com/PaySlip/", "https://ratpdf.com/payslip/"),
                ("https://ratpdf.com/RentReceipt/", "https://ratpdf.com/rentreceipt/"),
            };

            var count = 0;
            foreach (var file in Directory.EnumerateFiles(sitemapDir, "*.xml"))
            {
                var content = File.ReadAllText(file);
                var original = content;
                foreach (var (old, @new) in replacements)
                    content = content.Replace(old, @new);
                if (content == original) continue;
                File.WriteAllText(file, content);
                count++;
                Console.WriteLine($"  Fixed sitemap: {Path.GetFileName(file)}");
            }

            return count;
        }

        public static int RemoveFabricatedAggregateRatings(string viewsRoot)
        {
            var count = 0;
            foreach (var file in Directory.EnumerateFiles(viewsRoot, "*.cshtml", SearchOption.AllDirectories))
            {
                var content = File.ReadAllText(file);
                if (!content.Contains("aggregateRating", StringComparison.Ordinal))
                    continue;

                var updated = AggregateRatingBlockRegex.Replace(content, "");
                updated = TrailingCommaBeforeBraceRegex.Replace(updated, "$1");
                if (updated == content) continue;

                File.WriteAllText(file, updated);
                count++;
                Console.WriteLine($"  Removed aggregateRating: {Path.GetRelativePath(viewsRoot, file)}");
            }

            return count;
        }

        public static int FixInvoiceHeroImages(string viewsRoot)
        {
            var invoiceDir = Path.Combine(viewsRoot, "Invoice");
            if (!Directory.Exists(invoiceDir)) return 0;

            var count = 0;
            foreach (var file in Directory.EnumerateFiles(invoiceDir, "*.cshtml"))
            {
                var content = File.ReadAllText(file);
                if (!content.Contains("hero-invoice.svg", StringComparison.Ordinal))
                    continue;

                var updated = content
                    .Replace("loading=\"lazy\" />", "width=\"480\" height=\"320\" />")
                    .Replace("loading=\"lazy\"/>", "width=\"480\" height=\"320\"/>");

                if (!updated.Contains("width=\"480\"", StringComparison.Ordinal))
                {
                    updated = updated.Replace(
                        "class=\"img-fluid rounded shadow-lg\" />",
                        "class=\"img-fluid rounded shadow-lg\" width=\"480\" height=\"320\" />");
                }

                if (updated == content) continue;
                File.WriteAllText(file, updated);
                count++;
                Console.WriteLine($"  Fixed hero image: {Path.GetFileName(file)}");
            }

            return count;
        }
    }
}
