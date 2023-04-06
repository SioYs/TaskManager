using Microsoft.AspNetCore.Identity;
using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManagerWeb.Services
{
    public class UserService : IUserService  
    {
        private readonly ManagerContext _dbContext;


        //FOR FUTURE PROJECTS
        //private readonly UserManager<Users> _userManager;
        //private readonly SignInManager<Users> _signInManager;

        //public UserService(UserManager<Users> userManager, SignInManager<Users> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public UserService(ManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Users GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public Users GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public Users CreateUser(Users user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
        


        //FOR FUTURE PROJECTS

        //public async Task<Users> AuthenticateAsync(string username, string password)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
        //    if (result.Succeeded)
        //    {
        //        return await _userManager.FindByNameAsync(username);
        //    }
        //    return null;
        //}

        //public async Task<IdentityResult> CreateAsync(string name, string username, string email, string password)
        //{
        //    var user = new Users
        //    {
        //        Name = name,
        //        Username = username,
        //        Email = email
        //    };
        //    var result = await _userManager.CreateAsync(user, password);
        //    return result;
        //}

    }
}
