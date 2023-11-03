using CSC390_WebApplication.Data;
using CSC390_WebApplication.Models;
using CSC390_WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    public class BookingController : Controller
    {

        //Injecting the service (placeholder until data persistence is implemented)
        //private IMyInterface _service; //old data before db
        private MyDbContext _dbContext;


        public BookingController( MyDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public IActionResult Index() //Default page
        { 
            return View(_dbContext.Bookings.ToList()); //Pass info to view
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
            Booking? b = _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
            ViewBag.id = id;
            return View(b);
        }
        [HttpGet]
        public IActionResult Add() //will only be called for get requests
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Booking newBooking) //Will only be called for post requests
        {
            if (!ModelState.IsValid) //Enforcing validation
            {
                return View();
            }
            _dbContext.Bookings.Add(newBooking);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", _dbContext.Bookings.ToList()); //New request, will create new instance of controller
            

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Search for specific booking
            Booking? booking = _dbContext.Bookings.FirstOrDefault(Book => Book.Id == id);

            if(booking == null)
            {
                return NotFound();
            } else
            {
                return View(booking);
            }
        }
        [HttpPost]
        public IActionResult Edit(Booking booki)
        {
            Booking? booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == booki.Id);
            if (!ModelState.IsValid) //Enforcing validation
            {
                return View(booking);
            }
            if (booking != null)
            {
                //Set new values for editable fields
                booking.CustomerEmail = booki.CustomerEmail;
                booking.ServiceId = booki.ServiceId;
                booking.Status = booki.Status;
                _dbContext.SaveChanges();

            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index", _dbContext.Bookings.ToList()); //New request, will create new instance of controller
            //return View("Index",_service.allBookings); //Temp fix until data persistence is implemented
        }

        //Not best implementation
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Search for specific booking
            Booking? booking = _dbContext.Bookings.FirstOrDefault(Book => Book.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return View(booking);
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            //Search for specific booking
            Booking? booking = _dbContext.Bookings.FirstOrDefault(Book => Book.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Bookings.Remove(booking);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

    }

}
