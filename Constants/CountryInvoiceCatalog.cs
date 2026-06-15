using ratpdf.Models.Invoice;

namespace ratpdf.Constants
{
    public static class CountryInvoiceCatalog
    {
        public static CountryInvoiceLandingModel Usa => new()
        {
            CountryName = "United States",
            RoutePath = "/invoice/invoice-generator-usa",
            H1 = "Free Invoice Generator for the United States",
            Lead = "Create professional invoices, 1099-friendly bills, and PDF receipts online. Ideal for US freelancers, LLCs, agencies, and small businesses.",
            Badge = "Trusted by US Freelancers & Small Businesses",
            CurrencyCode = "USD",
            TaxLabel = "Sales tax",
            FeaturesSubtitle = "Built for US freelancers, contractors, and SMB billing workflows.",
            FeatureTitles =
            [
                "Sales Tax Line Items",
                "Instant PDF Download",
                "Business Branding",
                "Mobile Friendly",
                "Recurring-Ready Layout",
                "No Login Required",
            ],
            FeatureDescriptions =
            [
                "Add state or local sales tax as separate line items on each invoice.",
                "Download polished PDF invoices instantly for email or client portals.",
                "Add logo, EIN, payment terms, and wire/ACH instructions.",
                "Create invoices from desktop, tablet, or phone browsers.",
                "Reuse client details and line-item templates for repeat billing.",
                "Start invoicing immediately — upgrade only when you need Pro features.",
            ],
            Faqs =
            [
                ("What is an invoice generator in the USA?", "An online invoice generator helps US businesses create PDF bills with line items, tax, and payment terms without desktop software."),
                ("Can I add sales tax to invoices?", "Yes — add sales tax as line items or notes. Consult your accountant for state-specific rules."),
                ("Is the US invoice generator free?", "Yes — RatPDF offers free invoice creation with optional Pro features for high-volume users."),
            ],
            GeoRegion = "US",
            GeoCountry = "United States",
            OgLocale = "en_US",
            Keywords = "invoice generator USA, US invoice maker, free invoice generator United States, PDF invoice USA, freelancer invoice USA, small business invoice template",
        };

        public static CountryInvoiceLandingModel Australia => new()
        {
            CountryName = "Australia",
            RoutePath = "/invoice/invoice-generator-australia",
            H1 = "Free Invoice Generator for Australia",
            Lead = "Create GST-ready invoices and PDF bills for Australian freelancers and SMBs.",
            Badge = "Trusted by Australian Businesses",
            CurrencyCode = "AUD",
            TaxLabel = "GST",
            FeaturesSubtitle = "Designed for ABN holders and Australian tax invoicing.",
            FeatureTitles = ["GST Invoice Support", "Instant PDF Download", "Business Branding", "Mobile Friendly", "ABN Fields", "No Login Required"],
            FeatureDescriptions =
            [
                "Include GST amounts and ABN on compliant-style invoices.",
                "Download PDF invoices instantly.",
                "Add logo, ABN, and payment terms.",
                "Works on mobile and desktop browsers.",
                "Capture Australian Business Number on every bill.",
                "Free to start — Pro for unlimited volume.",
            ],
            Faqs =
            [
                ("Can I generate GST invoices in Australia?", "Yes — add GST line items and your ABN on each invoice PDF."),
                ("Is it free?", "Yes — RatPDF offers free Australian invoice generation online."),
                ("Can I download PDF invoices?", "Yes — every invoice exports as a professional PDF."),
            ],
            GeoRegion = "AU",
            GeoCountry = "Australia",
            OgLocale = "en_AU",
            Keywords = "invoice generator Australia, GST invoice Australia, free invoice maker AU",
        };

        public static CountryInvoiceLandingModel Canada => new()
        {
            CountryName = "Canada",
            RoutePath = "/invoice/invoice-generator-canada",
            H1 = "Free Invoice Generator for Canada",
            Lead = "Create HST/GST-ready invoices and PDF bills for Canadian freelancers and businesses.",
            Badge = "Trusted by Canadian Businesses",
            CurrencyCode = "CAD",
            TaxLabel = "HST/GST",
            FeaturesSubtitle = "Built for Canadian provincial tax and bilingual-ready layouts.",
            FeatureTitles = ["HST/GST Support", "Instant PDF Download", "Business Branding", "Mobile Friendly", "BN Fields", "No Login Required"],
            FeatureDescriptions =
            [
                "Add HST, GST, or PST as line items on invoices.",
                "Download PDF invoices instantly.",
                "Add logo, business number, and payment terms.",
                "Invoice from any device with a browser.",
                "Capture business number fields for CRA records.",
                "Free tier available with optional Pro upgrade.",
            ],
            Faqs =
            [
                ("Can I create GST/HST invoices in Canada?", "Yes — add tax line items appropriate for your province."),
                ("Is the invoice generator free?", "Yes — create and download PDF invoices for free."),
                ("Does it support PDF export?", "Yes — every invoice downloads as PDF."),
            ],
            GeoRegion = "CA",
            GeoCountry = "Canada",
            OgLocale = "en_CA",
            Keywords = "invoice generator Canada, HST invoice Canada, free invoice maker CAD",
        };
    }
}
