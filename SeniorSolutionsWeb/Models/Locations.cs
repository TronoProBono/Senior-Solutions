using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Locations
    {
        [Key]
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        public List<ClubMeeting>? Meetings { get; set; }
    }
}
