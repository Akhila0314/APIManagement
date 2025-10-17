using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase {
        private readonly ITaskService taskService;
       

        public TaskController(ITaskService service)
        {
            taskService = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(taskService.GetList());

        [HttpPost]
        public IActionResult Post([FromBody] TaskData data)
        {
            var added = taskService.AddTask(data);
            return Ok(added);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            taskService.DeleteTask(id);
            return NoContent();
        }
    }
}