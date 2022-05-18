using MyTasksNetCore.Core.Models.Domains;
using System.Collections.Generic;

namespace MyTasksNetCore.Core.Repositories
{
    public interface ITaskJobRepository
    {
        IEnumerable<TaskJob> Get(string userId, bool isExecuted = false, int categoryId = 0, string title = null);

        IEnumerable<Category> GetCategories();

        TaskJob Get(int id, string userId);

        void Add(TaskJob taskJob);

        void Update(TaskJob taskJob);

        void Delete(int id, string userId);

        void Finish(int id, string userId);

    }
}
