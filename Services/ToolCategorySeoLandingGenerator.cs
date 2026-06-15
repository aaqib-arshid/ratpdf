using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    /// <summary>Programmatic SEO for medical and calculator tool long-tail intents.</summary>
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
            BmiCalculator(),
            EgfrCalculator(),
            HeartScore(),
            Cha2ds2Score(),
            WellsScore(),
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
            var pageType = ProgrammaticSeoTemplates.DetectType(keyword);
            var toolHref = PdfToolSeo.Canonical(cfg.ToolUrl);
            var toolLink = $"<a href=\"{toolHref}\">{cfg.ToolLinkText}</a>";
            var hubHref = PdfToolSeo.Canonical(cfg.HubPath);

            return new SEOPageModel
            {
                Title = ProgrammaticSeoTemplates.BuildTitle(keyword, pageType, cfg.ToolLinkText),
                Description = ProgrammaticSeoTemplates.BuildDescription(keyword, pageType, cfg.ToolLinkText),
                Slug = GenerateSlug(keyword),
                RoutePrefix = cfg.RoutePrefix,
                ToolUrl = cfg.ToolUrl,
                ToolLinkText = cfg.ToolLinkText,
                FullContentHtml = ProgrammaticSeoTemplates.BuildContentHtml(
                    pageType, keyword, toolLink, toolHref, cfg.VerbPhrase, hubHref),
                FAQ = ProgrammaticSeoTemplates.BuildFaqs(pageType, keyword, cfg.ToolLinkText, cfg.ToolUrl, cfg.VerbPhrase),
            };
        }

        private static LandingConfig BmiCalculator() => new(
            "medical-tools", "/bmi-calculator", "BMI Calculator", "calculate body mass index",
            "/tools/medical", "Medical tools",
            [
                "bmi calculator for women", "bmi calculator for men", "bmi calculator for seniors",
                "bmi calculator metric units", "bmi calculator imperial units", "bmi calculator for athletes",
                "bmi calculator for children", "bmi calculator for pregnancy", "bmi calculator kg cm",
                "bmi calculator lbs inches", "bmi calculator for weight loss", "bmi calculator normal range",
                "bmi calculator online free", "bmi calculator for obesity screening", "bmi calculator for teens",
            ]);

        private static LandingConfig EgfrCalculator() => new(
            "medical-tools", "/egfr-calculator", "eGFR Calculator", "estimate glomerular filtration rate",
            "/tools/medical", "Medical tools",
            [
                "egfr calculator for elderly", "egfr calculator ckd staging", "egfr calculator from creatinine",
                "egfr calculator mdrd", "egfr calculator ckdepi", "egfr calculator for diabetes",
                "egfr calculator online free", "egfr calculator pediatric", "egfr calculator black race coefficient",
                "egfr calculator for nephrology", "egfr calculator mg dl", "egfr calculator umol l",
            ]);

        private static LandingConfig HeartScore() => new(
            "medical-tools", "/heart-score", "HEART Score Calculator", "calculate HEART score for chest pain",
            "/tools/medical", "Medical tools",
            [
                "heart score calculator chest pain", "heart score for ed triage", "heart score low risk criteria",
                "heart score calculator online", "heart score for acute coronary syndrome", "heart score mace risk",
                "heart score calculator free", "heart score emergency department", "heart score protocol",
                "heart score vs troponin", "heart score clinical decision rule",
            ]);

        private static LandingConfig Cha2ds2Score() => new(
            "medical-tools", "/cha2ds2-vasc-score", "CHA₂DS₂-VASc Calculator", "calculate CHA₂DS₂-VASc stroke risk",
            "/tools/medical", "Medical tools",
            [
                "cha2ds2 vasc calculator", "cha2ds2 vasc score atrial fibrillation", "cha2ds2 vasc anticoagulation",
                "cha2ds2 vasc calculator online", "cha2ds2 vasc score interpretation", "cha2ds2 vasc for stroke risk",
                "cha2ds2 vasc calculator free", "cha2ds2 vasc elderly patient", "cha2ds2 vasc female score",
                "cha2ds2 vasc diabetes hypertension",
            ]);

        private static LandingConfig WellsScore() => new(
            "medical-tools", "/wells-score", "Wells Score Calculator", "calculate Wells score for DVT or PE",
            "/tools/medical", "Medical tools",
            [
                "wells score dvt calculator", "wells score pe calculator", "wells criteria pulmonary embolism",
                "wells score deep vein thrombosis", "wells score calculator online", "wells score cut off",
                "wells score clinical probability", "wells score for leg swelling", "wells score emergency medicine",
                "wells score d dimer pathway",
            ]);

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
