using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Club
    {
        [Key]
        [Display(Name = "Club ID")]
        public int ClubId { get; set; }

        [Display(Name = "Club Name")]
        public string ClubName { get; set; }

        [Display(Name = "Date Account Created")]
        public DateTime DateClubCreated { get; set; } = DateTime.Now;
        public List<ClubMeeting>? ClubMeetings { get; set; }
        public List<Invite>? Invites { get; set; }
        public List<ClubMembership>? Memberships { get; set; }
    }
}
