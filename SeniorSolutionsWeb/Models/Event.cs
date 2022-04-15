namespace SeniorSolutionsWeb.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Resident>? Residents { get; set; }
        //public List<EventRoles> Roles { get; set; }
        public List<Invite>? Invites { get; set; }
        //public List<EventMembership>? Memberships { get; set; }
    }
}
