using ratpdf.Content;

namespace ratpdf.Services.Seo
{
    internal static class ContentGuideSearchScore
    {
        private static readonly Dictionary<string, int> TrafficScore = new(StringComparer.OrdinalIgnoreCase)
        {
            ["High"] = 3,
            ["Medium"] = 2,
            ["Low"] = 1,
        };

        private static readonly Dictionary<string, int> PriorityScore = new(StringComparer.OrdinalIgnoreCase)
        {
            ["P0"] = 3,
            ["P1"] = 2,
            ["P2"] = 1,
        };

        public static int Estimate(string slug)
        {
            var roadmap = ContentRoadmapIndex.Get(slug);
            if (roadmap == null)
                return 1;

            var traffic = TrafficScore.GetValueOrDefault(roadmap.TrafficPotential, 1);
            var priority = PriorityScore.GetValueOrDefault(roadmap.Priority, 1);
            return traffic * priority;
        }
    }
}
