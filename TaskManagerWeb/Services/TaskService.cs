using TaskManager.Data;
using TaskManager.Data.Models;

namespace TaskManagerWeb.Services
{

    public class TaskService : ITaskService
    {

        private readonly ManagerContext context;
        public TaskService(ManagerContext context)
        {
            this.context = context;
        }


        public IEnumerable<Tasks> GetAllTasks()
        {
            return context.Tasks.ToList();
        }

        public Tasks GetTaskById(int id)
        {
            return context.Tasks.Find(id);
        }
        public IEnumerable<Tasks> GetTaskByTaskListId(int taskListId)
        {
            return context.Tasks
                           .Where(t => t.TaskListId == taskListId)
                           .ToList();
        }

        public TaskList GetTaskListById(int id)
        {
            return context.TaskList.Where(t => t.Id == id).FirstOrDefault();
        }
        public void Create(Tasks task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void Update(Tasks task)
        {
            context.Tasks.Update(task);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = context.Tasks.Find(id);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
    }
}
