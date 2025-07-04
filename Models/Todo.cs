using System;

namespace ToDoListAPI.Models;

public class Todo
{
    public int Id { get; set; }
    public required String Title { get; set; }
    public String? Description { get; set; }
    public Boolean IsDone { get; set; } = false;


    // Navigational properties
    public int UserId { get; set; }
    public User User { get; set; } = null!;
 
}
