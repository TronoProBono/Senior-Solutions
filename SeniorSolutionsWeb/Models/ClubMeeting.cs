using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubMeeting
    {
        [Key]
        [Display(Name = "Meeting ID")]
        public int MeetId { get; set; }

        [Display(Name = "Club ID")]
        public int ClubId { get; set; }

        [Display(Name = "Meeting Place")]
        public int MeetingPlace { get; set; }

        [Display(Name = "Meeting Day")]
        public String MeetingDay { get; set; }

        [Display(Name = "Meeting Start Time")]
        public int? StartTime { get; set; }

        [Display(Name = "Meeting End Time")]
        public int? EndTime { get; set; }
    }
}
