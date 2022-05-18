using MyTasksNetCore.Core;
using MyTasksNetCore.Core.Models.Domains;
using MyTasksNetCore.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Persistence.Services
{
    public class TaskJobService : ITaskJobService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskJobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TaskJob> Get(string userId, bool isExecuted = false, int categoryId = 0, string title = null)
        {
            return _unitOfWork.TaskJob.Get(userId, isExecuted, categoryId, title);

        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.TaskJob.GetCategories();
        }

        public TaskJob Get(int id, string userId)
        {
            return _unitOfWork.TaskJob.Get(id, userId);
        }

        public void Add(TaskJob taskJob)
        {
            _unitOfWork.TaskJob.Add(taskJob);
            _unitOfWork.Complete();
        }

        public void Update(TaskJob taskJob)
        {
            _unitOfWork.TaskJob.Update(taskJob);
            _unitOfWork.Complete();

        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.TaskJob.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void Finish(int id, string userId)
        {
            _unitOfWork.TaskJob.Finish(id, userId);
            //email
            _unitOfWork.Complete();
        }

    }
}
