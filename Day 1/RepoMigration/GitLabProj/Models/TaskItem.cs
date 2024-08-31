using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}