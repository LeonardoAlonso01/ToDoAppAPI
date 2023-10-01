using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.TasksViewModels;
using ToDoApp.Core.Models;

namespace ToDoApp.Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksQuery: IRequest<PaginationResult<TaskViewModel>>
    {
        public string Query { get; private set; }
        public int IdUser { get; private set; }
        public int Page { get; set; }

        public GetAllTasksQuery(string query, int idUser, int page)
        {
            Query = query;
            IdUser = idUser;
            Page = page;
        }
    }
}
