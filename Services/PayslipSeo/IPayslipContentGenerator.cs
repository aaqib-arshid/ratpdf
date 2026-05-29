using Microsoft.Extensions.Caching.Memory;
using ratpdf.Models;
using ratpdf.Models.PaySlipSEO;

namespace ratpdf.Services.PayslipSeo
{
    public interface IPayslipContentGenerator
    {
        Task<PayslipPageContent> GenerateAsync(string slug);
    }
    public class PayslipContentGenerator : IPayslipContentGenerator
    {
        private readonly IPayslipAllowedSlugsService _slugService;
        private readonly IMemoryCache _cache;
        private const string ToolUrl = "https://ratpdf.com/free-payslip-generator";

        // Sample data for uniqueness
        private static readonly string[] CompanyNames = { "Acme Inc.", "TechCorp", "BlueSky Ltd", "NexGen Solutions", "FinEdge" };
        private static readonly string[] PayPeriods = { "January 2025", "February 2025", "March 2025", "Q1 2025" };
        private static readonly Random _rand = new();

        public PayslipContentGenerator(IPayslipAllowedSlugsService slugService, IMemoryCache cache)
        {
            _slugService = slugService;
            _cache = cache;
        }

        public async Task<PayslipPageContent> GenerateAsync(string slug)
        {
            var cacheKey = $"PayslipPage_{slug}";
            if (_cache.TryGetValue(cacheKey, out PayslipPageContent? cached) && cached != null)
                return cached;

            var content = new PayslipPageContent
            {
                Slug = slug,
                UpdatedAt = DateTime.UtcNow,
                RelatedSlugs = GetRelatedSlugs(slug),
                Sections = new List<ContentSection>(),
                Faqs = new List<FaqItem>()
            };

            // Determine category from slug
            var category = GetCategory(slug);
            string friendlyName = SlugToFriendlyName(slug);

            switch (category)
            {
                case "monthly":
                    BuildMonthlyContent(content, friendlyName, slug);
                    break;
                case "weekly":
                    BuildWeeklyContent(content, friendlyName, slug);
                    break;
                case "contractor":
                    BuildContractorContent(content, friendlyName, slug);
                    break;
                case "free":
                    BuildFreeContent(content, friendlyName, slug);
                    break;
                case "pdf":
                    BuildPdfContent(content, friendlyName, slug);
                    break;
                case "word":
                    BuildWordContent(content, friendlyName, slug);
                    break;
                default:
                    BuildGenericContent(content, friendlyName, slug);
                    break;
            }

            // Add sample payslip table (uniquely generated per slug)
            content.SamplePayslipHtml = GenerateSamplePayslipTable(slug);
            _cache.Set(cacheKey, content, TimeSpan.FromHours(24));
            return content;
        }

        private string GetCategory(string slug)
        {
            if (slug.Contains("monthly")) return "monthly";
            if (slug.Contains("weekly")) return "weekly";
            if (slug.Contains("contractor")) return "contractor";
            if (slug.Contains("free")) return "free";
            if (slug.Contains("pdf")) return "pdf";
            if (slug.Contains("word") || slug.Contains("doc")) return "word";
            return "generic";
        }

        private string SlugToFriendlyName(string slug)
        {
            return slug.Replace("-", " ")
                       .Replace("pay slip", "Pay Slip")
                       .Replace("salary slip", "Salary Slip")
                       .Replace("pay stub", "Pay Stub")
                       .Trim();
        }

        private List<string> GetRelatedSlugs(string currentSlug)
        {
            var all = _slugService.GetAllSlugs();
            return all.Where(s => s != currentSlug)
                      .OrderBy(_ => Guid.NewGuid())
                      .Take(5)
                      .ToList();
        }

        private string GetToolCta(string friendlyName)
        {
            return $@"
<div class='tool-cta' style='background:#eef2ff; padding:20px; border-radius:12px; margin:25px 0; text-align:center;'>
    <a href='{ToolUrl}' target='_blank' rel='noopener' style='background:#2563eb; color:white; padding:12px 28px; text-decoration:none; border-radius:8px; font-weight:bold;'>
        ✨ Generate {friendlyName} Instantly
    </a>
    <p style='margin-top:12px;'>No sign-up – download as PDF or print.</p>
</div>";
        }

