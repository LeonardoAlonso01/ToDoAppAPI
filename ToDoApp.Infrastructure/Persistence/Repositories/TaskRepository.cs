using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Models;

namespace ToDoApp.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private const int _pageSize = 2;
        private readonly ToDoAppContext _appContext;

        public TaskRepository(ToDoAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            await _appContext.Tasks.AddAsync(task);
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

        public async Task<PaginationResult<Tasks>> GetTasksAsync(string query, int page = 1)
        {
            IQueryable <Tasks> tasks = _appContext.Tasks;

            if(!string.IsNullOrWhiteSpace(query))
            {
                tasks = tasks.Where(t => 
                                t.Title.Contains(query) || 
                                    t.Description.Contains(query));
            }
            return await tasks.GetPaged<Tasks>(page, _pageSize);
        }

        public async Task UpdateTaskAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
