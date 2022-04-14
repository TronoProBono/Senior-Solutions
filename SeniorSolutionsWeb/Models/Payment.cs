using System.ComponentModel.DataAnnotations;

namespace SeniorSolutionsWeb.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int ResidentID { get; set; }
        public string Catagory { get; set; }
        public int Amount { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool? isPaid { get; set; }
    }
}
