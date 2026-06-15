using System.Text;
using ratpdf.Constants;
using ratpdf.Models.CompressPdfSeo;
using ratpdf.Models.ProgrammaticSeo;
using ratpdf.Services.Seo;

namespace ratpdf.Services
{
    /// <summary>
    /// Programmatic SEO engine for PDF compression — curated hub-and-spoke pages plus
    /// thousands of long-tail slugs from compress-pdf-keywords.txt.
    /// </summary>
    public static class PdfCompressProgrammaticSeoGenerator
    {
        private const string ToolPath = "/pdf/compress";
        private const string HubPath = "/compress-pdf";
        private static readonly object SlugLock = new();
        private static HashSet<string>? _keywordSlugs;
        private static HashSet<string>? _allSlugs;
        private static string? _sitemapLastMod;

        /// <summary>Stable lastmod for sitemap entries (keywords file date, not rebuild time).</summary>
        public static string SitemapLastModified =>
            _sitemapLastMod ??= DateTime.UtcNow.ToString("yyyy-MM-dd");

        public enum PageCategory
        {
            SizeTarget,
            SizeUnder,
            UseCase,
            Device,
            Quality,
            CompetitorAlternative,
            CompetitorComparison,
            SubmissionRequirement,
            LongTail
        }

        private sealed record CuratedPage(
            string Slug,
            string H1,
            string Title,
            string MetaDescription,
            PageCategory Category,
            string PrimaryKeyword,
            string[] RelatedSlugs);

