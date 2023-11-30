using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
