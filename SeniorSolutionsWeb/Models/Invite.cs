using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorSolutionsWeb.Models
{
    public class Invite
    {
        [Key]
        [Display(Name = "Invite ID")]
        public int ID { get; set; }

        [Display(Name = "Resident ID")]
        public int ResidentID { get; set; }

        [Display(Name = "Club ID")]
        public int? ClubID { get; set; }

        [Display(Name = "Club Role ID")]
        [ForeignKey("ClubRoles")]
        public int? RoleID { get; set; }

        [Display(Name = "Event ID")]
        public int? EventID { get; set; }

        [Display(Name = "Event Role ID")]
        [ForeignKey("EventRoles")]
        public int? EventRoleID { get; set; }

    }
}
