namespace SeniorSolutionsWeb.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateIncurred { get; set; } = DateTime.Now;
        public DateTime? DatePayed { get; set; }
        public int AmountOwed { get; set; }
        public int AmountPaid { get; set; } = 0;
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
