using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public string Password { get; set; }
        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; } = DateTime.Now;
        public string? Position { get; set; }
    }
}