        private static readonly CuratedPage[] CuratedPages =
        [
            // ── Size targets ──
            new("compress-pdf-to-50kb", "Compress PDF to 50KB", "Compress PDF to 50KB Online — Free Size Target Tool | RatPDF",
                "Compress PDF to 50KB for strict government portals and form uploads. Free online tool with Ghostscript engine — no signup.",
                PageCategory.SizeTarget, "compress pdf to 50kb",
                ["compress-pdf-to-100kb", "compress-pdf-under-100kb", "compress-pdf-for-government-forms"]),
            new("compress-pdf-to-100kb", "Compress PDF to 100KB", "Compress PDF to 100KB Online — Passport & Form Ready | RatPDF",
                "Reduce any PDF to 100KB or less for passport scans, visa forms, and university uploads. Free, secure, instant download.",
                PageCategory.SizeTarget, "compress pdf to 100kb",
                ["compress-pdf-to-200kb", "pdf-under-100kb-passport", "compress-pdf-for-passport-application"]),
            new("compress-pdf-to-150kb", "Compress PDF to 150KB", "Compress PDF to 150KB — Online PDF Size Reducer | RatPDF",
                "Hit a 150KB upload limit without losing readable text. Compress PDF to 150KB online free with RatPDF.",
                PageCategory.SizeTarget, "compress pdf to 150kb",
                ["compress-pdf-to-100kb", "compress-pdf-to-200kb", "compress-pdf-for-online-submission"]),
            new("compress-pdf-to-200kb", "Compress PDF to 200KB", "Compress PDF to 200KB Online — Government Form Ready | RatPDF",
                "Compress PDF to 200KB for government portals, job applications, and email. Balanced quality with maximum size reduction.",
                PageCategory.SizeTarget, "compress pdf to 200kb",
                ["compress-pdf-to-100kb", "pdf-under-200kb-government-form", "compress-pdf-for-job-application"]),
            new("compress-pdf-to-250kb", "Compress PDF to 250KB", "Compress PDF to 250KB — Free Online Compressor | RatPDF",
                "Need exactly 250KB or less? Our PDF compressor targets portal limits with three quality presets.",
                PageCategory.SizeTarget, "compress pdf to 250kb",
                ["compress-pdf-to-200kb", "compress-pdf-to-300kb", "compress-pdf-for-university-application"]),
            new("compress-pdf-to-300kb", "Compress PDF to 300KB", "Compress PDF to 300KB Online Free | RatPDF",
                "Compress PDF to 300KB for online submissions. Ghostscript-powered engine preserves text clarity.",
                PageCategory.SizeTarget, "compress pdf to 300kb",
                ["compress-pdf-to-200kb", "compress-pdf-to-500kb", "compress-pdf-for-online-submission"]),
            new("compress-pdf-to-500kb", "Compress PDF to 500KB", "Compress PDF to 500KB — Email & Portal Ready | RatPDF",
                "Compress PDF to 500KB for email attachments and web uploads. Free tier: 3 compressions/day, 200 MB files.",
                PageCategory.SizeTarget, "compress pdf to 500kb",
                ["compress-pdf-to-300kb", "pdf-under-500kb-email", "compress-pdf-for-email"]),
            new("compress-pdf-to-1mb", "Compress PDF to 1MB", "Compress PDF to 1MB Online — Fast Size Reduction | RatPDF",
                "Shrink large PDFs under 1MB for cloud storage and messaging apps. Three compression levels available.",
                PageCategory.SizeTarget, "compress pdf to 1mb",
                ["compress-pdf-to-500kb", "compress-pdf-to-2mb", "compress-pdf-for-whatsapp"]),
            new("compress-pdf-to-2mb", "Compress PDF to 2MB", "Compress PDF to 2MB — Free PDF Compressor | RatPDF",
                "Compress PDF to 2MB for email providers with 2MB attachment caps. Secure HTTPS upload, auto-delete after download.",
                PageCategory.SizeTarget, "compress pdf to 2mb",
                ["compress-pdf-to-1mb", "compress-pdf-to-5mb", "compress-pdf-for-email"]),
            new("compress-pdf-to-5mb", "Compress PDF to 5MB", "Compress PDF to 5MB Online Free | RatPDF",
                "Reduce PDF file size to 5MB or less. Ideal for corporate email limits and LMS uploads.",
                PageCategory.SizeTarget, "compress pdf to 5mb",
                ["compress-pdf-to-2mb", "compress-pdf-for-website-upload", "compress-pdf-without-losing-quality"]),
            new("compress-pdf-to-10mb", "Compress PDF to 10MB", "Compress PDF to 10MB Online Free | RatPDF",
                "Shrink large PDFs under 10MB for enterprise email gateways and cloud uploads. Three compression presets.",
                PageCategory.SizeTarget, "compress pdf to 10mb",
                ["compress-pdf-to-5mb", "compress-pdf-for-email", "compress-pdf-without-losing-quality"]),

            // ── Under-size intent ──
            new("compress-pdf-under-100kb", "Compress PDF Under 100KB", "Compress PDF Under 100KB — Strict Limit Tool | RatPDF",
                "Get any PDF under 100KB for portals with hard caps. Step-by-step guide plus free online compressor.",
                PageCategory.SizeUnder, "compress pdf under 100kb",
                ["compress-pdf-to-100kb", "pdf-under-100kb-passport", "compress-pdf-for-passport-application"]),
            new("compress-pdf-under-200kb", "Compress PDF Under 200KB", "Compress PDF Under 200KB Online Free | RatPDF",
                "Compress PDF under 200KB for government and HR forms. Extreme mode for scan-heavy documents.",
                PageCategory.SizeUnder, "compress pdf under 200kb",
                ["compress-pdf-to-200kb", "pdf-under-200kb-government-form", "compress-pdf-for-government-forms"]),
            new("compress-pdf-under-500kb", "Compress PDF Under 500KB", "Compress PDF Under 500KB — Email-Safe PDFs | RatPDF",
                "Keep PDFs under 500KB for reliable email delivery. Recommended compression preserves readable images.",
                PageCategory.SizeUnder, "compress pdf under 500kb",
                ["compress-pdf-to-500kb", "pdf-under-500kb-email", "compress-pdf-for-email"]),
            new("compress-pdf-under-1mb", "Compress PDF Under 1MB", "Compress PDF Under 1MB — Fast Upload Ready | RatPDF",
                "Compress PDF under 1MB for email, LMS, and job portals. Balanced quality with Ghostscript /ebook profile.",
                PageCategory.SizeUnder, "compress pdf under 1mb",
                ["compress-pdf-to-1mb", "compress-pdf-for-email", "compress-pdf-for-job-application"]),

            // ── Use cases ──
            new("compress-pdf-for-email", "Compress PDF for Email", "Compress PDF for Email Attachments — Under 25MB Free | RatPDF",
                "Compress PDF for email before sending. Avoid bounce-backs from Gmail, Outlook, and Yahoo size limits.",
                PageCategory.UseCase, "compress pdf for email",
                ["pdf-under-500kb-email", "compress-pdf-to-500kb", "compress-pdf-for-whatsapp"]),
            new("compress-pdf-for-whatsapp", "Compress PDF for WhatsApp", "Compress PDF for WhatsApp — Mobile-Friendly Size | RatPDF",
                "WhatsApp caps documents at 100MB but large files fail on slow networks. Compress PDF for WhatsApp sharing.",
                PageCategory.UseCase, "compress pdf for whatsapp",
                ["compress-pdf-on-android", "compress-pdf-on-iphone", "compress-pdf-for-email"]),
            new("compress-pdf-for-university-application", "Compress PDF for University Application", "Compress PDF for University Application — Portal Ready | RatPDF",
                "Meet university portal limits for transcripts, SOPs, and recommendation letters. Compress PDF for university application uploads.",
                PageCategory.UseCase, "compress pdf for university application",
                ["compress-pdf-to-200kb", "compress-pdf-for-job-application", "compress-pdf-for-online-submission"]),
            new("compress-pdf-for-government-forms", "Compress PDF for Government Forms", "Compress PDF for Government Forms — e-Governance Ready | RatPDF",
                "Indian and international government portals often cap uploads at 100–500KB. Compress PDF for government forms safely.",
                PageCategory.UseCase, "compress pdf for government forms",
                ["pdf-under-200kb-government-form", "compress-pdf-for-passport-application", "compress-pdf-to-200kb"]),
            new("compress-pdf-for-passport-application", "Compress PDF for Passport Application", "Compress PDF for Passport Application — 100KB Scan Guide | RatPDF",
                "Passport seva and consulate portals require tiny scan files. Compress PDF for passport application step by step.",
                PageCategory.UseCase, "compress pdf for passport application",
                ["pdf-under-100kb-passport", "compress-pdf-to-100kb", "compress-pdf-for-visa-application"]),
            new("compress-pdf-for-visa-application", "Compress PDF for Visa Application", "Compress PDF for Visa Application — Embassy Upload Limits | RatPDF",
                "Visa portals reject oversized bank statements and employment letters. Compress PDF for visa application online free.",
                PageCategory.UseCase, "compress pdf for visa application",
                ["compress-pdf-for-passport-application", "compress-pdf-to-200kb", "compress-pdf-for-government-forms"]),
            new("compress-pdf-for-job-application", "Compress PDF for Job Application", "Compress PDF for Job Application — ATS-Friendly Size | RatPDF",
                "Recruiters and ATS systems prefer lean résumé PDFs. Compress PDF for job application without breaking layout.",
                PageCategory.UseCase, "compress pdf for job application",
                ["compress-pdf-to-500kb", "compress-pdf-for-email", "compress-pdf-for-online-submission"]),
            new("compress-pdf-for-online-submission", "Compress PDF for Online Submission", "Compress PDF for Online Submission — Portal Size Limits | RatPDF",
                "Generic guide for any web portal with a file-size field. Compress PDF for online submission in one click.",
                PageCategory.UseCase, "compress pdf for online submission",
                ["compress-pdf-to-200kb", "compress-pdf-for-government-forms", "compress-pdf-for-university-application"]),
            new("compress-pdf-for-website-upload", "Compress PDF for Website Upload", "Compress PDF for Website Upload — Optimize for Web | RatPDF",
                "Speed up page loads by compressing PDFs before CMS upload. Compress PDF for website upload with web-optimized settings.",
                PageCategory.UseCase, "compress pdf for website upload",
                ["optimize-pdf-for-web", "compress-pdf-without-losing-quality", "compress-pdf-to-1mb"]),

            // ── Devices ──
            new("compress-pdf-on-iphone", "Compress PDF on iPhone", "Compress PDF on iPhone — No App Required | RatPDF",
                "Compress PDF on iPhone in Safari without installing apps. Works on iOS 15+ with drag-and-drop upload.",
                PageCategory.Device, "compress pdf on iphone",
                ["compress-pdf-on-ipad", "compress-pdf-for-whatsapp", "compress-pdf-for-email"]),
            new("compress-pdf-on-android", "Compress PDF on Android", "Compress PDF on Android — Browser-Based Compressor | RatPDF",
                "Compress PDF on Android phones and tablets via Chrome. No Play Store download needed.",
                PageCategory.Device, "compress pdf on android",
                ["compress-pdf-on-iphone", "compress-pdf-for-whatsapp", "compress-pdf-on-ipad"]),
            new("compress-pdf-on-mac", "Compress PDF on Mac", "Compress PDF on Mac — Online Alternative to Preview | RatPDF",
                "Compress PDF on Mac without Adobe or Preview tricks. Browser tool with Ghostscript-quality output.",
                PageCategory.Device, "compress pdf on mac",
                ["compress-pdf-on-windows", "lossless-pdf-compression", "adobe-pdf-compressor-alternative"]),
            new("compress-pdf-on-windows", "Compress PDF on Windows", "Compress PDF on Windows — Free Online Tool | RatPDF",
                "Compress PDF on Windows 10/11 without installing software. Edge, Chrome, and Firefox supported.",
                PageCategory.Device, "compress pdf on windows",
                ["compress-pdf-on-mac", "compress-pdf-on-iphone", "pdf24-compressor-alternative"]),
            new("compress-pdf-on-ipad", "Compress PDF on iPad", "Compress PDF on iPad — Split View Friendly | RatPDF",
                "Compress PDF on iPad while referencing email or Notes side-by-side. Touch-optimized upload UI.",
                PageCategory.Device, "compress pdf on ipad",
                ["compress-pdf-on-iphone", "compress-pdf-for-email", "compress-pdf-on-mac"]),

            // ── Quality ──
            new("compress-pdf-without-losing-quality", "Compress PDF Without Losing Quality", "Compress PDF Without Losing Quality — Smart Optimization | RatPDF",
                "Reduce PDF size while keeping text sharp and images readable. Recommended mode uses balanced Ghostscript /ebook profile.",
                PageCategory.Quality, "compress pdf without losing quality",
                ["lossless-pdf-compression", "compress-pdf-high-quality", "best-pdf-compression-settings"]),
            new("compress-pdf-high-quality", "Compress PDF High Quality", "High Quality PDF Compression — Preserve Detail | RatPDF",
                "High quality PDF compression for portfolios, medical records, and legal briefs where clarity matters.",
                PageCategory.Quality, "compress pdf high quality",
                ["compress-pdf-without-losing-quality", "lossless-pdf-compression", "pdf-optimization-guide"]),
            new("best-pdf-compression-settings", "Best PDF Compression Settings", "Best PDF Compression Settings — Extreme vs Recommended | RatPDF",
                "Compare extreme, recommended, and less compression presets. Choose the best PDF compression settings for your document type.",
                PageCategory.Quality, "best pdf compression settings",
                ["compress-pdf-without-losing-quality", "pdf-optimization-guide", "optimize-pdf-for-web"]),
            new("lossless-pdf-compression", "Lossless PDF Compression", "Lossless PDF Compression Online — Text & Vector Safe | RatPDF",
                "Lossless PDF compression re-encodes streams without destroying vector text. When lossless is enough vs when you need lossy.",
                PageCategory.Quality, "lossless pdf compression",
                ["compress-pdf-without-losing-quality", "compress-pdf-high-quality", "best-pdf-compression-settings"]),
            new("optimize-pdf-for-web", "Optimize PDF for Web", "Optimize PDF for Web — Fast-Loading Documents | RatPDF",
                "Optimize PDF for web embedding: linearize, downsample images, strip unused objects. Better Core Web Vitals.",
                PageCategory.Quality, "optimize pdf for web",
                ["compress-pdf-for-website-upload", "best-pdf-compression-settings", "compress-pdf-to-1mb"]),
            new("pdf-optimization-guide", "PDF Optimization Guide", "Complete PDF Optimization Guide — Compression, Fonts & Images | RatPDF",
                "Authoritative PDF optimization guide covering compression levels, DPI trade-offs, font subsetting, and portal checklists.",
                PageCategory.Quality, "pdf optimization guide",
                ["best-pdf-compression-settings", "lossless-pdf-compression", "compress-pdf-without-losing-quality"]),

            // ── Competitor alternatives ──
            new("adobe-pdf-compressor-alternative", "Adobe PDF Compressor Alternative", "Adobe PDF Compressor Alternative — Free Online | RatPDF",
                "Free Adobe PDF compressor alternative with no subscription. Same Ghostscript engine, zero install.",
                PageCategory.CompetitorAlternative, "adobe pdf compressor alternative",
                ["compress-pdf-vs-adobe", "compress-pdf-on-mac", "lossless-pdf-compression"]),
            new("ilovepdf-compressor-alternative", "iLovePDF Compressor Alternative", "iLovePDF Compressor Alternative — No Watermark | RatPDF",
                "iLovePDF compressor alternative with transparent limits, HTTPS upload, and automatic file deletion.",
                PageCategory.CompetitorAlternative, "ilovepdf compressor alternative",
                ["compress-pdf-vs-ilovepdf", "compress-pdf-for-email", "compress-pdf-to-500kb"]),
            new("smallpdf-compressor-alternative", "Smallpdf Compressor Alternative", "Smallpdf Compressor Alternative — Free Daily Uses | RatPDF",
                "Smallpdf compressor alternative: 3 free compressions per day, Pro up to 4 GB. No desktop app required.",
                PageCategory.CompetitorAlternative, "smallpdf compressor alternative",
                ["compress-pdf-vs-smallpdf", "compress-pdf-for-job-application", "compress-pdf-online"]),
            new("pdf24-compressor-alternative", "PDF24 Compressor Alternative", "PDF24 Compressor Alternative — Browser-Based | RatPDF",
                "PDF24 compressor alternative that runs entirely in the browser. Compare features, limits, and privacy.",
                PageCategory.CompetitorAlternative, "pdf24 compressor alternative",
                ["compress-pdf-vs-adobe", "compress-pdf-on-windows", "compress-pdf-for-government-forms"]),

            // ── Comparisons ──
            new("compress-pdf-vs-adobe", "Compress PDF vs Adobe Acrobat", "Compress PDF vs Adobe — Feature & Price Comparison | RatPDF",
                "Honest compress PDF vs Adobe comparison: cost, quality, speed, privacy, and when Acrobat still wins.",
                PageCategory.CompetitorComparison, "compress pdf vs adobe",
                ["adobe-pdf-compressor-alternative", "compress-pdf-on-mac", "lossless-pdf-compression"]),
            new("compress-pdf-vs-smallpdf", "Compress PDF vs Smallpdf", "Compress PDF vs Smallpdf — Which Is Better? | RatPDF",
                "Compress PDF vs Smallpdf: daily limits, max file size, compression quality, and data retention compared.",
                PageCategory.CompetitorComparison, "compress pdf vs smallpdf",
                ["smallpdf-compressor-alternative", "compress-pdf-for-email", "compress-pdf-to-1mb"]),
            new("compress-pdf-vs-ilovepdf", "Compress PDF vs iLovePDF", "Compress PDF vs iLovePDF — Free Tool Comparison | RatPDF",
                "Compress PDF vs iLovePDF breakdown for students, freelancers, and teams who compress daily.",
                PageCategory.CompetitorComparison, "compress pdf vs ilovepdf",
                ["ilovepdf-compressor-alternative", "compress-pdf-for-whatsapp", "compress-pdf-to-200kb"]),

            // ── Submission requirements ──
            new("pdf-under-100kb-passport", "PDF Under 100KB for Passport", "PDF Under 100KB for Passport Application — Step-by-Step | RatPDF",
                "How to get PDF under 100KB for passport scans: DPI, crop, compression level, and verification checklist.",
                PageCategory.SubmissionRequirement, "pdf under 100kb passport",
                ["compress-pdf-to-100kb", "compress-pdf-for-passport-application", "compress-pdf-under-100kb"]),
            new("pdf-under-200kb-government-form", "PDF Under 200KB for Government Form", "PDF Under 200KB for Government Forms — Upload Checklist | RatPDF",
                "Government e-filing often rejects files over 200KB. Guide to PDF under 200KB for government form submission.",
                PageCategory.SubmissionRequirement, "pdf under 200kb government form",
                ["compress-pdf-to-200kb", "compress-pdf-for-government-forms", "compress-pdf-under-200kb"]),
            new("pdf-under-500kb-email", "PDF Under 500KB for Email", "PDF Under 500KB for Email — Attachment Size Guide | RatPDF",
                "Keep PDF under 500KB for email so mobile recipients can open attachments on cellular data.",
                PageCategory.SubmissionRequirement, "pdf under 500kb email",
                ["compress-pdf-for-email", "compress-pdf-to-500kb", "compress-pdf-under-500kb"]),
        ];

