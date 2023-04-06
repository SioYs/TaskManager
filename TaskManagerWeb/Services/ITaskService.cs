using TaskManager.Data.Models;

namespace TaskManagerWeb.Services
{
    public interface ITaskService
    {
        IEnumerable<Tasks> GetAllTasks();
        Tasks GetTaskById(int id);
        void Create(Tasks task);
        void Update(Tasks task);
        void Delete(int id);
        public IEnumerable<Tasks> GetTaskByTaskListId(int taskListId);

    }
}
