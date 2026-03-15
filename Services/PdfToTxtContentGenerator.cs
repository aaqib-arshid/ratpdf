using ratpdf.Models;
using System.Text;

namespace ratpdf.Services
{
    public  class PdfToTxtContentGenerator
    {
        private static  readonly Random _rand = new Random();
        //private static  readonly string KeywordsFile = Path.Combine(Directory.GetCurrentDirectory(), "pdf-to-txt-keywords.txt");

        public static  SEOPageModel? PopulateSEOPageData(string slug, string webRootPath)
        {
            string keywordsFile = Path.Combine(webRootPath, "pdf-to-txt-keywords.txt");

            if (!File.Exists(keywordsFile))
                return null;

            var keywords = File.ReadAllLines(keywordsFile)
                               .Where(k => !string.IsNullOrWhiteSpace(k))
                               .Select(k => k.Trim())
                               .ToList();

            var keyword = keywords.FirstOrDefault(k => GenerateSlug(k) == slug);
            if (keyword == null)
                return null;


            var title = $"Convert PDF to Text Online | {keyword}";

            return GenerateSEOPage(title, keyword);
        }

        public static  string GenerateSlug(string keyword)
        {
            return keyword.ToLower()
                          .Replace("&", "and")
                          .Replace("'", "")
                          .Replace(",", "")
                          .Replace("?", "")
                          .Replace(" ", "-");
        }
        public static  SEOPageModel GenerateSEOPage(string title, string keyword)
        {
            var toolUrl = "<a href=\"https://ratpdf.com/PDF/PdfToText\" target=\"_blank\">PDF to Text Tool</a>";
            var model = new SEOPageModel
            {
                Title = title,
                Slug = keyword.ToLower().Replace(" ", "-"),
                Description = $"Learn how to {keyword} easily and quickly with our free online PDF tool."
            };

            var sb = new StringBuilder();

            // 1. Introduction
            sb.Append($@"<h1>{title}</h1>
             <p>Looking for a way to {keyword}? Our free online tool {toolUrl} lets you {keyword} quickly, securely, and without installing any software. Whether you're a student, researcher, or professional, this guide will show you how to make the most out of our PDF tool {toolUrl}.</p>
             <p>By using this tool {toolUrl}, you can {keyword} in just a few simple steps. It's designed for speed, accuracy, and ease of use, helping you save time and avoid the hassle of complicated software.</p>");

            // 2. How-To / Step-by-step
            sb.Append(@"<h2>How to Use the Tool</h2>
            <ol>");
            sb.Append($@"
            <li>Upload your PDF document to our online tool {toolUrl}.</li>
            <li>Click the 'Convert' or 'Extract' button to {keyword}.</li>
            <li>Wait a few seconds for the process to finish.</li>
            <li>Download the resulting text file to your computer.</li>");
            sb.Append("</ol>");
            sb.Append($@"<p>Our tool {toolUrl} supports all types of PDFs, including scanned documents, research papers, and legal files. By {keyword} using this method, you can ensure all text is properly extracted while maintaining formatting where possible.</p>");

            // 3. Benefits / Features
            sb.Append(@"<h2>Benefits of Using Our PDF to Text Tool</h2>
            <ul>");
            sb.Append($@"
            <li>Fast and efficient {keyword} process</li>
            <li>Secure: all files are deleted after processing</li>
            <li>No signup required, completely free</li>
            <li>Supports multiple PDF types including scanned PDFs</li>
            <li>Compatible with all modern browsers and devices</li>");
            sb.Append("</ul>");

            // 4. Use Cases 
            sb.Append(@"<h2>Who Can Benefit from This Tool</h2>");
            sb.Append($@"
             <p>Students can {keyword} from lecture notes and research papers to make studying easier. Researchers can extract text from large PDF datasets for analysis. Professionals, such as lawyers and accountants, can convert legal or financial PDFs into editable text for reporting purposes.</p>
             <p>With this tool {toolUrl}, anyone can {keyword} without worrying about software installation, compatibility issues, or losing important information.</p>");

            // 5. Generate Unique FAQ per Keyword
            sb.Append(@"<h2>Frequently Asked Questions</h2>");
            var faq = GenerateFAQ(keyword);
            foreach (var (Question, Answer) in faq)
            {
                sb.Append($@"<h3>{Question}</h3><p>{Answer}</p>");
            }

            model.FAQ = faq;

            // 6. Conclusion
            sb.Append($@"<h2>Conclusion</h2>
            <p>In summary, {keyword} has never been easier. Our free online PDF tool {toolUrl} ensures a fast, reliable, and secure way to extract text from any PDF. Start {keyword} today and see how simple it can be!</p>");

            model.FullContentHtml = sb.ToString();
            return model;
        }

        private static List<(string Question, string Answer)> GenerateFAQ(string keyword)
        {
            var faqs = new List<(string, string)>
        {
            ($"Can I {keyword} with scanned PDFs?",
             $"Yes! Our tool supports OCR technology, which allows you to {keyword} even from scanned PDF documents."),

            ($"Is {keyword} free?",
             $"Absolutely. You can {keyword} completely free without signing up or installing software."),

            ($"How long does it take to {keyword}?",
             $"Most PDFs are processed in just a few seconds, depending on the file size."),

            ($"Is it safe to {keyword} online?",
             $"Yes, your files are securely processed and deleted immediately after conversion, ensuring privacy."),

            ($"Can I {keyword} multiple PDFs at once?",
             $"Yes! You can {keyword} multiple PDFs using batch conversion, saving time and effort.")
        };

            // Shuffle answers slightly to increase uniqueness
            for (int i = 0; i < faqs.Count; i++)
            {
                var q = faqs[i].Item1;
                var a = faqs[i].Item2;
                if (_rand.NextDouble() > 0.5) a += " It’s fast and reliable!";
                faqs[i] = (q, a);
            }

            return faqs;
        }
    }
}
