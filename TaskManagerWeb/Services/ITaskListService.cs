using TaskManager.Data.Models;

namespace TaskManagerWeb.Services
{
    public interface ITaskListService
    {
        IEnumerable<TaskList> GetAllTaskLists();
        TaskList GetTaskListById(int id);
        
        void CreateTaskList(TaskList taskList);
        void UpdateTaskList(TaskList taskList);
        void DeleteTaskList(int id);
        void AddTask(TaskList taskList, Tasks task);
    }   
}
