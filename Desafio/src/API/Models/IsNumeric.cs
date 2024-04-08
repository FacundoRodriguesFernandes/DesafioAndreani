using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class IsNumeric : ValidationAttribute
    {
        public const string DefaultErrorMessage = "El campo {0} debe ser un número";

        public IsNumeric() : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value is null) return false;

            return Convert.ToInt64(value) >= 0;
        }
    }
}