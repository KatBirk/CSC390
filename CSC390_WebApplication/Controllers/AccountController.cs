using CSC390_WebApplication.Data;
using CSC390_WebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
	public class AccountController : Controller
	{
		//Inject signInManager
		private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
			_signInManager = signInManager;
			_userManager = userManager;
        }

        //Login
		public IActionResult Login() //Get the form
		{
			if (User != null && User.Identity != null && User.Identity.IsAuthenticated == true)
			{
				return RedirectToAction("Index", "Booking");
			}
			return View();	
		}
		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel) 
        {
            if (ModelState.IsValid)
			{
				//attempt login
				var result = await _signInManager.PasswordSignInAsync(loginModel.Username, 
					loginModel.Password, loginModel.RememberMe, false);


				//Check success
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Booking");
				}
            }
            //If login failed
			ModelState.AddModelError("", "Failed to login");
            return View(loginModel);
        }


        //logout
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("HomePage", "Home");
        }

		//register
		public IActionResult Register() //will give us registration form
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register) //saves the new user
        {
			if (ModelState.IsValid) 
			{
				//attempt account registration
				User newUser = new()
				{
					FirstName = register.Firstname,
					LastName = register.Lastname,
					Email = register.Email,
					UserName = register.Username
				};
				var result = await _userManager.CreateAsync(newUser, register.Password);

				
				//check result
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Booking");
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("",error.Description);
					}
				}
			}
			//something went wrong...

            return View(register);
        }
    }
}
