using ClosedXML.Excel;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Models.BulkPaySlip;
using Razorpay.Api;
using System.Collections.Concurrent;
using System.IO.Compression;

namespace ratpdf.Controllers
{
    [Route("bulk-payslip-generator")]
    public class BulkPaySlipController : Controller
    {
        private readonly IConfiguration _config;
        // ─── Header keyword tables (order = priority) ────────────────────────────
        private static readonly string[] NameKeywords = { "employeename", "empname", "name", "fullname", "staffname" };
        private static readonly string[] IdKeywords = { "employeeid", "empid", "staffid", "workerid", "id" };
        private static readonly string[] DeptKeywords = { "department", "dept", "division", "team" };
        private static readonly string[] DesigKeys = { "designation", "position", "jobtitle", "title", "role" };
        private static readonly string[] PeriodKeys = { "period", "month", "payperiod", "salarymonth", "paymonth", "year" };
        private static readonly string[] TypeEarning = { "earning", "earnings", "credit", "income", "addition" };
        private static readonly string[] TypeDeduction = { "deduction", "deductions", "debit", "subtraction" };
        private static readonly string[] DeductionKw = { "pf", "provident", "tax", "tds", "esi", "insurance",
                                                              "loan", "deduction", "deduct", "nps", "advance",
                                                              "penalty", "recovery", "absent", "levy" };
        // ─── PDF palette ─────────────────────────────────────────────────────────
        private static readonly DeviceRgb CPrimary = new(15, 23, 42);
        private static readonly DeviceRgb CAccent = new(99, 102, 241);
        private static readonly DeviceRgb CEarning = new(16, 185, 129);
        private static readonly DeviceRgb CDeduction = new(239, 68, 68);
        private static readonly DeviceRgb CSurface = new(248, 250, 252);
        private static readonly DeviceRgb CMuted = new(100, 116, 139);
        private static readonly DeviceRgb CBorder = new(226, 232, 240);
        private static readonly DeviceRgb CWhite = new(255, 255, 255);
        private static readonly DeviceRgb CNetText = new(99, 102, 241);

        // ─── Parallelism cap: leave headroom for other requests ──────────────────
        private static readonly int MaxDegreeOfParallelism =
            Math.Max(1, Environment.ProcessorCount - 1);

        public BulkPaySlipController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("pricing")]
        public IActionResult Pricing(string plan)
        {
            if (plan != "starter" && plan != "pro")
                return RedirectToAction("Index", "PaySlip");

            ViewBag.Plan = plan;
            ViewBag.PlanName = plan == "starter" ? "Starter (100 rows)" : "Professional (500 rows)";
            ViewBag.Amount = plan == "starter" ? 499 : 999;
            return View();
        }
        [HttpGet("")]
        public IActionResult Index() => View();
        [HttpGet("download-template")]
        public IActionResult DownloadTemplate()
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Template");

            // Header row (added Designation)
            ws.Cell(1, 1).Value = "Employee Name";
            ws.Cell(1, 2).Value = "Employee ID";
            ws.Cell(1, 3).Value = "Department";
            ws.Cell(1, 4).Value = "Designation";     
            ws.Cell(1, 5).Value = "Basic Salary";
            ws.Cell(1, 6).Value = "HRA";
            ws.Cell(1, 7).Value = "Allowances";
            ws.Cell(1, 8).Value = "PF";
            ws.Cell(1, 9).Value = "Professional Tax";
            ws.Cell(1, 10).Value = "Income Tax";

