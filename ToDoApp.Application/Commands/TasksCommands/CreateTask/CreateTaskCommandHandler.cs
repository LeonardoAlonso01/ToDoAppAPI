using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Application.Commands.TasksCommands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Tasks(request.Title, request.Description, request.IdUser);
            
            await _unitOfWork.TaskRepository.CreateTaskAsync(task);
            await _unitOfWork.CompleteAsync();

            return task.Id;
        }
    }
}
