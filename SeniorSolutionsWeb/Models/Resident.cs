using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Resident : User
    {

        [Display(Name = "Residency Status")]
        public string ResidencyStatus { get; set; } = "Valid";
        [Display(Name = "Resident Lease Number")]
        public int ResidentLeaseNumber { get; set; }
        public List<CommunityIssue>? CommunityIssueList { get; set; }
        public List<CommunityIssueReply> CommunityIssueReplies { get; set; }
        public List<CommunityIssueVote>? CommunityIssueVotes { get; set; }
        //[DataType(DataType.DateTime)] Uneccessary assignment with DataAnnotation
    }
}
