using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index(int id)
        {
            return Content($"Hello from the Home Controller, index action. The id of the page is {id}");
        }

        public ViewResult HomePage()
        {
            return View();
        }

        public IActionResult Error() 
        {
            return View();
        }

    }
}
