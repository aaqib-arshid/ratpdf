using ratpdf.Services;

namespace ratpdf.Routing
{
    /// <summary>Route constraint so compress SEO slugs do not collide with WordCounter catch-all routes.</summary>
    public class CompressSeoSlugConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var raw) || raw is not string slug)
                return false;

            return PdfCompressProgrammaticSeoGenerator.IsKnownSlug(slug);
        }
    }
}
