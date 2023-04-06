using TaskManager.Data.Models;

namespace TaskManagerWeb.Services
{
    public interface IUserService
    {
        Users GetUserById(int id);
        Users GetUserByUsername(string username);
        Users CreateUser(Users user);
    }
}
