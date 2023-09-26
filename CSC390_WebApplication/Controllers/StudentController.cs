using Microsoft.AspNetCore.Mvc;
using CSC390_WebApplication.Models;

namespace CSC390_WebApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Student controller, Index action");
        }

        public ViewResult Show(int id)
        {
            Student student = new Student();
            if (id == 1)
            {
                student.StudentId = 1;
                student.GPA = 4.0;
                student.Name = "Name";
                student.Major = Major.CS;
                student.AdmissionDate = DateTime.Now;
                student.IsVeteran = true;
            }
            else
            {
                student.StudentId = 2;
                student.GPA = 3.89;
                student.Name = "Name2";
                student.Major = Major.ART;
                student.AdmissionDate = DateTime.Now;
                student.IsVeteran = false;

            }
            ViewBag.student = student;
            return View();
        }

        public IActionResult GoToGoogle()
        {
            return Redirect("https://www.google.com");
        }
    }
}
