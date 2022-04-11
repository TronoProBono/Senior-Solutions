using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [ValidateNever]
        [Required]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Account Created")]
        public DateTime DateAccountCreated { get; set; } = DateTime.Now;
        
    }
}
