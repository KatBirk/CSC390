using Microsoft.AspNetCore.Mvc;
using CSC390_WebApplication.Models;

namespace CSC390_WebApplication.Controllers
{
    public class ServiceController : Controller
    {
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
        }
    }
}
