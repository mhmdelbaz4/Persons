using System.ComponentModel.DataAnnotations;

namespace PersonsWebApp.Helper;

public class ModelValidation
{

    internal static void Validate(object? obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        ValidationContext validationContext = new ValidationContext(obj);

        List<ValidationResult> errorList = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj , validationContext ,errorList , true);

        if(! isValid)
        {
            throw new ArgumentException(errorList.FirstOrDefault()?.ErrorMessage);
        }

    }

}
