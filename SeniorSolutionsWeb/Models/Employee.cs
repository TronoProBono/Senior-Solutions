using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Employee : User
    {
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; } = DateTime.Now;
        public string? Position { get; set; }
        public List<ServiceRequest>? ServiceRequests { get; set; }
    }
}
