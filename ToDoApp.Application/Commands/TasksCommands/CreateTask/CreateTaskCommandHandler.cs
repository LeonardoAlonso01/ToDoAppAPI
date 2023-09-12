using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Commands.TasksCommands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Tasks(request.Title, request.Description, request.IdUser);
            
            await _taskRepository.CreateTaskAsync(task);

            return task.Id;
        }
    }
}
