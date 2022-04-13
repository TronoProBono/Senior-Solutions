namespace SeniorSolutionsWeb.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
