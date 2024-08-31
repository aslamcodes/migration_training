using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasData(new TaskItem() { Id = 1, Description = "Hello Todo", IsCompleted = false });
        }
    }


}