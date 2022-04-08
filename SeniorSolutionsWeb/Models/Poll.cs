using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Poll
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Question { get; set; } = string.Empty;
        [MaxLength(200)]
        [Display(Name = "Answer 1")]
        public string Answer { get; set; }
        public int Answer1Votes { get; set; } = 0;
        [MaxLength(200)]
        [Display(Name = "Answer 2")]
        public string Answer2 { get; set; }
        public int Answer2Votes { get; set; } = 0;
        [MaxLength(200)]
        [Display(Name = "Answer 3")]
        public string? Answer3 { get; set; }
        public int Answer3Votes { get; set; } = 0;
        [MaxLength(200)]
        [Display(Name = "Answer 4")]
        public string? Answer4 { get; set; }
        public int Answer4Votes { get; set; } = 0;
        public List<PollVote>? Votes { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
