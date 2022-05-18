using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasksNetCore.Core.Models;
using MyTasksNetCore.Core.Models.Domains;
using MyTasksNetCore.Core.Service;
using MyTasksNetCore.Core.ViewModels;
using MyTasksNetCore.Persistence.Extensions;
using System;

namespace MyTasksNetCore.Controllers
{
    [Authorize]
    public class TaskJobController : Controller
    {
        private ITaskJobService _taskJobService;

        public TaskJobController(ITaskJobService taskJobService)
        {
            _taskJobService = taskJobService;
        }

        public IActionResult TaskJobs()
        {
            var userId = User.GetUserId();

            var vm = new TaskJobsViewModel
            {
                FilterTasks = new FilterTasks(),
                TaskJobs = _taskJobService.Get(userId),
                Categories = _taskJobService.GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult TaskJobs(TaskJobsViewModel viewModel)
        {
            var userId = User.GetUserId();

            var tasks = _taskJobService.Get(userId,
                viewModel.FilterTasks.IsExecuted,
                viewModel.FilterTasks.CategoryId,
                viewModel.FilterTasks.Title);

            return PartialView("_TaskJobsTable", tasks);
        }

        public IActionResult TaskJob(int id = 0)
        {
            var userId = User.GetUserId();

            var task = id == 0 ?
                new TaskJob { Id = 0, UserId = userId, Term = DateTime.Today } :
                _taskJobService.Get(id, userId);

            var vm = new TaskJobViewModel
            {
                TaskJob = task,
                Heading = id == 0 ? "Add new task" : "Edit task",
                Categories = _taskJobService.GetCategories()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaskJob(TaskJob taskJob)
        {
            var userId = User.GetUserId();
            taskJob.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new TaskJobViewModel
                {
                    TaskJob = taskJob,
                    Heading = taskJob.Id == 0 ? "Add new task" : "Edit task",
                    Categories = _taskJobService.GetCategories()
                };
                return View("TaskJob", vm);
            }

            if (taskJob.Id == 0)
                _taskJobService.Add(taskJob);
            else
                _taskJobService.Update(taskJob);

            return RedirectToAction("TaskJobs");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _taskJobService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Finish(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _taskJobService.Finish(id, userId);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

    }
}
