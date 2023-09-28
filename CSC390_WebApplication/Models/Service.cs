namespace CSC390_WebApplication.Models
{
    public enum ServiceType {BEAUTY,TECH,CAR,OTHER}
    public class Service
    {
        public String ServiceName { get; set; }
        public String ServiceDescription { get; set; }
        public ServiceType ServiceType { get; set;}
        public double Price { get; set; }

    }
}
