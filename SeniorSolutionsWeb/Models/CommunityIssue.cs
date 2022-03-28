
namespace SeniorSolutionsWeb.Models
{
    public class CommunityIssue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}
