using ratpdf.Content;

namespace ratpdf.Constants
{
    /// <summary>Competitor intelligence: keyword gaps, content/backlink targets, and comparison page data.</summary>
    public static class CompetitiveSeoCatalog
    {
        public const string CompareHubPath = "/compare";

        public sealed record CompetitorProfile(
            string Slug,
            string Name,
            string Domain,
            string FreeTierSummary,
            string[] Strengths,
            string[] Weaknesses,
            string[] KeywordsTheyRankFor);

        public sealed record KeywordGap(
            string Keyword,
            string Intent,
            string RatPdfUrl,
            string? GuidePath,
            string CompetitorLeader,
            string Priority);

        public sealed record ComparePage(
            string Slug,
            string Title,
            string Description,
            string CompetitorName,
            string CompetitorDomain,
            string HeroSummary,
            string[] KeywordGaps,
            (string Feature, string RatPdf, string Competitor)[] ComparisonRows,
            (string Question, string Answer)[] Faqs);

        public static readonly CompetitorProfile[] Competitors =
        [
            new("ilovepdf", "iLovePDF", "ilovepdf.com",
                "Unlimited merges with file caps; 2-hour file deletion; daily limits on some tools.",
                ["Brand recognition", "Bulk merge", "Cloud Drive integration", "Mobile apps"],
                ["Daily task limits", "Pro upsell on OCR/e-sign", "Server upload required"],
                ["merge pdf", "compress pdf", "split pdf", "pdf to word", "organize pdf", "sign pdf", "pdf to jpg", "rotate pdf"]),
            new("smallpdf", "Smallpdf", "smallpdf.com",
                "2 tasks/day free across all tools; Strong compression is Pro; GDPR + ISO marketing.",
                ["Polished UX", "Trust badges (GDPR, ISO)", "Rich FAQ schema", "Tutorial hub per tool"],
                ["Strict 2/day free limit", "Pro required for strong compression", "Heavy subscription push"],
                ["compress pdf", "merge pdf", "pdf to word", "compress pdf to 100kb", "pdf to jpg", "edit pdf", "sign pdf"]),
            new("pdf24", "PDF24 Tools", "pdf24.org",
                "Generous free tier; large file support; offline desktop app cross-sell.",
                ["Fewer free limits", "Large file merges", "Broad tool count", "Offline PDF24 Creator"],
                ["Dated UI", "German-market focus", "Less content marketing in EN"],
                ["merge pdf", "compress pdf", "edit pdf", "pdf converter", "pdf to word", "rotate pdf"]),
            new("adobe-acrobat", "Adobe Acrobat Online", "adobe.com",
                "1–2 free tasks; Adobe ID required; brand trust on enterprise queries.",
                ["Brand authority", "Enterprise trust", "Advanced edit on paid tiers"],
                ["Account required", "Very limited free", "Expensive subscriptions"],
                ["pdf editor", "compress pdf", "convert pdf to word", "sign pdf", "merge pdf"]),
            new("sejda", "Sejda", "sejda.com",
                "3 tasks/hour; 50 MB / 200-page limits on free; page-level editing.",
                ["Page-level control", "Hourly reset vs daily cap", "Developer API on paid"],
                ["Low hourly limits", "Watermark on some free outputs"],
                ["merge pdf", "split pdf", "compress pdf", "edit pdf", "crop pdf", "pdf to word"]),
            new("foxit", "Foxit PDF", "foxit.com",
                "Desktop-first; online tools secondary; B2B positioning.",
                ["Enterprise PDF editor", "Compliance messaging"],
                ["Online tools less visible", "Heavy install funnel"],
                ["pdf editor", "merge pdf", "compress pdf", "pdf to word"]),
            new("sodapdf", "Soda PDF", "sodapdf.com",
                "Freemium desktop + web; OCR and e-sign on paid tiers; aggressive upsell.",
                ["Desktop + online bundle", "OCR on paid", "Brand advertising"],
                ["Watermark on free exports", "Subscription push", "Less transparent limits"],
                ["merge pdf", "convert pdf", "pdf to word", "compress pdf", "sign pdf", "pdf to powerpoint"]),
            new("pdf-candy", "PDF Candy", "pdfcandy.com",
                "Tool-per-page SEO; 40+ utilities; daily task limits on free.",
                ["Huge tool count", "Long-tail landing pages", "Chrome extension"],
                ["Fragmented UX", "Daily limits", "Quality varies by tool"],
                ["pdf to word", "merge pdf", "compress pdf", "pdf to jpg", "edit pdf", "split pdf"]),
            new("pdfelement", "PDFelement", "pdf.wondershare.com",
                "Freemium desktop + cloud; OCR and batch on paid; Wondershare account funnel.",
                ["Affordable vs Adobe", "Desktop + cloud bundle", "Form recognition on Pro"],
                ["Watermark on free exports", "Account upsell", "Online tools secondary to install"],
                ["pdf editor", "pdf to word", "merge pdf", "compress pdf", "ocr pdf", "sign pdf"]),
            new("wondershare", "Wondershare PDF", "wondershare.com",
                "PDFelement parent brand; desktop-first PDF suite with subscription marketing.",
                ["Brand recognition in Asia", "PDFelement cross-sell", "Video tutorial ecosystem"],
                ["Heavy subscription push", "Free web tier limited", "Multiple product confusion"],
                ["pdf editor", "pdf converter", "pdf to word", "compress pdf", "merge pdf"]),
        ];

