using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Resident : User
    {
        
        [Display(Name = "Residency Status")]
        public string ResidencyStatus { get; set; }
        [Display(Name = "Resident Lease Number")]
        public int ResidentLeaseNumber { get; set; }
        //[DataType(DataType.DateTime)] Uneccessary assignment with DataAnnotation
    }
}
