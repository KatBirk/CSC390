using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.Validators
{
    public class CheckDateAfter2000Attribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? dt = (DateTime?)value;

            if (dt is null)
            {
                return true;
            }
            else
            {
                return dt >= DateTime.Parse("1/1/2000") && dt<= DateTime.Now;
            }
        }
    }
}
