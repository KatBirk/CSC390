using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Error() 
        {
            return View();
        }

    }
}
