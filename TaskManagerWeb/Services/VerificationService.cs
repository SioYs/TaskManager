using TaskManager.Data;
using TaskManager.Data.Models;
using System.Linq;
using TaskManagerWeb.Verifications;

namespace TaskManagerWeb.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly ManagerContext _db;
        public VerificationService(ManagerContext db)
        {
            _db = db;
        }

        public bool Contains(string email)
        {
            return _db.Users.Where(u => u.Email == email).Any();

            //foreach (var item in _db.Users)
            //{
            //    if (item.Email == email)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
        public Users FindUserByName(string name)
        {


            return  _db.Users.Where(u => u.Name == name).FirstOrDefault();

       


        }
    
        public bool IsValidLogin(string email, string password)
        {
            var item = _db.Users.Where(e => e.Email == email).FirstOrDefault();

            if (item.Password == password)
            {
                return true;
            }
            return false;
           
        }
     
        public void SetLoggedName(string email)
        {
            LoggedUser.Name = _db.Users.Where(u => u.Email == email).Select(u => u.Name).First();   
            
        }
      
    }
}
