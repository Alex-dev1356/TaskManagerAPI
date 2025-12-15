using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        //Implementing Dependency Injection
        private readonly TaskManagerAPIContext _context;
        public TasksController(TaskManagerAPIContext context)
        {
            _context = context;
        }

        public static readonly List<Tasks> tasks = new List<Tasks> {
            new Tasks { ID = 1, Title = "Task 1", Description = "Description for Task 1", IsCompleted = false },
            new Tasks { ID = 2, Title = "Task 2", Description = "Description for Task 2", IsCompleted = false },
            new Tasks { ID = 3, Title = "Task 3", Description = "Description for Task 3", IsCompleted = false }
        };

        [HttpGet]
        public ActionResult<Tasks> GetAllTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Tasks> GetTaskById(int id)
        {
            var getTaskById = tasks.FirstOrDefault(t => t.ID == id);

            if (getTaskById == null)
                return NotFound();

            return Ok(getTaskById);
        }

        [HttpPost]
        public ActionResult<Tasks> AddTask(Tasks newTask)
        {
            if (newTask == null)
                return BadRequest();

            tasks.Add(newTask);

            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.ID}, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Tasks updateTask)
        {
            var getTaskById = tasks.Find(t => t.ID == id);

            if (getTaskById == null)
                return NotFound();

            getTaskById.ID = updateTask.ID;
            getTaskById.Title = updateTask.Title;
            getTaskById.Description = updateTask.Description;
            getTaskById.IsCompleted = updateTask.IsCompleted;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var getTaskById = tasks.Find(t => t.ID == id);

            if (getTaskById == null)
                return NotFound();

            tasks.Remove(getTaskById);

            return NoContent();
        }
    }
}
