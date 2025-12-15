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

        //Inserting Data to our Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasData(
                new Tasks
                {
                    ID = 1,
                    Title = "Task 1",
                    Description = "Description for Task 1",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Tasks
                {
                    ID = 2,
                    Title = "Task 2",
                    Description = "Description for Task 2",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2024, 12, 1)
                },
                new Tasks
                {
                    ID = 3,
                    Title = "Task 3",
                    Description = "Description for Task 3",
                    IsCompleted = false,
                    CreatedAt = new DateTime(2024, 3, 1)
                }
            );
        }
    }
}
