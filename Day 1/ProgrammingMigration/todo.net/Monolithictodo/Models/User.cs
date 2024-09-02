using System.ComponentModel.DataAnnotations;
using ToDoApp.Data;

public class User
{

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public ICollection<TaskItem> Tasks { get; set; }
}