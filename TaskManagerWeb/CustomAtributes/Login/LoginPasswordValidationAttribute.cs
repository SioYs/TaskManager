using System.ComponentModel.DataAnnotations;
using System.Linq;
using TaskManager.Data;

public class LoginPasswordValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value.ToString();

        var dbContext = new ManagerContext(); 
        if (!dbContext.Users.Any(u => u.Password == password))
        {
            return new ValidationResult("Wrong Password");
        }
       
        return ValidationResult.Success;
    }
}
