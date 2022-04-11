using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ClubMembership
    {
        [Key]
        [Display(Name = "Meet ID")]
        public int MeetId { get; set; }

        [Display(Name = "Meet ID")]
        public int ClubId { get; set; }

        [Display(Name = "Resident Name")]
        public int ResidentID { get; set; }

        [Display(Name = "Role Privileges")]
        public int RoleID { get; set; }

    }
}
