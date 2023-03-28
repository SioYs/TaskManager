using System;
using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ManagerContext();

            var user = new Users();


            user.Username = "Miro";

            user.Email = "Hanko@gamil.com";
            user.Password = "202020022";
            user.Name = "Sashko";


            context.Add(user);
            context.SaveChanges();

        }
    }
}