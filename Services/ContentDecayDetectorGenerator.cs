using ratpdf.Models;
using System.Text;

namespace ratpdf.Services
{
    public static class ContentDecayDetectorGenerator
    {
        private static readonly Random _rand = new Random();

        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath)
        {
            string keywordsFile = Path.Combine(webRootPath, "decay_urls.txt");

            if (!File.Exists(keywordsFile))
                return null;

            var keywords = File.ReadAllLines(keywordsFile)
                               .Where(k => !string.IsNullOrWhiteSpace(k))
                               .Select(k => k.Trim())
                               .ToList();

            var keywordMap = keywords.ToDictionary(k => GenerateSlug(k), k => k);

            if (!keywordMap.TryGetValue(slug, out var keyword))
                return null;

            var title = GetVariation(
                $"Content Decay Checker | {keyword}",
                $"Content Decay Detector | {keyword}",
                $"Content decay explained | {keyword}"
            );

            return GenerateSEOPage(title, keyword);
        }

        public static string GenerateSlug(string keyword)
        {
            return keyword.ToLower()
                          .Replace("&", "and")
                          .Replace("'", "")
                          .Replace(",", "")
                          .Replace("?", "")
                          .Replace(" ", "-");
        }

        private static string GetVariation(params string[] options)
        {
            return options[_rand.Next(options.Length)];
        }
        public static SEOPageModel GenerateSEOPage(string title, string keyword)
        {
            var toolUrl = "<a href=\"https://ratpdf.com/tools/gscindex\" target=\"_blank\">Content Decay Detector Tool</a>";

            var model = new SEOPageModel
            {
                Title = title,
                Slug = GenerateSlug(keyword),
                Description = $"Complete guide to {keyword}. Learn how to detect content decay, recover rankings, and improve SEO performance."
            };

            var sb = new StringBuilder();

            sb.Append($"<h1>{title}</h1>");
            sb.Append(GenerateLongIntro(keyword, toolUrl));

            sb.Append($"<h2>What Does \"{keyword}\" Mean?</h2>");
            sb.Append(GenerateParagraphs(keyword, 4));

            sb.Append("<h2>How to Use the Content Decay Detector (Step-by-Step Guide)</h2>");
            sb.Append("<ol>");
            sb.Append($"<li>Enter your website URL into the {toolUrl}</li>");
            sb.Append($"<li>Analyze pages affected by {keyword}</li>");
            sb.Append($"<li>Review traffic decline and ranking drops</li>");
            sb.Append($"<li>Export report and start optimization</li>");
            sb.Append("</ol>");
            sb.Append(GenerateParagraphs(keyword, 5));

            sb.Append("<h2>Different Types of Content Decay</h2>");
            sb.Append("<h3>1. Traffic Decay</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));

            sb.Append("<h3>2. Ranking Decay</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));

            sb.Append("<h3>3. Engagement Decay</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));

            sb.Append("<h2>Benefits of Detecting Content Decay</h2>");
            sb.Append("<ul>");
            sb.Append("<li>Recover lost organic traffic</li>");
            sb.Append("<li>Improve SEO performance of old content</li>");
            sb.Append("<li>Identify underperforming pages</li>");
            sb.Append("<li>Increase content ROI without creating new posts</li>");
            sb.Append("</ul>");
            sb.Append(GenerateParagraphs(keyword, 5));

            sb.Append("<h2>Real-World Use Cases</h2>");
            sb.Append(GenerateUseCases(keyword));

            sb.Append("<h2>Best Practices for Fixing Content Decay</h2>");
            sb.Append(GenerateParagraphs(keyword, 6));

            sb.Append("<h2>Advanced SEO Strategies to Recover Decayed Content</h2>");
            sb.Append(GenerateParagraphs(keyword, 6));

            sb.Append("<h2>Common Issues and Solutions</h2>");
            sb.Append(GenerateParagraphs(keyword, 5));

            sb.Append("<h2>Content Refresh vs Content Deletion</h2>");
            sb.Append(GenerateParagraphs(keyword, 4));

            var faq = GenerateBigFAQ(keyword);
            sb.Append("<h2>Frequently Asked Questions</h2>");
            foreach (var f in faq)
            {
                sb.Append($"<h3>{f.Question}</h3><p>{f.Answer}</p>");
            }

            model.FAQ = faq;

            sb.Append("<h2>Conclusion</h2>");
            sb.Append(GenerateParagraphs(keyword, 4));

            model.FullContentHtml = sb.ToString();
            return model;
        }
        private static string GenerateLongIntro(string keyword, string toolUrl)
        {
            return $@"
            <p>If you are trying to improve your website performance, understanding {keyword} is essential. Over time, even high-performing content loses rankings and traffic due to changing search intent and competition.</p>

            <p>With our {toolUrl}, you can easily identify pages affected by {keyword} and take action before they lose significant visibility.</p>

            <p>This guide explains how {keyword} works, how to detect it, and how to recover lost traffic effectively.</p>

            <p>Whether you run a blog, SaaS website, or affiliate site, learning to manage {keyword} is critical for long-term SEO success.</p>
            ";
        }
        private static string GenerateUseCases(string keyword)
        {
            return $@"
            <p>SEO bloggers use {keyword} analysis to revive old posts and regain lost rankings.</p>
            <p>Digital marketing agencies rely on it to improve client website performance.</p>
            <p>SaaS companies use it to optimize landing pages that lose organic traffic over time.</p>
            <p>Affiliate marketers use {keyword} tools to maintain revenue from aging content.</p>
            ";
        }
        private static List<(string Question, string Answer)> GenerateBigFAQ(string keyword)
        {
            return new List<(string, string)>
    {
        ($"What is {keyword}?",
         $"{keyword} refers to the decline in organic traffic, rankings, or engagement of previously well-performing content over time."),

        ($"Why does {keyword} happen?",
         $"{keyword} happens due to competition, outdated content, changing search intent, and algorithm updates."),

        ($"How do I fix {keyword}?",
         $"You can fix {keyword} by updating content, improving SEO structure, adding new information, and optimizing internal links."),

        ($"Can {keyword} affect all websites?",
         $"Yes, almost every website experiences {keyword} over time if content is not maintained."),

        ($"Is {keyword} reversible?",
         $"Yes, in most cases {keyword} can be reversed by refreshing and optimizing the affected pages.")
    };
        }
        private static string GenerateParagraphs(string keyword, int count)
        {
            var sb = new StringBuilder();

            var templates = new[]
            {
        $"Understanding {keyword} is essential for maintaining long-term SEO performance and traffic stability.",
        $"Many websites experience {keyword} when older pages lose relevance in search results.",
        $"By analyzing {keyword}, you can identify which pages need updates or optimization.",
        $"One of the biggest challenges in SEO is managing {keyword} across large content libraries.",
        $"Modern SEO tools make it easier to detect {keyword} and take corrective action quickly.",
        $"Ignoring {keyword} can lead to gradual traffic loss and reduced visibility in search engines.",
        $"Regular audits help prevent {keyword} from affecting your top-performing pages.",
        $"Fixing {keyword} often results in faster ranking recovery compared to publishing new content."
    };

            for (int i = 0; i < count; i++)
            {
                sb.Append($"<p>{templates[_rand.Next(templates.Length)]}</p>");
            }

            return sb.ToString();
        }
    }
}
