namespace ratpdf.Models.PaySlip
{
    public class PayslipModel
    {
        public string CompanyName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string PayPeriod { get; set; } = string.Empty;

        public decimal BasicSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }

        public IFormFile CompanyLogo { get; set; }

        public decimal NetSalary =>
            BasicSalary + Bonus - Deductions;
    }
}
