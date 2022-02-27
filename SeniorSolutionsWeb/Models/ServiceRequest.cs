using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        [Display(Name = "Requestor Name")]
        public string RequestorName { get; set; }
        [Display(Name = "Requestor Id")]
        public int RequestorId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "New";
        [Display(Name = "Employee Assigned Id")]
        public int? EmployeeAssignedId { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
    }
}
