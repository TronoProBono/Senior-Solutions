using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubViewModel
    {
        [Display(Name = "Club ID")]
        [DefaultValue(-1)]
        public int ClubId { get; set; } = -1;

        [Display(Name = "Meeting Day")]
        [DefaultValue("")]
        public String ClubName { get; set; } = "";

        [Display(Name = "Date Account Created")]
        [DefaultValue("")]
        public DateTime DateClubCreated { get; set; } = DateTime.Now;

        [Display(Name = "Meeting Place")]
        [DefaultValue("")]
        public String LocationName { get; set; } = "";

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
