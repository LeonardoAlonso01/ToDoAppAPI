using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoAppContext _context;
        public UnitOfWork(ToDoAppContext context, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _context = context;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
        }

        public ITaskRepository TaskRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
