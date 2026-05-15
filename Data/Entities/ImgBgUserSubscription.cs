namespace ratpdf.Data.Entities
{
    public class ImgBgUserSubscription
    {
        public int Id { get; set; }

        public string UserKey { get; set; } = string.Empty;

        public string PlanName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
