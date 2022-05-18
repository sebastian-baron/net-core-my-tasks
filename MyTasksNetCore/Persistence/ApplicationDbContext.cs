using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTasksNetCore.Core;
using MyTasksNetCore.Core.Models.Domains;

namespace MyTasksNetCore.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskJob> TaskJobs { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
