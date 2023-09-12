using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.TasksViewModels;

namespace ToDoApp.Application.Queries.TaskQueries.GetTask
{
    public class GetTaskQuery: IRequest<TasksDetailViewModel>
    {
        public int Id { get; set; }
    }
}
