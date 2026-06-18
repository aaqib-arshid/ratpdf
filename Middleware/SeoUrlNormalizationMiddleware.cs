using System.Text.RegularExpressions;

namespace ratpdf.Middleware
{
    /// <summary>301 redirects for duplicate URLs, lowercase paths, and trailing-slash normalization.</summary>
    public sealed class SeoUrlNormalizationMiddleware
    {
        private static readonly HashSet<string> SkipPrefixes = new(StringComparer.OrdinalIgnoreCase)
        {
            "/invoicedashboard/", "/error/",
        };

        private static readonly Dictionary<string, string> PermanentRedirects =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["/PDF/Compress"] = "/pdf/compress",
                ["/PDF/UnlockPdf"] = "/pdf/unlockpdf",
                ["/PDF/SignText"] = "/pdf/signtext",
                ["/PDF/Watermark"] = "/pdf/watermark",
                ["/pdf/compress/"] = "/pdf/compress",
                ["/compress-pdf/"] = "/compress-pdf",
                ["/Account/Login"] = "/account/login",
                ["/Account/Register"] = "/account/register",
                ["/Subscription/Plans"] = "/subscription/plans",
                ["/Invoice/Create"] = "/invoice/create",
                ["/Home/About"] = "/home/about",
            };

        private static readonly Regex MultiSlash = new(@"/{2,}", RegexOptions.Compiled);

        private readonly RequestDelegate _next;

        public SeoUrlNormalizationMiddleware(RequestDelegate next) => _next = next;

        public Task InvokeAsync(HttpContext context)
        {
            if (!HttpMethods.IsGet(context.Request.Method) && !HttpMethods.IsHead(context.Request.Method))
                return _next(context);

            var path = context.Request.Path.Value ?? "/";

            if (path.StartsWith("/sitemap", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/sitemaps/", StringComparison.OrdinalIgnoreCase)
                || path.Equals("/robots.txt", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/lib/", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/css/", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/js/", StringComparison.OrdinalIgnoreCase)
                || path.StartsWith("/images/", StringComparison.OrdinalIgnoreCase)
                || path.Contains('.'))
            {
                return _next(context);
            }

            if (SkipPrefixes.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
                return _next(context);

            var normalized = MultiSlash.Replace(path, "/");
            if (normalized.Length > 1 && normalized.EndsWith('/'))
                normalized = normalized.TrimEnd('/');

            if ((PermanentRedirects.TryGetValue(path, out var target)
                 || PermanentRedirects.TryGetValue(normalized, out target))
                && !string.Equals(normalized, target, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectPermanent(context, target!);
            }

            var lower = normalized.ToLowerInvariant();
            if (!string.Equals(normalized, lower, StringComparison.Ordinal))
            {
                var qs = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";
                return RedirectPermanent(context, lower + qs);
            }

            if (!string.Equals(path, normalized, StringComparison.Ordinal))
            {
                var qs = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";
                return RedirectPermanent(context, normalized + qs);
            }

            return _next(context);
        }

        private static Task RedirectPermanent(HttpContext context, string location)
        {
            context.Response.StatusCode = StatusCodes.Status301MovedPermanently;
            context.Response.Headers.Location = location;
            return Task.CompletedTask;
        }
    }
}
