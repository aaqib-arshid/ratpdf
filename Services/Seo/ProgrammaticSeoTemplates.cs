using System.Text;
using ratpdf.Constants;

namespace ratpdf.Services.Seo
{
    public enum ProgrammaticPageType
    {
        LongTail,
        Comparison,
        Alternative,
        UseCase,
        Location,
    }

    /// <summary>Reusable HTML builders for programmatic SEO page types.</summary>
    public static class ProgrammaticSeoTemplates
    {
        private static readonly string[] Competitors = ["Adobe Acrobat", "iLovePDF", "Smallpdf", "PDF24", "Sejda", "Foxit"];

        public static ProgrammaticPageType DetectType(string keyword)
        {
            var k = keyword.ToLowerInvariant();
            if (k.Contains(" vs ") || k.Contains(" versus ") || k.Contains("-vs-"))
                return ProgrammaticPageType.Comparison;
            if (k.Contains("alternative") || k.Contains("instead of"))
                return ProgrammaticPageType.Alternative;
            if (k.Contains(" for ") && !IsLocationKeyword(k))
                return ProgrammaticPageType.UseCase;
            if (IsLocationKeyword(k))
                return ProgrammaticPageType.Location;
            return ProgrammaticPageType.LongTail;
        }

        private static bool IsLocationKeyword(string k) =>
            k.Contains(" in india") || k.Contains(" in uk") || k.Contains(" in usa")
            || k.Contains(" in australia") || k.Contains(" in canada") || k.Contains(" in singapore")
            || k.Contains(" online india") || k.Contains(" online uk") || k.Contains(" online usa");

        public static string BuildTitle(string keyword, ProgrammaticPageType type, string toolName)
        {
            return type switch
            {
                ProgrammaticPageType.Comparison =>
                    $"{Capitalize(keyword)} — Feature Comparison | RatPDF",
                ProgrammaticPageType.Alternative =>
                    $"{Capitalize(keyword)} — Free Online | RatPDF",
                ProgrammaticPageType.UseCase =>
                    $"{Capitalize(keyword)} — Step-by-Step Guide | RatPDF",
                ProgrammaticPageType.Location =>
                    $"{Capitalize(keyword)} — Free & Secure | RatPDF",
                _ => keyword switch
                {
                    var s when s.Contains("free", StringComparison.OrdinalIgnoreCase) =>
                        $"{Capitalize(keyword)} — Free Online Tool | RatPDF",
                    var s when s.StartsWith("how to", StringComparison.OrdinalIgnoreCase) =>
                        $"{Capitalize(keyword)} — Guide | RatPDF",
                    _ => $"{Capitalize(keyword)} Online — Fast & Secure | RatPDF",
                },
            };
        }

        public static string BuildDescription(string keyword, ProgrammaticPageType type, string toolName) =>
            type switch
            {
                ProgrammaticPageType.Comparison =>
                    $"Compare {keyword} with RatPDF {toolName}. Side-by-side features, pricing, limits, and privacy — choose the best PDF workflow.",
                ProgrammaticPageType.Alternative =>
                    $"Looking for {keyword}? RatPDF offers a free browser-based {toolName} with HTTPS upload, no watermarks, and Pro plans from $8.99/mo.",
                ProgrammaticPageType.UseCase =>
                    $"Learn how to {keyword} with RatPDF. Practical workflow for real-world documents — secure, fast, no desktop install.",
                ProgrammaticPageType.Location =>
                    $"{Capitalize(keyword)} with RatPDF — GDPR-friendly processing, free tier, and Pro support for large files up to 4 GB.",
                _ => $"Learn how to {keyword} with RatPDF. Secure online PDF processing — free tier available, Pro up to 4 GB.",
            };

        public static string BuildContentHtml(
            ProgrammaticPageType type,
            string keyword,
            string toolLinkHtml,
            string toolHref,
            string verbPhrase,
            string hubHref)
        {
            return type switch
            {
                ProgrammaticPageType.Comparison => BuildComparison(keyword, toolLinkHtml, toolHref),
                ProgrammaticPageType.Alternative => BuildAlternative(keyword, toolLinkHtml, toolHref),
                ProgrammaticPageType.UseCase => BuildUseCase(keyword, toolLinkHtml, toolHref, verbPhrase),
                ProgrammaticPageType.Location => BuildLocation(keyword, toolLinkHtml, toolHref),
                _ => BuildLongTail(keyword, toolLinkHtml, toolHref, verbPhrase, hubHref),
            };
        }

