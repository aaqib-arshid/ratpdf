using ratpdf.Models;

namespace ratpdf.Constants
{
    /// <summary>Category hub pages for non-PDF tool silos (medical, developer, calculators, utilities, business).</summary>
    public static class CategoryToolsCatalog
    {
        private static readonly Dictionary<string, CategoryToolsPageModel> BySlug =
            Build().ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        public static CategoryToolsPageModel? Get(string slug) => BySlug.GetValueOrDefault(slug);

        public static IEnumerable<CategoryToolsPageModel> All => BySlug.Values;

        public static IEnumerable<string> SitemapPaths() => BySlug.Values.Select(p => p.Path);

        private static IEnumerable<CategoryToolsPageModel> Build()
        {
            yield return Hub(
                "medical",
                "/tools/medical",
                "Free Medical Calculators & Clinical Scores Online | RatPDF",
                "Clinical calculators for BMI, eGFR, HEART score, CHA₂DS₂-VASc, Wells score, GCS, MAP, HAS-BLED, Parkland formula, and NIHSS — free in the browser.",
                "Medical Calculators & Clinical Scores",
                "Evidence-based calculators for screening, risk stratification, and clinical documentation — no install required.",
                "Medical & clinical",
                SiteToolNavigation.MedicalTools.Select(t => (t.Name, t.Url, ToolBlurb(t.Url))).ToArray(),
                [
                    "Estimate BMI for patient intake forms",
                    "Calculate eGFR from creatinine for CKD staging",
                    "Score chest pain with HEART before disposition",
                    "Assess stroke risk with CHA₂DS₂-VASc for anticoagulation discussions",
                    "Evaluate DVT/PE pre-test probability with Wells criteria",
                ],
                [
                    ("Are these medical calculators for diagnosis?", "No — they are educational aids. Always apply clinical judgment and local protocols; they do not replace licensed medical advice."),
                    ("Do you store patient data?", "Calculators run in your browser session. RatPDF does not require patient identifiers for these tools."),
                    ("Can I use these on mobile?", "Yes — all calculators are responsive and work on phones and tablets."),
                ]);

            yield return Hub(
                "developer",
                "/tools/developer",
                "Free Developer Tools — JSON, JWT, HTML & Text Utilities | RatPDF",
                "Format JSON and HTML, decode JWT tokens, compare text diffs, encode URLs, convert binary, and run DNS lookups — free online developer utilities.",
                "Developer Tools",
                "Debug APIs, tidy payloads, and inspect tokens without leaving the browser.",
                "Developers & DevOps",
                SiteToolNavigation.DeveloperTools.Select(t => (t.Name, t.Url, ToolBlurb(t.Url))).ToArray(),
                [
                    "Pretty-print JSON API responses for debugging",
                    "Decode JWT header and payload during auth integration",
                    "Format minified HTML templates before commit",
                    "Compare config file diffs during code review",
                ],
                [
                    ("Is JWT decoding secure?", "Decoding is client-side for inspection only — never paste production secrets into shared machines."),
                    ("Do you log pasted JSON or tokens?", "Developer tools process input for formatting; see our trust center for retention policies on server-backed tools."),
                    ("Are there file size limits?", "Large payloads may hit browser memory limits before server limits on client-side formatters."),
                ]);

            yield return Hub(
                "calculators",
                "/tools/calculators",
                "Free Online Calculators — BMI, EMI, Age, Percentage & More | RatPDF",
                "Everyday and financial calculators: BMI, loan EMI, age in years/months/days, percentages, period dates, freelance rates, and GST invoice checks.",
                "Online Calculators",
                "Quick math for health, finance, education, and business compliance checks.",
                "General & financial",
                SiteToolNavigation.Calculators
                    .Concat([
                        new SiteNavTool("Freelance Rate Calculator", "/freelance-rate-calculator"),
                        new SiteNavTool("GST Invoice Checker", "/gst-invoice-checker"),
                        new SiteNavTool("PDF Size Checker", "/pdf-size-checker"),
                    ])
                    .DistinctBy(t => t.Url, StringComparer.OrdinalIgnoreCase)
                    .Select(t => (t.Name, t.Url, ToolBlurb(t.Url)))
                    .ToArray(),
                [
                    "Estimate home loan EMI before applying",
                    "Calculate exact age for visa or school forms",
                    "Find percentage change for grades and discounts",
                    "Validate GST invoice fields before filing",
                ],
                [
                    ("Are calculator results exact?", "Results use standard formulas; verify against your lender or tax advisor for binding decisions."),
                    ("Is the EMI calculator for India only?", "EMI math works globally; GST checker is India-specific."),
                ]);

            yield return Hub(
                "utilities",
                "/tools/utilities",
                "Free Online Utilities — Word Counter, QR Codes, Passwords & Ring Sizes | RatPDF",
                "Word counter for SEO and essays, QR code generator, secure password generator, and international ring size converter.",
                "Online Utilities",
                "Small tools that save time for writers, marketers, and shoppers.",
                "Productivity",
                SiteToolNavigation.Utilities.Select(t => (t.Name, t.Url, ToolBlurb(t.Url))).ToArray(),
                [
                    "Hit essay word limits before submission",
                    "Generate QR codes for menus and event links",
                    "Create strong passwords for new accounts",
                    "Convert US ring sizes to UK/EU when shopping online",
                ],
                [
                    ("Is the word counter accurate for SEO?", "It counts words, characters, and sentences in pasted text — useful for meta descriptions and content briefs."),
                    ("Are generated passwords stored?", "No — passwords are generated in your browser session."),
                ]);

            yield return Hub(
                "business",
                "/tools/business",
                "Free Business Tools — Invoices, Payslips & Rent Receipts | RatPDF",
                "Create GST and VAT invoices, salary slips, bulk payslips, and rent receipts — download PDF instantly.",
                "Business & Finance Tools",
                "Invoicing and payroll paperwork for freelancers, SMBs, and landlords.",
                "Business & finance",
                SiteToolNavigation.BusinessTools.Select(t => (t.Name, t.Url, ToolBlurb(t.Url))).ToArray(),
                [
                    "Issue GST invoices to clients in India",
                    "Generate salary slips for small teams",
                    "Produce rent receipts for HRA tax claims",
                    "Bulk-generate payslips from spreadsheet upload",
                ],
                [
                    ("Can I customize invoice templates?", "Yes — add line items, tax IDs, and branding on the invoice generator."),
                    ("Are invoices legally valid?", "Templates include standard fields; verify requirements for your jurisdiction and tax regime."),
                ]);

            yield return Hub(
                "all-tools",
                "/tools",
                "All Free Online Tools — PDF, Medical, Developer & Business | RatPDF",
                "Browse every RatPDF tool: PDF edit and convert, medical calculators, developer utilities, image tools, and business generators.",
                "All RatPDF Tools",
                "One platform for PDF workflows, clinical scores, developer debugging, and business documents.",
                "All categories",
                SiteToolNavigation.PdfEditTools
                    .Concat(SiteToolNavigation.PdfConvertTools)
                    .Concat(SiteToolNavigation.MedicalTools)
                    .Concat(SiteToolNavigation.DeveloperTools)
                    .Concat(SiteToolNavigation.Utilities)
                    .Concat(SiteToolNavigation.BusinessTools)
                    .DistinctBy(t => t.Url, StringComparer.OrdinalIgnoreCase)
                    .Take(24)
                    .Select(t => (t.Name, t.Url, ToolBlurb(t.Url)))
                    .ToArray(),
                [
                    "Start with PDF compress or merge for document workflows",
                    "Use medical calculators for clinical education",
                    "Format JSON and decode JWT during development",
                    "Generate invoices and payslips for clients and staff",
                ],
                [
                    ("How many tools does RatPDF offer?", $"Over {PdfToolSeo.ToolCountLabel} PDF tools plus medical, developer, calculator, and business utilities."),
                    ("Is everything free?", "Core tools include a free tier (3 uses/day per tool). Pro unlocks higher limits and larger files."),
                ]);
        }

