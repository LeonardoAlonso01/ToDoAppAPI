using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoAppContext _appContext;

        public TaskRepository(ToDoAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            await _appContext.Tasks.AddAsync(task);
            await _appContext.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Tasks task)
        {
            _appContext.Tasks.Remove(task);
            await _appContext.SaveChangesAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            return await _appContext.Tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tasks>> GetTasksAsync()
        {
            return await _appContext.Tasks.ToListAsync();
        }

        public async Task UpdateTaskAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
