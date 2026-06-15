using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ratpdf.Helpers
{
    /// <summary>Converts URL slugs and keyword phrases into readable display titles with preserved acronyms.</summary>
    public static class SlugTitleHelper
    {
        private static readonly Dictionary<string, string> TokenMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["bmi"] = "BMI",
            ["egfr"] = "eGFR",
            ["gcs"] = "GCS",
            ["map"] = "MAP",
            ["nihss"] = "NIHSS",
            ["ocr"] = "OCR",
            ["pdf"] = "PDF",
            ["pdfs"] = "PDFs",
            ["gst"] = "GST",
            ["vat"] = "VAT",
            ["dvt"] = "DVT",
            ["pe"] = "PE",
            ["ckd"] = "CKD",
            ["af"] = "AF",
            ["mace"] = "MACE",
            ["hmrc"] = "HMRC",
            ["html"] = "HTML",
            ["json"] = "JSON",
            ["jwt"] = "JWT",
            ["dns"] = "DNS",
            ["ip"] = "IP",
            ["url"] = "URL",
            ["docx"] = "DOCX",
            ["xlsx"] = "XLSX",
            ["pptx"] = "PPTX",
            ["png"] = "PNG",
            ["jpg"] = "JPG",
            ["jpeg"] = "JPEG",
            ["webp"] = "WEBP",
            ["heart"] = "HEART",
            ["cha2ds2"] = "CHA₂DS₂",
            ["vasc"] = "VASc",
            ["wells"] = "Wells",
            ["mdrd"] = "MDRD",
            ["ckdepi"] = "CKD-EPI",
            ["ed"] = "ED",
            ["acs"] = "ACS",
            ["emi"] = "EMI",
            ["uk"] = "UK",
            ["usa"] = "USA",
            ["api"] = "API",
            ["txt"] = "TXT",
            ["zip"] = "ZIP",
        };

        private static readonly HashSet<string> LowercaseWords = new(StringComparer.OrdinalIgnoreCase)
        {
            "a", "an", "the", "and", "or", "for", "to", "in", "on", "of", "with", "from", "by", "at", "vs", "versus",
        };

        private static readonly Regex SlugSplit = new(@"[-_\s]+", RegexOptions.Compiled);
        private static readonly Regex SizeSuffix = new(@"^(\d+)(kb|mb|gb)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static string FromSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return string.Empty;
            return FromPhrase(SlugSplit.Replace(slug.Trim(), " "));
        }

        public static string FromPhrase(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) return string.Empty;

            var tokens = SlugSplit.Split(NormalizeUnicode(phrase.Trim()))
                .Where(t => t.Length > 0)
                .ToList();

            if (tokens.Count == 0) return string.Empty;

            var sb = new StringBuilder();
            for (var i = 0; i < tokens.Count; i++)
            {
                if (i > 0) sb.Append(' ');
                sb.Append(FormatToken(tokens[i], i == 0 || IsAlwaysCapitalized(tokens, i)));
            }

            return FixKnownPhrases(sb.ToString());
        }

        private static string NormalizeUnicode(string input) =>
            input.Replace('₂', '2').Replace('–', '-').Replace('—', '-');

        private static bool IsAlwaysCapitalized(IReadOnlyList<string> tokens, int index)
        {
            if (index == 0) return true;
            var prev = tokens[index - 1];
            return prev.Equals("vs", StringComparison.OrdinalIgnoreCase)
                || prev.Equals("versus", StringComparison.OrdinalIgnoreCase);
        }

        private static string FormatToken(string token, bool forceCapitalize)
        {
            var sizeMatch = SizeSuffix.Match(token);
            if (sizeMatch.Success)
                return sizeMatch.Groups[1].Value + sizeMatch.Groups[2].Value.ToUpperInvariant();

            if (TokenMap.TryGetValue(token, out var mapped))
                return mapped;

            if (!forceCapitalize && LowercaseWords.Contains(token))
                return token.ToLowerInvariant();

            if (token.All(char.IsDigit))
                return token;

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(token.ToLowerInvariant());
        }

        private static string FixKnownPhrases(string title)
        {
            return title
                .Replace("Cha₂ds₂ Vasc", "CHA₂DS₂-VASc", StringComparison.OrdinalIgnoreCase)
                .Replace("Cha2ds2 Vasc", "CHA₂DS₂-VASc", StringComparison.OrdinalIgnoreCase)
                .Replace("Cha₂ds₂-Vasc", "CHA₂DS₂-VASc", StringComparison.OrdinalIgnoreCase)
                .Replace("Heart Score", "HEART Score", StringComparison.OrdinalIgnoreCase)
                .Replace("Wells Score", "Wells Score", StringComparison.Ordinal)
                .Replace("Ckd-Epi", "CKD-EPI", StringComparison.OrdinalIgnoreCase)
                .Replace("Ckd Epi", "CKD-EPI", StringComparison.OrdinalIgnoreCase);
        }
    }
}