        public static List<(string Question, string Answer)> BuildFaqs(
            ProgrammaticPageType type,
            string keyword,
            string toolLinkText,
            string toolHref,
            string verbPhrase)
        {
            var baseFaqs = new List<(string, string)>
            {
                ($"How do I {keyword}?", $"Open {toolLinkText} at ratpdf.com{toolHref}, upload your PDF, and follow the on-screen steps."),
                ("Is it free?", "Yes — 3 uses per tool per day on the free tier (200 MB/file). Pro adds unlimited use and 4 GB uploads."),
                ("Are files private?", "Uploads use HTTPS and temporary storage. Files are deleted after download."),
            };

            if (type == ProgrammaticPageType.Comparison)
                baseFaqs.Add(($"Is RatPDF better for {keyword}?", "RatPDF runs in the browser with no install, transparent free limits, and production PDF engines. Compare the table above to your current tool."));
            if (type == ProgrammaticPageType.Alternative)
                baseFaqs.Add(($"Why switch from a paid PDF tool?", "RatPDF covers merge, split, compress, convert, and sign in one site — free to start, Pro when you need volume or large files."));
            if (type == ProgrammaticPageType.UseCase)
                baseFaqs.Add(($"What file order should I use when I {verbPhrase}?", "Drag files into the order you want before processing. You can reorder in the preview on supported tools."));
            if (type == ProgrammaticPageType.Location)
                baseFaqs.Add(("Does RatPDF work internationally?", "Yes — RatPDF is browser-based and works worldwide. Data is processed over HTTPS; check our Privacy policy for retention details."));

            return baseFaqs;
        }

        private static string BuildLongTail(string keyword, string toolLink, string toolHref, string verbPhrase, string hubHref)
        {
            var sb = new StringBuilder();
            sb.Append($"""
                <p>Need to <strong>{keyword}</strong>? RatPDF's {toolLink} runs on production-grade engines with HTTPS upload and automatic file deletion. No desktop install required.</p>
                <h2>Why {keyword} online?</h2>
                <p>Browser tools save time on locked-down laptops, phones, and shared machines. Upload once, process on our servers, download the result. Free: 3 uses/day per tool, 200 MB per file. <a href="/Subscription/Plans">Pro</a>: 4 GB files, unlimited daily use.</p>
                <h2>How to {verbPhrase}</h2>
                <ol>
                <li>Open the {toolLink} on ratpdf.com.</li>
                <li>Upload your PDF (or multiple files if the tool supports batch).</li>
                <li>Configure options — page range, order, quality, or security settings.</li>
                <li>Start processing and wait for the progress indicator.</li>
                <li>Download the finished file when the job completes.</li>
                </ol>
                <h2>Related tools</h2>
                <p>Explore <a href="{hubHref}">more guides</a>, <a href="/pdf/compress">Compress PDF</a>, <a href="/pdf/merge">Merge PDF</a>, and <a href="/guides">step-by-step tutorials</a>.</p>
                """);
            return sb.ToString();
        }

        private static string BuildComparison(string keyword, string toolLink, string toolHref)
        {
            var competitor = ExtractCompetitor(keyword);
            var sb = new StringBuilder();
            sb.Append($"""
                <p>Evaluating <strong>{keyword}</strong>? This guide compares <strong>{competitor}</strong> with RatPDF's {toolLink} so you can pick the right workflow for speed, privacy, and cost.</p>
                <h2>{Capitalize(keyword)} — quick comparison</h2>
                <div class="table-responsive"><table class="table table-bordered">
                <thead><tr><th>Feature</th><th>RatPDF</th><th>{competitor}</th></tr></thead>
                <tbody>
                <tr><td>Install required</td><td>No — browser only</td><td>Often desktop app or account</td></tr>
                <tr><td>Free tier</td><td>3 uses/tool/day, 200 MB</td><td>Varies; often watermarks or limits</td></tr>
                <tr><td>Max file size (Pro)</td><td>4 GB</td><td>Plan-dependent</td></tr>
                <tr><td>HTTPS upload</td><td>Yes</td><td>Varies</td></tr>
                <tr><td>File retention</td><td>Deleted after download</td><td>Check vendor policy</td></tr>
                <tr><td>Related PDF tools</td><td>{PdfToolSeo.ToolCountLabel} on one site</td><td>Usually single-purpose</td></tr>
                </tbody></table></div>
                <h2>When RatPDF wins</h2>
                <ul>
                <li>You need a quick one-off task without installing software.</li>
                <li>You want merge + compress + convert in one subscription.</li>
                <li>You care about transparent free limits before upgrading.</li>
                </ul>
                <h2>Try RatPDF now</h2>
                <p>Open the {toolLink} and run your document through the same workflow you would use on {competitor} — compare output quality and speed yourself.</p>
                """);
            return sb.ToString();
        }

