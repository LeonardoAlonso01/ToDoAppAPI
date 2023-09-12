using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Commands.TasksCommands.ReopenTask
{
    public class ReopenTaskCommandHandler : IRequestHandler<ReopenTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public ReopenTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(ReopenTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);

            if (task != null)
            {
                task.Reopen();
            }
        }
    }
}
