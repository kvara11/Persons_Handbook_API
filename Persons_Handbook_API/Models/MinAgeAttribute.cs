using System.ComponentModel.DataAnnotations;

namespace Persons_Handbook_API.Models
{
    public class MinAgeAttribute : ValidationAttribute
    {
        int _minAge;

        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minAge) < DateTime.Now;
            }

            return false;
        }
    }
}