        private static readonly Dictionary<string, CuratedPage> CuratedBySlug =
            CuratedPages.ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        /// <summary>Hand-crafted compress SEO pages in PdfCompressSeoController (still indexed, not programmatic).</summary>
        public static readonly string[] StaticLegacySlugs =
        [
            "compress-pdf",
            "compress-pdf-adobe",
            "compress-pdf-app",
            "compress-pdf-adobe-acrobat",
            "compress-pdf-ilovepdf",
            "compress-pdf-smallpdf",
            "compress-pdf-as-per-size",
            "compress-pdf-and-merge",
            "compress-pdf-ave",
            "compress-pdf-according-to-size",
            "compress-pdf-avepdf",
            "compress-pdf-ai",
            "compress-pdf-and-jpg",
            "compress-pdf-acrobat",
            "compress-pdf-adobe-free",
            "compress-pdf-online",
            "compress-pdf-as-per-required-size",
            "shrink-pdf-size-online",
            "reduce-pdf-size-online",
            "compress-pdf-app-for-pc",
            "compress-aadhar-pdf",
            "pdf-compress-aap",
            "compress-pdf-reduce-pdf-size",
            "compress-pdf-to-pdf-small-size",
            "compress-pdf-file-size",
            "compress-pdf-above-200-mb",
            "compress-pdf-adobe-online",
            "compress-pdf-above-100-kb",
            "compress-pdf-above-50-kb",
            "compress-pdf-above-100kb-free",
            "compress-pdf-10-mb-without-losing-quality",
            "compress-pdf-1-mb-without-losing-quality",
            "compress-pdf-200kb-without-losing-quality",
            "how-to-compress-a-large-pdf-file-for-emailing",
            "how-do-i-shrink-a-pdf-size",
        ];

        /// <summary>Slugs handled by PdfCompressSeoController static actions — excluded from programmatic routing.</summary>
        private static readonly HashSet<string> StaticControllerSlugs = new(StaticLegacySlugs, StringComparer.OrdinalIgnoreCase);

