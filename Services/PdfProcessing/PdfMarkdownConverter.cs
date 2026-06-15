using System.Text;
using System.Text.RegularExpressions;

namespace ratpdf.Services.PdfProcessing
{
    public static partial class PdfMarkdownConverter
    {
        public static string FromExtractedText(string text, string? title = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# {title ?? "PDF Export"}");
            sb.AppendLine();

            var parts = PageSplit().Split(text);
            if (parts.Length <= 1)
            {
                sb.AppendLine(NormalizeBlock(text));
                return sb.ToString().TrimEnd() + Environment.NewLine;
            }

            for (var i = 1; i < parts.Length; i += 2)
            {
                if (i + 1 >= parts.Length) break;
                var pageNum = parts[i].Trim();
                var body = parts[i + 1].Trim();
                if (string.IsNullOrWhiteSpace(body)) continue;
                sb.AppendLine($"## Page {pageNum}");
                sb.AppendLine();
                sb.AppendLine(NormalizeBlock(body));
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd() + Environment.NewLine;
        }

        private static string NormalizeBlock(string block)
        {
            var lines = block.Split('\n')
                .Select(l => l.TrimEnd())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            if (lines.Count == 0) return string.Empty;

            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (trimmed.Length < 80 && trimmed == trimmed.ToUpperInvariant() && trimmed.Any(char.IsLetter))
                    sb.AppendLine($"### {trimmed}");
                else
                    sb.AppendLine(trimmed);
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }

        [GeneratedRegex(@"--- Page (\d+) ---", RegexOptions.Multiline)]
        private static partial Regex PageSplit();
    }
}
