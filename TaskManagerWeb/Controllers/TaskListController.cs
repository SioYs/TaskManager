using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Models;


namespace TaskManagerWeb.Controllers
{
    using Services;
    using System.Collections;

    public class TaskListController : Controller
    {
        private readonly ITaskListService _taskListService;
        private readonly ITaskService _taskService;

        public TaskListController(ITaskListService taskListService, ITaskService taskService)
        {
            _taskListService = taskListService;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            var taskLists = _taskListService.GetAllTaskLists();

            return View(taskLists);
        }

        public IActionResult Details(int id)
        {
            var taskList = _taskListService.GetTaskListById(id);

            if (taskList == null)
            {
                return NotFound();
            }

            taskList.Tasks = (ICollection<Tasks>)_taskService.GetTaskByTaskListId(id);

            return View(taskList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description")] TaskList taskList)
        {
            //if (ModelState.ContainsKey("{User}"))
            //    ModelState["{User}"].Errors.Clear();


            _taskListService.CreateTaskList(taskList);
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult AddTask(int id)
        {
            var taskList = _taskListService.GetTaskListById(id);

            if (taskList == null)
            {
                return NotFound();
            }

            var taskViewModel = new TaskViewModel
            {
                TaskListId = taskList.Id
            };

            return View(taskViewModel);
        }

        
        [HttpPost]
        public IActionResult AddTask(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = new Tasks
                {
                    Name = model.Name,
                    Description = model.Description,
                    TaskListId = model.TaskListId
                };
                _taskService.Create(task);
                return RedirectToAction("Details", "TaskList", new { id = model.TaskListId });
            }
            return View(model);
        }




        public IActionResult Edit(int id)
        {
            var taskList = _taskListService.GetTaskListById(id);
            return View(taskList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskList taskList, int id)
        {

            var oldTaskList = _taskListService.GetTaskListById(id);
            if (id != taskList.Id)
            {
                return NotFound();
            }
            taskList.User = oldTaskList.User;
            taskList.OwnerName = oldTaskList.OwnerName;
            taskList.Tasks = oldTaskList.Tasks;
            taskList.UserId = oldTaskList.UserId;



            _taskListService.UpdateTaskList(taskList);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int id)
        {
            var taskList = _taskListService.GetTaskListById(id);
            return View(taskList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskListService.DeleteTaskList(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