        // --- Unique content builders ---

        private void BuildMonthlyContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"{friendlyName} – Monthly Salary Slip Generator | Free PDF Download";
            content.MetaDescription = $"Create professional monthly pay slips for employees. {friendlyName} includes earnings, deductions, and net pay. Instant download.";
            content.HeadingH1 = $"{friendlyName} – Generate Monthly Payslip Online";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>A monthly salary slip is a legal document provided to employees every month. It shows gross salary, deductions (tax, provident fund), and net take‑home pay.</p>
<p>Our tool lets you customise company details, employee info, and payment components in seconds.</p>";

            content.Sections = new List<ContentSection>
            {
                new() {
                    Heading = "What a monthly pay slip includes",
                    Html = @"
<ul>
    <li>Employee name, ID, designation</li>
    <li>Pay period (e.g., March 2025)</li>
    <li>Earnings: Basic, HRA, allowances</li>
    <li>Deductions: Income tax, EPF, professional tax</li>
    <li>Net payable amount</li>
</ul>"
                },
                new() {
                    Heading = "Why use our monthly payslip generator?",
                    Html = "<p>✔️ Compliant with tax regulations ✔️ Editable templates ✔️ Download as PDF ✔️ Free for up to 10 slips/month</p>"
                }
            };

            content.Faqs = new List<FaqItem>
            {
                new() { Question = "Is a monthly salary slip mandatory?", Answer = "Yes, in many countries employers must issue monthly payslips to full‑time employees." },
                new() { Question = "Can I add reimbursements?", Answer = "Absolutely – our generator includes custom earning fields." }
            };
        }

        private void BuildWeeklyContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"{friendlyName} – Weekly Pay Stub Creator | Hourly & Overtime";
            content.MetaDescription = $"Generate weekly pay stubs for hourly workers, freelancers, or part‑time staff. Includes overtime rates and net pay.";
            content.HeadingH1 = $"{friendlyName} – Weekly Payment Record";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Weekly pay stubs are ideal for construction, retail, and hospitality industries. They track hours worked, regular pay, overtime, and deductions per week.</p>";

