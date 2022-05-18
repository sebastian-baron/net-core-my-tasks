using MyTasksNetCore.Core.Repositories;
using MyTasksNetCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksNetCore.Core
{
    public interface IUnitOfWork
    {
        ITaskJobRepository TaskJob { get; }

        void Complete();

    }
}
