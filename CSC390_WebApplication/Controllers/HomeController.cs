using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello from Index action, Home Controller");
        }

        public IActionResult SecondAction(int id)
        {
            return Content($"Hello from second action {id}^2 = {id*id}");
        }

    }
}
