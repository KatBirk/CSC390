using Microsoft.AspNetCore.Identity;

namespace CSC390_WebApplication.Data
{
	public class User : IdentityUser
	{
        public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
