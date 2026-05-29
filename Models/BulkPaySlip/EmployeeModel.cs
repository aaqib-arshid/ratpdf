namespace ratpdf.Models.BulkPaySlip
{
    public class EmployeeModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;   
        public string PayPeriod { get; set; } = string.Empty;   
        public Dictionary<string, decimal> Earnings { get; set; } = new();
        public Dictionary<string, decimal> Deductions { get; set; } = new();
    }
}