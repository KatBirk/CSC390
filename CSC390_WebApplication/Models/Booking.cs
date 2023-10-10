using System.ComponentModel.DataAnnotations;
namespace CSC390_WebApplication.Models
{
    public enum Status {READY,COMPLETE,PENDING,CANCELLED }
    public class Booking
    {
        [Display (Name="ID ")]
        public int Id { get; set; }
        [Display(Name = "Date created ")]
        [DataType(DataType.Date)] //Data type validation
        public DateTime? Created { get; set; }
        [Display(Name = "Service chosen ")]
        public int ServiceId { get; set; } //Add FK reference to Service
        [Display(Name = "Customer name ")]
        public String CustomerName { get; set; } //name of person who made the booking
        [Display(Name = "Customer email ")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; } //Email of person who made the booking
        [Display(Name ="Status ")]
        public Status Status { get; set; }

    }
}
