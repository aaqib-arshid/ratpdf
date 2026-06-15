using ratpdf.Constants;

namespace ratpdf.Middleware
{
    /// <summary>Returns 410 Gone for removed medical calculator routes (YMYL de-index).</summary>
    public sealed class MedicalToolsRemovalMiddleware
    {
        private readonly RequestDelegate _next;

        public MedicalToolsRemovalMiddleware(RequestDelegate next) => _next = next;

        public Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? "/";
            if (MedicalToolsRemoval.IsRemovedPath(path))
            {
                context.Response.StatusCode = StatusCodes.Status410Gone;
                context.Response.Headers["X-Robots-Tag"] = "noindex, nofollow";
                return context.Response.WriteAsync("This page has been removed.");
            }

            return _next(context);
        }
    }
}
