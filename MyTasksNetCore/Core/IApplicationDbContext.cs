using Microsoft.EntityFrameworkCore;
using MyTasksNetCore.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core
{
    public interface IApplicationDbContext
    {
        DbSet<TaskJob> TaskJobs { get; set; }
        DbSet<Category> Categories { get; set; }

        int SaveChanges();
    }
}
