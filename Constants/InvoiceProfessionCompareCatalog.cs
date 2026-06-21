namespace ratpdf.Constants
{
    /// <summary>BOFU compare pages: best invoice generators by profession (from deferred content-roadmap).</summary>
    public static class InvoiceProfessionCompareCatalog
    {
        public sealed record ProfessionComparePage(
            string Slug,
            string Title,
            string Description,
            string Profession,
            string HeroSummary,
            (string Feature, string RatPdf, string TypicalAlternative)[] ComparisonRows,
            (string Question, string Answer)[] Faqs);

        private static readonly Dictionary<string, string> GuideSlugToCompareSlug =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["invoice-generator-guide"] = "invoice-generators-freelancers",
                ["recurring-invoice-generator"] = "invoice-generators-freelancers",
                ["invoice-generator-india"] = "invoice-generators-small-business",
                ["invoice-generator-usa"] = "invoice-generators-small-business",
                ["invoice-generator-uk"] = "invoice-generators-small-business",
            };

        public static string? CompareSlugForGuide(string guideSlug)
        {
            if (GuideSlugToCompareSlug.TryGetValue(guideSlug, out var slug))
                return slug;
            foreach (var page in Pages)
            {
                if (guideSlug.Contains(page.Profession.Replace(' ', '-'), StringComparison.OrdinalIgnoreCase)
                    || guideSlug.Contains(page.Slug.Replace("invoice-generators-", ""), StringComparison.OrdinalIgnoreCase))
                    return page.Slug;
            }
            return guideSlug.Contains("invoice", StringComparison.OrdinalIgnoreCase)
                ? "invoice-generators-freelancers"
                : null;
        }

        public static ProfessionComparePage? GetPage(string slug) =>
            Pages.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        public static IReadOnlyList<string> AllComparePaths() =>
            Pages.Select(p => $"/compare/{p.Slug}").ToList();

        public static readonly ProfessionComparePage[] Pages =
        [
            Build("freelancers", "Freelancers", "Wave, FreshBooks"),
            Build("accountants", "Accountants & bookkeepers", "QuickBooks, Xero"),
            Build("lawyers", "Lawyers & legal teams", "Clio, LawPay"),
            Build("consultants", "Consultants", "FreshBooks, HoneyBook"),
            Build("small-business", "Small businesses", "Wave, Zoho Invoice"),
            Build("healthcare-administrators", "Healthcare administrators", "Kareo, SimplePractice"),
            Build("real-estate-agents", "Real estate agents", "HoneyBook, Dotloop"),
            Build("photographers", "Photographers", "HoneyBook, Studio Ninja"),
            Build("developers", "Developers & agencies", "Stripe Invoicing, PayPal"),
            Build("startups", "Startups", "Stripe Billing, Pilot"),
        ];

        private static ProfessionComparePage Build(string slugSuffix, string profession, string alternatives)
        {
            var slug = $"invoice-generators-{slugSuffix}";
            return new ProfessionComparePage(
                Slug: slug,
                Title: $"Best Invoice Generators for {profession} (2026) — RatPDF vs {alternatives}",
                Description: $"Compare free and Pro invoice PDF tools for {profession.ToLowerInvariant()}. RatPDF vs {alternatives}: pricing, PDF export, branding, and daily limits.",
                Profession: profession,
                HeroSummary: $"RatPDF is a browser invoice generator for {profession.ToLowerInvariant()} — create PDF invoices, add tax lines, and download without installing {alternatives.Split(',')[0].Trim()}.",
                ComparisonRows:
                [
                    ("Install required", "No — browser only", "Often requires account + app"),
                    ("PDF export", "Instant PDF download", "PDF on paid tiers"),
                    ("Free tier", "3 invoices/tool/day, 200 MB", "Limited free tasks on most SaaS"),
                    ("Branding / logo", "Pro: logo, colors, UPI QR", "Branding usually paid"),
                    ("Multi-currency", "90+ currencies on form", "Varies by vendor"),
                    ("Bulk CSV (INR GST)", "Business tier ZIP export", "Rare on free tiers"),
                    ("Guides", "Step-by-step invoice + PDF guides", "Help center only"),
                ],
                Faqs:
                [
                    ($"What is the best free invoice generator for {profession.ToLowerInvariant()}?", $"RatPDF Create Invoice runs in the browser with PDF export on the free tier (3 uses/day). Compare paid {alternatives} if you need payroll or CRM."),
                    ("Can I add my logo to invoice PDFs?", "Yes on RatPDF Pro — upload logo and brand colors at /branding/edit before generating PDFs."),
                    ("Is RatPDF good for recurring invoices?", "Use Create Invoice for one-off PDFs; duplicate line items manually or use CSV bulk on Business tier for statement runs."),
                    ($"How does RatPDF compare to {alternatives.Split(',')[0].Trim()}?", $"RatPDF focuses on fast PDF invoice export without a full accounting suite — ideal when you only need professional PDF bills, not ledger sync."),
                ]);
        }
    }
}
