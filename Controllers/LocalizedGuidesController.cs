using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Content;
using ratpdf.Models;
using ratpdf.Services;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    [Route("{locale:regex(^(pt|es|de|id|fr)$)}/guides")]
    public class LocalizedGuidesController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index(string locale)
        {
            var guideLocale = GuideLocales.FromUrlPrefix(locale);
            if (guideLocale == null)
                return NotFound();

            var guides = LocalizedGuideStore.AllForLocale(guideLocale.UrlPrefix).ToList();
            if (guides.Count == 0)
                return NotFound();

            ViewData["Title"] = LocalizedHubTitle(guideLocale);
            ViewData["Description"] = LocalizedHubDescription(guideLocale);
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical($"/{guideLocale.UrlPrefix}/guides");
            ViewData["OgLocale"] = guideLocale.Hreflang.Replace('-', '_');
            ViewData["ContentLocale"] = guideLocale.UrlPrefix;
            ViewData["GuidesHubPath"] = $"/{guideLocale.UrlPrefix}/guides";

            return View("~/Views/Guides/Index.cshtml", guides.Select(g => g.ToContentEntry()).ToList());
        }

        [HttpGet("{slug}")]
        public IActionResult Article(string locale, string slug)
        {
            var guideLocale = GuideLocales.FromUrlPrefix(locale);
            if (guideLocale == null)
                return NotFound();

            var entry = LocalizedGuideStore.Get(guideLocale.UrlPrefix, slug);
            if (entry == null)
                return NotFound();

            var model = entry.ToContentEntry();
            ViewData["Title"] = entry.Title;
            ViewData["Description"] = entry.Description;
            ViewData["Keywords"] = entry.PrimaryKeyword;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.Path);
            ViewData["ContentLocale"] = guideLocale.UrlPrefix;
            ViewData["GuidesHubPath"] = $"/{guideLocale.UrlPrefix}/guides";
            GuideHreflangHelper.ApplyToViewData(ViewData, entry.SourceSlug, guideLocale.Hreflang);

            return View("~/Views/Guides/Article.cshtml", model);
        }

        private static string LocalizedHubTitle(GuideLocale locale) => locale.UrlPrefix switch
        {
            "pt" => "Guias de PDF e Documentos — Tutoriais Grátis | RatPDF",
            "es" => "Guías de PDF y Documentos — Tutoriales Gratis | RatPDF",
            "de" => "PDF- & Dokumenten-Guides — Kostenlose Tutorials | RatPDF",
            "id" => "Panduan PDF & Dokumen — Tutorial Gratis | RatPDF",
            "fr" => "Guides PDF et Documents — Tutoriels Gratuits | RatPDF",
            _ => "PDF & Document Guides | RatPDF",
        };

        private static string LocalizedHubDescription(GuideLocale locale) => locale.UrlPrefix switch
        {
            "pt" => "Guias passo a passo para todas as ferramentas RatPDF: comprimir, mesclar, converter PDF para Word/Excel, faturas, OCR e muito mais.",
            "es" => "Guías paso a paso para todas las herramientas RatPDF: comprimir, unir, convertir PDF a Word/Excel, facturas, OCR y más.",
            "de" => "Schritt-für-Schritt-Anleitungen für alle RatPDF-Tools: komprimieren, zusammenführen, PDF in Word/Excel konvertieren, Rechnungen, OCR und mehr.",
            "id" => "Panduan langkah demi langkah untuk semua alat RatPDF: kompres, gabung, konversi PDF ke Word/Excel, faktur, OCR, dan lainnya.",
            "fr" => "Guides pas à pas pour tous les outils RatPDF : compresser, fusionner, convertir PDF en Word/Excel, factures, OCR et plus.",
            _ => $"{PdfToolSeo.ToolCountLabel} step-by-step guides for every RatPDF tool.",
        };
    }
}
