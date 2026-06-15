using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    public static class IntentClassifier
    {
        public const double MinIndexConfidence = 0.55;
        public const double MinSitemapConfidence = 0.55;

        private static readonly string[] CompetitorTokens =
        [
            "adobe", "acrobat", "ilovepdf", "smallpdf", "pdfescape", "sejda", "foxit",
            "nitro", "pdfelement", "wondershare", "pdf24", "sodapdf",
        ];

        private static readonly string[] GlobalInvalidTokens =
        [
            "pycryptodome", "rv-kbb", "kbb-value", "rv-values-kbb", "motorhome",
            "apk-mod", "pirate", "torrent", "cracked", "keygen",
        ];

        private static readonly string[] DeviceTokens =
        [
            "iphone", "ipad", "android", "mac", "macos", "windows", "linux", "chromebook", "mobile",
        ];

        private static readonly Dictionary<string, string> DeviceLabels = new(StringComparer.OrdinalIgnoreCase)
        {
            ["iphone"] = "iPhone", ["ipad"] = "iPad", ["android"] = "Android",
            ["mac"] = "Mac", ["macos"] = "Mac", ["windows"] = "Windows",
            ["linux"] = "Linux", ["chromebook"] = "Chromebook", ["mobile"] = "Mobile",
        };

        private static readonly string[] ErrorRecoveryTokens =
        [
            "failed", "error", "cannot", "can't", "won't", "corrupt", "password-protected",
            "encrypted", "blank", "empty", "garbled", "unreadable", "not-working",
        ];

        public static IntentClassification Classify(PdfToolVertical vertical, string slug, string? keywordPhrase = null) =>
            vertical switch
            {
                PdfToolVertical.PdfToText => ClassifyPdfToText(slug, keywordPhrase),
                PdfToolVertical.PdfToWord => ClassifyPdfToWord(slug, keywordPhrase),
                PdfToolVertical.EditPdf => ClassifyEditPdf(slug, keywordPhrase),
                PdfToolVertical.CompressPdf => ClassifyCompress(slug, keywordPhrase),
                _ => new IntentClassification(SearchIntent.Invalid, 0, vertical),
            };

        public static IndexDisposition GetDisposition(IntentClassification c) =>
            c.Intent == SearchIntent.Invalid
                ? IndexDisposition.NotFound
                : c.Confidence < MinIndexConfidence || c.HasCompetitorNoise
                    ? IndexDisposition.NoIndex
                    : IndexDisposition.Index;

        public static bool IsSitemapEligible(IntentClassification c) =>
            c.Intent != SearchIntent.Invalid
            && c.Confidence >= MinSitemapConfidence
            && !c.HasCompetitorNoise;

        private static IntentClassification ClassifyPdfToText(string slug, string? keywordPhrase)
        {
            var vertical = PdfToolVertical.PdfToText;
            var text = Normalize(slug, keywordPhrase);

            if (ContainsAny(text, "pycryptodome", "convert-hyp-to", "convert-mht-to", "img-to-pdf", "hyp-to-pdf"))
                return Invalid(vertical, 1.0);
            if (ContainsAny(text, "text-message", "via-text", "attach-pdf-to", "pdf-text-to-speech"))
                return Invalid(vertical, 0.92);

            return ClassifyCore(vertical, text, ["pdf", "text", "txt", "extract", "ocr", "scanned", "scan", "plain", "convert"]);
        }

        private static IntentClassification ClassifyPdfToWord(string slug, string? keywordPhrase)
        {
            var vertical = PdfToolVertical.PdfToWord;
            var text = Normalize(slug, keywordPhrase);
            if (IsGloballyInvalid(text)) return Invalid(vertical, 1.0);

            return ClassifyCore(vertical, text,
                ["pdf", "word", "doc", "docx", "convert", "document", "office"],
                taskExtra: ["docx", "word", "convert"]);
        }

        private static IntentClassification ClassifyEditPdf(string slug, string? keywordPhrase)
        {
            var vertical = PdfToolVertical.EditPdf;
            var text = Normalize(slug, keywordPhrase);
            if (IsGloballyInvalid(text)) return Invalid(vertical, 1.0);
            if (text.Contains("amazon-fire") || text.Contains("apk-mod")) return Invalid(vertical, 0.9);

            return ClassifyCore(vertical, text,
                ["pdf", "edit", "editor", "annotate", "signature", "sign", "form", "fill", "modify", "change"],
                taskExtra: ["edit", "add", "fill", "sign", "annotate", "change"]);
        }

        private static IntentClassification ClassifyCompress(string slug, string? keywordPhrase)
        {
            var vertical = PdfToolVertical.CompressPdf;
            var text = Normalize(slug, keywordPhrase);
            if (IsGloballyInvalid(text)) return Invalid(vertical, 1.0);
            if (ContainsAny(text, "pdf-to-word", "pdf-to-ppt", "html-to-pdf", "word-to-pdf", "invoice-generator", "bmi-calculator"))
                return Invalid(vertical, 0.95);

            return ClassifyCore(vertical, text,
                ["pdf", "compress", "shrink", "reduce", "size", "kb", "mb", "smaller", "optimize", "compression"],
                taskExtra: ["compress", "shrink", "reduce", "optimize"]);
        }

        private static IntentClassification ClassifyCore(
            PdfToolVertical vertical,
            string text,
            string[] relevanceTokens,
            string[]? taskExtra = null)
        {
            if (IsGloballyInvalid(text)) return Invalid(vertical, 1.0);

            var hasCompetitor = CompetitorTokens.Any(t => text.Contains(t, StringComparison.Ordinal));
            var relevance = ScoreRelevance(text, relevanceTokens);
            if (relevance <= 0)
                return new IntentClassification(SearchIntent.Invalid, 0.88, vertical, HasCompetitorNoise: hasCompetitor);

            var device = DetectDevice(text);
            if (device != null)
            {
                var conf = 0.72 + relevance * 0.2 - (hasCompetitor ? 0.25 : 0);
                return new IntentClassification(SearchIntent.DeviceBased, conf, vertical, device, hasCompetitor);
            }

            if (ErrorRecoveryTokens.Any(t => text.Contains(t, StringComparison.Ordinal)))
            {
                var conf = 0.68 + relevance * 0.22;
                return new IntentClassification(SearchIntent.ErrorRecovery, conf, vertical, HasCompetitorNoise: hasCompetitor);
            }

            var taskTokens = new[] { "how-to", "how-do", "how to", "how do", "extract", "convert", "copy" }
                .Concat(taskExtra ?? []).ToArray();
            if (taskTokens.Any(t => text.Contains(t, StringComparison.Ordinal))
                || text.Contains("scanned") || text.Contains("ocr"))
            {
                var conf = 0.70 + relevance * 0.25 - (hasCompetitor ? 0.2 : 0);
                return new IntentClassification(SearchIntent.TaskBased, conf, vertical, HasCompetitorNoise: hasCompetitor);
            }

            if (text.Contains("online") || text.Contains("free") || text.Contains("tool") || text.Contains("converter"))
            {
                var conf = 0.74 + relevance * 0.2 - (hasCompetitor ? 0.22 : 0);
                return new IntentClassification(SearchIntent.Navigational, conf, vertical, HasCompetitorNoise: hasCompetitor);
            }

            var residual = 0.42 + relevance * 0.35 - (hasCompetitor ? 0.15 : 0);
            var intent = residual >= MinIndexConfidence ? SearchIntent.Navigational : SearchIntent.TaskBased;
            return new IntentClassification(intent, residual, vertical, HasCompetitorNoise: hasCompetitor);
        }

        private static string Normalize(string slug, string? phrase) => $"{slug} {phrase}".ToLowerInvariant();

        private static bool IsGloballyInvalid(string text) =>
            GlobalInvalidTokens.Any(t => text.Contains(t, StringComparison.Ordinal));

        private static bool ContainsAny(string text, params string[] tokens) =>
            tokens.Any(t => text.Contains(t, StringComparison.Ordinal));

        private static IntentClassification Invalid(PdfToolVertical v, double conf) =>
            new(SearchIntent.Invalid, conf, v);

        private static string? DetectDevice(string text)
        {
            foreach (var token in DeviceTokens)
            {
                if (text.Contains(token, StringComparison.Ordinal))
                    return DeviceLabels.GetValueOrDefault(token, token);
            }
            return null;
        }

        private static double ScoreRelevance(string text, string[] tokens)
        {
            var hits = tokens.Count(t => text.Contains(t, StringComparison.Ordinal));
            if (hits == 0) return 0;
            if (hits >= 3) return 1.0;
            if (hits == 2) return 0.75;
            return 0.5;
        }
    }
}
