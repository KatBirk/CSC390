using CSC390_WebApplication.Validators;
using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.Models
{
    public enum ServiceType {
		[Display(Name = "Beauty")] BEAUTY,
		[Display(Name = "Technology")] TECH,
		[Display(Name = "Car")] CAR,
		[Display(Name = "Other")] OTHER
	}
    public class Service
    {
        public int Id { get; set; }

		[Display(Name = "Service name ")]
		[Required(ErrorMessage = "You must specify a name for the service")]
		[DataType(DataType.Text)] //Data type validation
		[StringLength(50, MinimumLength =2)]
		public String? ServiceName { get; set; }

		[Display(Name = "Service description ")]
		[StringMinLengthOf2(ErrorMessage = "Your service description must be longer than 2 characters")]
		[Required(ErrorMessage ="You must have a service description")]
		public String? ServiceDescription { get; set; }

		[Display(Name = "Service type ")]
		public ServiceType ServiceType { get; set;}

		[Display(Name = "Price ")]
		[DataType(DataType.Currency)]
		[Required(ErrorMessage ="Please enter a price for the service")]
		public double? Price { get; set; }
    }
}
