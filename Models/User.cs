using System;

namespace ToDoListAPI.Models;

public class User
{
    public int Id { get; set; }
    public required String UserName { get; set; }
    public required String Password { get; set; }

    // Navigational properties
    // Has one profile
    public Profile? UserProfile { get; set; }
    // Has many Todos
    public List<Todo> Todos { get; set; } = [];
}
