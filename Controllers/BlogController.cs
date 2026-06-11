using Microsoft.AspNetCore.Mvc;
using ratpdf.Content;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewData["Title"] = "RatPDF Blog — PDF Tips, Business Workflows & Security";
            ViewData["Description"] = "Practical articles on PDF compression, conversion, invoicing, and document security for freelancers and small businesses.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/blog");
            return View(ContentLibrary.Blogs.OrderByDescending(b => b.Published).ToList());
        }

        [HttpGet("{slug}")]
        public IActionResult Article(string slug)
        {
            var entry = ContentLibrary.GetBlog(slug);
            if (entry == null) return NotFound();
            ViewData["Title"] = entry.Title;
            ViewData["Description"] = entry.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.Path);
            return View(entry);
        }
    }
}
