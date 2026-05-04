using ratpdf.Models;

namespace ratpdf.Services
{
    public class DecayCalculatorService
    {
        public DecayResult Calculate(string domain, List<ArticleDecay> articles)
        {
            var atRisk = articles.Where(a => a.DecayPercent >= 30).ToList();
            int overallScore = articles.Any()
                ? (int)articles.Average(a => a.DecayPercent)
                : 0;

            string risk = overallScore switch
            {
                >= 70 => "High",
                >= 40 => "Medium",
                _ => "Low"
            };

            double trafficLoss = articles.Any()
                ? articles.Sum(a => a.PeakClicks - a.CurrentClicks) /
                  (double)articles.Sum(a => a.PeakClicks) * 100
                : 0;

            return new DecayResult
            {
                Domain = domain,
                DecayScore = overallScore,
                RiskLevel = risk,
                AtRiskArticles = atRisk.Count,
                EstimatedTrafficLoss = $"-{trafficLoss:F0}%",
                Articles = articles.Take(10).ToList(),
                RefreshChecklist = GetChecklist(risk)
            };
        }

        private List<string> GetChecklist(string risk) => risk switch
        {
            "High" => new List<string>
        {
            "Update all statistics and data points to current year",
            "Replace outdated screenshots and tool references",
            "Add 3–5 new H2 sections covering recent developments",
            "Refresh internal links to newer related posts",
            "Re-submit URLs to Google Search Console after publishing",
            "Add FAQ schema to top decaying pages"
        },
            "Medium" => new List<string>
        {
            "Audit top 5 decaying articles for outdated stats",
            "Refresh meta titles to include current year",
            "Improve internal linking from high-traffic pages",
            "Update images and alt text"
        },
            _ => new List<string>
        {
            "Set a quarterly content review calendar",
            "Monitor GSC impressions weekly",
            "Keep evergreen articles updated annually"
        }
        };
    }
}
