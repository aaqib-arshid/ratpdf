namespace ratpdf.Constants
{
    /// <summary>Per-tool tutorial steps with click-marker hints for slide videos.</summary>
    public static class ToolTutorialSteps
    {
        public sealed record Step(string Text, double? MarkerX = null, double? MarkerY = null, string? ClickLabel = null);

        public static IReadOnlyList<Step> Get(string toolUrl, string toolName)
        {
            var slug = ToolHowToVideos.SlugFromUrl(toolUrl);
            if (BySlug.TryGetValue(slug, out var steps))
                return steps;

            if (toolUrl.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase) || toolUrl.Equals("/pdf-redaction", StringComparison.OrdinalIgnoreCase))
                return PdfUploadToolSteps(toolName);

            if (toolUrl.Contains("calculator", StringComparison.OrdinalIgnoreCase) ||
                slug.Contains("calculator"))
                return CalculatorSteps(toolName);

            if (toolUrl.StartsWith("/invoice", StringComparison.OrdinalIgnoreCase) || slug.Contains("payslip") || slug.Contains("receipt"))
                return FormSteps(toolName, "Fill in the fields", "Generate PDF");

            if (slug is "jsonformatter" or "jwtdecoder" or "htmlformatter" or "text-comparer" or "url-encoder" or "url-decoder")
                return PasteToolSteps(toolName);

            return DefaultSteps(toolName);
        }

        private static IReadOnlyList<Step> PdfUploadToolSteps(string name) =>
        [
            new($"Open {name} on RatPDF — no install needed.", null, null, null),
            new("Drag your file into the upload box, or click to browse.", 0.50, 0.40, "Upload here"),
            new("Click the main button to start processing.", 0.50, 0.68, "Click to process"),
            new("Download your finished file when processing completes.", 0.50, 0.84, "Download"),
        ];

        private static IReadOnlyList<Step> CalculatorSteps(string name) =>
        [
            new($"Open {name} on RatPDF.", null, null, null),
            new("Enter your values in the form fields.", 0.50, 0.45, "Enter values"),
            new("Click Calculate to see the result.", 0.50, 0.72, "Calculate"),
            new("Read the score or result on screen.", 0.50, 0.55, "Result"),
        ];

        private static IReadOnlyList<Step> FormSteps(string name, string fill, string action) =>
        [
            new($"Open {name}.", null, null, null),
            new(fill, 0.50, 0.42, "Form fields"),
            new($"Click {action}.", 0.50, 0.70, action),
            new("Download or save your PDF.", 0.50, 0.82, "Download PDF"),
        ];

        private static IReadOnlyList<Step> PasteToolSteps(string name) =>
        [
            new($"Open {name}.", null, null, null),
            new("Paste or type your content in the editor.", 0.50, 0.45, "Paste here"),
            new("Click the format or decode button.", 0.50, 0.68, "Run tool"),
            new("Copy the output from the result panel.", 0.50, 0.55, "Output"),
        ];

        private static IReadOnlyList<Step> DefaultSteps(string name) =>
        [
            new($"Open {name} on RatPDF.", null, null, null),
            new("Follow the on-screen instructions for your input.", 0.50, 0.45, "Input area"),
            new("Click the main action button.", 0.50, 0.68, "Action button"),
            new("Download or copy your result.", 0.50, 0.82, "Result"),
        ];

        private static readonly Dictionary<string, Step[]> BySlug = new(StringComparer.OrdinalIgnoreCase)
        {
            ["compress"] =
            [
                new("Open Compress PDF on RatPDF.", null, null, null),
                new("Upload your PDF — drag and drop or click the upload zone.", 0.50, 0.38, "Upload PDF"),
                new("Choose Low, Medium, or High compression.", 0.50, 0.55, "Compression level"),
                new("Click Compress PDF, then download the smaller file.", 0.50, 0.72, "Compress button"),
            ],
            ["merge"] =
            [
                new("Open Merge PDF.", null, null, null),
                new("Upload two or more PDF files.", 0.50, 0.40, "Upload files"),
                new("Drag files to reorder if needed.", 0.50, 0.52, "Reorder list"),
                new("Click Merge PDF and download the combined file.", 0.50, 0.72, "Merge button"),
            ],
            ["htmltopdf"] =
            [
                new("Open HTML to PDF.", null, null, null),
                new("Paste HTML or upload an .html file.", 0.50, 0.42, "HTML editor"),
                new("Click Convert HTML to PDF.", 0.50, 0.72, "Convert button"),
                new("Download your PDF.", 0.50, 0.84, "Download"),
            ],
        };
    }
}