        /// <summary>Load keyword slugs from wwwroot — call once at app startup.</summary>
        public static void Initialize(string webRootPath) => LoadKeywordSlugs(webRootPath);

        public static bool IsKnownSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug) || StaticControllerSlugs.Contains(slug))
                return false;

            if (IsBlockedSlug(slug))
                return false;

            EnsureSlugCache();
            return _allSlugs!.Contains(slug);
        }

        public static IReadOnlyList<string> AllLandingPaths()
        {
            EnsureSlugCache();
            return _allSlugs!.Select(s => $"/{s}").ToList();
        }

        /// <summary>All compress SEO URLs for sitemap: hero tool, legacy static pages, curated + keyword landings.</summary>
        public static IReadOnlyList<string> AllSitemapPaths()
        {
            EnsureSlugCache();
            var paths = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ToolPath,
            };
            foreach (var slug in StaticLegacySlugs)
                paths.Add($"/{slug}");
            foreach (var slug in _allSlugs!)
            {
                if (IsBlockedSlug(slug)) continue;
                if (CuratedBySlug.ContainsKey(slug) || StaticLegacySlugs.Contains(slug))
                {
                    paths.Add($"/{slug}");
                    continue;
                }
                var intent = IntentClassifier.Classify(PdfToolVertical.CompressPdf, slug, slug.Replace('-', ' '));
                if (IntentClassifier.IsSitemapEligible(intent))
                    paths.Add($"/{slug}");
            }
            return paths.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public static IReadOnlyList<(string Label, string Path)> HubSpokeLinks() =>
        [
            ("Compress PDF Hub", "/compress-pdf"),
            ("Compress PDF to 100KB", "/compress-pdf-to-100kb"),
            ("Compress PDF to 200KB", "/compress-pdf-to-200kb"),
            ("Compress PDF to 500KB", "/compress-pdf-to-500kb"),
            ("Compress PDF Under 1MB", "/compress-pdf-under-1mb"),
            ("Compress PDF for Email", "/compress-pdf-for-email"),
            ("Compress Without Losing Quality", "/compress-pdf-without-losing-quality"),
            ("Adobe Alternative", "/adobe-pdf-compressor-alternative"),
            ("Passport Upload (100KB)", "/pdf-under-100kb-passport"),
            ("PDF Optimization Guide", "/pdf-optimization-guide"),
        ];

        public static CompressSeoLandingModel? GetPage(string slug, string webRootPath)
        {
            if (string.IsNullOrWhiteSpace(slug) || StaticControllerSlugs.Contains(slug))
                return null;

            if (IsBlockedSlug(slug))
                return null;

            if (CuratedBySlug.TryGetValue(slug, out var curated))
                return BuildCuratedPage(curated);

            LoadKeywordSlugs(webRootPath);
            if (_keywordSlugs == null || !_keywordSlugs.Contains(slug))
                return null;

            return BuildLongTailPage(slug);
        }

        /// <summary>Reject keyword-file slugs unrelated to PDF compression.</summary>
        private static bool IsBlockedSlug(string slug)
        {
            var lower = slug.ToLowerInvariant();
            string[] blocked =
            [
                "rv-kbb", "kbb-value", "kbb-book", "rv-values-kbb", "motorhome",
                "pdf-to-word-converter", "pdf-to-ppt", "html-to-pdf", "word-to-pdf",
                "invoice-generator", "payslip", "bmi-calculator", "egfr-calculator",
            ];
            return blocked.Any(b => lower.Contains(b, StringComparison.Ordinal));
        }

        private static void EnsureSlugCache()
        {
            if (_allSlugs != null) return;
            lock (SlugLock)
            {
                if (_allSlugs != null) return;
                _allSlugs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var p in CuratedPages)
                    _allSlugs.Add(p.Slug);
            }
        }

        public static void RegisterKeywordSlugs(IEnumerable<string> slugs)
        {
            EnsureSlugCache();
            lock (SlugLock)
            {
                foreach (var s in slugs)
                {
                    if (!string.IsNullOrWhiteSpace(s) && !StaticControllerSlugs.Contains(s) && !IsBlockedSlug(s))
                        _allSlugs!.Add(s.Trim());
                }
            }
        }

        private static void LoadKeywordSlugs(string webRootPath)
        {
            if (_keywordSlugs != null || string.IsNullOrEmpty(webRootPath)) return;
            var path = Path.Combine(webRootPath, "compress-pdf-keywords.txt");
            if (!File.Exists(path))
            {
                _keywordSlugs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                _sitemapLastMod = DateTime.UtcNow.ToString("yyyy-MM-dd");
                return;
            }

            _sitemapLastMod = File.GetLastWriteTimeUtc(path).ToString("yyyy-MM-dd");

            var lines = File.ReadAllLines(path)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => GenerateSlug(l.Trim()))
                .Where(s => !StaticControllerSlugs.Contains(s) && !IsBlockedSlug(s));

            _keywordSlugs = new HashSet<string>(lines, StringComparer.OrdinalIgnoreCase);
            RegisterKeywordSlugs(_keywordSlugs);
        }

        private static CompressSeoLandingModel? BuildLongTailPage(string slug)
        {
            var keywordPhrase = slug.Replace('-', ' ');
            var intent = IntentClassifier.Classify(PdfToolVertical.CompressPdf, slug, keywordPhrase);
            var disposition = IntentClassifier.GetDisposition(intent);
            if (disposition == IndexDisposition.NotFound)
                return null;

            var displayTitle = VerticalIntentContentBuilder.BuildDisplayTitle(
                PdfToolVertical.CompressPdf, slug, keywordPhrase, intent);
            var toolHref = PdfToolSeo.Canonical(ToolPath);
            var noIndex = disposition == IndexDisposition.NoIndex;

            var faqs = VerticalIntentContentBuilder
                .BuildFaqs(PdfToolVertical.CompressPdf, intent, toolHref, slug)
                .Select(f => new FaqItem { Question = f.Question, Answer = f.Answer })
                .ToList();

            var model = BuildModel(
                slug,
                displayTitle,
                ProgrammaticMetadataService.BuildTitle(displayTitle, intent, false),
                ProgrammaticMetadataService.BuildDescription(displayTitle, intent),
                PageCategory.LongTail,
                keywordPhrase,
                GetDefaultRelated(slug),
                VerticalIntentContentBuilder.BuildContent(PdfToolVertical.CompressPdf, intent, displayTitle, slug, toolHref),
                faqs,
                BuildHowToSteps(keywordPhrase));
            model.NoIndex = noIndex;
            return model;
        }

        private static CompressSeoLandingModel BuildCuratedPage(CuratedPage page)
        {
            var content = page.Category switch
            {
                PageCategory.SizeTarget => BuildSizeTargetContent(page),
                PageCategory.SizeUnder => BuildSizeUnderContent(page),
                PageCategory.UseCase => BuildUseCaseContent(page),
                PageCategory.Device => BuildDeviceContent(page),
                PageCategory.Quality => BuildQualityContent(page),
                PageCategory.CompetitorAlternative => BuildAlternativeContent(page),
                PageCategory.CompetitorComparison => BuildComparisonContent(page),
                PageCategory.SubmissionRequirement => BuildSubmissionContent(page),
                _ => BuildLongTailContent(page.PrimaryKeyword)
            };

            var faqs = page.Category switch
            {
                PageCategory.SizeTarget or PageCategory.SizeUnder => BuildSizeFaqs(page),
                PageCategory.UseCase => BuildUseCaseFaqs(page),
                PageCategory.Device => BuildDeviceFaqs(page),
                PageCategory.Quality => BuildQualityFaqs(page),
                PageCategory.CompetitorAlternative or PageCategory.CompetitorComparison => BuildCompetitorFaqs(page),
                PageCategory.SubmissionRequirement => BuildSubmissionFaqs(page),
                _ => BuildGenericFaqs(page.PrimaryKeyword)
            };

            return BuildModel(
                page.Slug,
                page.H1,
                page.Title,
                page.MetaDescription,
                page.Category,
                page.PrimaryKeyword,
                ResolveRelated(page.RelatedSlugs),
                content,
                faqs,
                BuildHowToSteps(page.PrimaryKeyword));
        }

        private static CompressSeoLandingModel BuildModel(
            string slug,
            string h1,
            string title,
            string metaDescription,
            PageCategory category,
            string primaryKeyword,
            List<(string Label, string Path)> related,
            string contentHtml,
            List<FaqItem> faqs,
            List<(string Name, string Text)> howToSteps)
        {
            var canonical = PdfToolSeo.Canonical($"/{slug}");
            return new CompressSeoLandingModel
            {
                Slug = slug,
                H1 = h1,
                Title = title,
                MetaDescription = metaDescription,
                CanonicalUrl = canonical,
                ContentHtml = contentHtml,
                PageCategory = category.ToString(),
                HubPath = HubPath,
                ToolPath = ToolPath,
                FaqItems = faqs,
                HowToSteps = howToSteps,
                RelatedPages = related,
                RelatedTools =
                [
                    ("Merge PDF", "/PDF/Merge"),
                    ("Split PDF", "/PDF/Split"),
                    ("PDF to Word", "/PDF/PdfToDoc"),
                    ("Protect PDF", "/PDF/Password"),
                ],
                Breadcrumbs =
                [
                    new BreadcrumbItem { Name = "Home", Url = PdfToolSeo.Canonical("/") },
                    new BreadcrumbItem { Name = "Compress PDF", Url = PdfToolSeo.Canonical(HubPath) },
                    new BreadcrumbItem { Name = h1, Url = canonical },
                ],
                Rating = new AggregateRating { RatingValue = 4.8, ReviewCount = 2847 },
                Organization = new Organization
                {
                    Name = "RatPDF",
                    Url = PdfToolSeo.SiteUrl,
                    Logo = PdfToolSeo.DefaultOgImage,
                    Description = "Free online PDF tools: compress, merge, split, convert, edit, and more.",
                    Email = "ethan.brooks@ratpdf.com"
                },
                WebSite = new WebSite { Name = "RatPDF", Url = PdfToolSeo.SiteUrl }
            };
        }

        private static List<(string Label, string Path)> ResolveRelated(IEnumerable<string> slugs) =>
            slugs.Where(s => CuratedBySlug.ContainsKey(s) || (_keywordSlugs?.Contains(s) ?? false))
                 .Select(s => (Label: CuratedBySlug.TryGetValue(s, out var p) ? p.H1 : FormatSlugLabel(s), Path: $"/{s}"))
                 .ToList();

        private static List<(string Label, string Path)> GetDefaultRelated(string slug) =>
            HubSpokeLinks().Where(l => !l.Path.EndsWith(slug, StringComparison.OrdinalIgnoreCase)).Take(6).ToList();

        private static string FormatSlugLabel(string slug) =>
            Capitalize(slug.Replace('-', ' '));

        private static string ToolLink() =>
            $"<a href=\"{PdfToolSeo.Canonical(ToolPath)}\">PDF Compressor</a>";

        private static string HubLink() =>
            $"<a href=\"{PdfToolSeo.Canonical(HubPath)}\"><strong>Compress PDF hub</strong></a>";

        // ── Content builders ──

        private static string BuildSizeTargetContent(CuratedPage page)
        {
            var size = ExtractSize(page.Slug);
            var tool = ToolLink();
            var sb = new StringBuilder();
            sb.Append($"""
                <p class="lead">Need to <strong>{page.PrimaryKeyword}</strong>? RatPDF's {tool} lets you upload any PDF and shrink it toward a <strong>{size}</strong> target using Ghostscript — the same engine used by print shops worldwide. No Adobe subscription, no desktop install, and your file is deleted automatically after download.</p>
                <p>Portal administrators set hard upload caps because storage and bandwidth cost money. A 15 MB scan of a passport photo will be rejected even if the content is perfect. Targeting {size} before you upload saves hours of trial-and-error resizing in image editors.</p>

                <h2>Why compress PDF to {size}?</h2>
                <p>Many government, education, and HR portals enforce a maximum file size between 50 KB and 2 MB. When the form says "maximum {size}", exceeding it blocks submission entirely — there is no partial credit. Compressing proactively means your application, visa form, or job packet goes through on the first attempt.</p>
                <p>Email servers and messaging apps also behave better with smaller attachments. Recipients on mobile data can download a {size} PDF in seconds; a 20 MB scan may never finish.</p>
                <ul>
                <li><strong>Passport &amp; visa portals</strong> — often require 100–200 KB scans</li>
                <li><strong>University admissions</strong> — transcript uploads capped at 500 KB–1 MB</li>
                <li><strong>Corporate HR systems</strong> — résumé fields limited to 200–500 KB</li>
                <li><strong>Insurance &amp; banking KYC</strong> — ID proof uploads with strict ceilings</li>
                </ul>

                <h2>How RatPDF hits your {size} target</h2>
                <p>Our compressor offers three levels. Start with <em>Recommended</em> — it balances readability and size. If the output is still above {size}, run <em>Extreme</em> compression or remove blank pages first with our <a href="/PDF/Split">Split PDF</a> tool.</p>
                <ol>
                <li><strong>Upload</strong> your PDF to the {tool}.</li>
                <li><strong>Choose compression level</strong> — Recommended for text-heavy docs, Extreme for scan photos.</li>
                <li><strong>Download</strong> and check file size in your file manager.</li>
                <li><strong>Re-compress if needed</strong> — free users get 3 runs per day; iterate until you are under {size}.</li>
                </ol>
                <p>Image-heavy PDFs (scanned certificates, mark sheets) shrink the most because JPEG re-encoding saves the largest bytes. Text-only PDFs may only drop 10–30% with lossless stream compression — in those cases, flatten unnecessary layers or export at lower DPI from the source scanner.</p>

                <h2>Compression methods explained</h2>
                <h3>Lossless optimization</h3>
                <p>RatPDF removes duplicate objects, compresses PDF streams with Flate, and subsets fonts. This never blurs text but may not reach {size} alone on photo scans.</p>
                <h3>Lossy image downsampling</h3>
                <p>Extreme mode re-encodes embedded images at lower DPI (screen profile ≈ 72 DPI). Text stays vector-sharp; photographs become smaller. This is how most online compressors achieve 70–90% reduction.</p>
                <h3>Pre-processing tips</h3>
                <p>Crop scanner margins, convert colour scans to grayscale when colour is not required, and merge multi-page uploads only after each page is already small. See our <a href="/pdf-optimization-guide">PDF optimization guide</a> for advanced workflows.</p>

                <h2>Common mistakes when targeting {size}</h2>
                <p>Uploading a phone photo saved as PNG inside a PDF wastes space — always scan directly to PDF or convert photos first. Another mistake is using "Print to PDF" repeatedly, which bloats file size with each pass. Compress once from the original export.</p>
                <p>Verify the portal's limit: some list KB while others list MB. {size} is not interchangeable with a larger allowance — always read the fine print on the upload button.</p>

                <h2>Related size targets</h2>
                <p>Browse our {HubLink()} for other common limits, or jump to a neighbouring target if {size} is too aggressive for your document type.</p>
                """);
            return sb.ToString();
        }

        private static string BuildSizeUnderContent(CuratedPage page)
        {
            var limit = ExtractSize(page.Slug);
            return $"""
                <p class="lead">When a portal says "file must be <strong>{limit}</strong>", you need headroom — not an exact match. This guide shows how to <strong>{page.PrimaryKeyword}</strong> reliably using RatPDF's {ToolLink()}.</p>
                <h2>Under vs exact size targets</h2>
                <p>"Under {limit}" means the file size in bytes must be strictly less than the limit. A 102,400-byte file fails a 100 KB cap. Aim for 85–90% of the limit so metadata overhead does not push you over after re-saving.</p>
                <h2>Step-by-step workflow</h2>
                <ol>
                <li>Upload to RatPDF and select Recommended compression.</li>
                <li>Download and confirm size in Windows Explorer or macOS Get Info.</li>
                <li>If still over {limit}, switch to Extreme and compress again.</li>
                <li>For scans, reduce scanner DPI to 150 before creating the PDF.</li>
                </ol>
                <h2>Where {limit} limits appear</h2>
                <p>Indian e-governance portals, scholarship forms, and railway recruitment uploads frequently use 100–200 KB caps. International visa DS-160 supporting documents often need under 200 KB per file. Email is looser but keeping attachments under 500 KB improves deliverability.</p>
                <h2>Quality checklist</h2>
                <p>After compression, zoom to 100% and confirm dates, signatures, and ID numbers remain legible. If text looks fuzzy, back off from Extreme to Recommended and crop whitespace instead.</p>
                <p>Return to the {HubLink()} for more size-specific guides and competitor comparisons.</p>
                """;
        }

        private static string BuildUseCaseContent(CuratedPage page)
        {
            var tool = ToolLink();
            return $"""
                <p class="lead"><strong>{Capitalize(page.PrimaryKeyword)}</strong> is one of the most common PDF tasks we see at RatPDF. Whether you are submitting a form before a deadline or sharing a contract with a client, file size limits appear everywhere. Our {tool} handles the compression; this page explains the workflow end to end.</p>
                <h2>Typical size limits for this use case</h2>
                <p>Requirements vary by platform. Always check the current portal FAQ, but these ranges help you plan:</p>
                <ul>
                <li><strong>Email (Gmail)</strong> — 25 MB attachment, but keep under 5 MB for mobile recipients</li>
                <li><strong>WhatsApp</strong> — 100 MB max, but 1–5 MB sends faster on 4G</li>
                <li><strong>University portals</strong> — 200 KB–2 MB per document</li>
                <li><strong>Government e-forms</strong> — 100–500 KB common in India</li>
                <li><strong>Job boards / ATS</strong> — 2–5 MB résumé PDF recommended</li>
                </ul>
                <h2>Recommended compression settings</h2>
                <p>For {page.PrimaryKeyword}, start with <em>Recommended</em> compression. Text résumés and typed forms usually shrink enough without visible quality loss. Scanned certificates need <em>Extreme</em> or pre-scan DPI reduction.</p>
                <h2>Security considerations</h2>
                <p>Passport copies, bank statements, and offer letters contain PII. RatPDF transfers files over TLS, processes them in isolated jobs, and deletes uploads after download. We never use document content for advertising or model training.</p>
                <h2>Before you upload</h2>
                <p>Remove password protection if you own the file (<a href="/PDF/UnlockPdf">Unlock PDF</a>). Merge related pages with <a href="/PDF/Merge">Merge PDF</a> only after each part is already compressed — merging bloated scans first makes compression harder.</p>
                <h2>After compression</h2>
                <p>Open the PDF locally, verify every page, and confirm the file name matches portal rules (some require surname_firstname.pdf). Keep the original uncompressed archive for your records.</p>
                <p>Explore related workflows on our {HubLink()} including device-specific guides and Adobe alternatives.</p>
                """;
        }

        private static string BuildDeviceContent(CuratedPage page)
        {
            return $"""
                <p class="lead">You can <strong>{page.PrimaryKeyword}</strong> without installing a dedicated app. RatPDF runs in your mobile or desktop browser — upload from Files, Google Drive, or iCloud and download the compressed PDF in place.</p>
                <h2>Browser support</h2>
                <p>Safari on iOS 15+, Chrome on Android 10+, and all modern desktop browsers support drag-and-drop upload. If drag-and-drop fails, tap the upload zone and pick the file from your document picker.</p>
                <h2>Mobile workflow tips</h2>
                <ul>
                <li>On iPhone/iPad, use Share → Save to Files, then upload from Files in Safari.</li>
                <li>On Android, locate the PDF in Downloads or Google Drive first.</li>
                <li>Switch to Wi-Fi for files over 10 MB to avoid timeouts.</li>
                <li>Keep the tab open until the progress bar completes — background tabs may pause on iOS.</li>
                </ul>
                <h2>Desktop workflow</h2>
                <p>Mac and Windows users get the same {ToolLink()} with larger screen estate for comparing before/after file sizes side by side in Finder or Explorer.</p>
                <h2>No app store required</h2>
                <p>App-based compressors often bundle ads, subscription nags, or excessive permissions. A browser tool avoids install friction and works on managed corporate laptops where the App Store is blocked.</p>
                <p>See also: {HubLink()} for email, WhatsApp, and passport-specific guides.</p>
                """;
        }

        private static string BuildQualityContent(CuratedPage page)
        {
            return $"""
                <p class="lead">Searching for <strong>{page.PrimaryKeyword}</strong>? Quality and file size pull in opposite directions — the art is finding the minimum compression that still looks professional. RatPDF exposes three explicit levels so you control that trade-off.</p>
                <h2>Understanding compression levels</h2>
                <table class="table table-bordered">
                <thead><tr><th>Level</th><th>Best for</th><th>Typical reduction</th></tr></thead>
                <tbody>
                <tr><td>Less (lossless-leaning)</td><td>Text contracts, vector diagrams</td><td>5–20%</td></tr>
                <tr><td>Recommended (/ebook)</td><td>Mixed text + images, résumés</td><td>30–60%</td></tr>
                <tr><td>Extreme (/screen)</td><td>Scans, photos, strict KB limits</td><td>60–90%</td></tr>
                </tbody>
                </table>
                <h2>What stays sharp?</h2>
                <p>Vector text and line art survive all levels because they are not re-rasterized. Embedded JPEG photos absorb most of the byte loss. If your PDF is scan-only (each page is one big image), expect visible softness at Extreme — that is the physics of lower DPI.</p>
                <h2>Lossless vs lossy in practice</h2>
                <p>True lossless PDF compression removes redundancy but cannot magically shrink a 5 MB photo scan. Lossy re-encoding is required for order-of-magnitude gains. For archival legal records, keep an uncompressed original and distribute a compressed copy.</p>
                <h2>Web optimization</h2>
                <p>PDFs embedded in websites should load under 1 MB when possible. Combine compression with <a href="/PDF/FlattenPdf">Flatten PDF</a> to remove interactive form overhead if users only need to read — not fill — the document.</p>
                <h2>Further reading</h2>
                <p>Our <a href="/guides/compress-pdf-guide">step-by-step compress PDF guide</a> walks through Ghostscript profiles. Use the {ToolLink()} to A/B test levels on your actual file — thumbnails lie; your document does not.</p>
                """;
        }

        private static string BuildAlternativeContent(CuratedPage page)
        {
            var competitor = page.Slug switch
            {
                var s when s.Contains("adobe") => "Adobe Acrobat",
                var s when s.Contains("ilovepdf") => "iLovePDF",
                var s when s.Contains("smallpdf") => "Smallpdf",
                var s when s.Contains("pdf24") => "PDF24",
                _ => "other tools"
            };
            return $"""
                <p class="lead">Looking for a <strong>{page.PrimaryKeyword}</strong>? {competitor} is popular but often requires subscriptions, desktop installs, or daily task limits. RatPDF offers a capable browser-based compressor with transparent free-tier rules.</p>
                <h2>Why switch?</h2>
                <ul>
                <li><strong>Cost</strong> — core compression is free (3 uses/day per tool); Pro unlocks 4 GB files</li>
                <li><strong>Privacy</strong> — HTTPS upload, auto-delete, no selling document content</li>
                <li><strong>Engine quality</strong> — Ghostscript + iText pipeline, same class as enterprise tools</li>
                <li><strong>No watermark</strong> — output PDFs are clean</li>
                </ul>
                <h2>Feature comparison snapshot</h2>
                <p>RatPDF focuses on doing compression exceptionally well rather than bundling dozens of mediocre utilities. You also get merge, split, OCR, and conversion in one account if you upgrade — but the compressor stands alone for SEO users who only need size reduction.</p>
                <h2>Migration workflow</h2>
                <ol>
                <li>Bookmark {PdfToolSeo.Canonical(ToolPath)} on your phone and desktop.</li>
                <li>Run a side-by-side test: compress the same file in {competitor} and RatPDF.</li>
                <li>Compare file size <em>and</em> text legibility at 100% zoom.</li>
                </ol>
                <p>Return to the {HubLink()} for detailed comparison articles and size-specific guides.</p>
                """;
        }

        private static string BuildComparisonContent(CuratedPage page)
        {
            return $"""
                <p class="lead">This <strong>{page.PrimaryKeyword}</strong> guide helps you pick the right tool for daily document work — not marketing fluff, but practical differences in price, privacy, compression quality, and limits.</p>
                <h2>Quick comparison</h2>
                <table class="table table-striped">
                <thead><tr><th>Criteria</th><th>RatPDF</th><th>Competitor</th></tr></thead>
                <tbody>
                <tr><td>Free tier</td><td>3 compressions/day, 200 MB file</td><td>Varies; often 1–2 tasks/day</td></tr>
                <tr><td>Max file (paid)</td><td>4 GB Pro</td><td>Varies by plan</td></tr>
                <tr><td>Install required</td><td>No — browser only</td><td>Often desktop app for full features</td></tr>
                <tr><td>Engine</td><td>Ghostscript + iText</td><td>Proprietary / undisclosed</td></tr>
                <tr><td>Data retention</td><td>Auto-delete after download</td><td>Check their privacy policy</td></tr>
                </tbody>
                </table>
                <h2>When RatPDF wins</h2>
                <p>Quick one-off compressions on a shared computer, mobile uploads, strict KB portal targets, and users who want related tools (merge, OCR) under one login.</p>
                <h2>When the competitor may win</h2>
                <p>Teams already standardized on a vendor's cloud storage integration, or workflows needing certified PDF/A archival with audited compliance trails — evaluate enterprise plans separately.</p>
                <h2>Try both on your file</h2>
                <p>The honest test is your document. Use our {ToolLink()} now and compare bytes and readability. Return to the {HubLink()} for size-specific landing pages.</p>
                """;
        }

        private static string BuildSubmissionContent(CuratedPage page)
        {
            var parts = page.Slug.Split('-');
            var sizePart = parts.Length >= 3 ? parts[2] : "target";
            return $"""
                <p class="lead">Submission portals reject more applications for <strong>file size</strong> than for content errors. This page covers <strong>{page.PrimaryKeyword}</strong> with a checklist you can follow in under five minutes.</p>
                <h2>Portal requirements</h2>
                <p>Upload fields often show "Max {sizePart}" without explaining whether that is KB or MB. Right-click your PDF → Properties (Windows) or Get Info (Mac) to read exact byte size before uploading.</p>
                <h2>Preparation checklist</h2>
                <ol>
                <li>Scan at 150 DPI greyscale unless colour is mandatory.</li>
                <li>Crop empty margins in Preview or any image editor.</li>
                <li>Compress with RatPDF {ToolLink()} — start Recommended, then Extreme.</li>
                <li>Verify text remains readable at 100% zoom.</li>
                <li>Rename file per portal instructions (no spaces if forbidden).</li>
                </ol>
                <h2>If rejection persists</h2>
                <p>Split multi-page PDFs and upload only required pages. Some passport flows want one JPEG per photo — export with <a href="/PDF/PdfToImages">PDF to Images</a> if PDF is not accepted at all.</p>
                <h2>Related guides</h2>
                <p>See {HubLink()} for neighbouring size targets and use-case specific walkthroughs.</p>
                """;
        }

        private static string BuildLongTailContent(string keyword)
        {
            var tool = ToolLink();
            var sb = new StringBuilder();
            sb.Append($"""
                <p class="lead">If you need to <strong>{keyword}</strong>, RatPDF provides a fast, secure online workflow. PDF compression is essential when portals, email servers, or cloud drives enforce size limits — and doing it correctly preserves readability while shedding megabytes of waste.</p>
                <h2>What "{keyword}" means in practice</h2>
                <p>Users search "{keyword}" when they have a concrete problem: an upload button that refuses their file, an email that bounces back, or a phone that will not send a document. The solution is not simply "make smaller" — it is optimizing the right objects inside the PDF (usually embedded images) while leaving vector text untouched.</p>
                <h2>How to {keyword} with RatPDF</h2>
                <ol>
                <li>Open the {tool} — works on phone, tablet, and desktop browsers.</li>
                <li>Upload your PDF via drag-and-drop or file picker.</li>
                <li>Select compression level: Recommended for most documents, Extreme for scans.</li>
                <li>Wait for processing (large files run as background jobs with a progress bar).</li>
                <li>Download the optimized PDF and verify size locally before submitting.</li>
                </ol>
                <h2>Compression methods</h2>
                <h3>Stream recompression</h3>
                <p>PDF objects store text and images in compressed streams. Re-flating these streams removes redundancy without visible change — ideal for text-heavy files.</p>
                <h3>Image downsampling</h3>
                <p>Photo scans embed high-resolution JPEGs. Re-encoding at lower DPI dramatically cuts size. RatPDF uses Ghostscript profiles tuned for screen (/screen), ebook (/ebook), and printer (/printer) output.</p>
                <h3>Object cleanup</h3>
                <p>Duplicate fonts, unused XObjects, and stale metadata inflate files. Our pipeline strips cruft left by "Print to PDF" chains and design tool exports.</p>
                <h2>Use cases</h2>
                <ul>
                <li><strong>Students</strong> — assignment uploads with strict LMS caps</li>
                <li><strong>Job seekers</strong> — lean résumé PDFs for ATS parsing</li>
                <li><strong>Small businesses</strong> — invoices and proposals via email</li>
                <li><strong>Travelers</strong> — visa and passport supporting documents</li>
                <li><strong>Developers</strong> — documentation bundles for web hosting</li>
                </ul>
                <h2>Best practices</h2>
                <p>Always keep an uncompressed original archived. Compress a copy for distribution. If quality looks soft after Extreme mode, re-scan at lower DPI rather than compressing the same scan repeatedly — generation loss adds up.</p>
                <p>For password-protected PDFs you own, unlock first with our <a href="/PDF/UnlockPdf">Unlock PDF</a> tool. Combine with <a href="/PDF/Merge">Merge PDF</a> only after each segment is already optimized.</p>
                <h2>Online vs offline tools</h2>
                <p>Desktop apps like Acrobat offer offline compression but cost money and require updates. Online tools like RatPDF fit locked-down corporate laptops and mobile workflows. Files transfer over TLS and are deleted after processing — suitable for non-classified personal and business documents.</p>
                <h2>Related resources</h2>
                <p>Visit our {HubLink()} for curated guides on email, WhatsApp, passport uploads, and Adobe alternatives. Read the <a href="/guides/compress-pdf-guide">full compression guide</a> for engine details.</p>
                """);
            return sb.ToString();
        }

        // ── FAQ builders ──

        private static List<FaqItem> BuildSizeFaqs(CuratedPage page)
        {
            var size = ExtractSize(page.Slug);
            return
            [
                new() { Question = $"Can I {page.PrimaryKeyword} for free?", Answer = "Yes. RatPDF offers 3 free compressions per day on the free tier. Pro subscribers get unlimited daily use and 4 GB max file size." },
                new() { Question = $"Will compressing to {size} blur my text?", Answer = "Vector text stays sharp at all compression levels. Only embedded photos soften — use Recommended first and Extreme only if you still exceed the limit." },
                new() { Question = "What if my PDF is still too large?", Answer = $"Try Extreme compression, crop scanner margins, reduce scan DPI to 150, or split unnecessary pages with our Split PDF tool before compressing again." },
                new() { Question = "Is it safe to upload passport or bank documents?", Answer = "Files are transferred over HTTPS and deleted after download. Do not upload documents you are not authorized to process on a third-party server." },
                new() { Question = $"How long does it take to {page.PrimaryKeyword}?", Answer = "Most files under 10 MB finish in seconds. Larger files run as background jobs — keep the tab open until the download button appears." },
            ];
        }

        private static List<FaqItem> BuildUseCaseFaqs(CuratedPage page) =>
        [
            new() { Question = $"How do I {page.PrimaryKeyword}?", Answer = $"Open RatPDF's PDF Compressor, upload your file, choose Recommended compression, and download. Verify size before submitting to the portal." },
            new() { Question = "Which compression level should I use?", Answer = "Start with Recommended. Switch to Extreme for scanned documents or very strict size caps. Use Less for text-only contracts where quality is critical." },
            new() { Question = "Can I compress on my phone?", Answer = "Yes — RatPDF works in mobile browsers. See our device-specific guides for iPhone and Android tips." },
            new() { Question = "Do you add watermarks?", Answer = "No. Output PDFs are clean with no RatPDF branding embedded in the document." },
            new() { Question = "What is the maximum file size?", Answer = "Free users: 200 MB per file. Pro users: up to 4 GB per file." },
        ];

        private static List<FaqItem> BuildDeviceFaqs(CuratedPage page) =>
        [
            new() { Question = $"Do I need an app to {page.PrimaryKeyword}?", Answer = "No app required. Use Safari, Chrome, or Edge and visit ratpdf.com/pdf/compress directly." },
            new() { Question = "Does it work offline?", Answer = "Compression requires an internet connection because processing runs on secure servers. Download the result for offline use." },
            new() { Question = "Can I upload from Google Drive or iCloud?", Answer = "Download the PDF to your device first, then upload via the file picker. Direct cloud integration is not required." },
            new() { Question = "Will iOS pause my upload?", Answer = "Keep Safari in the foreground until processing completes. Large files on cellular may take longer — Wi-Fi is recommended." },
        ];

        private static List<FaqItem> BuildQualityFaqs(CuratedPage page) =>
        [
            new() { Question = $"How do I {page.PrimaryKeyword}?", Answer = "Use Recommended compression for balanced results. Less compression minimizes quality loss; Extreme maximizes size reduction for scans." },
            new() { Question = "Is lossless compression enough?", Answer = "Lossless helps text PDFs but rarely shrinks photo scans enough for 100 KB portal limits. Combine lossless cleanup with image downsampling when needed." },
            new() { Question = "What DPI should scans use?", Answer = "150 DPI greyscale for ID documents; 200–300 DPI for detailed drawings. Higher DPI increases size without helping on-screen review." },
            new() { Question = "Can I undo compression?", Answer = "Compression is one-way. Always archive your original file before distributing a compressed copy." },
        ];

        private static List<FaqItem> BuildCompetitorFaqs(CuratedPage page) =>
        [
            new() { Question = "Is RatPDF really free?", Answer = "Yes — 3 uses per tool per day on the free tier. Pro plans add unlimited use and larger file limits." },
            new() { Question = "How does compression quality compare?", Answer = "RatPDF uses Ghostscript, an industry-standard engine. Run the same file through both tools and compare size and legibility side by side." },
            new() { Question = "Do you store my files?", Answer = "Files are automatically deleted after you download the result. We do not sell or train on document content." },
            new() { Question = "Can I switch from my current tool?", Answer = "Yes — bookmark /pdf/compress and use the same workflow: upload, compress, download. No migration or account import needed." },
        ];

        private static List<FaqItem> BuildSubmissionFaqs(CuratedPage page) =>
        [
            new() { Question = $"What happens if my PDF exceeds the portal limit?", Answer = "The upload field typically shows an error and blocks submission. Compress before uploading to avoid losing form data." },
            new() { Question = "Should I use KB or MB settings?", Answer = "Portals specify their own units. Check exact byte size locally — 100 KB = 102,400 bytes, not 100,000." },
            new() { Question = "Can I compress the same file twice?", Answer = "Yes, but repeated lossy compression degrades images. Better to adjust DPI at the source than compress an already Extreme file again." },
            new() { Question = "Are colour scans required?", Answer = "Most ID portals accept greyscale if all data is visible. Colour doubles size — use it only when the portal explicitly requires colour." },
        ];

        private static List<FaqItem> BuildGenericFaqs(string keyword) =>
        [
            new() { Question = $"What is the best way to {keyword}?", Answer = "Use RatPDF's online PDF Compressor with Recommended settings first. Adjust to Extreme if you need more reduction." },
            new() { Question = $"Does {keyword} reduce quality?", Answer = "Moderate compression preserves readable text. Extreme mode softens embedded photos but keeps vector text sharp." },
            new() { Question = $"Can I {keyword} for free?", Answer = "Yes — free users get 3 compressions per day. No credit card required." },
            new() { Question = "Are uploads secure?", Answer = "All transfers use HTTPS/TLS. Files are deleted after download." },
            new() { Question = $"Why should I {keyword}?", Answer = "Smaller PDFs upload faster, pass portal limits, and cost less to store and email." },
        ];

        private static List<(string Name, string Text)> BuildHowToSteps(string keyword) =>
        [
            ("Open the PDF Compressor", "Navigate to ratpdf.com/pdf/compress in any modern browser."),
            ("Upload your PDF", "Drag and drop your file or click the upload zone. Password-protected PDFs are supported if you enter the password."),
            ("Select compression level", "Choose Recommended for balanced quality, Extreme for maximum size reduction, or Less for minimal quality impact."),
            ("Download the result", "Click download when processing completes. Verify file size locally before submitting to portals or email."),
        ];

        private static string ExtractSize(string slug)
        {
            if (slug.Contains("100kb", StringComparison.OrdinalIgnoreCase)) return "100 KB";
            if (slug.Contains("50kb", StringComparison.OrdinalIgnoreCase)) return "50 KB";
            if (slug.Contains("150kb", StringComparison.OrdinalIgnoreCase)) return "150 KB";
            if (slug.Contains("200kb", StringComparison.OrdinalIgnoreCase)) return "200 KB";
            if (slug.Contains("250kb", StringComparison.OrdinalIgnoreCase)) return "250 KB";
            if (slug.Contains("300kb", StringComparison.OrdinalIgnoreCase)) return "300 KB";
            if (slug.Contains("500kb", StringComparison.OrdinalIgnoreCase)) return "500 KB";
            if (slug.Contains("1mb", StringComparison.OrdinalIgnoreCase)) return "1 MB";
            if (slug.Contains("2mb", StringComparison.OrdinalIgnoreCase)) return "2 MB";
            if (slug.Contains("5mb", StringComparison.OrdinalIgnoreCase)) return "5 MB";
            if (slug.Contains("10mb", StringComparison.OrdinalIgnoreCase)) return "10 MB";
            return "your target size";
        }

        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        private static string Capitalize(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return char.ToUpperInvariant(text[0]) + text[1..];
        }
    }
}
