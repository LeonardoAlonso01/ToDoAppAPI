using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Commands.TasksCommands.CancelTask
{
    public class CancelTaskCommandHandler : IRequestHandler<CancelTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public CancelTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(CancelTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);

            if (task != null)
            {
                task.Cancel();
            }
        }
    }
}
