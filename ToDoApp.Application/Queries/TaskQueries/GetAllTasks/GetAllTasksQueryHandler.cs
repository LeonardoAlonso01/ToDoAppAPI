using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Queries.TaskQueries.GetAllTasks;
using ToDoApp.Application.ViewModels.TasksViewModels;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Queries.TaskQueries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PaginationResult<TaskViewModel>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        // Caso não fosse paginado o retorno do método seria um list e não um pagination result
        public async Task<PaginationResult<TaskViewModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetTasksAsync(request.Query, request.Page);

            if (tasks.Data.Count > 0)
            {
                // Retorno não paginado
                // var userTasks = tasks.Data.Where(t => t.IdUser == request.IdUser);

                // var tasksViewModel = userTasks.Select(t => new TaskViewModel(t.Title, t.Status)).ToList();

                // return tasksViewModel;

                // Retorno paginado
                var userTasks = tasks.Data.Where(t => t.IdUser == request.IdUser);

                var tasksViewModel = userTasks.Select(t => new TaskViewModel(t.Title, t.Status)).ToList();

                var paginationTaksViewModel = new PaginationResult<TaskViewModel>(tasks.Page, tasks.TotalPages, tasks.PageSize, tasks.ItemsCount, tasksViewModel);
                
                return paginationTaksViewModel;
            }


            return null;

        }
    }
}
