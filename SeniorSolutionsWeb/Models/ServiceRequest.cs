using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorSolutionsWeb.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        [Display(Name = "Requestor Name")]
        public string RequestorName { get; set; }
        [Display(Name = "Requestor Id")]
        [ForeignKey("Resident")]
        public int RequestorId { get; set; }
        public Resident Resident { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "New";
        [Display(Name = "Employee Assigned Id")]
        [ForeignKey("Employee")]
        public int EmployeeAssignedId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
    }
}
