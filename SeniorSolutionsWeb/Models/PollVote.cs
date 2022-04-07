namespace SeniorSolutionsWeb.Models
{
    public class PollVote
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public string VotedFor { get; set; }

    }
}
