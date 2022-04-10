
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class CommunityIssue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MinLength(25)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public uint UpVotes { get; set; } = 0;
        public uint DownVotes { get; set; } = 0;
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }
        public List<CommunityIssueVote>? CommunityIssueVotes { get; set; }
        public List<CommunityIssueReply> CommunityIssueReplies { get; set; }
    }
}
