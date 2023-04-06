namespace TaskManagerWeb.Services
{
    using TaskManager.Data.Models;
    using TaskManagerWeb.Verifications;

    public interface IVerificationService
    {

        bool Contains(string email);
        Users FindUserByName(string name);
        public bool IsValidLogin(string email, string password);
        void SetLoggedName(string email);
    }
}
