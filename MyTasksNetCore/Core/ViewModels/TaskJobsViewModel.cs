using MyTasksNetCore.Core.Models;
using MyTasksNetCore.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core.ViewModels
{
    public class TaskJobsViewModel
    {
        public IEnumerable<TaskJob> TaskJobs { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public FilterTasks FilterTasks { get; set; }
    }
}
