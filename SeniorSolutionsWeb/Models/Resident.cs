using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Resident
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        //Nullable property since not every resident may have a middle name
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Residency Status")]
        public string ResidencyStatus { get; set; }
        [Display(Name = "Resident Lease Number")]
        public int ResidentLeaseNumber { get; set; }
        //[DataType(DataType.DateTime)] Uneccessary assignment with DataAnnotation
        [Display(Name = "Date Account Created")]
        public DateTime DateAccountCreated { get; set; } = DateTime.Now;

    }
}
