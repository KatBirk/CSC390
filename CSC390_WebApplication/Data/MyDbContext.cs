using CSC390_WebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSC390_WebApplication.Data
{
    public class MyDbContext : IdentityDbContext<User>
    {
        //Saving bookings and services 
        public DbSet<Booking> Bookings { get; set; } //Name will be tablename
        public DbSet<Service> Services { get; set; } //Name will be tablename

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed database
            //Initial data in database
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasData(
                new Booking() {
                    Id = 45,
                    Created = DateTime.Parse("12/12/2022"),
                    ServiceId = 1,
                    CustomerName = "Joe",
                    CustomerEmail = "joe@gmail.com"
                },
                new Booking()
                {
                    Id = 76,
                    Created = DateTime.Now,
                    ServiceId = 0,
                    CustomerName = "Patty",
                    CustomerEmail = "PatriciaJones@mail.com"
                },
                new Booking()
                {
                    Id = 1,
                    Created = DateTime.Parse("08/06/2020"),
                    ServiceId = 3,
                    CustomerName = "John",
                    CustomerEmail = "John@mail.com"
                },
                new Booking()
                {
                    Id = 5,
                    Created = DateTime.Parse("07/06/2007"),
                    ServiceId = 3,
                    CustomerName = "Sam",
                    CustomerEmail = "Sam@mail.com"
                },
                new Booking()
                {
                    Id = 2,
                    Created = DateTime.Parse("02/06/2023"),
                    ServiceId = 1,
                    CustomerName = "Kayla Rose",
                    CustomerEmail = "krandfam@mail.com"
                }
                );
            modelBuilder.Entity<Service>().HasData(
                new Service()
                {
                    Id = 1,
                    Price = 100,
                    ServiceName = "Oil change",
                    ServiceType = ServiceType.QUICK,
                    ServiceDescription = "Get your oil changed",
                    CreatedDate = DateTime.Parse("02/02/2010"),
                    IsActive = true
                },
                new Service()
                {
                    Id = 2,
                    Price = 50,
                    ServiceName = "General car serivce checkup",
                    ServiceType = ServiceType.GENERAL,
                    ServiceDescription = "Schedules checkup for your car",
                    CreatedDate = DateTime.Now,
					IsActive = true
				},
                new Service()
                {
                    Id = 3,
                    Price = 70,
                    ServiceName = "Crash assessment",
                    ServiceType = ServiceType.EMERGENCYREPAIR,
                    ServiceDescription = "Get damage to your car assessed and get a price estimate",
                    CreatedDate = DateTime.Parse("12/03/2003"),
					IsActive = false
				}
				) ;
        }
    }
}
