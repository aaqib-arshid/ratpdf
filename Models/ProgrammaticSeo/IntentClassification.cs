namespace ratpdf.Models.ProgrammaticSeo
{
    public sealed record IntentClassification(
        SearchIntent Intent,
        double Confidence,
        PdfToolVertical Vertical,
        string? Device = null,
        bool HasCompetitorNoise = false,
        bool IsPillar = false);
}
