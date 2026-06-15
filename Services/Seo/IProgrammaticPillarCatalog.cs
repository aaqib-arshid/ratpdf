namespace ratpdf.Services.Seo
{
    public interface IProgrammaticPillarCatalog
    {
        bool IsPillar(string slug);
        ProgrammaticPillarPage? Get(string slug);
        IReadOnlyList<string> AllSlugs { get; }
    }

    public sealed record ProgrammaticPillarPage(
        string Slug,
        string H1,
        string MetaDescription,
        string ContentHtml,
        IReadOnlyList<(string Question, string Answer)> Faqs,
        IReadOnlyList<(string Name, string Text)> HowToSteps,
        string[] RelatedSlugs);
}
