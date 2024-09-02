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

        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskItem>().Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasMany(u => u.Tasks).WithOne(u => u.User).HasForeignKey(u => u.UserId);

            modelBuilder.Entity<User>().HasData([new User() {
                Id = 1,
                Name = "admin",
                Email = "admin@todo.com",
                Password = "admin"

            }]);
        }
    }


}