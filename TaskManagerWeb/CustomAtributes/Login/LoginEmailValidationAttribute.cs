using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

using TaskManagerWeb.Services;

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TaskManager.Data;

public class LoginEmailValidationAttribute : ValidationAttribute
{
    
   
    
    public override bool IsValid(object value)
    {

        var email = value.ToString();
        if (CheckIfEmailExists(email))
        {

            return true;

            
        }
        else
        {
            ErrorMessage = "User doesn't exist";
            return false;
        }
      



    }
    private bool CheckIfEmailExists(string email)
    {
        using (var dbContext = new ManagerContext())
        {
            return dbContext.Users.Any(u => u.Email == email);
        }
    }
}

