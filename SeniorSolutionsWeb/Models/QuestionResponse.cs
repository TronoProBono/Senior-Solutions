namespace SeniorSolutionsWeb.Models
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public string Response { get; set; }
    }
}
