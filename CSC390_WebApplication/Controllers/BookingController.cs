using CSC390_WebApplication.Data;
using CSC390_WebApplication.Models;
using CSC390_WebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSC390_WebApplication.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {

        //Injecting the service (placeholder until data persistence is implemented)
        //private IMyInterface _service; //old data before db
        private MyDbContext _dbContext;


        public BookingController( MyDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        [AllowAnonymous]
        public IActionResult Index(string searchByCustomerName) //Default page
            //Automatically populated param with the input from search box due to same name
        {
            var bookings = _dbContext.Bookings.AsEnumerable(); 

            if(! string.IsNullOrEmpty(searchByCustomerName))
            {
                bookings = bookings.Where(book => book.CustomerName.ToLower().Contains(searchByCustomerName.ToLower()));
            }
            ViewBag.searchByCustomerName=searchByCustomerName;

			Dictionary<int, string> photos = new(); //stores cover photos 
													//Create image from byte[] in db
			foreach (var b in bookings)
			{
				if (b.CustomerImage != null) //If image exists in db
				{
					//Covert byte[] back into image
					string imageBase64Data = Convert.ToBase64String(b.CustomerImage);
					string customerImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
					photos[b.Id] = customerImage;
				}
			}
			ViewBag.photos = photos; //Pass dictionary to viewbag

			return View(bookings.ToList()); //Pass info to view
        }
        public IActionResult ListAll()
        {
            //Show all bookings, same as index
            return RedirectToAction("Index"); //Reroute to index
        }

        [AllowAnonymous]
        public IActionResult ShowDetails(int id)
        {
            //Show details about each booking

            //Search through BookingList using LINQ
            Booking? b = _dbContext.Bookings.FirstOrDefault(b => b.Id == id);

			if (b != null)
			{
				if (b.CustomerImage != null) //If image exists in db
				{
					//Covert byte[] back into image
					string imageBase64Data = Convert.ToBase64String(b.CustomerImage);
					string customerImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
					ViewBag.customerImage = customerImage;
				}
			}
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
			foreach (var file in Request.Form.Files) //Convert file to memorystream
			{
				MemoryStream ms = new();
				file.CopyTo(ms);
				newBooking.CustomerImage = ms.ToArray();

				ms.Close();
				ms.Dispose();
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
