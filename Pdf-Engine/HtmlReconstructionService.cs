using System.Text;
using System.Text.Json;

namespace ratpdf.Services
{
    public class HtmlReconstructionService
    {


        /// <summary>
        /// Converts the strict JSON layout (from Python) into a self‑contained HTML file.
        /// </summary>
        /// <param name="layoutJson">The exact JSON string from the LayoutEngineProcessor.</param>
        /// <param name="imageBase64Map">Optional: dictionary mapping image index to base64 data URI.</param>
        public string BuildHtml(string layoutJson, Dictionary<int, string>? imageBase64Map = null)
        {
            using JsonDocument doc = JsonDocument.Parse(layoutJson);
            var root = doc.RootElement;
            var pages = root.GetProperty("pages");

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head><meta charset=\"utf-8\">");
            sb.AppendLine("<style>");
            sb.AppendLine("body { margin:0; padding:0; }");
            sb.AppendLine(".page { position:relative; overflow:hidden; margin-bottom:10px; border:1px solid #ccc; }");
            sb.AppendLine(".element { position:absolute; white-space:pre; box-sizing:border-box; }");
            sb.AppendLine(".line, .rectangle { pointer-events:none; }");
            sb.AppendLine("</style></head><body>");

            int imageCounter = 0;

            foreach (var page in pages.EnumerateArray())
            {
                double pageWidth = page.GetProperty("width").GetDouble();
                double pageHeight = page.GetProperty("height").GetDouble();

                sb.AppendLine($"<div class=\"page\" style=\"width:{pageWidth}px; height:{pageHeight}px;\">");

                foreach (var el in page.GetProperty("elements").EnumerateArray())
                {
                    string type = el.GetProperty("type").GetString()!;
                    double x = el.GetProperty("x").GetDouble();
                    double y = el.GetProperty("y").GetDouble();
                    double w = el.GetProperty("width").GetDouble();
                    double h = el.GetProperty("height").GetDouble();
                    string color = el.GetProperty("color").GetString() ?? "#000";
                    double rotation = el.TryGetProperty("rotation", out var rotProp) ? rotProp.GetDouble() : 0;
                    int zIndex = el.TryGetProperty("zIndex", out var zProp) ? zProp.GetInt32() : 0;

                    string baseStyle = $"left:{x}px; top:{y}px; width:{w}px; height:{h}px; z-index:{zIndex};";
                    if (rotation != 0)
                        baseStyle += $" transform:rotate({rotation}deg); transform-origin:0 0;";

                    switch (type)
                    {
                        case "text":
                            string text = System.Net.WebUtility.HtmlEncode(el.GetProperty("text").GetString() ?? "");
                            string fontFamily = el.GetProperty("fontFamily").GetString() ?? "Arial";
                            double fontSize = el.GetProperty("fontSize").GetDouble();
                            string fontWeight = el.GetProperty("fontWeight").GetString() ?? "normal";
                            string textColor = color;
                            // Avoid huge line heights causing overlap – use a tight line-height
                            string textStyle = $"{baseStyle} font-family:{fontFamily}; font-size:{fontSize}px; " +
                                                $"font-weight:{fontWeight}; color:{textColor}; line-height:1; overflow:hidden;";
                            sb.AppendLine($"<div class=\"element\" style=\"{textStyle}\">{text}</div>");
                            break;

                        case "line":
                            // Render as a thin div with background color; if it's a diagonal line we approximate
                            string lineStyle = $"{baseStyle} background-color:{color}; ";
                            // If width > height → horizontal line; else vertical
                            if (w > h)
                            {
                                double thickness = h;
                                lineStyle += $"height:{thickness}px; top:{y + h / 2 - thickness / 2}px;";
                            }
                            else
                            {
                                double thickness = w;
                                lineStyle += $"width:{thickness}px; left:{x + w / 2 - thickness / 2}px;";
                            }
                            sb.AppendLine($"<div class=\"element line\" style=\"{lineStyle}\"></div>");
                            break;
                        case "rectangle":
                            string rectStyle = $"{baseStyle} background-color:{color}; border:1px solid {color}; box-sizing:border-box;";
                            sb.AppendLine($"<div class=\"element rectangle\" style=\"{rectStyle}\"></div>");
                            break;
                        case "image":
                            string imgData = "";
                            if (el.TryGetProperty("imageData", out JsonElement dataProp))
                                imgData = dataProp.GetString() ?? "";

                            string imgTag;
                            if (!string.IsNullOrEmpty(imgData))
                            {
                                imgTag = $"<img src=\"{imgData}\" style=\"width:100%; height:100%; object-fit:fill;\" />";
                            }
                            else
                            {
                                imgTag = $"<div style=\"width:100%; height:100%; background:#eee; border:1px dashed #999; display:flex; align-items:center; justify-content:center; font-size:10px;\">[Image {imageCounter}]</div>";
                            }

                            string imgStyle = baseStyle + " overflow:hidden;";
                            sb.AppendLine($"<div class=\"element\" style=\"{imgStyle}\">{imgTag}</div>");
                            imageCounter++;
                            break;

                        case "table":
                            // Build an HTML table inside the container
                            string tableStyle = baseStyle + " overflow:hidden;";
                            sb.AppendLine($"<div class=\"element\" style=\"{tableStyle}\">");
                            sb.AppendLine("<table style=\"width:100%; height:100%; border-collapse:collapse; table-layout:fixed;\">");
                            if (el.TryGetProperty("rows", out var rows))
                            {
                                foreach (var row in rows.EnumerateArray())
                                {
                                    sb.AppendLine("<tr>");
                                    foreach (var cell in row.EnumerateArray())
                                    {
                                        string cellText = cell.GetProperty("text").GetString() ?? "";
                                        cellText = System.Net.WebUtility.HtmlEncode(cellText);
                                        double cw = cell.GetProperty("width").GetDouble();
                                        double ch = cell.GetProperty("height").GetDouble();
                                        string cf = cell.GetProperty("fontFamily").GetString() ?? "Arial";
                                        double cs = cell.GetProperty("fontSize").GetDouble();
                                        string cwght = cell.GetProperty("fontWeight").GetString() ?? "normal";
                                        string cc = cell.GetProperty("color").GetString() ?? "#000";
                                        string cellStyle = $"font-family:{cf}; font-size:{cs}px; font-weight:{cwght}; color:{cc}; border:1px solid #ccc; padding:2px; vertical-align:top;";
                                        sb.AppendLine($"<td style=\"{cellStyle}\">{cellText}</td>");
                                    }
                                    sb.AppendLine("</tr>");
                                }
                            }
                            sb.AppendLine("</table></div>");
                            break;
                    }
                }
                sb.AppendLine("</div>"); // close page
            }

            sb.AppendLine("</body></html>");
            return sb.ToString();
        }

    }
}