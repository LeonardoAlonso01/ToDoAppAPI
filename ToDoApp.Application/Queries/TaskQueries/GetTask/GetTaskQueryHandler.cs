using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.TasksViewModels;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Queries.TaskQueries.GetTask
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TasksDetailViewModel>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TasksDetailViewModel> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);

            if (task == null)
            {
                var taskDetailView = new TasksDetailViewModel(task.Title, task.Description, task.Status, task.CreatedAt);
                return taskDetailView;
            }
            return null;
        }

    }
}
