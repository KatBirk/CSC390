using Microsoft.AspNetCore.Mvc;
using CSC390_WebApplication.Models;
using CSC390_WebApplication.Data;
using Microsoft.AspNetCore.Authorization;

namespace CSC390_WebApplication.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private MyDbContext _dbContext;

        public ServiceController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		//Display all services
		[AllowAnonymous]
        public IActionResult Index()
        {
			var services = _dbContext.Services.AsEnumerable();

			Dictionary<int, string> photos = new(); //stores cover photos  
			
			//Create image from byte[] in db
			foreach(var s in services)
			{
				if (s.ServiceCoverImage != null) //If image exists in db
				{
					//Covert byte[] back into image
					string imageBase64Data = Convert.ToBase64String(s.ServiceCoverImage);
					string serviceCoverImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
					photos[s.Id] = serviceCoverImage;
				}
			}
			ViewBag.photos = photos; //Pass dictionary to viewbag
            return View(services);
        }

        //Display one service
        [AllowAnonymous]
        public IActionResult ShowDetails(int id)
		{
			//Show details about each booking
			

			//Search through BookingList using LINQ
			Service? s = _dbContext.Services.FirstOrDefault(s => s.Id == id);
			if(s != null)
			{
				if (s.ServiceCoverImage != null) //If image exists in db
				{
					//Covert byte[] back into image
					string imageBase64Data = Convert.ToBase64String(s.ServiceCoverImage);
					string serviceCoverImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
					ViewBag.serviceCoverImage = serviceCoverImage;
				}
			}
			ViewBag.id = id;
			return View(s);
		}

		//add a service
		[HttpGet]
		public IActionResult Add() //will only be called for get requests
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Service newService) //Will only be called for post requests
		{
			if (!ModelState.IsValid) //Enforcing validation
			{
				return View();
			}

			foreach (var file in Request.Form.Files) //Convert file to memorystream
			{
				MemoryStream ms = new();
				file.CopyTo(ms);
				newService.ServiceCoverImage = ms.ToArray();

				ms.Close();
				ms.Dispose();
			}
			_dbContext.Services.Add(newService);
			_dbContext.SaveChanges();
			return RedirectToAction("Index", _dbContext.Services.ToList()); //New request, will create new instance of controller
		}

		//Edit a service
		[HttpGet]
		public IActionResult Edit(int id)
		{
			//Search for specific booking
			Service? service = _dbContext.Services.FirstOrDefault(Serv => Serv.Id == id);

			if (service == null)
			{
				return NotFound();
			}
			else
			{
				return View(service);
			}
		}
		[HttpPost]
		public IActionResult Edit(Service serv)
		{
			Service? service = _dbContext.Services.FirstOrDefault(s => s.Id == serv.Id);
			if (!ModelState.IsValid) //Enforcing validation
			{
				return View(service);
			}
			if (service != null)
			{
				//Set new values for editable fields
				service.ServiceName = serv.ServiceName;
				service.ServiceDescription = serv.ServiceDescription;
				service.Price = serv.Price;
				service.IsActive = serv.IsActive;
				_dbContext.SaveChanges();
			}
			else
			{
				return BadRequest();
			}
			return RedirectToAction("Index", _dbContext.Services.ToList()); //New request, will create new instance of controller
		}

		//Delete a service
		[HttpGet]
		public IActionResult Delete(int id)
		{
			//Search for specific booking
			Service? service = _dbContext.Services.FirstOrDefault(S => S.Id == id);

			if (service == null)
			{
				return NotFound();
			}
			else
			{
				return View(service);
			}
		}

		[HttpPost]
		public IActionResult DeleteConfirm(int id)
		{
			//Search for specific service
			Service? service = _dbContext.Services.FirstOrDefault(s => s.Id == id);

			if (service == null)
			{
				return NotFound();
			}
			else
			{
				_dbContext.Services.Remove(service);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
		}



	}
}

