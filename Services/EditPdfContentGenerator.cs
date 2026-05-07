using ratpdf.Models;
using System.Text;

namespace ratpdf.Services
{
    public class EditPdfContentGenerator
    {
        private static readonly Random _rand = new Random();

        public static SEOPageModel? PopulateSEOPageData(string slug, string webRootPath)
        {
            string keywordsFile = Path.Combine(webRootPath, "edit_pdf_urls_100k.txt");
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
                "Edit PDF" => "Edit PDF Online Free | No Software Needed",
                "PDF Editor" => "Free PDF Editor Online – Add Text, Images & More",
                "edit pdf online free" => "Edit PDF Online Free – Fast, Easy & Secure",
                "pdf editor online" => "PDF Editor Online – No Installation Required",
                "edit pdf file" => "Edit PDF Files Online – Change Text, Images & Pages",
                _ => $"Edit PDF – {keyword} | Free Online PDF Editor"
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
            string toolUrl = "<a href=\"https://ratpdf.com/PDF/EditPDF\" target=\"_blank\">PDF Editor</a>";

            var model = new SEOPageModel
            {
                Title = title,
                Slug = keyword.ToLower().Replace(" ", "-"),
                Description = $"Use our free online tool to {keyword} instantly. Add text, images, annotations, signatures, and more – no signup, no watermarks, 100% secure."
            };

            var sb = new StringBuilder();

            // --- Hero Section ---
            sb.Append($@"
<h1>{title}</h1>
<p>Need to <strong>{keyword}</strong> without installing expensive software? Our free {toolUrl} lets you modify any PDF directly in your browser – no downloads, no registration, no hidden fees. Whether you need to fix a typo, fill in a form, add your signature, or annotate a report, our tool handles it all in seconds.</p>
<p>In this in‑depth guide, you will discover everything about how to {keyword}: step‑by‑step instructions, real‑world use cases, expert tips for preserving formatting, and an honest comparison with other tools. By the time you finish reading, you will be able to {keyword} confidently and efficiently.</p>
<p>Our {toolUrl} is trusted by students, business professionals, lawyers, teachers, and freelancers worldwide. It supports all PDF versions and handles complex layouts – multi‑column, tables, embedded images, and even digital signatures.</p>
<p>Privacy is our top priority. Every file you upload is encrypted during transit and automatically deleted from our servers within 1 hour. No human ever views your documents, and we never store personal data.</p>
");

            // --- Step-by-step ---
            sb.Append(@"
<h2>How to Edit a PDF Online – Step by Step</h2>
<p>Follow these quick steps and you will be able to edit any PDF file in under a minute:</p>
<ol>");
            sb.Append($@"
<li><strong>Open the PDF Editor</strong> – Click the ''Choose File'' button in our {toolUrl} and upload the PDF from your computer, Google Drive, or Dropbox.</li>
<li><strong>Select what you want to edit</strong> – Click any text block to modify words, sentences, or paragraphs. Drag to reposition elements. Use the toolbar to add images, shapes, or highlight text.</li>
<li><strong>Add text, annotations, or signatures</strong> – Use the sidebar tools to insert new text boxes, sticky notes, freehand drawings, or an electronic signature.</li>
<li><strong>Fill forms automatically</strong> – If your PDF contains interactive form fields, click on them and type directly. Our tool detects checkboxes, radio buttons, and dropdowns.</li>
<li><strong>Download or share your edited PDF</strong> – When done, click ''Save'' and download the updated PDF instantly. Optionally generate a shareable link.</li>");
            sb.Append(@"
</ol>
<p><strong>Pro tip:</strong> If you want to edit a scanned PDF, enable our built‑in OCR (Optical Character Recognition) mode before opening the file. This converts image‑based text into real, selectable, and editable content – a feature most free editors simply do not offer.</p>
<p>Our editor works seamlessly on all devices – Windows PC, Mac, Linux, iPhone, iPad, and Android tablets. No app download required; a modern web browser is all you need.</p>
");

            // --- Why Choose Us ---
            sb.Append(@"
<h2>Why Choose Our Free PDF Editor?</h2>
<ul>");
            sb.Append($@"
<li><strong>Completely Free – Zero Cost</strong> – You can {keyword} without ever paying. No subscription, no watermarks stamped on your documents, and no page limits.</li>
<li><strong>Edit Text Directly</strong> – Click any word and change it. Our engine identifies font, size, and color automatically so edits blend in perfectly.</li>
<li><strong>Add Images & Shapes</strong> – Insert logos, photos, stamps, arrows, or rectangles. Resize and rotate them with simple drag handles.</li>
<li><strong>Digital Signatures</strong> – Draw, type, or upload an image of your signature and place it anywhere on the page. Legally valid in most countries.</li>
<li><strong>Annotate & Highlight</strong> – Add sticky notes, highlight text in multiple colors, strikethrough outdated content, or underline important clauses.</li>
<li><strong>Form Filling</strong> – Fill interactive PDF forms with accurate field detection. Supports text inputs, checkboxes, radio buttons, and select dropdowns.</li>
<li><strong>Rearrange & Delete Pages</strong> – Drag pages to reorder them, delete unwanted pages, or insert blank pages between existing ones.</li>
<li><strong>Merge or Split PDFs</strong> – Combine multiple PDFs into one or split a large document into smaller files – right inside the same editor.</li>
<li><strong>Bank‑Level Security</strong> – TLS 1.3 encryption protects your files during upload and download. All files are permanently deleted after 1 hour.</li>
<li><strong>No Registration Required</strong> – We never ask for your email or any personal information. Upload and start editing immediately.</li>");
            sb.Append(@"
</ul>
<p>Unlike Adobe Acrobat (which requires a monthly subscription of $15+), our tool delivers professional‑grade editing at zero cost. And unlike many free alternatives that cap you at 2MB or 5 pages, we accept PDFs up to <strong>50MB</strong>.</p>
");

            // --- Use Cases ---
            string[] useCases = {
                "Students can correct mistakes in submitted assignments before reprinting.",
                "HR professionals redact personal information from resumes and employment records.",
                "Real estate agents fill in purchase agreements and add client signatures.",
                "Accountants correct amounts on invoices without recreating the entire document.",
                "Teachers annotate lecture slides with feedback before sharing with students.",
                "Lawyers redline contracts by adding strikethroughs and margin comments.",
                "Freelancers customize proposal templates with client‑specific names and prices.",
                "Medical staff fill in patient intake forms electronically instead of on paper.",
                "Architects mark up floor plan PDFs with revision notes and approval stamps.",
                "Marketers update product brochures by swapping outdated images and pricing."
            };

            sb.Append($@"
<h2>Who Needs to {keyword}? Real‑World Use Cases</h2>
<p>Nearly every profession that deals with digital documents eventually needs to {keyword}. Here are the most common scenarios where our {toolUrl} saves hours of work:</p>
<ul>");
            foreach (var uc in useCases)
            {
                sb.Append($"<li>{uc}</li>");
            }
            sb.Append(@"
</ul>
<p>Consider James, a freelance consultant who receives signed contracts as PDFs. Instead of printing, scanning, and re‑uploading, he opens our editor, fills in the relevant fields, drops in his signature, and emails the finished document – all in under two minutes. No printer required.</p>
<p>Or think of Maria, a teacher who creates lesson quizzes in PDF. When a student points out an error, she does not have to dig up the original Word file. She simply edits the published PDF directly – changing the question, updating the answer key, and saving a new version instantly.</p>
");

            // --- Tips ---
            sb.Append(@"
<h2>5 Expert Tips to Get Perfect Results Every Time</h2>
<ul>
<li><strong>Match fonts before editing</strong> – When adding new text, check the existing font name in the toolbar and match it. This makes your edits invisible to the naked eye.</li>
<li><strong>Use the ''White Rectangle'' trick</strong> – To erase content without leaving a gap, place a white‑filled rectangle over it, then add your new text on top. Works great for correcting dates and prices.</li>
<li><strong>Enable OCR for scanned files</strong> – Always turn on OCR Mode when working with scanned documents. Without it, the text appears as an image and cannot be edited.</li>
<li><strong>Flatten before sending</strong> – After editing, use the ''Flatten'' option to merge all layers and prevent others from undoing your changes or revealing hidden content.</li>
<li><strong>Use ''Redact'' for sensitive data</strong> – Our redaction tool permanently blacks out content (not just hides it), so sensitive numbers and names cannot be recovered with copy‑paste tricks.</li>
</ul>
<p>Our {toolUrl} is updated regularly with machine‑learning improvements that make text recognition and font matching more accurate every month. If you encounter a complex file that causes issues, contact our support team – we will investigate within 24 hours.</p>
");

            // --- Comparison Table ---
            sb.Append(@"
<h2>How Does Our PDF Editor Compare?</h2>
<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%'>
<tr>
  <th>Tool</th>
  <th>Cost</th>
  <th>Edit Text</th>
  <th>OCR Support</th>
  <th>Signatures</th>
  <th>Security</th>
  <th>File Size Limit</th>
</tr>
<tr><td><strong>Our PDF Editor</strong></td><td>Free</td><td>✅ Yes</td><td>✅ Yes</td><td>✅ Yes</td><td>High (auto‑delete)</td><td>50MB</td></tr>
<tr><td>Adobe Acrobat Pro</td><td>$15/month</td><td>✅ Yes</td><td>✅ Yes</td><td>✅ Yes</td><td>High</td><td>Unlimited</td></tr>
<tr><td>Smallpdf</td><td>Freemium</td><td>⚠️ Limited</td><td>❌ Paid only</td><td>✅ Yes</td><td>Medium</td><td>5MB (free)</td></tr>
<tr><td>Google Docs (PDF import)</td><td>Free</td><td>⚠️ Breaks layout</td><td>⚠️ Basic</td><td>❌ No</td><td>Low (stored on Google)</td><td>50MB</td></tr>
<tr><td>PDF Escape</td><td>Freemium</td><td>⚠️ Limited</td><td>❌ No</td><td>✅ Yes</td><td>Medium</td><td>10MB (free)</td></tr>
<tr><td>LibreOffice Draw (desktop)</td><td>Free</td><td>✅ Yes</td><td>❌ No</td><td>❌ No</td><td>Local only</td><td>No limit</td></tr>
</table>
<p>Our tool hits the sweet spot: full text editing, OCR, signatures, and security – all for free. Most freemium tools upsell you before you can do anything useful. We do not.</p>
");

            // --- Troubleshooting ---
            sb.Append(@"
<h2>Troubleshooting Common PDF Editing Problems</h2>
<h3>Why can't I click on the text in my PDF?</h3>
<p>Your PDF is likely a scanned image rather than a text‑based document. Enable <strong>OCR Mode</strong> before uploading and our engine will convert the image into selectable, editable text automatically.</p>

<h3>The font looks different after I edit a line – why?</h3>
<p>Some PDFs embed proprietary fonts that are not available on our server. In such cases, we substitute the closest matching font. For pixel‑perfect results, use the ''White Rectangle'' overlay method to hide the original text and add new text in a visually similar font.</p>

<h3>My signature placement keeps shifting when I download</h3>
<p>Make sure to use the ''Flatten'' option before downloading. This bakes all annotations and signatures into the PDF permanently, preventing any layout shift across different PDF viewers.</p>

<h3>The PDF editor shows a blank white page</h3>
<p>This usually happens with password‑protected or corrupted PDFs. If the file is password‑protected, enter the password when prompted. If it's corrupted, try re‑exporting it from the source application and uploading again.</p>

<h3>I edited the PDF but the file size increased dramatically</h3>
<p>Adding images or using certain annotation types can increase file size. After editing, use our built‑in <strong>PDF Compressor</strong> tool (also free) to reduce the file size before sharing or emailing.</p>
");

            // --- FAQ ---
            sb.Append(@"
<h2>Frequently Asked Questions</h2>");
            var faq = GenerateExpandedFAQ(keyword, toolUrl);
            foreach (var (Question, Answer) in faq)
            {
                sb.Append($@"<h3>{Question}</h3><p>{Answer}</p>");
            }

            // --- Conclusion ---
            sb.Append($@"
<h2>Conclusion – Edit Any PDF for Free, Right Now</h2>
<p>You no longer need expensive desktop software to {keyword}. Our free {toolUrl} gives you professional‑grade editing, OCR, digital signatures, form filling, and page management – all in your browser, all at no cost.</p>
<p>Whether you are a student fixing a report, a lawyer annotating a contract, or a business owner updating a brochure, our tool is built for you. No signup, no watermarks, no frustration.</p>
<p><strong>Ready to get started?</strong> Visit our {toolUrl} now and experience the fastest, easiest way to edit PDF files online.</p>
<p>Already a fan? Share this guide with colleagues who are still struggling with PDF headaches. And explore our full suite of free tools – PDF to Word, PDF to Excel, Merge PDF, Split PDF, Compress PDF, and more – all available on <a href=""https://ratpdf.com"" target=""_blank"">ratpdf.com</a>.</p>");

            model.FullContentHtml = sb.ToString();
            model.FAQ = faq;
            return model;
        }

        private static List<(string Question, string Answer)> GenerateExpandedFAQ(string keyword, string toolUrl)
        {
            var baseFaqs = new List<(string, string)>
            {
                ($"Is it really free to {keyword}?",
                 $"Yes, 100% free. No credit card required, no trial period, and no watermarks added to your document. You can {keyword} as many times as you like."),

                ($"Can I {keyword} on a Mac or iPhone?",
                 $"Absolutely. Our {toolUrl} works in any modern browser – Safari, Chrome, Firefox, Edge. No software installation needed on Mac, Windows, iOS, or Android."),

                ($"Does editing a PDF change the original file?",
                 $"No. You upload a copy to our server, edit it, and download the result. Your original local file is never modified. The server copy is deleted automatically after 1 hour."),

                ($"Can I edit a password‑protected PDF?",
                 $"Yes, as long as you know the password. Our editor will prompt you to enter it before opening the file. We never store or share your password."),

                ($"Is it possible to {keyword} without losing the original formatting?",
                 $"Yes. Our intelligent text engine detects fonts, sizes, colors, and spacing so that edits blend seamlessly with the surrounding content."),

                ($"Can I add a signature to a PDF?",
                 $"Yes. Use the Signature tool to draw, type, or upload an image of your signature, then drag it to the correct position on the page."),

                ($"Can I delete or add pages?",
                 $"Absolutely. The Page Manager panel lets you drag‑and‑drop to reorder pages, delete any page, or insert blank pages wherever you need them."),

                ($"What file size limit applies?",
                 $"Free users can upload PDFs up to 50MB. Need to process larger files? Contact us for enterprise or API access."),

                ($"Does the tool support scanned PDFs?",
                 $"Yes. Enable OCR Mode before uploading your scanned document and our AI will recognize text in over 60 languages, converting it into fully editable content."),

                ($"Will my edited PDF work in Adobe Reader?",
                 $"Yes. We output standard PDF/1.7 files fully compatible with Adobe Reader, Preview on Mac, Chrome's PDF viewer, and all major PDF applications."),

                ($"Can I highlight and annotate text?",
                 $"Yes. Select any text and choose Highlight, Underline, or Strikethrough. You can also add sticky notes and freehand drawings anywhere on the page."),

                ($"Is my data safe when I {keyword} online?",
                 $"We use TLS 1.3 encryption for all uploads and downloads. Files are automatically and permanently deleted after 1 hour. We never sell or share user data."),

                ($"Can I merge multiple PDFs while editing?",
                 $"Yes. Use the Merge panel to add additional PDFs and arrange all pages from different files into one combined document before saving."),

                ($"What happens if the conversion or edit fails?",
                 $"If something goes wrong, a detailed error message will appear. Most issues are solved by re‑uploading the file. For persistent problems, contact our support team – we respond within 24 hours."),

                ($"Do I need to create an account to {keyword}?",
                 $"No account needed. Just open the {toolUrl}, upload your PDF, make your edits, and download. We never ask for your email or personal information.")
            };

            var shuffled = baseFaqs.OrderBy(_ => _rand.Next()).ToList();

            var extraQuestions = new List<(string, string)>
            {
                ($"Can I {keyword} that contains only images?",
                 $"Yes. Enable OCR mode and our tool will recognize text inside images, making it editable. Ideal for scanned books, receipts, and old paper records."),

                ($"How does your editor handle right‑to‑left languages like Arabic?",
                 $"Our editor fully supports Unicode and bidirectional text, including Arabic, Hebrew, Persian, and Urdu. Editing flows naturally in the correct direction."),

                ($"Can I undo changes while editing?",
                 $"Yes. Use Ctrl+Z (or Cmd+Z on Mac) to undo any action. We maintain a full undo history for the entire editing session."),

                ($"Is there a limit to how many edits I can make?",
                 $"No limit. You can make as many text, image, annotation, and page changes as you need within a single session before downloading.")
            };

            if (_rand.NextDouble() > 0.4)
                shuffled.Add(extraQuestions[_rand.Next(extraQuestions.Count)]);

            for (int i = 0; i < shuffled.Count; i++)
            {
                var (q, a) = shuffled[i];
                if (_rand.NextDouble() > 0.7)
                    a += " Our team continuously improves the editor with new features and smarter AI models each month.";
                else if (_rand.NextDouble() > 0.8)
                    a += " For developers and power users, we also provide an API to integrate PDF editing directly into your own applications.";
                shuffled[i] = (q, a);
            }

            return shuffled.Take(12).ToList();
        }
    }
}