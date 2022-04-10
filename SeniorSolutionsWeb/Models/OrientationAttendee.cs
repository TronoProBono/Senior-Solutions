namespace SeniorSolutionsWeb.Models
{
    public class OrientationAttendee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public int OrientationId { get; set; }
        public Orientation Orientation { get; set; }
    }
}
