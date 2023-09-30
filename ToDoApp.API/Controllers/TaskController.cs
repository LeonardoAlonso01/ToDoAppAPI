using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Application.Commands.TasksCommands;
using ToDoApp.Application.Commands.TasksCommands.CancelTask;
using ToDoApp.Application.Commands.TasksCommands.CreateTask;
using ToDoApp.Application.Commands.TasksCommands.DeleteTask;
using ToDoApp.Application.Commands.TasksCommands.FinishTask;
using ToDoApp.Application.Commands.TasksCommands.ReopenTask;
using ToDoApp.Application.Commands.TasksCommands.UpdateTask;
using ToDoApp.Application.Queries.TaskQueries.GetAllTasks;
using ToDoApp.Application.Queries.Users.GetUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TaskController>
         [HttpGet]
         public async Task<IActionResult> Get(string query, int idUser)
         {
            var tasksQuery = new GetAllTasksQuery(query, idUser);
            var tasks = await _mediator.Send(tasksQuery);
            return Ok(tasks);

         }

         // GET api/<TaskController>/5
         [HttpGet("{id}")]
         public async Task<IActionResult> GetById(int id)
         {
             var taskQuery = new GetUserQuery(id);
             var task = await _mediator.Send(taskQuery);

             if (task == null)
             {
                 NotFound("Não foi possível carregar informações da tarefa!");
             }

             return Ok(task);
         }

         // POST api/<TaskController>
         [HttpPost]
         public async Task<IActionResult> Post([FromBody] CreateTaskCommand command)
         {
             var id = await _mediator.Send(command);
             return CreatedAtAction(nameof(GetById), new { id = id }, command);
         }

         // PUT api/<TaskController>/5
         [HttpPut("{id}")]
         public async Task<IActionResult> Put(int id, [FromBody] UpdateTaskCommand command)
         {
             command.Id = id;
             await _mediator.Send(command);
             return Ok(command);
         }

         // DELETE api/<TaskController>/5
         [HttpDelete]
         public async Task<IActionResult> Delete([FromQuery]DeleteTaskCommand command)
         {
             await _mediator.Send(command);
             return Ok();
         }

        [HttpPut("Cancel")]
        public async Task<IActionResult> CancelTask([FromQuery] CancelTaskCommand command)
         {
             await _mediator.Send(command);
             return Ok("Tarefa cancelada!");
         }

        [HttpPut("Finish")]
        public async Task<IActionResult> FinishTask([FromQuery] FinishTaskCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tarefa concluída!");
        }

        [HttpPut("Reopen")]
        public async Task<IActionResult> ReopenTask([FromQuery] ReopenTaskCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tarefa concluída!");
        } 
    }
}
