using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commands.Users.CreateUser;
using ToDoApp.Application.Commands.Users.DeleteUser;
using ToDoApp.Application.Commands.Users.Login;
using ToDoApp.Application.Commands.Users.UpdateUser;
using ToDoApp.Application.Queries.Users.GetUser;
using ToDoApp.Application.ViewModels.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userQuery = new GetUserQuery(id);
            var user = await _mediator.Send(userQuery);

            if (user == null)
            {
                NotFound("Não foi possível carregar informações do usuário!");
            }
            
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok(command);
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }
    }
}
