using Microsoft.AspNetCore.Mvc;

namespace TaskManagerWeb.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Services;
    using System.Security.Claims;
    using TaskManager.Data.Models;
    using ViewModels;
    using Verifications;
    public class AccountController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly IVerificationService _verificationService;

        public AccountController(IUserService userService, IVerificationService verificationService)
        {
            _userService = userService;
            _verificationService = verificationService;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            LoggedUser.Remove();
            Nav.isShowed = false;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {

            
            //Change the || to && when the app is finished
            if (ModelState.IsValid )
            {
                if (_verificationService.IsValidLogin(model.Email, model.Password))
                {
                    var email = model.Email;
                    Nav.isShowed = true;
                    _verificationService.SetLoggedName(email);
                    return RedirectToAction("Index", "TaskList");

                }                               
                
            }
            Nav.isShowed = false;
            return View(model);
        }

        [HttpPost]
      
        public  IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };
                
                //Creates Signed User
                

                //Creates User
                _userService.CreateUser(user);
                Nav.isShowed = true;
                return RedirectToAction("Index", "TaskList");
            }
            Nav.isShowed = false;

            return View(model);
        }


        //FOR FUTURE PROJECTS

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Index", "Home");
        //}


        //private async Task AuthenticateAsync(Users user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim(ClaimTypes.Role, "User")
        //    };

        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);

        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //}



    }

}

