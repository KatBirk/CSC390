namespace CSC390_WebApplication.Models
{
    public enum Major { ART,CS,IT,OTHER};
    public class Student
    {
        //properties
        public String? Name { get; set; }
        public int StudentId { get; set; }
        public Major Major { get; set; }
        public bool IsVeteran { get; set; }
        public DateTime AdmissionDate { get; set; }
        public double GPA { get; set; }
    }
}
