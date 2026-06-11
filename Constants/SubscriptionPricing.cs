namespace ratpdf.Constants
{
    /// <summary>
    /// UI displays USD. Razorpay backend still charges INR (Pro 699, Business 2999).
    /// </summary>
    public static class SubscriptionPricing
    {
        public const string DisplayCurrencyCode = "USD";
        public const string DisplayCurrencySymbol = "$";

        public const decimal ProMonthlyUsd = 8.99m;
        public const decimal BusinessMonthlyUsd = 35.99m;

        // Backend charge (Razorpay only — not shown on UI)
        public const string ChargeCurrencyCode = "INR";
        public const int ProMonthlyInr = 699;
        public const int BusinessMonthlyInr = 2999;

        public const int ProMonthly = ProMonthlyInr;
        public const int BusinessMonthly = BusinessMonthlyInr;

        public static string FormatProDisplay() =>
            $"{DisplayCurrencySymbol}{ProMonthlyUsd:0.00}/month";

        public static string FormatBusinessDisplay() =>
            $"{DisplayCurrencySymbol}{BusinessMonthlyUsd:0.00}/month";

        public static string FormatProShort() =>
            $"{DisplayCurrencySymbol}{ProMonthlyUsd:0.00}/mo";

        public static string FormatBusinessShort() =>
            $"{DisplayCurrencySymbol}{BusinessMonthlyUsd:0.00}/mo";

        public static string FormatProTagline() =>
            "Cancel anytime · 7-day money-back guarantee";

        public static string FormatBusinessTagline() =>
            "Cancel anytime · priority support included";

        // Legacy — returns USD tagline (no INR on UI)
        public static string FormatProChargeNote() => FormatProTagline();
        public static string FormatBusinessChargeNote() => FormatBusinessTagline();
    }
}
