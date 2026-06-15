namespace ratpdf.Models.ProgrammaticSeo
{
    public enum SearchIntent
    {
        Navigational,
        TaskBased,
        DeviceBased,
        ErrorRecovery,
        Invalid,
    }

    public enum PdfToolVertical
    {
        PdfToText,
        PdfToWord,
        EditPdf,
        CompressPdf,
    }

    public enum IndexDisposition
    {
        Index,
        NoIndex,
        NotFound,
    }
}
