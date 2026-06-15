using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    /// <summary>Legacy /about/team URLs → canonical /authors profiles.</summary>
    [Route("about/team")]
    public class AboutTeamController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() =>
            RedirectPermanent(PdfToolSeo.Canonical(SiteAuthors.HubPath));

        [HttpGet("{slug}")]
        public IActionResult Profile(string slug) =>
            RedirectPermanent(PdfToolSeo.Canonical($"{SiteAuthors.HubPath}/{slug}"));
    }
}
