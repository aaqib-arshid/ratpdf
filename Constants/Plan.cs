namespace ratpdf.Constants
{
    public class Plan
    {
        public const string Pro_Monthly = "plan_SpJkFZVM1Jzlix";
        public const string Business_Monthly = "plan_SonQzgvkbHECBH";
        public static string GetPlanName(string planId)
        {
            return planId switch
            {
                Pro_Monthly => "Pro Monthly",
                Business_Monthly => "Business Monthly",
                _ => "Free Plan"
            };
        }
    }
}
