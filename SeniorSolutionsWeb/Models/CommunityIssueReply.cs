namespace SeniorSolutionsWeb.Models
{
    public class CommunityIssueReply
    {
        public int Id { get; set; }
        public int CommunityIssueID { get; set; }
        public CommunityIssue CommunityIssue { get; set; }
        public int ResidentID { get; set; }
        public Resident Resident { get; set; }
        public string ResidentName { get; set; }
        public string? Response { get; set; }
        public DateTime DateResponse { get; set; } = DateTime.Now;
    }
}