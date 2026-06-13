using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Content;
using ratpdf.Models;

namespace ratpdf.Controllers
{
    [Route("authors")]
    public class AuthorsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Editorial Team — PDF & Document Experts | RatPDF";
            ViewData["Description"] = "Meet the RatPDF editorial team: PDF conversion specialists, business document editors, and security reviewers who write and fact-check our guides.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(SiteAuthors.HubPath);
            return View(SiteAuthors.All);
        }

        [HttpGet("{slug}")]
        public IActionResult Profile(string slug)
        {
            var author = SiteAuthors.Get(slug);
            if (author == null) return NotFound();

            var articles = SiteAuthors.FilterByAuthor(ContentLibrary.All, slug)
                .OrderByDescending(a => a.LastReviewed ?? a.Published)
                .ToList();

            ViewData["Title"] = $"{author.Name} — {author.JobTitle} | RatPDF";
            ViewData["Description"] = author.Bio;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical($"{SiteAuthors.HubPath}/{slug}");

            return View(new AuthorProfilePageModel { Author = author, Articles = articles });
        }
    }
}
