using CSC390_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class BookingController : Controller
    {
        //Placeholder until DB is implemented
        private List<Booking> BookingList = new();

        public BookingController()
        {
            //Adding bookings to list
            BookingList.Add(new Booking()
            {
                Id = 45,
                Created = DateTime.Parse("12/12/2022"),
                ServiceId = 1,
                CustomerName = "Joe",
                CustomerEmail = "joe@gmail.com"
            });
            BookingList.Add(new Booking()
            {
                Id = 76,
                Created = DateTime.Now,
                ServiceId = 0,
                CustomerName = "Patty",
                CustomerEmail = "PatriciaJones@mail.com"
            }) ;
            BookingList.Add(new Booking()
            {
                Id = 1,
                Created = DateTime.Parse("08/06/2020"),
                ServiceId = 3,
                CustomerName = "John",
                CustomerEmail = "John@mail.com"
            });
            BookingList.Add(new Booking()
            {
                Id = 5,
                Created = DateTime.Parse("07/06/2007"),
                ServiceId = 3,
                CustomerName = "Sam",
                CustomerEmail = "Sam@mail.com"
            });
            BookingList.Add(new Booking()
            {
                Id = 2,
                Created = DateTime.Parse("02/06/2023"),
                ServiceId = 1,
                CustomerName = "Kayla Rose",
                CustomerEmail = "krandfam@mail.com"
            });
        }
        public IActionResult Index() //Default page
        { 
            return View(BookingList); //Pass info to view
        }
        public IActionResult ListAll()
        {
            //Show all bookings, same as index
            return RedirectToAction("Index"); //Reroute to index
        }

        public IActionResult ShowDetails(int id)
        {
            //Show details about each booking

            //Search through BookingList using LINQ
            Booking? b = BookingList.FirstOrDefault(b => b.Id == id);
            ViewBag.id = id;
            return View(b);
        }
        public IActionResult AddBooking()
        {
            return View();
        }
    }

}
