using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> CompleteAsync(); 
    }
}
