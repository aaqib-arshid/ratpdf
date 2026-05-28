using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using ratpdf.Models.PaySlip;

namespace ratpdf.Services.PaySlip
{
    public class PayslipPdfService
    {
        public byte[] GeneratePdf(PayslipModel model)
        {
            using var stream = new MemoryStream();

            // PDF Writer
            var writer = new PdfWriter(stream);

            // PDF Document
            var pdf = new PdfDocument(writer);

            // Document
            var document = new Document(pdf);

            // PAGE MARGIN
            document.SetMargins(30, 30, 30, 30);

            // =====================================================
            // HEADER
            // =====================================================

            var headerTable = new Table(2)
                .UseAllAvailableWidth();

            headerTable.SetBorder(Border.NO_BORDER);

            // LOGO CELL
            var logoCell = new Cell()
                .SetBorder(Border.NO_BORDER);

            if (model.CompanyLogo != null &&
                model.CompanyLogo.Length > 0)
            {
                using var logoStream =
                    model.CompanyLogo.OpenReadStream();

                var memoryStream = new MemoryStream();

                logoStream.CopyTo(memoryStream);

                var imageData =
                    ImageDataFactory.Create(
                        memoryStream.ToArray()
                    );

                var logo = new Image(imageData)
                    .ScaleToFit(80, 80);

                logoCell.Add(logo);
            }

            headerTable.AddCell(logoCell);

            // TITLE CELL
            var titleCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            titleCell.Add(
                new Paragraph("PAYSLIP")
                    .SetFontSize(26)
                    .SimulateBold()
            );

            titleCell.Add(
                new Paragraph(model.PayPeriod ?? "")
                    .SetFontSize(11)
                    .SetFontColor(ColorConstants.GRAY)
            );

            headerTable.AddCell(titleCell);

            document.Add(headerTable);

            // SPACING
            document.Add(new Paragraph(" "));

            // =====================================================
            // COMPANY + EMPLOYEE INFO
            // =====================================================

            var infoTable = new Table(2)
                .UseAllAvailableWidth();

            infoTable.SetMarginTop(10);

            // LEFT SECTION
            var companyCell = new Cell()
                .SetPadding(10);

            companyCell.Add(
                new Paragraph("Company Details")
                    .SimulateBold()
                    .SetFontSize(14)
            );

            companyCell.Add(
                new Paragraph(model.CompanyName ?? "")
                    .SetFontSize(12)
            );

            infoTable.AddCell(companyCell);

            // RIGHT SECTION
            var employeeCell = new Cell()
                .SetPadding(10);

            employeeCell.Add(
                new Paragraph("Employee Details")
                    .SimulateBold()
                    .SetFontSize(14)
            );

            employeeCell.Add(
                new Paragraph($"Employee: {model.EmployeeName}")
            );

            employeeCell.Add(
                new Paragraph($"Employee ID: {model.EmployeeId}")
            );

            employeeCell.Add(
                new Paragraph($"Designation: {model.Designation}")
            );

            infoTable.AddCell(employeeCell);

            document.Add(infoTable);

            // =====================================================
            // SALARY TABLE
            // =====================================================

            document.Add(
                new Paragraph("Salary Breakdown")
                    .SimulateBold()
                    .SetFontSize(16)
                    .SetMarginTop(25)
                    .SetMarginBottom(10)
            );

            var salaryTable = new Table(2)
                .UseAllAvailableWidth();

            // HEADER
            salaryTable.AddHeaderCell(
                new Cell()
                    .Add(new Paragraph("Description")
                    .SimulateBold()
                    .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetPadding(8)
            );

            salaryTable.AddHeaderCell(
                new Cell()
                    .Add(new Paragraph("Amount")
                    .SimulateBold()
                    .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // BASIC SALARY
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Basic Salary"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"₹ {model.BasicSalary:N2}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // BONUS
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Bonus"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"₹ {model.Bonus:N2}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
            );

            // DEDUCTIONS
            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph("Deductions"))
                    .SetPadding(8)
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(new Paragraph($"₹ {model.Deductions:N2}"))
                    .SetPadding(8)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.RED)
            );

            // NET SALARY
            salaryTable.AddCell(
                new Cell()
                    .Add(
                        new Paragraph("Net Salary")
                            .SimulateBold()
                    )
                    .SetPadding(10)
                    .SetBackgroundColor(
                        ColorConstants.LIGHT_GRAY
                    )
            );

            salaryTable.AddCell(
                new Cell()
                    .Add(
                        new Paragraph($"₹ {model.NetSalary:N2}")
                            .SimulateBold()
                    )
                    .SetPadding(10)
                    .SetBackgroundColor(
                        ColorConstants.LIGHT_GRAY
                    )
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.BLUE)
            );

            document.Add(salaryTable);

            // =====================================================
            // FOOTER
            // =====================================================

            document.Add(
                new Paragraph(" ")
                    .SetMarginTop(20)
            );

            document.Add(
                new Paragraph(
                    "This is a computer-generated payslip and does not require a signature."
                )
                .SetFontSize(9)
                .SetFontColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER)
            );

            document.Add(
                new Paragraph("Generated by RatPDF.com")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.GRAY)
            );

            // CLOSE DOCUMENT
            document.Close();

            // RETURN PDF BYTES
            return stream.ToArray();
        }
    }
}
