namespace SeniorSolutionsWeb.Models
{
    public class HomeViewModel
    {
        public IEnumerable<CommunityIssue> CommunityIssues { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Poll> Polls { get; set; }
        public IEnumerable<Questionnaire> Questionnaires { get; set; }
        public IEnumerable<PollVote> Votes { get; set; }
        
    }
}
