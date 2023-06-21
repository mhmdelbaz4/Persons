using System.ComponentModel.DataAnnotations;


namespace Persons.Services
{
    public class ValidationHelper
    {
        public static void Validate(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);

            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults);

            if (! isValid)
            {
                throw new ArgumentException(validationResults.SingleOrDefault()?.ErrorMessage);
            }

        }

    }
}
