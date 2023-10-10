using CSC390_WebApplication.Models;
namespace CSC390_WebApplication.Services
{
    public interface IMyInterface
    {
        List<Booking> allBookings { get; set; }
    }
}