        /// <summary>High-value keywords competitors rank for where RatPDF coverage is weak or missing.</summary>
        public static readonly KeywordGap[] KeywordGaps =
        [
            new("organize pdf online", "Transactional", "/pdf/merge", "/guides/merge-pdf", "iLovePDF", "P0"),
            new("rearrange pdf pages", "Transactional", "/pdf/merge", "/guides/merge-pdf", "iLovePDF", "P0"),
            new("combine pdf files", "Transactional", "/pdf/merge", "/guides/merge-pdf", "Smallpdf", "P0"),
            new("compress pdf to 100kb", "Transactional", "/compress-pdf-to-100kb", "/guides/compress-pdf-guide", "Smallpdf", "P0"),
            new("compress pdf to 1mb", "Transactional", "/compress-pdf-to-1mb", "/guides/compress-pdf-guide", "Smallpdf", "P0"),
            new("pdf to jpg", "Transactional", "/pdf/pdftoimages", "/guides/pdf-to-images", "iLovePDF", "P0"),
            new("pdf to png", "Transactional", "/pdf/pdftoimages", "/guides/pdf-to-images", "iLovePDF", "P0"),
            new("pdf to powerpoint", "Transactional", "/pdf/pdftoppt", "/guides/pdf-to-powerpoint", "Smallpdf", "P0"),
            new("powerpoint to pdf", "Transactional", "/pdf/ppttopdf", "/guides/powerpoint-to-pdf", "Smallpdf", "P0"),
            new("html to pdf", "Transactional", "/pdf/htmltopdf", "/guides/html-to-pdf", "PDF24", "P0"),
            new("pdf to markdown", "Transactional", "/pdf/pdftomarkdown", "/guides/pdf-to-markdown", "N/A", "P1"),
            new("pdf redaction online", "Transactional", "/pdf-redaction", "/guides/pdf-redaction", "Adobe", "P1"),
            new("compress pdf for email", "Transactional", "/compress-pdf-for-email", "/guides/compress-pdf-email-limits", "Smallpdf", "P0"),
            new("best pdf tool", "Commercial", "/compare", "/guides/choose-pdf-tool", "iLovePDF", "P0"),
            new("sodapdf alternative", "Commercial", "/compare/sodapdf-alternative", "/guides/pdf-tool-alternatives", "Soda PDF", "P1"),
            new("pdf candy alternative", "Commercial", "/compare/pdf-candy-alternative", "/guides/pdf-tool-alternatives", "PDF Candy", "P1"),
            new("crop pdf online", "Transactional", "/pdf/editpdf", "/guides/edit-pdf", "Sejda", "P1"),
            new("repair pdf online", "Transactional", "/pdf/flattenpdf", "/guides/flatten-pdf", "PDF24", "P2"),
            new("pdf reader online", "Informational", "/guides/pdf-tools", null, "Adobe", "P2"),
            new("ilovepdf alternative", "Commercial", "/compare/ilovepdf-alternative", "/guides/pdf-tool-alternatives", "iLovePDF", "P0"),
            new("smallpdf alternative", "Commercial", "/compare/smallpdf-alternative", "/guides/pdf-tool-alternatives", "Smallpdf", "P0"),
            new("pdf24 alternative", "Commercial", "/compare/pdf24-alternative", "/guides/pdf-tool-alternatives", "PDF24", "P0"),
            new("adobe acrobat alternative", "Commercial", "/compare/adobe-acrobat-alternative", "/guides/pdf-tool-alternatives", "Adobe", "P0"),
            new("sejda alternative", "Commercial", "/compare/sejda-alternative", "/guides/pdf-tool-alternatives", "Sejda", "P1"),
            new("foxit alternative", "Commercial", "/compare/foxit-alternative", "/guides/pdf-tool-alternatives", "Foxit", "P2"),
            new("pdfelement alternative", "Commercial", "/compare/pdfelement-alternative", "/guides/pdf-tool-alternatives", "PDFelement", "P1"),
            new("wondershare alternative", "Commercial", "/compare/wondershare-alternative", "/guides/pdf-tool-alternatives", "Wondershare", "P1"),
            new("gst invoice pdf", "Commercial", "/invoice/gst-invoice-generator", "/guides/invoice-generator-guide", "N/A", "P0"),
            new("compress aadhar pdf", "Transactional", "/compress-aadhar-pdf", "/guides/compress-pdf-guide", "iLovePDF", "P0"),
        ];

