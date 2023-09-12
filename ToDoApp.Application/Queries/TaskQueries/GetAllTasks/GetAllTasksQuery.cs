using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.TasksViewModels;

namespace ToDoApp.Application.Queries.Tasks.GetAllTasks
{
    public class GetAllTasksQuery: IRequest<TaskViewModel>
    {
        public string Query { get; set; }
    }
}
