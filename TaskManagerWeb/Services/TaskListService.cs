using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Models;
using TaskManagerWeb.Verifications;


namespace TaskManagerWeb.Services
{

    public class TaskListService : ITaskListService
    {
        private readonly ManagerContext _db;
        private readonly IVerificationService verificationService;

        public TaskListService(ManagerContext db)
        {
            _db = db;
        }

        public IEnumerable<TaskList> GetAllTaskLists()
        {
            return _db.TaskList.Where(t => t.OwnerName == LoggedUser.Name);
        }

        public TaskList GetTaskListById(int id)
        {
            return _db.TaskList.Find(id);
        }

        public void CreateTaskList(TaskList taskList)
        {
            taskList.OwnerName = LoggedUser.Name;
            //taskList.User = verificationService.FindUserByName(LoggedUser.Name);     
            taskList.User = _db.Users.Where(u => u.Name == LoggedUser.Name).FirstOrDefault();

            _db.TaskList.Add(taskList);
            _db.SaveChanges();
        }
       

        public void UpdateTaskList(TaskList taskList)
        {
            var item = _db.TaskList.Where(x => x.Id == taskList.Id).FirstOrDefault();

            //_db.TaskList.AddOrUpdate(taskList);
            item.Description = taskList.Description;
            item.Name = taskList.Name;


            _db.Update(item);
            _db.SaveChanges();
            


        }

        public void DeleteTaskList(int id)
        {
            TaskList taskList = _db.TaskList.Find(id);
            _db.TaskList.Remove(taskList);
            _db.SaveChanges();
        }
        public void AddTask(TaskList taskList, Tasks task)
        {
            taskList.Tasks.Add(task);
            _db.TaskList.Add(taskList);
            _db.SaveChanges();
        }

       
    }
}