            content.Sections = new List<ContentSection>
            {
                new() {
                    Heading = "Components of a weekly pay stub",
                    Html = @"
<ul>
    <li>Week ending date</li>
    <li>Regular hours (e.g., 40h × $20)</li>
    <li>Overtime hours (1.5× or 2× rate)</li>
    <li>Reimbursements or bonuses</li>
    <li>Tax deductions (federal/state)</li>
</ul>"
                }
            };
            // Unique FAQ for weekly
            content.Faqs.Add(new FaqItem { Question = "How is overtime calculated?", Answer = "Overtime is usually 1.5× the regular hourly rate for hours above 40/week." });
        }

        private void BuildContractorContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"{friendlyName} – Independent Contractor Pay Stub | 1099 Friendly";
            content.MetaDescription = $"Create professional pay stubs for freelancers and independent contractors. No tax deductions – just gross payment and project details.";
            content.HeadingH1 = $"{friendlyName} – Contractor Payment Slip";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Contractors don't receive traditional salary slips. Our tool generates a clear payment record showing project name, invoice number, hours worked, and total amount paid.</p>";

            content.Sections = new List<ContentSection>
            {
                new() {
                    Heading = "What to include on a contractor pay stub",
                    Html = @"
<ul>
    <li>Contractor’s business name & address</li>
    <li>Client company details</li>
    <li>Invoice number & date</li>
    <li>Service description & hourly/flat fee</li>
    <li>Total amount (no tax deductions)</li>
</ul>"
                }
            };
        }

        private void BuildFreeContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"100% Free {friendlyName} – No Credit Card Required";
            content.MetaDescription = $"Generate unlimited free pay stubs online. Download PDF instantly. No watermark, no registration.";
            content.HeadingH1 = $"Free {friendlyName} – Zero Cost, Unlimited Use";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Our free pay stub generator helps small businesses, landlords, and individuals create professional salary slips without any hidden fees.</p>";

            content.Faqs = new List<FaqItem>
            {
                new() { Question = "Is there a limit on free generation?", Answer = "No – you can create as many pay stubs as you need." },
                new() { Question = "Do I need to create an account?", Answer = "No account required. All processing is anonymous." }
            };
        }

        private void BuildPdfContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"{friendlyName} – Download as PDF | Printable Pay Slip";
            content.MetaDescription = $"Create a payslip and save as PDF for email or records. High‑resolution, print‑ready format.";
            content.HeadingH1 = $"{friendlyName} – PDF Pay Slip Maker";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>PDF payslips are secure, non‑editable, and universally accepted by banks and employers. Our generator produces a polished PDF in one click.</p>";
        }

        private void BuildWordContent(PayslipPageContent content, string friendlyName, string slug)
        {
            content.MetaTitle = $"{friendlyName} – Editable Word Template (DOCX)";
            content.MetaDescription = $"Download payslip in Microsoft Word format. Customise logo, font, and layout before printing.";
            content.HeadingH1 = $"{friendlyName} – Word Document Payslip";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Word format allows full customisation – add your company logo, change colors, or insert additional rows.</p>";
        }

        private void BuildGenericContent(PayslipPageContent content, string friendlyName, string slug)
        {
            // SEO metadata – rich and keyword‑dense
            content.MetaTitle = $"{friendlyName} – Complete Guide, Template & Free Generator";
            content.MetaDescription = $"Learn what a {friendlyName} is, what it must include, legal requirements, and generate yours for free. Download PDF, Word, or Excel.";
            content.HeadingH1 = $"{friendlyName} – Everything You Need to Know + Free Generator";

            // Introduction with CTA and clear value
            content.IntroductionHtml = GetToolCta(friendlyName) + $@"
<div style='background:#f0fdf4; padding:15px; border-left:4px solid #22c55e; margin:20px 0;'>
    <strong>⚡ Quick answer:</strong> A {friendlyName} is an official document showing earnings, deductions, and net pay for an employee over a specific period.
</div>

<p>Whether you're an employer, HR professional, freelancer, or employee – understanding and creating proper pay slips is essential. This comprehensive guide covers:</p>
<ul>
    <li>📌 What information a payslip must contain (legally required fields)</li>
    <li>📌 Differences between a pay slip, salary slip, and pay stub</li>
    <li>📌 How to generate a {friendlyName} in under 2 minutes – for free</li>
    <li>📌 Common mistakes to avoid</li>
    <li>📌 Downloadable templates (Excel, Word, PDF)</li>
</ul>";

            // Main sections – lengthy and informative
            content.Sections = new List<ContentSection>
    {
        new()
        {
            Heading = "1. What is a Payslip / Salary Slip / Pay Stub?",
            Html = @"
<p>A <strong>payslip</strong> (also called a salary slip, pay stub, or pay advice) is a document issued by an employer to an employee that outlines the details of their pay for a specific period. It serves as proof of income, employment, and tax deductions.</p>
<p>In most countries, employers are legally required to provide a payslip to every employee – whether paid monthly, weekly, or hourly. Digital payslips (PDF) are now the norm, but printed versions are still accepted.</p>"
        },
        new()
        {
            Heading = "2. Mandatory Fields in a Payslip (Legal Requirements)",
            Html = @"
<table style='width:100%; border-collapse:collapse; margin:15px 0;'>
    <tr style='background:#e2e8f0;'><th style='padding:10px; text-align:left;'>Field</th><th style='padding:10px; text-align:left;'>Description</th></tr>
    <tr><td style='padding:8px; border-bottom:1px solid #ddd;'><strong>Employee name & ID</strong></td><td style='padding:8px; border-bottom:1px solid #ddd;'>Unique identifier (e.g., employee number or PAN)</td></tr>
    <tr><td style='padding:8px; border-bottom:1px solid #ddd;'><strong>Employer name & address</strong></td><td style='padding:8px; border-bottom:1px solid #ddd;'>Legal entity paying the salary</td></tr>
    <tr><td style='padding:8px; border-bottom:1px solid #ddd;'><strong>Pay period dates</strong></td><td style='padding:8px; border-bottom:1px solid #ddd;'>e.g., 1st March 2025 – 31st March 2025</td></tr>
    <tr><td style='padding:8px; border-bottom:1px solid #ddd;'><strong>Gross earnings</strong></td><td style='padding:8px; border-bottom:1px solid #ddd;'>Basic + HRA + allowances + bonuses + overtime</td></tr>
    <tr><td style='padding:8px; border-bottom:1px solid #ddd;'><strong>Deductions</strong></td><td style='padding:8px; border-bottom:1px solid #ddd;'>Tax (PAYE/Income tax), social security, provident fund, health insurance, loan repayments</td></tr>
    <tr><td style='padding:8px;'><strong>Net pay</strong></td><td style='padding:8px;'>Gross earnings minus total deductions. The amount actually paid to the employee.</td></tr>
</table>
<p>Additional common fields: pay rate (hourly/monthly), leave balance, employer contributions, and year‑to‑date totals.</p>"
        },
        new()
        {
            Heading = "3. Step‑by‑Step: How to Create a Professional Payslip",
            Html = @"
<ol>
    <li><strong>Gather employee information</strong> – Name, ID, designation, department, and pay period.</li>
    <li><strong>Calculate gross earnings</strong> – Add basic salary, HRA, special allowances, overtime, bonuses.</li>
    <li><strong>Calculate deductions</strong> – Income tax, provident fund, professional tax, insurance, any loan EMIs.</li>
    <li><strong>Compute net pay</strong> – Gross earnings – total deductions.</li>
    <li><strong>Use a template or generator</strong> – Our tool below does all the formatting automatically.</li>
    <li><strong>Download as PDF or Word</strong> – Email to employee or print for records.</li>
</ol>
<p>⏱️ The entire process takes less than 2 minutes using our free generator.</p>"
        },
        new()
        {
            Heading = "4. Payslip vs. Salary Slip vs. Pay Stub – Is there a difference?",
            Html = @"
<p>No real difference – the terms are used interchangeably. However, subtle variations exist by region:</p>
<ul>
    <li><strong>Payslip / Pay Slip</strong> – Common in UK, Australia, India, South Africa.</li>
    <li><strong>Salary Slip</strong> – Popular in India and Middle East, often for monthly paid employees.</li>
    <li><strong>Pay Stub</strong> – Standard term in the US and Canada, especially for hourly or weekly workers.</li>
</ul>
<p>All three documents contain the same core information: earnings, deductions, and net pay. Our generator creates all three formats automatically.</p>"
        },
        new()
        {
            Heading = "5. Common Mistakes to Avoid When Making a Payslip",
            Html = @"
<ul>
    <li>❌ <strong>Missing the pay period</strong> – Without dates, the slip is invalid for legal purposes.</li>
    <li>❌ <strong>Incorrect tax calculations</strong> – Use our auto‑tax feature to avoid penalties.</li>
    <li>❌ <strong>Forgetting year‑to‑date (YTD) totals</strong> – Many loan applications require YTD earnings and deductions.</li>
    <li>❌ <strong>Using non‑editable formats too early</strong> – Always keep a master copy (Word/Excel) before converting to PDF.</li>
    <li>❌ <strong>Not including employer’s legal name</strong> – Contractors or freelancers must use their registered business name.</li>
</ul>"
        },
        new()
        {
            Heading = "6. Example Payslip Template (Text Format)",
            Html = @"
<pre style='background:#f1f5f9; padding:15px; border-radius:8px; overflow-x:auto;'>
╔══════════════════════════════════════════════════════════╗
║                    MONTHLY PAY SLIP                      ║
╠══════════════════════════════════════════════════════════╣
║ Employer:   TechCorp Solutions                           ║
║ Employee:   Jane Doe (ID: EMP1001)                       ║
║ Designation: Senior Software Engineer                    ║
║ Pay Period: March 2025 (01/03/2025 – 31/03/2025)        ║
╠══════════════════════════════════════════════════════════╣
║ EARNINGS                     DEDUCTIONS                  ║
║ Basic Salary     $5,000      Income Tax       $800       ║
║ HRA              $2,000      Provident Fund   $720       ║
║ Allowances       $1,000      Professional Tax  $200      ║
║ Bonus              $500      Health Insurance  $150      ║
║                                                          ║
║ Gross Pay        $8,500      Total Deductions  $1,870    ║
║                                                          ║
║                      NET PAY = $6,630                     ║
╚══════════════════════════════════════════════════════════╝
</pre>
<p>You can customise this template with your company logo, colours, and additional fields.</p>"
        }
    };

            // FAQ – at least 5, covering common user questions
            content.Faqs = new List<FaqItem>
    {
        new() { Question = "Is a digital payslip legally valid?", Answer = "Yes – in most countries, a PDF or printed version of a digital payslip is legally equivalent to a paper one, as long as it contains all mandatory fields." },
        new() { Question = "Can I generate payslips for past months?", Answer = "Absolutely. Our generator allows you to select any past or future pay period. Backdated payslips are often needed for loan applications or visa processing." },
        new() { Question = "What if I make a mistake after generating?", Answer = "You can regenerate as many times as you like – there's no limit. Simply correct the data and click generate again." },
        new() { Question = "Do I need to download software or install anything?", Answer = "No. Our tool runs entirely in your browser. No downloads, no registration, no credit card." },
        new() { Question = "Can I add my company logo?", Answer = "Yes – our generator lets you upload a logo and choose from multiple professional templates." },
        new() { Question = "Is this tool free for unlimited payslips?", Answer = "Yes – we offer a completely free tier with up to 100 payslips per month. No watermark, no hidden fees." }
    };
        }

        // Generates a sample table with random (but slug‑consistent) numbers 
        private string GenerateSamplePayslipTable(string slug)
        {
            // Deterministic pseudo-random based on slug hash to keep caching consistent
            int seed = slug.GetHashCode();
            var r = new Random(seed);
            decimal basic = r.Next(2000, 8000);
            decimal hra = basic * 0.4m;
            decimal allowances = r.Next(500, 1500);
            decimal gross = basic + hra + allowances;
            decimal tax = gross * 0.1m;
            decimal provident = gross * 0.12m;
            decimal net = gross - tax - provident;

            string company = CompanyNames[r.Next(CompanyNames.Length)];
            string period = PayPeriods[r.Next(PayPeriods.Length)];

            return $@"
            <div style='border:1px solid #ccc; padding:15px; margin:20px 0; background:#fafafa;'>
                <h4>📄 Sample Payslip Preview</h4>
                <p><strong>{company}</strong> | Pay Period: {period}</p>
                <table style='width:100%; border-collapse:collapse;'>
                    <tr style='background:#e2e8f0;'><th>Earnings</th><th>Amount ($)</th><th>Deductions</th><th>Amount ($)</th></tr>
                    <tr><td>Basic Salary</td><td>{basic:F2}</td><td>Income Tax</td><td>{tax:F2}</td></tr>
                    <tr><td>HRA</td><td>{hra:F2}</td><td>Provident Fund</td><td>{provident:F2}</td></tr>
                    <tr><td>Other Allowances</td><td>{allowances:F2}</td><td></td><td></td></tr>
                    <tr style='font-weight:bold; background:#f1f5f9;'><td>Gross Pay</td><td>{gross:F2}</td><td>Total Deductions</td><td>{(tax + provident):F2}</td></tr>
                    <tr style='background:#cbd5e1;'><td colspan='2'><strong>Net Pay</strong></td><td colspan='2'><strong>{net:F2}</strong></td></tr>
                </table>
                <p class='text-sm'>*Actual amounts vary by company policy and local tax laws.</p>
            </div>";
        }
    }
}
