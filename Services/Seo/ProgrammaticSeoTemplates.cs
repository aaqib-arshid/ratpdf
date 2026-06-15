using System.Text;
using ratpdf.Constants;
using ratpdf.Helpers;

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

        public static string BuildDisplayTitle(string keyword, string slug) =>
            SlugTitleHelper.FromPhrase(keyword);

        public static string BuildTitle(string keyword, ProgrammaticPageType type, string toolLinkText, string slug) =>
            ProgrammaticToolMetaCatalog.BuildPageTitle(BuildDisplayTitle(keyword, slug), type);

        public static string BuildDescription(
            ProgrammaticToolCategory category,
            string displayTitle,
            string toolLinkText) =>
            ProgrammaticToolMetaCatalog.BuildMetaDescription(category, displayTitle, toolLinkText);

        public static string BuildContentHtml(
            ProgrammaticToolCategory category,
            ProgrammaticPageType type,
            string keyword,
            string displayTitle,
            string toolLinkHtml,
            string toolHref,
            string verbPhrase,
            string hubHref,
            string toolLinkText)
        {
            if (category == ProgrammaticToolCategory.MedicalCalculator)
                return BuildMedicalCalculator(type, displayTitle, toolLinkHtml, toolHref, toolLinkText, hubHref);

            if (category == ProgrammaticToolCategory.GeneralCalculator)
                return BuildGeneralCalculator(displayTitle, toolLinkHtml, toolHref, toolLinkText, hubHref);

            return type switch
            {
                ProgrammaticPageType.Comparison => BuildComparison(displayTitle, keyword, toolLinkHtml, toolHref),
                ProgrammaticPageType.Alternative => BuildAlternative(displayTitle, keyword, toolLinkHtml, toolHref),
                ProgrammaticPageType.UseCase => BuildPdfUseCase(displayTitle, toolLinkHtml, toolHref, toolLinkText),
                ProgrammaticPageType.Location => BuildLocation(displayTitle, keyword, toolLinkHtml, toolHref),
                _ => BuildPdfLongTail(displayTitle, toolLinkHtml, toolHref, toolLinkText, hubHref),
            };
        }

        public static List<(string Question, string Answer)> BuildFaqs(
            ProgrammaticToolCategory category,
            ProgrammaticPageType type,
            string displayTitle,
            string toolLinkText,
            string toolHref,
            string verbPhrase)
        {
            if (category == ProgrammaticToolCategory.MedicalCalculator)
                return BuildMedicalFaqs(displayTitle, toolLinkText, toolHref);

            if (category == ProgrammaticToolCategory.GeneralCalculator)
                return BuildCalculatorFaqs(displayTitle, toolLinkText, toolHref);

            return BuildPdfFaqs(type, displayTitle, toolLinkText, toolHref, verbPhrase);
        }

        private static string BuildMedicalCalculator(
            ProgrammaticPageType type,
            string displayTitle,
            string toolLink,
            string toolHref,
            string toolLinkText,
            string hubHref)
        {
            var intro = type == ProgrammaticPageType.UseCase
                ? $"<p>Looking for <strong>{displayTitle}</strong>? Use the free {toolLink} on RatPDF.</p>"
                : $"<p>Use the free <strong>{displayTitle}</strong> on RatPDF. Enter the required clinical values and the calculator returns the result instantly.</p>";

            return $"""
                {intro}
                <p><strong>Educational use only</strong> — not a substitute for clinical judgment. Always apply local protocols and treat the patient, not the number.</p>
                <h2>How to use {toolLinkText}</h2>
                <ol>
                <li>Open {toolLink} at ratpdf.com{toolHref}.</li>
                <li>Enter the required values (height/weight, creatinine, score components, etc.).</li>
                <li>The calculator computes the result automatically.</li>
                <li>Review the output against clinical reference ranges.</li>
                <li>Document the result in your notes if needed.</li>
                </ol>
                <h2>Why use RatPDF?</h2>
                <ul>
                <li>Browser-based — no install on locked-down hospital laptops</li>
                <li>No patient identifiers required</li>
                <li>Free tier for light use; <a href="/Subscription/Plans">Pro</a> for high-volume workflows</li>
                </ul>
                <p>Explore more <a href="{hubHref}">medical calculators</a> or return to the <a href="/tools/medical">medical tools hub</a>.</p>
                """;
        }

        private static string BuildGeneralCalculator(
            string displayTitle,
            string toolLink,
            string toolHref,
            string toolLinkText,
            string hubHref) =>
            $"""
                <p>Use the free <strong>{displayTitle}</strong> on RatPDF. Enter your values and get instant results in the browser — no signup required.</p>
                <h2>How to use {toolLinkText}</h2>
                <ol>
                <li>Open {toolLink} at ratpdf.com{toolHref}.</li>
                <li>Enter the required numbers or dates in the form fields.</li>
                <li>Click Calculate (or see live results as you type).</li>
                <li>Review the output and copy or note the result.</li>
                </ol>
                <p>Browse more <a href="{hubHref}">calculators</a> on RatPDF.</p>
                """;

        private static string BuildPdfLongTail(
            string displayTitle,
            string toolLink,
            string toolHref,
            string toolLinkText,
            string hubHref) =>
            $"""
                <p>Need to <strong>{displayTitle.ToLowerInvariant()}</strong>? Upload your file to RatPDF's {toolLink}, select your options, and download the result. Free: 3 uses/day, 200 MB. Pro: 4 GB, unlimited.</p>
                <h2>How to use {toolLinkText}</h2>
                <ol>
                <li>Open {toolLink} at ratpdf.com{toolHref}.</li>
                <li>Upload your PDF file (drag and drop or click to browse).</li>
                <li>Configure tool-specific options.</li>
                <li>Click Process and wait for completion.</li>
                <li>Download your result.</li>
                </ol>
                <p>Related: <a href="{hubHref}">more guides</a>, <a href="/pdf/compress">Compress PDF</a>, <a href="/pdf/merge">Merge PDF</a>.</p>
                """;

        private static string BuildPdfUseCase(string displayTitle, string toolLink, string toolHref, string toolLinkText) =>
            $"""
                <p><strong>{displayTitle}</strong> is a common document workflow. RatPDF's {toolLink} helps you complete it without desktop software.</p>
                <h2>Steps</h2>
                <ol>
                <li>Open {toolLink} at ratpdf.com{toolHref}.</li>
                <li>Upload your PDF (or multiple files if supported).</li>
                <li>Configure options for your use case.</li>
                <li>Process and download the finished file.</li>
                <li>Optional: <a href="/pdf/compress">compress</a> if a portal has a size limit.</li>
                </ol>
                """;

        private static string BuildComparison(string displayTitle, string keyword, string toolLink, string toolHref)
        {
            var competitor = ExtractCompetitor(keyword);
            return $"""
                <p>Evaluating <strong>{displayTitle}</strong>? Compare <strong>{competitor}</strong> with RatPDF's {toolLink}.</p>
                <div class="table-responsive"><table class="table table-bordered">
                <thead><tr><th>Feature</th><th>RatPDF</th><th>{competitor}</th></tr></thead>
                <tbody>
                <tr><td>Install required</td><td>No</td><td>Often yes</td></tr>
                <tr><td>Free tier</td><td>3 uses/tool/day, 200 MB</td><td>Varies</td></tr>
                <tr><td>Max file size (Pro)</td><td>4 GB</td><td>Plan-dependent</td></tr>
                </tbody></table></div>
                <p>Try {toolLink} at ratpdf.com{toolHref}.</p>
                """;
        }

        private static string BuildAlternative(string displayTitle, string keyword, string toolLink, string toolHref)
        {
            var competitor = ExtractCompetitor(keyword);
            return $"""
                <p>Looking for <strong>{displayTitle}</strong>? RatPDF is a free browser alternative to {competitor}.</p>
                <ul>
                <li>All-in-one PDF toolkit on ratpdf.com</li>
                <li>No watermarks within free daily limits</li>
                <li>Pro from {SubscriptionPricing.FormatProShort()}</li>
                </ul>
                <p>Start with {toolLink} — ratpdf.com{toolHref}.</p>
                """;
        }

        private static string BuildLocation(string displayTitle, string keyword, string toolLink, string toolHref)
        {
            var region = ExtractRegion(keyword);
            return $"""
                <p><strong>{displayTitle}</strong> — users in {region} can process PDFs in the browser with HTTPS encryption.</p>
                <p>Use {toolLink} at ratpdf.com{toolHref}. See our <a href="/home/privacy">Privacy Policy</a> for data handling.</p>
                """;
        }

        private static List<(string, string)> BuildMedicalFaqs(string displayTitle, string toolLinkText, string toolHref)
        {
            var formula = ProgrammaticToolMetaCatalog.ClinicalFormulaHint(toolHref);
            return
            [
                ($"Is the {displayTitle} accurate?",
                    $"The calculator uses the {formula}. Results should always be interpreted alongside full clinical assessment."),
                ("Do you store patient data?",
                    "No patient identifiers are required. Calculations run in your browser session. RatPDF does not log or store clinical inputs."),
                ("Can I use this on mobile?",
                    "Yes — all calculators are fully responsive and work on phones and tablets."),
                ("Is this medical advice?",
                    "No. This tool is for educational use only and does not replace licensed medical judgment."),
            ];
        }

        private static List<(string, string)> BuildCalculatorFaqs(string displayTitle, string toolLinkText, string toolHref) =>
        [
            ($"How do I use the {displayTitle}?",
                $"Open {toolLinkText} at ratpdf.com{toolHref}, enter your values, and read the result instantly."),
            ("Is it free?",
                "Yes — 3 uses per tool per day on the free tier. Pro adds unlimited use."),
            ("Can I use this on mobile?",
                "Yes — the calculator is fully responsive."),
        ];

        private static List<(string, string)> BuildPdfFaqs(
            ProgrammaticPageType type,
            string displayTitle,
            string toolLinkText,
            string toolHref,
            string verbPhrase)
        {
            var faqs = new List<(string, string)>
            {
                ($"How do I use {displayTitle}?",
                    $"Open {toolLinkText} at ratpdf.com{toolHref}, upload your PDF, and follow the on-screen steps."),
                ("Is it free?",
                    "Yes — 3 uses per tool per day (200 MB/file). Pro: 4 GB files, unlimited daily use."),
                ("Are files private?",
                    "Uploads use HTTPS and temporary storage. Files are deleted after download."),
            };

            if (type == ProgrammaticPageType.Comparison)
                faqs.Add(($"Is RatPDF better for {displayTitle.ToLowerInvariant()}?",
                    "RatPDF runs in the browser with transparent free limits and production PDF engines."));
            return faqs;
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
    }
}
