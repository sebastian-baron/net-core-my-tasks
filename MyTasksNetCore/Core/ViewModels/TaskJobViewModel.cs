using MyTasksNetCore.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core.ViewModels
{
    public class TaskJobViewModel
    {
        public string Heading { get; set; }
        public TaskJob TaskJob { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
