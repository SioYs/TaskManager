using System.ComponentModel.DataAnnotations;

namespace TaskManagerWeb.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [NameValidation]
        public string Name { get; set; }

        [Required]
        [UsernameValidation]
        public string Username { get; set; }

        [Required]
        [EmailValidation]
        
        public string Email { get; set; }

        [Required]
        [PasswordValidation]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
