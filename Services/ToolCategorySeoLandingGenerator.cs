using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    /// <summary>Programmatic SEO for calculator tool long-tail intents.</summary>
    public static class ToolCategorySeoLandingGenerator
    {
        public sealed record LandingConfig(
            string RoutePrefix,
            string ToolUrl,
            string ToolLinkText,
            string VerbPhrase,
            string HubPath,
            string HubLabel,
            string[] Keywords);

        private static readonly LandingConfig[] Configs =
        [
            EmiCalculator(),
            AgeCalculator(),
            PercentageCalculator(),
            PeriodCalculator(),
        ];

        public static IReadOnlyList<string> AllLandingPaths()
        {
            var paths = new List<string>(Configs.Sum(c => c.Keywords.Length));
            foreach (var cfg in Configs)
            {
                foreach (var kw in cfg.Keywords)
                    paths.Add($"/{cfg.RoutePrefix}/{GenerateSlug(kw)}");
            }
            return paths;
        }

        public static SEOPageModel? Populate(string routePrefix, string slug)
        {
            foreach (var cfg in Configs.Where(c =>
                         c.RoutePrefix.Equals(routePrefix, StringComparison.OrdinalIgnoreCase)))
            {
                var keyword = cfg.Keywords.FirstOrDefault(k => GenerateSlug(k) == slug);
                if (keyword != null)
                    return GeneratePage(cfg, keyword);
            }
            return null;
        }

        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace("₂", "2", StringComparison.Ordinal)
                .Replace("–", "-", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        private static SEOPageModel GeneratePage(LandingConfig cfg, string keyword)
        {
            var slug = GenerateSlug(keyword);
            var pageType = ProgrammaticSeoTemplates.DetectType(keyword);
            var category = ProgrammaticToolMetaCatalog.ResolveCategory(cfg.RoutePrefix, cfg.ToolUrl);
            var displayTitle = ProgrammaticSeoTemplates.BuildDisplayTitle(keyword, slug);
            var toolHref = PdfToolSeo.Canonical(cfg.ToolUrl);
            var toolLink = $"<a href=\"{toolHref}\">{cfg.ToolLinkText}</a>";
            var hubHref = PdfToolSeo.Canonical(cfg.HubPath);

            return new SEOPageModel
            {
                Title = ProgrammaticSeoTemplates.BuildTitle(keyword, pageType, cfg.ToolLinkText, slug),
                DisplayTitle = displayTitle,
                Description = ProgrammaticSeoTemplates.BuildDescription(category, displayTitle, cfg.ToolLinkText),
                Slug = slug,
                RoutePrefix = cfg.RoutePrefix,
                ToolUrl = cfg.ToolUrl,
                ToolLinkText = cfg.ToolLinkText,
                Category = category,
                NoIndex = true,
                SchemaApplicationCategory = ProgrammaticToolMetaCatalog.SchemaApplicationCategory(category),
                FullContentHtml = ProgrammaticSeoTemplates.BuildContentHtml(
                    category, pageType, keyword, displayTitle, toolLink, toolHref, cfg.VerbPhrase, hubHref, cfg.ToolLinkText),
                FAQ = ProgrammaticSeoTemplates.BuildFaqs(category, pageType, displayTitle, cfg.ToolLinkText, cfg.ToolUrl, cfg.VerbPhrase),
            };
        }

        private static LandingConfig EmiCalculator() => new(
            "calculator-tools", "/emi-calculator", "EMI Calculator", "calculate loan EMI",
            "/tools/calculators", "Calculators",
            [
                "emi calculator home loan", "emi calculator personal loan", "emi calculator car loan",
                "emi calculator with prepayment", "emi calculator india", "emi calculator interest rate",
                "emi calculator monthly payment", "emi calculator tenure", "emi calculator reduce interest",
                "emi calculator compare loans", "emi calculator free online", "emi calculator for 20 years",
                "emi calculator for 15 years", "emi calculator floating rate", "emi calculator fixed rate",
            ]);

        private static LandingConfig AgeCalculator() => new(
            "calculator-tools", "/age-calculator", "Age Calculator", "calculate exact age",
            "/tools/calculators", "Calculators",
            [
                "age calculator for visa application", "age calculator in years months days",
                "age calculator from date of birth", "age calculator for school admission",
                "age calculator online free", "age calculator for government forms",
                "age calculator exact days", "age calculator retirement planning",
                "age calculator for eligibility", "age calculator birthday countdown",
            ]);

        private static LandingConfig PercentageCalculator() => new(
            "calculator-tools", "/percentage-calculator", "Percentage Calculator", "calculate percentages",
            "/tools/calculators", "Calculators",
            [
                "percentage calculator for grades", "percentage calculator increase decrease",
                "percentage calculator discount", "percentage calculator markup",
                "percentage calculator online free", "percentage calculator tip",
                "percentage calculator change between two numbers", "percentage calculator for students",
                "percentage calculator profit margin", "percentage calculator exam score",
            ]);

        private static LandingConfig PeriodCalculator() => new(
            "calculator-tools", "/period-calculator", "Period Calculator", "track menstrual cycle dates",
            "/tools/calculators", "Calculators",
            [
                "period calculator next date", "period calculator ovulation", "period calculator cycle length",
                "period calculator fertile window", "period calculator online free", "period calculator irregular cycle",
                "period calculator calendar", "period calculator due date",
            ]);
    }
}
