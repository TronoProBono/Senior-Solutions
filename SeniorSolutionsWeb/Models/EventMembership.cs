using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class EventMembership
    {
        [Key]
        [Display(Name = "Event Membership ID")]
        public int ID { get; set; }

        [Display(Name = "Resident Name")]
        public int ResidentID { get; set; }

        [Display(Name = "Role Privileges")]
        public int RoleID { get; set; }

        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        [Display(Name = "Checked In")]
        public bool? CheckedIN { get; set; }

        [Display(Name = "Random Score")]
        public int? Score { get; set; }

    }
}
