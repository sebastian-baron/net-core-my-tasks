using Microsoft.EntityFrameworkCore;
using MyTasksNetCore.Core;
using MyTasksNetCore.Core.Models.Domains;
using MyTasksNetCore.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyTasksNetCore.Persistence.Repositories
{
    public class TaskJobRepository : ITaskJobRepository
    {
        private IApplicationDbContext _context;

        public TaskJobRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskJob> Get(string userId, bool isExecuted = false, int categoryId = 0, string title = null)
        {
            var tasks = _context.TaskJobs
                .Include(x => x.Category)
                .Where(x => x.UserId == userId && x.IsExecuted == isExecuted);

            if(categoryId != 0)
                tasks = tasks.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                tasks = tasks.Where(x => x.Title.Contains(title));

            return tasks.OrderBy(x => x.Term).ToList();

        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Name).ToList();
        }

        public TaskJob Get(int id, string userId)
        {
            var task = _context.TaskJobs
                .Single(x => x.Id == id && x.UserId == userId);

            return task;
        }

        public void Add(TaskJob taskJob)
        {
            _context.TaskJobs.Add(taskJob);
        }

        public void Update(TaskJob taskJob)
        {
            var taskToUpdate = _context.TaskJobs.Single(x => x.Id == taskJob.Id);

            taskToUpdate.CategoryId = taskJob.CategoryId;
            taskToUpdate.Description = taskJob.Description;
            taskToUpdate.IsExecuted = taskJob.IsExecuted;
            taskToUpdate.Term = taskJob.Term;
            taskToUpdate.Title = taskJob.Title;


        }

        public void Delete(int id, string userId)
        {
            var taskToDelete = _context.TaskJobs.Single(x => x.Id == id && x.UserId == userId);

            _context.TaskJobs.Remove(taskToDelete);
        }

        public void Finish(int id, string userId)
        {
            var taskToUpdate = _context.TaskJobs.Single(x => x.Id == id && x.UserId == userId);

            taskToUpdate.IsExecuted = true;

        }
    }
}
