using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Models;

using TaskManager.Data;
using System;

namespace TaskManagerWeb.Controllers
{
    

    public class UsersController : Controller
    {
        private readonly ManagerContext context;
        public UsersController(ManagerContext context)
        {
            this.context = context;
        }

        public  IActionResult Index()
        {
            IEnumerable<Users> users = context.Users;
            return View(users);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users obj)
        {
            if ( obj.Username ==  obj.Name)
            {
                ModelState.AddModelError("name", "The Name cannot match the Username!");
            }
            if (ModelState.IsValid)
            {
                context.Users.Add(obj);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
             

        }
    }
}
