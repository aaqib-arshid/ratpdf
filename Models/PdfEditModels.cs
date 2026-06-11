namespace ratpdf.Models
{
    public class PdfEditViewModel
    {
        public string? SessionId { get; set; }
        public string? OriginalFileName { get; set; }
        public bool HasDocument => !string.IsNullOrEmpty(SessionId);
    }

    public class PdfEditUploadResponse
    {
        public string SessionId { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public int PageCount { get; set; }
        public object? DocumentModel { get; set; }
    }

    public class PdfEditExportRequest
    {
        public string SessionId { get; set; } = "";
        public List<PdfEditOperation> Edits { get; set; } = new();
    }

    public class PdfEditOperation
    {
        public string Type { get; set; } = ""; // whiteout | text_replace | text_add | image | highlight
        public int Page { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string? Text { get; set; }
        public double FontSize { get; set; } = 12;
        public string FontFamily { get; set; } = "Arial";
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public string Color { get; set; } = "#000000";
        public string? ImageBase64 { get; set; }
        public string? SpanId { get; set; }
    }
}
