using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubRoles
    {
        [Key]
        [Display(Name = "Role ID")]
        public int RoleID { get; set; }

        [Display(Name = "Club ID")]
        public int ClubId { get; set; }

        [Display(Name = "Role Rank")]
        public int RoleRank { get; set; }

        [Display(Name = "Role Name")]
        public String RoleName { get; set; }

        [Display(Name = "Role Permissions")]
        public int RoleEval { get; set; }
        public List<Invite>? Invites { get; set; }
        //public List<ClubMembership>? ClubMembership { get; set; }
    }
}
