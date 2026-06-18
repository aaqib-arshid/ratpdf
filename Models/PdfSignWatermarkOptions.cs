namespace ratpdf.Models;

public sealed class SignPdfOptions
{
    public string Mode { get; init; } = "typed";
    public string? Name { get; init; }
    public string? ImagePath { get; init; }
    public string PageTarget { get; init; } = "last";
    public int PageNumber { get; init; } = 1;
    public string Position { get; init; } = "bottom-right";
    public string FontStyle { get; init; } = "script";
    public bool IncludeDate { get; init; }
}

public sealed class WatermarkOptions
{
    public string Mode { get; init; } = "text";
    public string? Text { get; init; }
    public string? ImagePath { get; init; }
    public float Opacity { get; init; } = 0.35f;
    public float FontSize { get; init; } = 48f;
    public float RotationDegrees { get; init; } = -45f;
    public string Pages { get; init; } = "all";
    public int PageStart { get; init; } = 1;
    public int PageEnd { get; init; } = 1;
    public string Layout { get; init; } = "diagonal";
}
