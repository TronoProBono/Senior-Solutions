namespace SeniorSolutionsWeb.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Resident>? Residents { get; set; }
    }
}
