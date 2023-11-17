using CSC390_WebApplication.Validators;
using System.ComponentModel.DataAnnotations;
namespace CSC390_WebApplication.Models
{
    public enum Status
    {
        [Display(Name = "Ready")] READY,
        [Display(Name = "Complete")] COMPLETE,
        [Display(Name = "Pending")] PENDING,
        [Display(Name ="Cancelled")]CANCELLED 
    }
    public class Booking
    {
        //[Required(ErrorMessage =" Please enter an id")]
        //[Display (Name="ID ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must specify a creation date")]
        [Display(Name = "Date created ")]
        [CheckDateAfter2000(ErrorMessage = "A valid date is between year 2000 and today")]
        [DataType(DataType.Date)] //Data type validation
        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "Please input a service")]
        [Display(Name = "Service chosen ")]
        public int? ServiceId { get; set; } //Add FK reference to Service

        [Required(ErrorMessage = "Please input a name")] //Validation attribute
        //[StringLength(50,MinimumLength = 2)] 
        [StringMinLengthOf2(ErrorMessage = "A valid name is longer than 2 characters")]
        [Display(Name = "Customer name ")]
        public String? CustomerName { get; set; } //name of person who made the booking

        [Display(Name = "Customer email ")]
        [EmailAddress] //Validation attribute
        public string? CustomerEmail { get; set; } //Email of person who made the booking

        [Phone] //Validation attribute
        [Display(Name = "Phone Number ")]
        public string? PhoneNumber { get; set; }

        [Display(Name ="Status ")]
        public Status Status { get; set; }

		[Display(Name = "Customer photo")]
		public byte[]? CustomerImage { get; set; }

	}
}
