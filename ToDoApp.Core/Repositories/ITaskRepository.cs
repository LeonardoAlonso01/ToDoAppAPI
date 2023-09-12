using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;

namespace ToDoApp.Core.Repositories
{
    public interface ITaskRepository
    {
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync();
        Task DeleteTaskAsync(Tasks task);
        Task<Tasks> GetTaskByIdAsync(int id);
        Task<List<Tasks>> GetTasksAsync();
    }
}
