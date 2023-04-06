using System.ComponentModel.DataAnnotations;
using TaskManager.Data;

public class UsernameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string name = "";
        if (value != null)
        {
            name = value.ToString();
        }
        

        // Check name length
        if (name.Length < 2 || name.Length > 50 || value == null)
        {
            return new ValidationResult("Name must be between 2 and 50 characters long.");
        }

        // Check if name already exists in the database
        var dbContext = new ManagerContext();
        if (dbContext.Users.Any(u => u.Username == name))
        {
            return new ValidationResult("Name already exists.");
        }

        return ValidationResult.Success;
    }
}
