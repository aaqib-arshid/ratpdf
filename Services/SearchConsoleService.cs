using Google.Apis.Auth.OAuth2;
using Google.Apis.SearchConsole.v1.Data;
using Google.Apis.Services;
using ratpdf.Models;

namespace ratpdf.Services
{
    public class SearchConsoleService
    {

        public SearchConsoleService()
        {
        }

        public async Task<List<ArticleDecay>> GetPagePerformanceAsync(
        GoogleCredential credential,
        string domain)
        {

            var service = new Google.Apis.SearchConsole.v1.SearchConsoleService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Rat PDF GCS Web Client"
                });

            var siteProperties = new List<string>
            {
                $"sc-domain:{domain}",
                $"https://{domain}/",
                $"https://www.{domain}/"
            };

            SearchAnalyticsQueryResponse response = null;

            foreach (var site in siteProperties)
            {
                try
                {
                    var request = new SearchAnalyticsQueryRequest
                    {
                        StartDate = DateTime.UtcNow.AddMonths(-16).ToString("yyyy-MM-dd"),
                        EndDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                        Dimensions = new[] { "page", "date" },
                        RowLimit = 25000,
                        StartRow = 0
                    };

                    response = await service.Searchanalytics
                        .Query(request, site)
                        .ExecuteAsync();

                    if (response?.Rows != null && response.Rows.Count > 0)
                        break;
                }
                catch (Google.GoogleApiException ex)
                {
                    continue;
                }
            }

            if (response?.Rows == null || response.Rows.Count == 0)
                return new List<ArticleDecay>();

            return ParseDecayFromRows(response.Rows);
        }

        private List<ArticleDecay> ParseDecayFromRows(IList<ApiDataRow> rows)
        {
            var grouped = rows
                .Where(r => r.Keys.Count >= 2)
                .GroupBy(r => r.Keys[0]) // page
                .Select(g =>
                {
                    var clicksByMonth = g
                        .GroupBy(r => r.Keys[1].Substring(0, 7)) // yyyy-MM
                        .ToDictionary(m => m.Key, m => (int)m.Sum(r => r.Clicks));

                    int peak = clicksByMonth.Values.DefaultIfEmpty(0).Max();

                    int recent = clicksByMonth
                        .OrderByDescending(k => k.Key)
                        .Take(3)
                        .Select(k => k.Value)
                        .DefaultIfEmpty(0)
                        .Average() switch
                    {
                        double d => (int)d
                    };

                    int decayPct = peak > 0
                        ? (int)(((double)(peak - recent) / peak) * 100)
                        : 0;

                    return new ArticleDecay
                    {
                        Url = g.Key,
                        Title = g.Key.Split('/').LastOrDefault() ?? g.Key,
                        PeakClicks = peak,
                        CurrentClicks = recent,
                        DecayPercent = Math.Max(0, decayPct)
                    };
                })
                //.Where(a => a.PeakClicks > 10) 
                .OrderByDescending(a => a.DecayPercent)
                .ToList();

            return grouped;
        }
    }
}
