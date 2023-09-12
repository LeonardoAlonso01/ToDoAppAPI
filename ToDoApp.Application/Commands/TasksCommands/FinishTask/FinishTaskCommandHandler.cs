using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Commands.TasksCommands.FinishTask
{
    public class FinishTaskCommandHandler : IRequestHandler<FinishTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;

        public FinishTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Handle(FinishTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(request.Id);

            if (task != null)
            {
                task.Finish();
            }
        }
    }
}
