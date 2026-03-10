namespace ratpdf.Models
{
    public class RingSize
    {
        public string US { get; set; } = string.Empty;
        public string UK { get; set; } = string.Empty;
        public string AU { get; set; } = string.Empty;
        public string EU { get; set; } = string.Empty;
        public string FR_RU { get; set; } = string.Empty;
        public string JP { get; set; } = string.Empty;
        public string CH { get; set; } = string.Empty;
        public string CN { get; set; } = string.Empty;
        public string IN { get; set; } = string.Empty;
        public double DiameterMM { get; set; }
        public double CircumferenceMM { get; set; }
    }
}
