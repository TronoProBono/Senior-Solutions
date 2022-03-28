using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubMembership
    {
        [Key]
        [Display(Name = "Club ID")]
        public int ClubId { get; set; }

        [Display(Name = "Resident Name")]
        public string ResidentID { get; set; }

        [Display(Name = "Role Privileges")]
        public int RoleID { get; set; }

    }
}
