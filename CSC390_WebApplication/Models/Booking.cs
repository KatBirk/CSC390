namespace CSC390_WebApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int ServiceId { get; set; } //Add FK reference to Service
        public String CustomerName { get; set; } //name of person who made the booking
        public string CustomerEmail { get; set; } //Email of person who made the booking

    }
}
