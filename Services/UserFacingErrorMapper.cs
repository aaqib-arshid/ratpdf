using System.Text.RegularExpressions;

namespace ratpdf.Services;

/// <summary>Maps exceptions and raw messages to safe, user-facing text. Log full details server-side only.</summary>
public static class UserFacingErrorMapper
{
    public const string Generic = "Something went wrong. Please try again.";
    public const string ProcessingFailed = "We couldn't process your file. Please check the file and try again.";
    public const string Timeout = "Processing took too long. Try a smaller file or try again later.";
    public const string WrongPassword = "Incorrect PDF password. Please check the password and try again.";
    public const string PaymentFailed = "We couldn't start your subscription. Please try again or contact support.";
    public const string UploadFailed = "Upload failed. Please check your file and try again.";
    public const string PdfUnreadable = "This PDF couldn't be opened. It may be corrupted or password-protected.";
    public const string ImageConversionFailed = "We couldn't convert this image. Please try a JPG or PNG under 5 MB.";
    public const string ServiceUnavailable = "This tool is temporarily unavailable. Please try again in a few minutes.";

    private static readonly string[] SafePrefixes =
    [
        "Please ", "Maximum ", "No ", "Only ", "Empty ", "Invalid ", "Incorrect ", "Daily ",
        "Each file", "Select ", "Job not ", "Session expired", "Watermark ", "Password ",
        "Free daily", "Subscribe", "You can upload",
    ];

    private static readonly Regex TechnicalPattern = new(
        @"([A-Za-z]:\\|/home/|/var/|Pdf-Engine|wwwroot|\\Users\\|miniforge|blob\.core|Traceback|ModuleNotFoundError|FileNotFoundException|InvalidOperationException|at System\.|at Microsoft\.|stderr|Script not found|\.cs:line|\bException\b|Ghostscript not found|working directory not found)",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static string FromException(Exception ex)
    {
        if (ex is UnauthorizedAccessException)
            return WrongPassword;
        if (ex is OperationCanceledException or TimeoutException)
            return Timeout;
        if (ex is ArgumentException arg && IsUserSafe(arg.Message))
            return arg.Message;

        return Sanitize(ex.Message);
    }

    public static string Sanitize(string? message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return Generic;

        var trimmed = message.Trim();
        if (IsUserSafe(trimmed))
            return trimmed;

        return MapByKeywords(trimmed);
    }

    /// <summary>Extract a safe message from Python stderr output.</summary>
    public static string FromPythonStderr(string? stderr, string context = "processing")
    {
        if (string.IsNullOrWhiteSpace(stderr))
            return $"PDF {context} failed. Please try again.";

        var lines = stderr.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var errorLine = lines.LastOrDefault(l =>
            l.StartsWith("ERROR:", StringComparison.OrdinalIgnoreCase));
        if (errorLine != null)
        {
            var msg = errorLine["ERROR:".Length..].Trim();
            return IsUserSafe(msg) ? msg : MapByKeywords(msg);
        }

        var candidate = string.Join(" ", lines.TakeLast(4));
        return MapByKeywords(candidate);
    }

    private static bool IsUserSafe(string msg)
    {
        if (msg.Length > 280)
            return false;
        if (TechnicalPattern.IsMatch(msg))
            return false;
        if (SafePrefixes.Any(p => msg.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
            return true;
        if (msg.Contains("password", StringComparison.OrdinalIgnoreCase) && msg.Length < 140)
            return true;
        if (msg.Contains("limit", StringComparison.OrdinalIgnoreCase) && msg.Length < 140)
            return true;
        if (msg.Contains("subscribe", StringComparison.OrdinalIgnoreCase))
            return true;
        if (msg.Equals(WrongPassword, StringComparison.OrdinalIgnoreCase)
            || msg.Equals("Incorrect PDF password.", StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

    private static string MapByKeywords(string msg)
    {
        var lower = msg.ToLowerInvariant();

        if (lower.Contains("password") || lower.Contains("encrypted") || lower.Contains("decrypt"))
            return WrongPassword;
        if (lower.Contains("timeout") || lower.Contains("timed out") || lower.Contains("canceled"))
            return Timeout;
        if (lower.Contains("corrupt") || lower.Contains("invalid pdf") || lower.Contains("not a pdf")
            || lower.Contains("could not open"))
            return PdfUnreadable;
        if (lower.Contains("ocr") || lower.Contains("tesseract"))
            return "OCR couldn't read this document. Try a clearer scan at 300 DPI.";
        if (lower.Contains("ghostscript") || lower.Contains("compress"))
            return "PDF compression failed. Try a different file or compression level.";
        if (lower.Contains("merge") || lower.Contains("split") || lower.Contains("watermark")
            || lower.Contains("flatten") || lower.Contains("extract") || lower.Contains("metadata"))
            return ProcessingFailed;

        return ProcessingFailed;
    }
}
