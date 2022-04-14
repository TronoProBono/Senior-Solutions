using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class InviteViewModel
    {
        [Key]
        [Display(Name = "Invite ID")]
        public int ID { get; set; }

        [Display(Name = "Resident ID")]
        public int ResidentID { get; set; }

        [Display(Name = "Club ID")]
        public int? ClubID { get; set; }

        [Display(Name = "Club Name")]
        public string? ClubName { get; set; }

        [Display(Name = "Club Role ID")]
        public int? RoleID { get; set; }

        [Display(Name = "Club Role ID")]
        public string? RoleName { get; set; }

        [Display(Name = "Event ID")]
        public int? EventID { get; set; }

        [Display(Name = "Event Name")]
        public string? EventName { get; set; }

        [Display(Name = "Event Role ID")]
        public int? EventRoleID { get; set; }

        [Display(Name = "Event Role ID")]
        public string? EventRoleName { get; set; }

    }
}
