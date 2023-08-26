using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return "value";
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
        }
    }
}
