using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.Data
{
	public class User : IdentityUser
	{
		[Display(Name ="First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }
	}
}
