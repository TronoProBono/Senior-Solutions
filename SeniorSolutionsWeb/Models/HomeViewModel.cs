namespace SeniorSolutionsWeb.Models
{
    public class HomeViewModel
    {
        public IEnumerable<CommunityIssue> CommunityIssues { get; set; }
        public IEnumerable<Poll> Polls { get; set; }
    }
}
