using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            //TaskJobs = new Collection<TaskJob>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<TaskJob> TaskJobs { get; set; }
    }
}
