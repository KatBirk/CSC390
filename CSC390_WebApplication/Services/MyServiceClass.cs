using CSC390_WebApplication.Models;

namespace CSC390_WebApplication.Services
{
    public class MyServiceClass : IMyInterface
    {
        public List<Booking> allBookings { get; set; }

        public MyServiceClass()
        {
            allBookings = new List<Booking>();
            //Adding bookings to list
            allBookings.Add(new Booking()
            {
                Id = 45,
                Created = DateTime.Parse("12/12/2022"),
                ServiceId = 1,
                CustomerName = "Joe",
                CustomerEmail = "joe@gmail.com"
            });
            allBookings.Add(new Booking()
            {
                Id = 76,
                Created = DateTime.Now,
                ServiceId = 0,
                CustomerName = "Patty",
                CustomerEmail = "PatriciaJones@mail.com"
            });
            allBookings.Add(new Booking()
            {
                Id = 1,
                Created = DateTime.Parse("08/06/2020"),
                ServiceId = 3,
                CustomerName = "John",
                CustomerEmail = "John@mail.com"
            });
            allBookings.Add(new Booking()
            {
                Id = 5,
                Created = DateTime.Parse("07/06/2007"),
                ServiceId = 3,
                CustomerName = "Sam",
                CustomerEmail = "Sam@mail.com"
            });
            allBookings.Add(new Booking()
            {
                Id = 2,
                Created = DateTime.Parse("02/06/2023"),
                ServiceId = 1,
                CustomerName = "Kayla Rose",
                CustomerEmail = "krandfam@mail.com"
            });
        }
    }
}
