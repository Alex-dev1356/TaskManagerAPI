using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;
using System.Linq;

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

        //public static readonly List<Tasks> tasks = new List<Tasks> {
        //    new Tasks { ID = 1, Title = "Task 1", Description = "Description for Task 1", IsCompleted = false },
        //    new Tasks { ID = 2, Title = "Task 2", Description = "Description for Task 2", IsCompleted = false },
        //    new Tasks { ID = 3, Title = "Task 3", Description = "Description for Task 3", IsCompleted = false }
        //};

        [HttpGet]
        public async Task<ActionResult<Tasks>> GetAllTasks()
        {
            //return Ok(tasks);

            //Using the DbContext to fetch data from the database also known as the Asynchronous programming
            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTaskById(int id)
        {
            var getTaskById = await _context.Tasks.FindAsync(id);
            if (getTaskById == null)
                return NotFound();

            return Ok(getTaskById);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> AddNewTask(Tasks newTask)
        {
            if (newTask == null)
                return BadRequest();

            //newTask.CreatedAt = new DateTime(2025, 05, 14);

            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.ID }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Tasks updatedTask)
        {
            var getTaskById = await _context.Tasks.FindAsync(id);

            if (getTaskById == null)
                return NotFound();

            getTaskById.Title = updatedTask.Title;
            getTaskById.Description = updatedTask.Description;
            getTaskById.IsCompleted = updatedTask.IsCompleted;
            getTaskById.CreatedAt = new DateTime(2025, 12, 15);

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var getTaskById = await _context.Tasks.FindAsync(id);

            if (getTaskById == null)
                return NotFound();

            _context.Tasks.Remove(getTaskById);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //USING LINQ Queries
        [HttpGet("december")]
        public async Task<ActionResult<Tasks>> GetOnlyDecemberDates()
        {
            var getOnlyDecemberDates = await _context.Tasks.
                Where(t => t.CreatedAt.Month == 12).ToListAsync();

            return Ok(getOnlyDecemberDates);
        }

    }
}
