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
        public List<CommunityIssueReply>? CommunityIssueReplies { get; set; }
        public List<CommunityIssueVote>? CommunityIssueVotes { get; set; }
        public List<Event>? Events { get; set; }
        public List<Fee>? Fees { get; set; }
        public List<ServiceRequest>? ServiceRequests { get; set; }
        public List<Invite>? Invites { get; set; }
        //public List<EventMembership>? EventMembershipList { get; set; }
        //public List<ClubMembership>? ClubMemberships { get; set; }
    }
}
