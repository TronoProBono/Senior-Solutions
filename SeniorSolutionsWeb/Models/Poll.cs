using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Poll
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Question { get; set; }
        [MaxLength(200)]
        public string Answer { get; set; }
        public int Answer1Votes { get; set; }
        [MaxLength(200)]
        public string Answer2 { get; set; }
        public int Answer2Votes { get; set; }
        [MaxLength(200)]
        public string Answer3 { get; set; }
        public int Answer3Votes { get; set; }
        [MaxLength(200)]
        public string Answer4 { get; set; }
        public int Answer4Votes { get; set; }
        public List<PollVote> Votes { get; set; }
    }
}
