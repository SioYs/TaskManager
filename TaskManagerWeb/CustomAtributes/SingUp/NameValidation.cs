using System.ComponentModel.DataAnnotations;
using TaskManager.Data;

public class NameValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string name = "";
        if (value != null)
        {
            name = value.ToString();
        }
        if (HasSpecialChars(name))
        {
            return new ValidationResult("Name mustn't contain symbols or numbers");
        }

        if (name.Length < 2 || name.Length > 50 || value == null)
        {
            return new ValidationResult("Name must be between 2 and 50 characters long.");
        }        

        return ValidationResult.Success;
    }
    private bool HasSpecialChars(string yourString)
    {
        foreach (var item in yourString)
        {
            if (!char.IsLetter(item))
            {
                return true;
            }
        }
        return false;
       
    }
}
