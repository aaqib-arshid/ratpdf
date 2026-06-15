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
        public int TotalSpans { get; set; }
        public List<PdfEditPageSummary> Pages { get; set; } = new();
    }

    public class PdfEditPageSummary
    {
        public int PageNum { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int SpanCount { get; set; }
        public bool SpansTruncated { get; set; }
    }

    public class PdfEditExportRequest
    {
        public string SessionId { get; set; } = "";
        public List<PdfEditOperation> Edits { get; set; } = new();
        public List<PdfEditPageOperation> PageOps { get; set; } = new();
        /// <summary>Original page indices in display order (non-deleted pages only).</summary>
        public List<int>? PageOrder { get; set; }
    }

    public class PdfEditPageOperation
    {
        /// <summary>rotate_page | delete_page | reorder_pages</summary>
        public string Type { get; set; } = "";
        public int Page { get; set; }
        public int Angle { get; set; } = 90;
        public List<int>? Order { get; set; }
    }

    public class PdfEditOperation
    {
        public string Type { get; set; } = ""; // whiteout | text_replace | text_add | image | highlight | link
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
        public string? PdfFontName { get; set; }
        public string? ImageBase64 { get; set; }
        public string? ImageAssetId { get; set; }
        public string? SpanId { get; set; }
        public string? Url { get; set; }
        public string? RichHtml { get; set; }
    }
}