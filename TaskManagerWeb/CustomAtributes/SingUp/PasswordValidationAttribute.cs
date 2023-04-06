using System.ComponentModel.DataAnnotations;
using System.Linq;

public class PasswordValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value != null)
        {
            var password = value.ToString();

            if (!password.Any(char.IsUpper))
            {
               ErrorMessage = "Password must contain at least one uppercase letter.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                ErrorMessage = "Password must contain at least one lowercase letter.";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                ErrorMessage = "Password must contain at least one number.";
                return false;
            }
            if (password.Length <= 8)
            {
                ErrorMessage = "Password must be longer than 8";
                return false;
            }
        }

        return true;
    }
}
