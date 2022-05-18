using MyTasksNetCore.Core;
using MyTasksNetCore.Core.Repositories;
using MyTasksNetCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            TaskJob = new TaskJobRepository(context);
        }

        public ITaskJobRepository TaskJob { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
