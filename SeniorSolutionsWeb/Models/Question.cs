namespace SeniorSolutionsWeb.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<QuestionResponse>? Responses { get; set; }
    }
}
