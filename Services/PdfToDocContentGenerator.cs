using ratpdf.Models;
using System.Text;

namespace ratpdf.Services
{
    public class PdfToWordContentGenerator
    {
        private static readonly Random _rand = new Random();

        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath)
        {
            string keywordsFile = Path.Combine(webRootPath, "pdftodocx_urls.txt");
            if (!File.Exists(keywordsFile))
                return null;

            var keywords = File.ReadAllLines(keywordsFile)
                               .Where(k => !string.IsNullOrWhiteSpace(k))
                               .Select(k => k.Trim())
                               .ToList();

            var keyword = keywords.FirstOrDefault(k => GenerateSlug(k) == slug);
            if (keyword == null)
                return null;

            string title = keyword switch
            {
                "PDF To DOC" => "Convert PDF to DOC Online | Best Free Converter",
                "PDF To Word" => "Convert PDF to Word Online | High-Quality DOCX",
                "convert pdf to word online" => "Convert PDF to Word Online – Fast & Free",
                "pdf to word converter free" => "Free PDF to Word Converter – No Signup Required",
                _ => $"Convert {keyword} Easily | PDF to Word Tool"
            };

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

        public static SEOPageModel GenerateSEOPage(string title, string keyword)
        {
            string toolUrl = "<a href=\"https://ratpdf.com/PDF/PdfToDoc\" target=\"_blank\">PDF to Word Converter</a>";
            var model = new SEOPageModel
            {
                Title = title,
                Slug = keyword.ToLower().Replace(" ", "-"),
                Description = $"Learn how to {keyword} with our free online tool. Preserve formatting, tables, and images – 100% secure."
            };

            var sb = new StringBuilder();

            sb.Append($@"
<h1>{title}</h1>
<p>Do you need to <strong>{keyword}</strong> quickly and accurately? Our {toolUrl} is the perfect solution. Whether you have a single page or a 500‑page report, converting PDF to Word has never been easier. No software installation, no watermarks, and no signup – just pure, fast conversion.</p>
<p>In this comprehensive guide, we will explain why converting PDF to Word is essential for students, legal professionals, marketers, and anyone who needs editable documents. You'll learn the step‑by‑step process, discover advanced tips, and see real‑world use cases. By the end, you'll be able to {keyword} like a pro.</p>
<p>Our {toolUrl} uses advanced parsing algorithms to preserve your original layout, including fonts, bullet points, tables, and images. Unlike basic converters that output plain text, our tool gives you a fully editable DOCX file that looks almost identical to your original PDF.</p>
<p>We have helped thousands of users {keyword} for business reports, academic papers, e‑books, contracts, and more. The process takes only seconds, and your files are automatically deleted from our servers after conversion – guaranteeing your privacy and security.</p>
");

            sb.Append(@"
<h2>How to Convert PDF to Word – Step by Step</h2>
<p>Follow these simple steps to convert any PDF into an editable Word document:</p>
<ol>");
            sb.Append($@"
<li><strong>Upload your PDF file</strong> – Click the ''Choose File'' button on our {toolUrl} and select the PDF from your computer, Google Drive, or Dropbox.</li>
<li><strong>Select output format</strong> – Choose DOC (older Word format) or DOCX (modern format). For most users, DOCX is recommended because it supports all features.</li>
<li><strong>Click ''Convert''</strong> – Our server will immediately start processing. Depending on file size and complexity, conversion takes between 5 and 30 seconds.</li>
<li><strong>Download the Word file</strong> – Once finished, you will see a download button. Click it to save the editable Word document to your device.</li>");
            sb.Append(@"
</ol>
<p>Pro tip: For scanned PDFs or image‑based files, we automatically apply OCR (Optical Character Recognition). This means you can <strong>convert scanned documents into fully editable Word files</strong> – something many free converters cannot do.</p>
<p>If you need to convert multiple PDFs, simply repeat the process. We do not impose daily limits, so you can {keyword} as often as necessary. Our tool works perfectly on Windows, Mac, Linux, iPhone, and Android – any device with a modern browser.</p>
");

            sb.Append(@"
<h2>Why Choose Our PDF to Word Converter?</h2>
<ul>");
            sb.Append($@"
<li><strong>100% Free – No Hidden Fees</strong> – You can {keyword} without ever entering credit card details. No premium upsells, no watermarks, no page limits.</li>
<li><strong>Preserves Original Formatting</strong> – Headings, columns, tables, images, and even hyperlinks are maintained. Most other converters ruin complex layouts; ours does not.</li>
<li><strong>Secure & Private</strong> – All uploaded files are encrypted and automatically deleted within 1 hour. Even our administrators cannot access your data.</li>
<li><strong>OCR Support for Scanned PDFs</strong> – Convert image‑based PDFs into text‑searchable Word documents. Perfect for old books, contracts, or handwritten notes.</li>
<li><strong>Batch Conversion (Advanced)</strong> – While the free version handles one file at a time, you can use our API or paid plan to {keyword} in bulk.</li>
<li><strong>No Registration Required</strong> – Start converting immediately. We never ask for your email or personal information.</li>
<li><strong>Works Offline?</strong> – Actually it's online, but you can use it anywhere. No software to download or update – ever.</li>");
            sb.Append(@"
</ul>
<p>Compared to desktop software like Adobe Acrobat (which costs hundreds of dollars), our tool gives you the same conversion quality for free. And unlike online converters that limit file size to 2MB, we accept PDFs up to 50MB – generous enough for most documents.</p>
");

            string[] useCases = {
                "Students can convert lecture slides into editable notes.",
                "Lawyers often need to transform scanned court documents into Word for editing.",
                "Marketers extract text from PDF reports to reuse in blog posts.",
                "Accountants convert bank statements into Excel via Word (then copy tables).",
                "Writers receive manuscripts as PDF and need to edit them in Word.",
                "HR departments convert resumes from PDF to Word to redact personal info.",
                "Archivists digitize old paper records by scanning to PDF then OCR to Word."
            };
            sb.Append(@"
<h2>Who Benefits from Converting PDF to Word?</h2>
<p>Almost anyone who works with digital documents can save hours by using our {toolUrl}. Here are real‑world scenarios:</p>
<ul>");
            foreach (var uc in useCases)
            {
                sb.Append($"<li>{uc}</li>");
            }
            sb.Append(@"
</ul>
<p>For example, a university student named Sarah needed to <strong>convert a 200‑page research PDF into Word</strong> to add comments and reorganize chapters. Using our tool, she finished in under a minute and the resulting Word file kept all footnotes, citations, and figures intact.</p>
<p>Another user, a small business owner, had dozens of scanned invoices in PDF. By converting them to Word, she could extract totals and dates into an accounting spreadsheet. The OCR accuracy was above 99% even for faded receipts.</p>
<p>If you work with legal documents, you know that editing a PDF directly is painful. Our converter transforms contracts, NDAs, and briefs into fully editable Word files, allowing redlining and track changes – something impossible in a static PDF.</p>
");

            sb.Append(@"
<h2>5 Tips to Get the Highest Quality Word Output</h2>
<ul>
<li><strong>Use high‑quality source PDFs</strong> – If your PDF is a low‑resolution scan, enable the ''OCR Enhancement'' option (available on our tool) to improve text recognition.</li>
<li><strong>Check your Word version</strong> – Older Word (2003–2007) may not open DOCX files. In that case, choose DOC format during conversion.</li>
<li><strong>For tables and charts</strong> – Our converter does an excellent job with tables. If a complex chart becomes an image, you can still edit surrounding text.</li>
<li><strong>If you see garbled text</strong> – The original PDF might have embedded fonts that cannot be mapped. Try converting with our ''Standard Mode'' instead of ''Preserve Layout''.</li>
<li><strong>Split huge PDFs</strong> – For files over 50MB, split them into smaller parts using a free PDF splitter, then convert each part separately.</li>
</ul>
<p>Remember: our {toolUrl} is constantly improved using machine learning models. If you encounter a file that converts poorly, contact us – we will analyze it and update our algorithms.</p>
");

            sb.Append(@"
<h2>PDF to Word Conversion: Our Tool vs. Alternatives</h2>
<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%'>
<tr><th>Method</th><th>Cost</th><th>Formatting Quality</th><th>Security</th><th>Speed</th></tr>
<tr><td>Our Online Converter</td><td>Free</td><td>Excellent</td><td>High (auto-delete)</td><td>Fast</td></tr>
<tr><td>Adobe Acrobat Pro</td><td>$15/month</td><td>Excellent</td><td>High</td><td>Fast</td></tr>
<tr><td>SmallPDF</td><td>Freemium</td><td>Good</td><td>Medium</td><td>Medium</td></tr>
<tr><td>Copy‑paste manually</td><td>Free</td><td>Poor</td><td>N/A</td><td>Extremely slow</td></tr>
<tr><td>Google Docs (open PDF)</td><td>Free</td><td>Fair (breaks layout)</td><td>Low (files stay on Google)</td><td>Slow</td></tr>
</table>
<p>As you can see, our tool offers the best balance of quality, price, and privacy. Many ''free'' converters insert watermarks or limit you to one page per hour – we never do that.</p>
");

            sb.Append(@"
<h2>Troubleshooting Common Issues</h2>
<h3>Why is the converted Word file different from my PDF?</h3>
<p>PDF is a fixed‑layout format while Word is fluid. Complex designs (overlapping elements, custom fonts) may shift slightly. Use our ''Preserve Layout'' mode for better results.</p>
<h3>My scanned PDF converts to gibberish – what can I do?</h3>
<p>Make sure you select ''Enable OCR'' before conversion. Also, the original scan quality matters – 300 DPI or higher is recommended.</p>
<h3>Can I convert password‑protected PDFs?</h3>
<p>Yes, but only if you know the password. Our tool will ask for the password before conversion. We do not store it.</p>
<h3>How large can my PDF be?</h3>
<p>Up to 50MB for free users. Need larger? Contact us for a custom enterprise plan.</p>
");

            sb.Append(@"
<h2>Frequently Asked Questions</h2>");
            var faq = GenerateExpandedFAQ(keyword);
            foreach (var (Question, Answer) in faq)
            {
                sb.Append($@"<h3>{Question}</h3><p>{Answer}</p>");
            }

            sb.Append($@"
<h2>Conclusion – Start Converting Now</h2>
<p>Converting PDF to Word does not have to be expensive or complicated. With our free {toolUrl}, you can {keyword} in seconds, retain all your original formatting, and keep your data secure.</p>
<p>Whether you are a student, professional, or casual user, give our tool a try. No registration – just upload, convert, and download. Thousands of people already use it daily to improve their productivity.</p>
<p><strong>Ready to convert?</strong> Visit the {toolUrl} page now and experience the best free PDF to Word converter online.</p>
<p>If you found this guide helpful, please share it with colleagues who still struggle with PDFs. And check out our other tools like PDF to Excel, PDF to PPT, and PDF to JPG – all free, all high quality.</p>");

            model.FullContentHtml = sb.ToString();
            model.FAQ = faq;
            return model;
        }

        private static List<(string Question, string Answer)> GenerateExpandedFAQ(string keyword)
        {
            // Base FAQ list with many questions
            var baseFaqs = new List<(string, string)>
            {
                ($"Is it really free to {keyword}?",
                 $"Yes, completely free. No credit card, no trial period, no watermarks. You can {keyword} as many times as you need."),

                ($"Can I {keyword} on my phone?",
                 $"Absolutely. Our website is mobile‑friendly. Open it in Chrome, Safari, or any browser on iOS or Android."),

                ($"Does the tool preserve images and tables?",
                 $"Yes, images and tables are preserved as closely as possible. Tables become editable Word tables; images are embedded normally."),

                ($"What happens to my files after conversion?",
                 $"They are permanently deleted from our servers within 1 hour. We never store or share your documents."),

                ($"Can I convert a scanned PDF (image only) to Word?",
                 $"Yes, we have built‑in OCR. Enable ''OCR Mode'' before converting and our AI will recognize text even from photos."),

                ($"Do I need to install anything?",
                 $"No, it's 100% online. There is no software to download – everything runs in your browser and our secure cloud."),

                ($"What is the maximum file size?",
                 $"50MB per file. If you need larger, contact us for enterprise options."),

                ($"Is my data safe if I convert confidential documents?",
                 $"We use TLS encryption for upload/download. Files are automatically erased. We recommend avoiding highly sensitive data just in case, but millions of users trust us."),

                ($"Can I convert PDF to Word without losing hyperlinks?",
                 $"Yes, hyperlinks are preserved and remain clickable in the output Word document."),

                ($"What's the difference between DOC and DOCX?",
                 $"DOC is older (Word 97‑2003). DOCX is modern, smaller file size, better formatting. Choose DOCX unless you have very old Word."),

                ($"Why does my converted document have extra spaces?",
                 $"Some PDFs contain hidden characters. Use Word's ''Show/Hide ¶'' button to see them and clean up manually. We are working on an auto‑clean feature."),

                ($"Can I batch convert multiple PDFs to Word?",
                 $"The free version converts one file at a time. For batch conversion (up to 100 files), please see our API or Pro plan."),

                ($"Do you support right‑to‑left languages like Arabic or Hebrew?",
                 $"Yes, our converter supports all Unicode languages, including Arabic, Hebrew, Chinese, Japanese, and Korean."),

                ($"What if the conversion fails?",
                 $"Rarely, a corrupted or extremely complex PDF might fail. Try uploading a different copy or contact support – we usually fix it within 24h.")
            };

            var shuffled = baseFaqs.OrderBy(x => _rand.Next()).ToList();

            var extraQuestions = new List<(string, string)>
            {
                ($"Can I {keyword} if the PDF was created from a photo?",
                 $"Yes, that's what OCR is for. Our OCR engine can {keyword} even from phone camera pictures, as long as the text is reasonably clear."),
                ($"Is there an offline version of this converter?",
                 $"Not yet, but you can bookmark our page and use it online anywhere. Offline desktop software often costs money – we keep it free online."),
                ($"How does your tool compare to Microsoft Word's built-in PDF opener?",
                 $"Word often messes up complex layouts and images. Our dedicated converter is specifically tuned to preserve formatting better than Word's default importer.")
            };

            if (_rand.NextDouble() > 0.5)
                shuffled.Add(extraQuestions[_rand.Next(extraQuestions.Count)]);

            for (int i = 0; i < shuffled.Count; i++)
            {
                var (q, a) = shuffled[i];
                if (_rand.NextDouble() > 0.7)
                    a += " We continuously improve our algorithms, so the quality gets even better over time.";
                else if (_rand.NextDouble() > 0.8)
                    a += " For advanced users, we also provide an API to integrate conversion into your own apps.";
                shuffled[i] = (q, a);
            }

            return shuffled.Take(12).ToList(); 
        }
    }
}
