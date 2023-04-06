using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Models;
namespace TaskManagerWeb.TaskController
{
    using Services;
    using TaskManager.Data.Models.Enums;

    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }       

        public IActionResult Index()
        {
            var tasks = _taskService.GetAllTasks();

            return View(tasks);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        
        [HttpPost]
        public IActionResult CreateTask(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                var task = new Tasks
                {
                    
                    //Id = taskViewModel.Id,
                    Name = taskViewModel.Name,
                    Description = taskViewModel.Description,
                    DueDate = taskViewModel.DueDate,
                    Status = Status.InProgress,
                    PrioirtyLevel = taskViewModel.PrioirtyLevel,
                    
                    TaskListId = taskViewModel.TaskListId
                };

                _taskService.Create(task);

                return RedirectToAction("Details", "TaskList", new { id = task.TaskListId });
            }

            return View("AddTask", taskViewModel);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]      
        //public IActionResult Create(Tasks task)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _taskService.Create(task);
        //        return RedirectToAction("Index");
        //    }
        //    return View(task);
        //}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _taskService.GetTaskById(id);

            var taskViewModel = new TaskViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Status = item.Status,
                DueDate = item.DueDate,                
                TaskListId = item.TaskListId,

            };

            return View(taskViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, TaskViewModel model)
        {
            var task = _taskService.GetTaskById(id);

            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                task.Name = model.Name;
                task.Description = model.Description;
                task.PrioirtyLevel = model.PrioirtyLevel;


                _taskService.Update(task);
                return RedirectToAction("Details","TaskList", new { id = model.TaskListId });
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _taskService.GetTaskById(id);
            _taskService.Delete(id);

            return RedirectToAction("Details","TaskList", new { id = task.TaskListId });
        }

    }
}
