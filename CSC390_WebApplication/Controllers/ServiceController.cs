using Microsoft.AspNetCore.Mvc;
using CSC390_WebApplication.Models;
using CSC390_WebApplication.Data;

namespace CSC390_WebApplication.Controllers
{
    public class ServiceController : Controller
    {
        private MyDbContext _dbContext;

        public ServiceController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Display all services
        public IActionResult Index()
        {
            return View(_dbContext.Services.ToList());
        }

		//Display one service
		public IActionResult ShowDetails(int id)
		{
			//Show details about each booking

			//Search through BookingList using LINQ
			Service? s = _dbContext.Services.FirstOrDefault(s => s.Id == id);
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

/*
 [Route("findservice")]
        [Route("services/{id?}")]
        public ViewResult ShowService(int id)
        {
            Service service = new Service();
            if (id == 0)
            {
                service.ServiceName = "Haircut";
                service.ServiceDescription = "Get a standard haircut";
                service.ServiceType = ServiceType.BEAUTY;
                service.Price = 50;
            }
            else
            {
                service.ServiceName = "Phone repair";
                service.ServiceDescription = "Get your broken phone fixed";
                service.ServiceType = ServiceType.TECH;
                service.Price = 60;

            }
            ViewBag.service = service;
            return View();
        }

       
        public ContentResult PrintTotalServices()
        {
            return Content($"ServiceController - PrintAllServices: \nAll services include: {ServiceType.BEAUTY}," +
                $"{ServiceType.TECH}, {ServiceType.CAR} and misc. services");
        }

        public ContentResult SimplePrint()
        {
            Service s = new Service();
            s.ServiceName = "TestService";
            s.Price = 50;

            return Content($"ServiceController - Simple print: \nOne service is: {s.ServiceName}. It has a price of {50:c}");
        }*/
