using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            TaskJobs = new Collection<TaskJob>();
        }

        public ICollection<TaskJob> TaskJobs { get; set; }
    }
}