        private static CategoryToolsPageModel Hub(
            string slug, string path, string title, string description, string h1, string lead, string category,
            (string, string, string)[] tools, string[] useCases, (string, string)[] faqs) =>
            new()
            {
                Slug = slug,
                Path = path,
                Title = title,
                Description = description,
                H1 = h1,
                Lead = lead,
                CategoryLabel = category,
                FeaturedTools = tools.Select(t => (t.Item1, t.Item2, t.Item3)).ToArray(),
                UseCases = useCases,
                Faqs = faqs,
                HubBreadcrumbLabel = slug == "all-tools" ? null : "All tools",
                HubBreadcrumbPath = slug == "all-tools" ? null : "/tools",
            };

        private static string ToolBlurb(string url) => url.ToLowerInvariant() switch
        {
            var u when u.Contains("bmi") => "Body mass index from height and weight.",
            var u when u.Contains("egfr") => "Kidney function estimate from creatinine.",
            var u when u.Contains("heart-score") => "Chest pain risk stratification score.",
            var u when u.Contains("cha2ds2") => "Stroke risk in atrial fibrillation.",
            var u when u.Contains("wells") => "DVT and PE pre-test probability.",
            var u when u.Contains("json") => "Validate and pretty-print JSON.",
            var u when u.Contains("jwt") => "Inspect JWT header and payload.",
            var u when u.Contains("htmlformatter") => "Beautify HTML markup.",
            var u when u.Contains("wordcounter") => "Count words, characters, sentences.",
            var u when u.Contains("invoice") => "Professional invoice PDF export.",
            var u when u.Contains("payslip") => "Salary slip PDF for employees.",
            var u when u.Contains("compress") => "Reduce PDF file size.",
            var u when u.Contains("merge") => "Combine PDFs in order.",
            var u when u.Contains("editpdf") => "Edit text and images in PDF.",
            _ => "Free online tool — no install.",
        };
    }
}
