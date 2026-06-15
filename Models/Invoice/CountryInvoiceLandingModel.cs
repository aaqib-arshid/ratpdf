namespace ratpdf.Models.Invoice
{
    public sealed class CountryInvoiceLandingModel
    {
        public required string CountryName { get; init; }
        public required string RoutePath { get; init; }
        public required string H1 { get; init; }
        public required string Lead { get; init; }
        public required string Badge { get; init; }
        public required string CurrencyCode { get; init; }
        public required string TaxLabel { get; init; }
        public required string FeaturesSubtitle { get; init; }
        public required string[] FeatureTitles { get; init; }
        public required string[] FeatureDescriptions { get; init; }
        public required (string Question, string Answer)[] Faqs { get; init; }
        public string? GeoRegion { get; init; }
        public string? GeoCountry { get; init; }
        public string? OgLocale { get; init; }
        public string? Keywords { get; init; }
    }
}
