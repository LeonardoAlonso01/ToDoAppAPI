using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Commands.TasksCommands.DeleteTask
{
    public class DeleteTaskCommand: IRequest
    {
        public int Id { get; set; }
    }
}
