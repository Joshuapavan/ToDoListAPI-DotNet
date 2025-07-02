using System;

namespace ToDoListAPI.Models;

public class User
{
    public int Id { get; set; }
    public required String Username { get; set; }
    public required String Password { get; set; }

    // Navigational properties
    public Profile? UserProfile { get; set; }
}
