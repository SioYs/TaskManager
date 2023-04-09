using System.ComponentModel.DataAnnotations;

namespace TaskManagerWeb.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [LoginEmailValidation]
        
        
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [LoginPasswordValidation]
        //[Range(8, 70, ErrorMessage = "Password must be more than 8 symbols!")]
        public string Password { get; set; }

        //[Display(Name = "Remember me")]
        //public bool RememberMe { get; set; }
    }

}
