using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

    }
}
