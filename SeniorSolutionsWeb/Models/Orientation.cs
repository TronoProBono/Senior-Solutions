namespace SeniorSolutionsWeb.Models
{
    public class Orientation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrientationAttendee>? Attendees { get; set; }
    }
}