        private static string BuildAlternative(string keyword, string toolLink, string toolHref)
        {
            var competitor = ExtractCompetitor(keyword);
            var sb = new StringBuilder();
            sb.Append($"""
                <p>Searching for <strong>{keyword}</strong>? RatPDF is a capable free alternative to {competitor} for everyday PDF tasks — no credit card to start.</p>
                <h2>Why teams switch to RatPDF</h2>
                <ul>
                <li><strong>All-in-one toolkit</strong> — compress, merge, split, convert, sign, OCR on ratpdf.com</li>
                <li><strong>Browser-based</strong> — works on Windows, Mac, Linux, Chromebook, iPad</li>
                <li><strong>Clear pricing</strong> — free tier for light use; Pro from {SubscriptionPricing.FormatProShort()}</li>
                <li><strong>No watermarks</strong> on output for registered free-tier use within daily limits</li>
                </ul>
                <h2>Migration checklist</h2>
                <ol>
                <li>Bookmark {toolHref} for your most common task.</li>
                <li>Test one representative file (size, scan, forms) on the free tier.</li>
                <li>Upgrade to Pro if you hit daily limits or need 4 GB uploads.</li>
                </ol>
                <p>Start with the {toolLink} — same outcome as {competitor}, fewer tabs open.</p>
                """);
            return sb.ToString();
        }

        private static string BuildUseCase(string keyword, string toolLink, string toolHref, string verbPhrase)
        {
            var scenario = ExtractUseCase(keyword);
            var sb = new StringBuilder();
            sb.Append($"""
                <p><strong>{Capitalize(keyword)}</strong> is a common workflow in {scenario}. RatPDF's {toolLink} helps you {verbPhrase} without email attachments bouncing or portal rejections.</p>
                <h2>Typical workflow for {scenario}</h2>
                <ol>
                <li>Gather source PDFs in final order (cover letter → CV → certificates).</li>
                <li>Open {toolLink} and upload all files.</li>
                <li>Confirm page order in the preview.</li>
                <li>Process and download a single output PDF.</li>
                <li>Optional: <a href="/pdf/compress">compress</a> if the portal has a size cap.</li>
                </ol>
                <h2>Tips for {scenario}</h2>
                <ul>
                <li>Flatten forms first if uploads require non-editable PDFs.</li>
                <li>Use descriptive filenames before merging — easier to audit order.</li>
                <li>Run <a href="/pdf/ocrpdf">OCR</a> on scans so reviewers can search text.</li>
                </ul>
                """);
            return sb.ToString();
        }

        private static string BuildLocation(string keyword, string toolLink, string toolHref)
        {
            var region = ExtractRegion(keyword);
            var sb = new StringBuilder();
            sb.Append($"""
                <p>Users in <strong>{region}</strong> often search for <strong>{keyword}</strong>. RatPDF works globally — process PDFs from any browser with HTTPS encryption.</p>
                <h2>Popular in {region}</h2>
                <ul>
                <li>Freelancers sending invoices and contracts as single PDFs</li>
                <li>Students combining assignments before university portal upload</li>
                <li>Small businesses archiving receipts and statements monthly</li>
                </ul>
                <h2>Compliance &amp; privacy notes</h2>
                <p>Files are transferred over TLS and removed after processing. For GDPR-related questions see our <a href="/home/privacy">Privacy Policy</a>. No local install means less IT friction for distributed teams in {region}.</p>
                <p>Ready? Use the {toolLink} — free to start.</p>
                """);
            return sb.ToString();
        }

        private static string ExtractCompetitor(string keyword)
        {
            var k = keyword.ToLowerInvariant();
            foreach (var c in Competitors)
            {
                if (k.Contains(c.Split(' ')[0], StringComparison.OrdinalIgnoreCase))
                    return c;
            }
            if (k.Contains("ilovepdf")) return "iLovePDF";
            if (k.Contains("smallpdf")) return "Smallpdf";
            if (k.Contains("adobe") || k.Contains("acrobat")) return "Adobe Acrobat";
            return "other online PDF tools";
        }

        private static string ExtractUseCase(string keyword)
        {
            var idx = keyword.IndexOf(" for ", StringComparison.OrdinalIgnoreCase);
            if (idx >= 0)
                return keyword[(idx + 5)..].Trim();
            return "professional document workflows";
        }

        private static string ExtractRegion(string keyword)
        {
            var k = keyword.ToLowerInvariant();
            if (k.Contains("india")) return "India";
            if (k.Contains(" uk") || k.Contains("united kingdom")) return "the United Kingdom";
            if (k.Contains("usa") || k.Contains(" united states")) return "the United States";
            if (k.Contains("australia")) return "Australia";
            if (k.Contains("canada")) return "Canada";
            if (k.Contains("singapore")) return "Singapore";
            return "your region";
        }

        private static string Capitalize(string kword)
        {
            if (string.IsNullOrEmpty(kword)) return kword;
            return char.ToUpperInvariant(kword[0]) + kword[1..];
        }
    }
}
