using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Data.Entities;
using ratpdf.Helpers;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Contract;
using ratpdf.Services.Invoice.Feature;
using System.Security.Claims;

namespace ratpdf.Controllers
{
    [Authorize]
    public class BrandingController : Controller
    {
        private readonly BrandingService _brandingService;
        private readonly ILogoStorageService _logoStorage;
        private readonly FeatureAccessor _featureAccessor;

        public BrandingController(
            BrandingService brandingService,
            ILogoStorageService logoStorage,
            FeatureAccessor featureAccessor)
        {
            _brandingService = brandingService;
            _logoStorage = logoStorage;
            _featureAccessor = featureAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return Challenge();
            if (!await _featureAccessor.CanUploadLogoAsync())
                return RedirectToAction("Plans", "Subscription");

            var branding = await _brandingService.GetBrandingAsync(userId.Value) ?? new BrandingSettings();
            return View(branding);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandingSettings model, IFormFile? logoFile, IFormFile? upiQrFile)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return Challenge();
            if (!await _featureAccessor.CanUploadLogoAsync())
                return Forbid();

            if (logoFile != null && logoFile.Length > 0)
            {
                // Validate file
                if (logoFile.Length > 1 * 1024 * 1024) // 1 MB limit
                {
                    ModelState.AddModelError("logoFile", "Logo must be less than 1 MB.");
                    return View(model);
                }
                var allowedTypes = new[] { "image/png", "image/jpeg" };
                if (!allowedTypes.Contains(logoFile.ContentType))
                {
                    ModelState.AddModelError("logoFile", "Only PNG and JPEG allowed.");
                    return View(model);
                }

                using var stream = logoFile.OpenReadStream();
                var logoUrl = await _logoStorage.UploadLogoAsync(userId.Value, stream, logoFile.FileName);
                model.LogoUrl = logoUrl;
            }
            if (upiQrFile != null && upiQrFile.Length > 0)
            {
                var allowedTypes = new[] { "image/png", "image/jpeg" };

                if (!allowedTypes.Contains(upiQrFile.ContentType))
                {
                    ModelState.AddModelError("upiQrFile", "Only PNG and JPEG allowed.");
                    return View(model);
                }

                using var stream = upiQrFile.OpenReadStream();

                var qrUrl = await _logoStorage.UploadLogoAsync(
                    userId.Value,
                    stream,
                    upiQrFile.FileName
                );

                model.UpiQrUrl = qrUrl;
            }
            if (ModelState.IsValid)
            {
                await _brandingService.SaveBrandingAsync(userId.Value, model);
                return RedirectToAction("Edit", new { saved = true });
            }

            return View(model);
        }

        private Guid? GetCurrentUserId()
            => Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var uid) ? uid : null;
    }
}
