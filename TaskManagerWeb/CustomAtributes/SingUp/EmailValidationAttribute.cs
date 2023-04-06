using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using TaskManagerWeb.Services;

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TaskManager.Data;

public class EmailValidationAttribute : ValidationAttribute
{


    private readonly Regex _emailRegex = new Regex(@"^(?=.{1,254}$)(?=.{1,64}@)[^\s@]+@[^\s@]+\.[^\s@]+$");
    public override bool IsValid(object value)
    {

        var email = value.ToString();
        
       

        if (CheckIfEmailExists(email))
        {

            ErrorMessage = "Email is already used";
            return false;

        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return true;
        }

        if (email.Length > 254)
        {
            ErrorMessage = "Email address is too long.";
            return false;
        }

        if (email.Length < 5)
        {
            ErrorMessage = "Email address is too short.";
            return false;
        }

        if (!_emailRegex.IsMatch(email))
        {
            ErrorMessage = "Email address is invalid.";
            return false;
        }

        return true;

 
    }
    private bool CheckIfEmailExists(string email)
    {
        using (var dbContext = new ManagerContext())
        {
            return dbContext.Users.Any(u => u.Email == email);
        }
    }


}
    


