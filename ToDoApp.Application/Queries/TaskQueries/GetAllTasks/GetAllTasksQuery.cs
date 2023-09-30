using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.TasksViewModels;

namespace ToDoApp.Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksQuery: IRequest<List<TaskViewModel>>
    {
        public string Query { get; private set; }
        public int IdUser { get; private set; }

        public GetAllTasksQuery(string query, int idUser)
        {
            Query = query;
            IdUser = idUser;
        }
    }
}