            // Sample row (added sample designation)
            ws.Cell(2, 1).Value = "John Doe";
            ws.Cell(2, 2).Value = "EMP001";
            ws.Cell(2, 3).Value = "Sales";
            ws.Cell(2, 4).Value = "Sales Manager";     
            ws.Cell(2, 5).Value = 50000;
            ws.Cell(2, 6).Value = 10000;
            ws.Cell(2, 7).Value = 5000;
            ws.Cell(2, 8).Value = 1800;
            ws.Cell(2, 9).Value = 200;
            ws.Cell(2, 10).Value = 3500;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BulkPayslip_Template.xlsx");
        }
        [HttpGet("upload")]
        public IActionResult Upload()
        {
            string? activePlan = HttpContext.Session.GetString("ActivePlan");
            int? maxRows = HttpContext.Session.GetInt32("MaxRows");
            if (string.IsNullOrEmpty(activePlan) || !maxRows.HasValue)
                return RedirectToAction("Index", "PaySlip");

            ViewBag.PlanName = activePlan == "starter" ? "Starter (up to 100 rows)" : "Professional (up to 500 rows)";
            ViewBag.MaxRows = maxRows.Value;
            return View();
        }
        [HttpPost("generate")]
        public async Task<IActionResult> Generate(IFormFile excel, IFormFile logo, string companyName)
        {
            string? activePlan = HttpContext.Session.GetString("ActivePlan");
            int? maxRows = HttpContext.Session.GetInt32("MaxRows");
            if (string.IsNullOrEmpty(activePlan) || !maxRows.HasValue)
                return Unauthorized("No active plan. Please purchase a plan first.");
            // ── 1. Read Excel into memory once, then release the stream ──────────
            using var excelStream = new MemoryStream((int)excel.Length);
            await excel.CopyToAsync(excelStream);
            excelStream.Position = 0;

            // ── 2. Parse schema + rows (lazy enumeration, no ToList) ─────────────
            List<EmployeeModel> employees;
            using (var workbook = new XLWorkbook(excelStream))
            {
                employees = ParseEmployees(workbook.Worksheet(1));
            }
            // workbook + excelStream disposed here — memory freed before PDF work

            if (employees.Count == 0)
                return BadRequest("No employee data found in the spreadsheet.");
            if (employees.Count > maxRows.Value)
                return BadRequest($"Your file contains {employees.Count} rows, but your plan only allows up to {maxRows.Value}. Please upgrade or split your file.");
            // ── 3. Cache logo ImageData once (avoid disk + decode per PDF) ───────
            //    Keep as byte[] so each thread constructs its own ImageData
            //    (iText ImageData is NOT thread-safe to share across PdfDocuments)
            byte[]? logoBytes = await ReadLogoBytesAsync(logo);
            companyName ??= "Company";

            // ── 4. Generate all PDFs in parallel (CPU-bound) ─────────────────────
            //    Results stored by index so ZIP entries come out in sheet order.
            var pdfResults = new ConcurrentDictionary<int, (string name, byte[] pdf)>();

            await Task.Run(() =>
            {
                Parallel.For(0, employees.Count,
                    new ParallelOptions { MaxDegreeOfParallelism = MaxDegreeOfParallelism },
                    i =>
                    {
                        var emp = employees[i];
                        byte[] pdf = GeneratePdf(emp, logoBytes, companyName);
                        string safeName = SanitizeFileName($"{emp.EmployeeId}_{emp.EmployeeName}");
                        pdfResults[i] = (safeName, pdf);
                    });
            });

            // ── 5. Write ZIP to a temp file, then stream it back async ───────────
            //
            //    WHY NOT Response.Body directly:
            //      ZipArchive.Dispose() calls synchronous Write() when flushing the
            //      central directory — Kestrel throws InvalidOperationException on
            //      any sync write to Response.Body. ZipArchive has no DisposeAsync.
            //
            //    WHY NOT MemoryStream:
            //      Doubles peak RAM (ZIP buffer + ToArray() copy live simultaneously).
            //
            //    SOLUTION — temp file on disk:
            //      FileStream accepts sync writes (not Kestrel's pipe).
            //      ZipArchive.Dispose() flushes cleanly.
            //      PhysicalFileResult streams the file back using async I/O with a
            //      4 KB kernel buffer — zero RAM spike regardless of ZIP size.
            //      File is deleted via a cleanup callback after response completes.

            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"{Guid.NewGuid()}.zip");

            try
            {
                // Write ZIP to temp file — sync writes are fine on FileStream
                await Task.Run(() =>
                {
                    using var fs = new FileStream(
                        tempPath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None,
                        bufferSize: 64 * 1024,   // 64 KB write buffer
                        useAsync: false);         // sync on threadpool — safe here

                    using var archive = new ZipArchive(fs, ZipArchiveMode.Create, leaveOpen: false);

                    for (int i = 0; i < employees.Count; i++)
                    {
                        var (name, pdf) = pdfResults[i];
                        // NoCompression: PDFs are already DEFLATE-compressed internally.
                        // Running Optimal compression on them wastes CPU for ~0% gain.
                        var entry = archive.CreateEntry($"{name}.pdf", CompressionLevel.NoCompression);
                        using var entryStream = entry.Open();
                        entryStream.Write(pdf, 0, pdf.Length);
                    }
                    // ZipArchive.Dispose() flushes central directory here — fine on FileStream
                });

                // Stream the finished file back to the client using async reads
                // PhysicalFileResult handles Content-Disposition and async copy internally
                return PhysicalFile(tempPath, "application/zip", "Payslips.zip");
            }
            catch
            {
                // Clean up on error — success path cleanup is handled below
                if (System.IO.File.Exists(tempPath))
                    System.IO.File.Delete(tempPath);
                throw;
            }
            finally
            {
                // Schedule deletion after the response has been fully sent.
                // HttpContext.Response.OnCompleted fires after the last byte is flushed.
                var pathToDelete = tempPath;
                HttpContext.Response.OnCompleted(() =>
                {
                    try { System.IO.File.Delete(pathToDelete); } catch { /* best-effort */ }
                    return Task.CompletedTask;
                });
            }
        }
        [HttpPost("initiate-order")]
        public async Task<IActionResult> InitiateOrder([FromForm] string plan)
        {
            int amountInPaise = plan == "starter" ? 49900 : 99900;
            int maxRows = plan == "starter" ? 100 : 500;
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(); // ~10 chars
            string planCode = plan == "starter" ? "st" : "pr"; // 2 chars
            string randomSuffix = Guid.NewGuid().ToString("N").Substring(0, 6); // 6 chars
            string receipt = $"bulk_{planCode}_{timestamp}_{randomSuffix}";
            var client = new RazorpayClient(_config["Razorpay:KeyId"], _config["Razorpay:KeySecret"]);
            var orderOptions = new Dictionary<string, object>
            {
                { "amount", amountInPaise },
                { "currency", "INR" },
                { "receipt", receipt },
                { "payment_capture", 1 }
            };
            Razorpay.Api.Order order = client.Order.Create(orderOptions);
            string orderId = order["id"].ToString();

            HttpContext.Session.SetString("PendingPlan", plan);
            HttpContext.Session.SetInt32("PendingMaxRows", maxRows);

            return Ok(new
            {
                orderId,
                amount = amountInPaise / 100,
                key = _config["Razorpay:KeyId"],
                plan
            });
        }
        [HttpPost("verify-payment")]
        public async Task<IActionResult> VerifyPayment(
            [FromForm] string razorpay_payment_id,
            [FromForm] string razorpay_order_id,
            [FromForm] string razorpay_signature,
            [FromForm] string plan)
        {
            var secret = _config["Razorpay:Secret"];
            var attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", razorpay_payment_id },
                { "razorpay_order_id", razorpay_order_id },
                { "razorpay_signature", razorpay_signature }
            };
            try
            {
                Utils.verifyPaymentSignature(attributes);
            }
            catch
            {
                return BadRequest("Invalid payment signature.");
            }

            string? pendingPlan = HttpContext.Session.GetString("PendingPlan");
            int? pendingMaxRows = HttpContext.Session.GetInt32("PendingMaxRows");
            if (pendingPlan != plan || !pendingMaxRows.HasValue)
                return BadRequest("Plan mismatch or session expired.");

            HttpContext.Session.SetString("ActivePlan", plan);
            HttpContext.Session.SetInt32("MaxRows", pendingMaxRows.Value);
            HttpContext.Session.Remove("PendingPlan");
            HttpContext.Session.Remove("PendingMaxRows");

            return Ok(new { redirect = Url.Action("Upload") });
        }

        //  EXCEL PARSING

        private List<EmployeeModel> ParseEmployees(IXLWorksheet ws)
        {
            // Enumerate rows lazily — never materialise the whole sheet
            using var rowEnum = ws.RowsUsed().GetEnumerator();

            if (!rowEnum.MoveNext()) return [];

            // ── Header row ───────────────────────────────────────────────────────
            var colMeta = new Dictionary<int, (string key, string label)>();
            foreach (var cell in rowEnum.Current.Cells())
            {
                string raw = cell.GetString().Trim();
                if (!string.IsNullOrWhiteSpace(raw))
                    colMeta[cell.Address.ColumnNumber] = (NormalizeKey(raw), ToDisplayLabel(raw));
            }

            if (!rowEnum.MoveNext()) return [];

            // ── Optional type row detection ──────────────────────────────────────
            var typeMap = new Dictionary<int, string>();
            bool hasTypeRow = false;
            var candidateRow = rowEnum.Current;

            int typeHits = 0, totalCells = 0;
            foreach (var cell in candidateRow.Cells())
            {
                string val = NormalizeKey(cell.GetString());
                if (string.IsNullOrWhiteSpace(val)) continue;
                totalCells++;
                if (TypeEarning.Any(t => val.Contains(t))) { typeMap[cell.Address.ColumnNumber] = "earning"; typeHits++; }
                else if (TypeDeduction.Any(t => val.Contains(t))) { typeMap[cell.Address.ColumnNumber] = "deduction"; typeHits++; }
            }
            hasTypeRow = totalCells > 0 && (double)typeHits / totalCells >= 0.5;

            // ── Column role map ──────────────────────────────────────────────────
            var colRole = new Dictionary<int, string>(colMeta.Count);
            foreach (var (colIdx, (key, _)) in colMeta)
            {
                if (NameKeywords.Any(k => key.Contains(k))) colRole[colIdx] = "name";
                else if (IdKeywords.Any(k => key.Contains(k))) colRole[colIdx] = "id";
                else if (DeptKeywords.Any(k => key.Contains(k))) colRole[colIdx] = "dept";
                else if (DesigKeys.Any(k => key.Contains(k))) colRole[colIdx] = "designation";
                else if (PeriodKeys.Any(k => key.Contains(k))) colRole[colIdx] = "period";
                else if (typeMap.TryGetValue(colIdx, out var et)) colRole[colIdx] = et;
                else colRole[colIdx] = DeductionKw.Any(d => key.Contains(d)) ? "deduction" : "earning";
            }

            // ── Data rows ────────────────────────────────────────────────────────
            var employees = new List<EmployeeModel>();

            // If type row detected, first candidate row is the type row — skip it.
            // If not, the candidate row IS the first data row — process it now.
            IEnumerable<IXLRow> dataRows;
            if (hasTypeRow)
            {
                dataRows = EnumerateRemaining(rowEnum);
            }
            else
            {
                dataRows = Prepend(candidateRow, rowEnum);
            }

            foreach (var row in dataRows)
            {
                var emp = new EmployeeModel();

                foreach (var (colIdx, (_, label)) in colMeta)
                {
                    string raw = row.Cell(colIdx).GetString().Trim();
                    if (string.IsNullOrWhiteSpace(raw)) continue;

                    string role = colRole.GetValueOrDefault(colIdx, "earning");

                    switch (role)
                    {
                        case "name": emp.EmployeeName = raw; break;
                        case "id": emp.EmployeeId = raw; break;
                        case "dept": emp.Department = raw; break;
                        case "designation": emp.Designation = raw; break;
                        case "period": emp.PayPeriod = raw; break;
                        case "earning":
                        case "deduction":
                            if (TryParseAmount(raw, out decimal amt))
                            {
                                if (role == "earning") emp.Earnings[label] = amt;
                                else emp.Deductions[label] = amt;
                            }
                            break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(emp.EmployeeName))
                    employees.Add(emp);
            }

            return employees;
        }

        // Yield remaining items from an already-advanced enumerator
        private static IEnumerable<T> EnumerateRemaining<T>(IEnumerator<T> e)
        {
            while (e.MoveNext()) yield return e.Current;
        }

        // Prepend a single item to an enumerator's remaining items
        private static IEnumerable<T> Prepend<T>(T first, IEnumerator<T> rest)
        {
            yield return first;
            while (rest.MoveNext()) yield return rest.Current;
        }

        //  PDF GENERATION  (thread-safe: no shared mutable state)

        public byte[] GeneratePdf(EmployeeModel emp, byte[]? logoBytes, string companyName)
        {
            // SmartMode = false: disables expensive cross-object optimisation pass
            // that is unnecessary for single-page payslips.
            using var ms = new MemoryStream(32 * 1024); // pre-size to ~32 KB
            var writer = new PdfWriter(ms, new WriterProperties().UseSmartMode());
            var pdfDoc = new PdfDocument(writer);
            var doc = new Document(pdfDoc, PageSize.A4);
            doc.SetMargins(0, 0, 30, 0);

            // ── Accent stripe ────────────────────────────────────────────────────
            var stripe = new Table(1).UseAllAvailableWidth();
            stripe.AddCell(new Cell().SetBorder(Border.NO_BORDER)
                .SetHeight(5).SetBackgroundColor(CAccent));
            doc.Add(stripe);

            // ── Header band ──────────────────────────────────────────────────────
            var headerTable = new Table(new float[] { 60, 1, 1 })
                .UseAllAvailableWidth()
                .SetBackgroundColor(CPrimary);

            // Logo cell
            var logoCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetBackgroundColor(CPrimary)
                .SetPadding(18).SetPaddingLeft(28)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            if (logoBytes != null)
            {
                // Construct ImageData per thread from cached bytes — safe
                logoCell.Add(new Image(ImageDataFactory.Create(logoBytes))
                    .SetWidth(52).SetHeight(52)
                    .SetBorderRadius(new BorderRadius(8)));
            }
            else
            {
                string initial = companyName.Length > 0
                    ? companyName[0].ToString().ToUpper() : "C";
                logoCell.Add(new Paragraph(initial)
                    .SetFontSize(26).SimulateBold()
                    .SetFontColor(CWhite)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(CAccent)
                    .SetWidth(52).SetHeight(52)
                    .SetPaddingTop(10)
                    .SetBorderRadius(new BorderRadius(8)));
            }
            headerTable.AddCell(logoCell);

            // Company / payslip label cell
            var companyCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetBackgroundColor(CPrimary)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPaddingLeft(4).SetPaddingTop(18);
            companyCell.Add(new Paragraph(companyName)
                .SetFontSize(17).SimulateBold()
                .SetFontColor(CWhite).SetMarginBottom(2));
            companyCell.Add(new Paragraph("PAYSLIP")
                .SetFontSize(9)
                .SetFontColor(new DeviceRgb(148, 163, 184))
                .SetCharacterSpacing(2.5f));
            headerTable.AddCell(companyCell);

            // Pay period cell
            var periodCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetBackgroundColor(CPrimary)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPaddingRight(28).SetPaddingTop(18);
            if (!string.IsNullOrWhiteSpace(emp.PayPeriod))
            {
                periodCell.Add(new Paragraph("Pay Period")
                    .SetFontSize(8)
                    .SetFontColor(new DeviceRgb(148, 163, 184))
                    .SetCharacterSpacing(1.5f)
                    .SetTextAlignment(TextAlignment.RIGHT));
                periodCell.Add(new Paragraph(emp.PayPeriod)
                    .SetFontSize(13).SimulateBold()
                    .SetFontColor(CWhite)
                    .SetTextAlignment(TextAlignment.RIGHT));
            }
            headerTable.AddCell(periodCell);
            doc.Add(headerTable);

            // ── Employee info bar ────────────────────────────────────────────────
            var empCard = new Table(new float[] { 1, 1, 1, 1 })
                .UseAllAvailableWidth()
                .SetBackgroundColor(CAccent);

            AddInfoBadge(empCard, "Employee Name", emp.EmployeeName);
            AddInfoBadge(empCard, "Employee ID", emp.EmployeeId);
            AddInfoBadge(empCard, "Department", emp.Department);
            AddInfoBadge(empCard, "Designation", emp.Designation);
            doc.Add(empCard);

            // ── Body spacer ──────────────────────────────────────────────────────
            doc.Add(new Paragraph("").SetMarginBottom(12));

            // ── Earnings | Deductions side by side ───────────────────────────────
            var body = new Table(new float[] { 1, 1 })
                .UseAllAvailableWidth()
                .SetMarginLeft(24).SetMarginRight(24);

            decimal totalEarnings = 0, totalDeductions = 0;

            // Earnings column
            var earnCol = new Cell().SetBorder(Border.NO_BORDER).SetPaddingRight(10);
            earnCol.Add(SectionHeader("EARNINGS", CEarning));
            if (emp.Earnings.Any())
            {
                var earnTable = new Table(new float[] { 3, 2 }).UseAllAvailableWidth();
                bool alt = false;
                foreach (var (label, amount) in emp.Earnings)
                {
                    var bg = alt ? CSurface : CWhite;
                    earnTable.AddCell(LineCell(label, bg, TextAlignment.LEFT));
                    earnTable.AddCell(LineCell("₹ " + amount.ToString("N2"), bg, TextAlignment.RIGHT, true));
                    totalEarnings += amount;
                    alt = !alt;
                }
                earnTable.AddCell(TotalLabelCell("Total Earnings", CEarning));
                earnTable.AddCell(TotalAmountCell("₹ " + totalEarnings.ToString("N2"), CEarning));
                earnCol.Add(earnTable);
            }
            else { earnCol.Add(EmptyNote("No earnings recorded")); }

            // Deductions column
            var dedCol = new Cell().SetBorder(Border.NO_BORDER).SetPaddingLeft(10);
            dedCol.Add(SectionHeader("DEDUCTIONS", CDeduction));
            if (emp.Deductions.Any())
            {
                var dedTable = new Table(new float[] { 3, 2 }).UseAllAvailableWidth();
                bool alt = false;
                foreach (var (label, amount) in emp.Deductions)
                {
                    var bg = alt ? CSurface : CWhite;
                    dedTable.AddCell(LineCell(label, bg, TextAlignment.LEFT));
                    dedTable.AddCell(LineCell("₹ " + amount.ToString("N2"), bg, TextAlignment.RIGHT, true));
                    totalDeductions += amount;
                    alt = !alt;
                }
                dedTable.AddCell(TotalLabelCell("Total Deductions", CDeduction));
                dedTable.AddCell(TotalAmountCell("₹ " + totalDeductions.ToString("N2"), CDeduction));
                dedCol.Add(dedTable);
            }
            else { dedCol.Add(EmptyNote("No deductions recorded")); }

            body.AddCell(earnCol);
            body.AddCell(dedCol);
            doc.Add(body);

            // ── Net salary banner ────────────────────────────────────────────────
            decimal net = totalEarnings - totalDeductions;
            doc.Add(new Paragraph("").SetMarginBottom(16));

            var netBanner = new Table(new float[] { 1, 1 })
                .UseAllAvailableWidth()
                .SetMarginLeft(24).SetMarginRight(24)
                .SetBackgroundColor(CPrimary)
                .SetBorderRadius(new BorderRadius(10));

            var netLabel = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetPaddingLeft(24).SetPaddingTop(18).SetPaddingBottom(18)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);
            netLabel.Add(new Paragraph("NET SALARY PAYABLE")
                .SetFontSize(9)
                .SetFontColor(new DeviceRgb(148, 163, 184))
                .SetCharacterSpacing(2f).SetMarginBottom(4));
            netLabel.Add(new Paragraph("After all deductions")
                .SetFontSize(8).SetFontColor(new DeviceRgb(71, 85, 105)));
            netBanner.AddCell(netLabel);

            var netAmount = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetPaddingRight(24).SetPaddingTop(18).SetPaddingBottom(18)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);
            netAmount.Add(new Paragraph("₹ " + net.ToString("N2"))
                .SetFontSize(26).SimulateBold()
                .SetFontColor(CNetText)
                .SetTextAlignment(TextAlignment.RIGHT));
            netBanner.AddCell(netAmount);
            doc.Add(netBanner);

            // ── Footer ────────────────────────────────────────────────────────────
            doc.Add(new Paragraph("").SetMarginBottom(20));
            var footer = new Table(new float[] { 1, 1 })
                .UseAllAvailableWidth()
                .SetMarginLeft(24).SetMarginRight(24);

            var footNote = new Cell().SetBorder(Border.NO_BORDER);
            footNote.Add(new Paragraph("This is a computer-generated payslip and does not require a signature.")
                .SetFontSize(7.5f).SetFontColor(CMuted).SimulateItalic());

            var footDate = new Cell().SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT);
            footDate.Add(new Paragraph($"Generated on {DateTime.Now:dd MMM yyyy}")
                .SetFontSize(7.5f).SetFontColor(CMuted).SetTextAlignment(TextAlignment.RIGHT));

            footer.AddCell(footNote);
            footer.AddCell(footDate);
            doc.Add(footer);

            doc.Close();
            return ms.ToArray();
        }

        //  PDF ELEMENT HELPERS  (all static — no instance state, fully thread-safe)

        private static void AddInfoBadge(Table table, string label, string? value)
        {
            var c = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetPaddingTop(10).SetPaddingBottom(10)
                .SetPaddingLeft(20).SetPaddingRight(10);
            c.Add(new Paragraph(label.ToUpper())
                .SetFontSize(7)
                .SetFontColor(new DeviceRgb(199, 210, 254))
                .SetCharacterSpacing(1.5f).SetMarginBottom(2));
            c.Add(new Paragraph(string.IsNullOrWhiteSpace(value) ? "—" : value)
                .SetFontSize(10).SimulateBold().SetFontColor(new DeviceRgb(255, 255, 255)));
            table.AddCell(c);
        }

        private static IBlockElement SectionHeader(string title, DeviceRgb color)
        {
            var t = new Table(1).UseAllAvailableWidth();
            var c = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetBorderBottom(new SolidBorder(color, 2))
                .SetPaddingBottom(6).SetPaddingTop(0);
            c.Add(new Paragraph(title)
                .SetFontSize(10).SimulateBold()
                .SetFontColor(color).SetCharacterSpacing(1.5f));
            t.AddCell(c);
            return t;
        }

        private static Cell LineCell(string text, DeviceRgb bg, TextAlignment align, bool bold = false)
        {
            var p = new Paragraph(text).SetFontSize(9).SetTextAlignment(align)
                .SetFontColor(new DeviceRgb(15, 23, 42));
            if (bold) p.SimulateBold();
            return new Cell().Add(p)
                .SetBackgroundColor(bg).SetBorder(Border.NO_BORDER)
                .SetBorderBottom(new SolidBorder(new DeviceRgb(226, 232, 240), 0.5f))
                .SetPaddingTop(7).SetPaddingBottom(7)
                .SetPaddingLeft(8).SetPaddingRight(8);
        }

        private static Cell TotalLabelCell(string label, DeviceRgb color) =>
            new Cell()
                .Add(new Paragraph(label).SetFontSize(9).SimulateBold().SetFontColor(color))
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(new SolidBorder(color, 1.5f))
                .SetBackgroundColor(new DeviceRgb(248, 250, 252))
                .SetPaddingTop(8).SetPaddingBottom(8).SetPaddingLeft(8);

        private static Cell TotalAmountCell(string amount, DeviceRgb color) =>
            new Cell()
                .Add(new Paragraph(amount).SetFontSize(9).SimulateBold()
                    .SetFontColor(color).SetTextAlignment(TextAlignment.RIGHT))
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(new SolidBorder(color, 1.5f))
                .SetBackgroundColor(new DeviceRgb(248, 250, 252))
                .SetPaddingTop(8).SetPaddingBottom(8).SetPaddingRight(8)
                .SetTextAlignment(TextAlignment.RIGHT);

        private static IBlockElement EmptyNote(string msg) =>
            new Paragraph(msg).SetFontSize(9).SetFontColor(new DeviceRgb(100, 116, 139))
                .SimulateItalic().SetPaddingLeft(4);

        //  UTILITIES

        private static string NormalizeKey(string text) =>
            new(text.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray());

        private static string ToDisplayLabel(string raw) =>
            string.IsNullOrWhiteSpace(raw) ? raw :
            string.Join(" ", raw.Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => char.ToUpper(w[0]) + w[1..].ToLower()));

        private static bool TryParseAmount(string value, out decimal amount)
        {
            value = value.Replace(",", "").Replace("₹", "").Replace("$", "").Trim();
            return decimal.TryParse(value, out amount);
        }

        private static string SanitizeFileName(string name) =>
            string.Join("_", name.Split(System.IO.Path.GetInvalidFileNameChars()));

        private static async Task<byte[]?> ReadLogoBytesAsync(IFormFile? logo)
        {
            if (logo == null) return null;
            using var ms = new MemoryStream((int)logo.Length);
            await logo.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}