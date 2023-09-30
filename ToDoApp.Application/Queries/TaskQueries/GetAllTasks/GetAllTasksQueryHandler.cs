using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Queries.TaskQueries.GetAllTasks;
using ToDoApp.Application.ViewModels.TasksViewModels;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskViewModel>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskViewModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetTasksAsync();

            if (tasks.Count > 0)
            {
                var userTasks = tasks.Where(t => t.IdUser == request.IdUser);

                var tasksViewModel = userTasks.Select(t => new TaskViewModel(t.Title, t.Status)).ToList();
                return tasksViewModel;
            }

            return null;

        }
    }
}
