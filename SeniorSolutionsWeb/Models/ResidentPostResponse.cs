namespace SeniorSolutionsWeb.Models
{
    public class ResidentPostResponse
    {
        public int Id { get; set; }
        public int IssueID { get; set; }
        public CommunityIssue CommunityIssue { get; set; }
        public int ResidentID { get; set; }
        public Resident Resident { get; set; }
        public int Vote { get; set; }
        public string? Response { get; set; }
        public DateTime DateResponse { get; set; } = DateTime.Now;
    }
}