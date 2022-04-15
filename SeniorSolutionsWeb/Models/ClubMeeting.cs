using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubMeeting
    {
        [Key]
        [Display(Name = "Meeting ID")]
        [DefaultValue(-1)]
        public int MeetId { get; set; } = -1;

        [Display(Name = "Club ID")]
        [DefaultValue(-1)]
        public int ClubId { get; set; } = -1;
        public Club Club { get; set; }

        [Display(Name = "Meeting Place")]
        [DefaultValue(-1)]
        public int MeetingPlace { get; set; } = -1;
        //public Locations Location { get; set; }

        [Display(Name = "Meeting Day")]
        [DefaultValue("")]
        public String MeetingDay { get; set; } = "";

        [Display(Name = "Meeting Start Time")]
        [DefaultValue(-1)]
        public int? StartTime { get; set; } = -1;

        [Display(Name = "Meeting End Time")]
        [DefaultValue(-1)]
        public int? EndTime { get; set; } = -1;
    }
}
