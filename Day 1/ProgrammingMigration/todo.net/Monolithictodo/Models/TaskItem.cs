using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }

}