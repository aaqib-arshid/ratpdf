namespace ratpdf.Models
{
    public class IpResult
    {
        public string Query { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty ;
        public string RegionName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Lat { get; set; } = string.Empty;
        public string Lon { get; set; } = string.Empty;
        public string ISP { get; set; } = string.Empty;
        public string Org { get; set; } = string.Empty;
    }
}
