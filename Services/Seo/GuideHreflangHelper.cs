using ratpdf.Constants;
using ratpdf.Content;
using ratpdf.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ratpdf.Services.Seo
{
    public static class GuideHreflangHelper
    {
        public static void ApplyToViewData(ViewDataDictionary viewData, string slug, string? activeHreflang = null)
        {
            var alternates = LocalizedGuideStore.GetHreflangAlternates(slug);
            if (alternates.Count <= 2)
                return;

            viewData["HreflangAlternates"] = alternates;
            if (!string.IsNullOrWhiteSpace(activeHreflang))
                viewData["OgLocale"] = activeHreflang.Replace('-', '_');
        }

        public static IReadOnlyList<(string Path, IReadOnlyList<HreflangAlternate> Alternates)> BuildGuideLocaleEntries(
            string? localeUrlPrefix)
        {
            var entries = new List<(string Path, IReadOnlyList<HreflangAlternate> Alternates)>();

            foreach (var guide in ContentLibrary.Guides.OrderBy(g => g.Slug, StringComparer.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(localeUrlPrefix))
                {
                    if (!LocalizedGuideStore.Exists(localeUrlPrefix, guide.Slug))
                        continue;
                }

                var path = string.IsNullOrEmpty(localeUrlPrefix)
                    ? GuideLocales.EnglishGuidePath(guide.Slug)
                    : GuideLocales.LocalizedGuidePath(localeUrlPrefix, guide.Slug);

                entries.Add((path, LocalizedGuideStore.GetHreflangAlternates(guide.Slug)));
            }

            return entries;
        }
    }
}
