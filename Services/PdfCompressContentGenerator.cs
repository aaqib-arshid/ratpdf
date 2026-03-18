using ratpdf.Models;
using System.Text;

namespace ratpdf.Services
{
    public class PdfCompressContentGenerator
    {
        private static readonly Random _rand = new Random();

        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath)
        {
            string keywordsFile = Path.Combine(webRootPath, "compress-pdf-keywords.txt");

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
                $"Compress PDF Online | {keyword}",
                $"Reduce PDF File Size | {keyword}",
                $"Shrink PDF Instantly | {keyword}"
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
            var toolUrl = "<a href=\"https://ratpdf.com/PDF/Compress\" target=\"_blank\">Compress PDF Tool</a>";

            var model = new SEOPageModel
            {
                Title = title,
                Slug = GenerateSlug(keyword),
                Description = $"Complete guide to {keyword}. Learn methods, benefits, tools, and best practices."
            };

            var sb = new StringBuilder();


            sb.Append($"<h1>{title}</h1>");
            sb.Append(GenerateLongIntro(keyword, toolUrl));


            sb.Append($"<h2>What Does \"{keyword}\" Mean?</h2>");
            sb.Append(GenerateParagraphs(keyword, 4));


            sb.Append("<h2>How to Compress PDF Files (Step-by-Step Guide)</h2>");
            sb.Append("<ol>");
            sb.Append($"<li>Upload your file using {toolUrl}</li>");
            sb.Append($"<li>Start compression process to {keyword}</li>");
            sb.Append($"<li>Wait while optimization runs</li>");
            sb.Append($"<li>Download your compressed PDF</li>");
            sb.Append("</ol>");
            sb.Append(GenerateParagraphs(keyword, 5));


            sb.Append("<h2>Different Ways to Compress PDF</h2>");
            sb.Append("<h3>1. Online Tools</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));

            sb.Append("<h3>2. Offline Software</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));

            sb.Append("<h3>3. Manual Optimization</h3>");
            sb.Append(GenerateParagraphs(keyword, 3));


            sb.Append("<h2>Benefits of Compressing PDF Files</h2>");
            sb.Append("<ul>");
            sb.Append("<li>Reduced file size for faster sharing</li>");
            sb.Append("<li>Improved storage efficiency</li>");
            sb.Append("<li>Better performance for uploads</li>");
            sb.Append("<li>Enhanced compatibility</li>");
            sb.Append("</ul>");
            sb.Append(GenerateParagraphs(keyword, 5));


            sb.Append("<h2>Real-World Use Cases</h2>");
            sb.Append(GenerateUseCases(keyword));

        
            sb.Append("<h2>Best Practices for PDF Compression</h2>");
            sb.Append(GenerateParagraphs(keyword, 6));

    
            sb.Append("<h2>Advanced Tips to Optimize PDF Size Without Losing Quality</h2>");
            sb.Append(GenerateParagraphs(keyword, 6));

        
            sb.Append("<h2>Common Issues and Solutions</h2>");
            sb.Append(GenerateParagraphs(keyword, 5));

            sb.Append("<h2>Online vs Offline Compression</h2>");
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
    <p>If you are looking to {keyword}, you are in the right place. PDF files are widely used across industries, but they can sometimes become too large to manage efficiently.</p>
    <p>By using our {toolUrl}, you can easily {keyword} and improve file performance without sacrificing quality.</p>
    <p>This guide will walk you through everything you need to know about {keyword}, including tools, techniques, and best practices.</p>
    <p>Whether you are a student, professional, or business owner, learning how to {keyword} can save time and improve productivity.</p>
    ";
        }
        private static string GenerateUseCases(string keyword)
        {
            return $@"
    <p>Students often {keyword} to submit assignments online.</p>
    <p>Businesses use it to reduce storage costs and improve workflow.</p>
    <p>Freelancers rely on tools to {keyword} before sending client files.</p>
    <p>Organizations use compression to manage large document archives.</p>
    ";
        }
        private static List<(string Question, string Answer)> GenerateBigFAQ(string keyword)
        {
            return new List<(string, string)>
    {
        ($"What is the best way to {keyword}?",
         $"The best way to {keyword} is by using an online tool that ensures fast and secure compression."),

        ($"Does {keyword} reduce quality?",
         $"No, modern tools allow you to {keyword} while maintaining high quality."),

        ($"Can I {keyword} for free?",
         $"Yes, you can {keyword} using free online tools without any limitations."),

        ($"Is it safe to {keyword} online?",
         $"Yes, most tools ensure your files are deleted after processing."),

        ($"Why should I {keyword}?",
         $"You should {keyword} to reduce file size, improve sharing, and save storage space.")
    };
        }
        private static string GenerateParagraphs(string keyword, int count)
        {
            var sb = new StringBuilder();

            var templates = new[]
            {
        $"When you {keyword}, you significantly improve file handling efficiency. This process ensures that documents remain accessible while reducing their size.",
        $"Many users prefer to {keyword} because it allows faster uploads, downloads, and sharing across different platforms.",
        $"The ability to {keyword} is essential in modern workflows where storage and speed play a crucial role.",
        $"Using advanced tools to {keyword}, users can maintain document quality while minimizing file size.",
        $"In today’s digital world, knowing how to {keyword} can save both time and resources.",
        $"Professionals rely on techniques to {keyword} to optimize document performance and usability.",
        $"One of the biggest advantages when you {keyword} is improved compatibility across devices.",
        $"Efficient methods to {keyword} help ensure that files remain lightweight and easy to manage."
    };

            for (int i = 0; i < count; i++)
            {
                sb.Append($"<p>{templates[_rand.Next(templates.Length)]}</p>");
            }

            return sb.ToString();
        }
    }
}

