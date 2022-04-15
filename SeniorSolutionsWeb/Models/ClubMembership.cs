using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorSolutionsWeb.Models
{
    public class ClubMembership
    {
        [Key]
        [Display(Name = "Meet ID")]
        public int ClubId { get; set; }

        [Display(Name = "Resident Name")]
        public int ResidentID { get; set; }
        //public Resident Resident { get; set; }

        [Display(Name = "Role Privileges")]
        [ForeignKey("ClubRoles")]
        public int RoleID { get; set; }
        //public ClubRoles Roles { get; set; }

        [Display(Name = "Club ID")]
        [ForeignKey("Club")]
        public int CID { get; set; }
        public Club Club { get; set; }

    }
}
