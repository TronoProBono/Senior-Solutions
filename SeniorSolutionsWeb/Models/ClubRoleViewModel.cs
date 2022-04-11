using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubRoleViewModel
    {
        [Display(Name = "Club ID")]
        [DefaultValue(-1)]
        public int ClubId { get; set; } = -1;

        [Display(Name = "Club Name")]
        [DefaultValue("")]
        public String ClubName { get; set; } = "";

        [Display(Name = "Role Name")]
        public String RoleName { get; set; }

        [Display(Name = "Role Permisions")]
        public int RolePerms { get; set; }


    }
}
