namespace ratpdf.Models
{
    public class DecayResult
    {
        public string Domain { get; set; }
        public int DecayScore { get; set; }          // 0-100
        public string RiskLevel { get; set; }        // Low / Medium / High
        public int AtRiskArticles { get; set; }
        public string EstimatedTrafficLoss { get; set; }
        public List<ArticleDecay> Articles { get; set; }
        public List<string> RefreshChecklist { get; set; }
    }
    public class ArticleDecay
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int DecayPercent { get; set; }
        public int PeakClicks { get; set; }
        public int CurrentClicks { get; set; }
    }
}
