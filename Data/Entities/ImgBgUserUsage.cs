namespace ratpdf.Data.Entities
{
    public class ImgBgUserUsage
    {
        public int Id { get; set; }

        public string UserKey { get; set; } = string.Empty;

        public int FreeDownloadsUsed { get; set; }

        public DateTime LastResetDate { get; set; }
    }
}
