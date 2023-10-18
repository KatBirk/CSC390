using System.ComponentModel.DataAnnotations;

namespace CSC390_WebApplication.Validators
{
    public class StringMinLengthOf2Attribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string? str = (string?)value;
            if (str is null )
            {
                return true;
            }
            else
            {
                return str.Length >=2;
            }
        }
    }
}
