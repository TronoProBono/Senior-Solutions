namespace SeniorSolutionsWeb.Models
{
    public class CommunityIssueVote
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public int CommunityIssueId { get; set; }
        public CommunityIssue CommunityIssue { get; set; }
        
    }
}