        public static readonly ComparePage[] ComparePages = BuildComparePages();

        public static ComparePage? GetComparePage(string slug) =>
            ComparePages.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        public static IReadOnlyList<string> AllComparePaths() =>
            ComparePages.Select(p => $"{CompareHubPath}/{p.Slug}").Prepend(CompareHubPath).ToList();

        public static IReadOnlyList<KeywordGap> GapsForCompetitor(string competitorSlug) =>
            KeywordGaps.Where(g =>
                g.CompetitorLeader.Contains(
                    Competitors.FirstOrDefault(c => c.Slug == competitorSlug)?.Name ?? "",
                    StringComparison.OrdinalIgnoreCase)
                || g.RatPdfUrl.Contains(competitorSlug, StringComparison.OrdinalIgnoreCase))
            .ToList();

        private static ComparePage[] BuildComparePages()
        {
            return Competitors.Select(c =>
            {
                var rows = new (string Feature, string RatPdf, string Competitor)[]
                {
                    ("Install required", "No — browser only", c.Name.Contains("Adobe") || c.Name.Contains("Foxit") ? "Often requires account or desktop app" : "No install for web tools"),
                    ("Free tier", "3 uses/tool/day, 200 MB/file", c.FreeTierSummary),
                    ("Max upload (Pro)", "4 GB", c.Slug == "pdf24" ? "Large files on free tier" : c.Slug == "smallpdf" ? "5 GB on Pro" : "100 MB–1 GB typical free"),
                    ("HTTPS / TLS", "Yes", "Yes"),
                    ("File retention", "Auto-deleted after download", "1–24 hours (vendor policy)"),
                    ("Watermarks", "No within free daily limits", c.Slug == "sejda" ? "Some free tasks watermarked" : "Varies"),
                    ("Toolkit breadth", "22+ PDF tools + invoice generator", "One primary tool per landing page"),
                    ("Guides & tutorials", $"{ContentLibrary.Guides.Count()} step-by-step guides", "Tutorial sections on major tool pages"),
                };
                return new ComparePage(
                    Slug: $"{c.Slug}-alternative",
                    Title: $"Best {c.Name} Alternative — Free PDF Tools | RatPDF",
                    Description: $"Compare RatPDF vs {c.Name}: merge, compress, convert, sign PDFs online. Transparent free tier, Pro up to 4 GB, no install.",
                    CompetitorName: c.Name,
                    CompetitorDomain: c.Domain,
                    HeroSummary: $"RatPDF is a free {c.Name} alternative for merge, compress, split, PDF to Word, OCR, and secure PDF workflows — one site instead of many tabs.",
                    KeywordGaps: KeywordGaps
                        .Where(g => g.CompetitorLeader.Contains(c.Name, StringComparison.OrdinalIgnoreCase)
                            || (c.Slug == "ilovepdf" && g.Priority == "P0" && g.Intent == "Transactional"))
                        .Select(g => g.Keyword)
                        .Distinct()
                        .Take(10)
                        .ToArray(),
                    ComparisonRows: rows,
                    Faqs: BuildFaqs(c));
            }).ToArray();
        }

        private static (string, string)[] BuildFaqs(CompetitorProfile c) =>
        [
            ($"Is RatPDF a free {c.Name} alternative?", $"Yes — RatPDF offers a free tier (3 uses per tool per day, 200 MB per file) for merge, compress, convert, and sign workflows without installing {c.Name}."),
            ($"How does RatPDF compare to {c.Name} on file size limits?", $"RatPDF Pro supports uploads up to 4 GB. {c.Name} free tier: {c.FreeTierSummary}"),
            ("Are uploads secure?", "RatPDF uses HTTPS/TLS encryption and deletes files after processing. See our Privacy policy for retention details."),
            ($"Can I switch from {c.Name} to RatPDF?", "Yes — bookmark the tools you use most on ratpdf.com, test your typical files on the free tier, then upgrade to Pro if you need higher limits."),
        ];
    }
}
