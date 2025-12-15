using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Data
{
    public class TaskManagerAPIContext : DbContext
    {
        public TaskManagerAPIContext(DbContextOptions<TaskManagerAPIContext> options)
            : base(options)
        {
            
        }

        public DbSet<Tasks> Tasks { get; set; } = null!;
    }
}
