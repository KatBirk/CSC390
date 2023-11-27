using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.ViewModels
{
	public class LoginViewModel
	{
		[Display(Name = "Username")]
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
