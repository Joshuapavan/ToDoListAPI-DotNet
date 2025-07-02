using System;

namespace ToDoListAPI.Models;

public class Profile
{
    public int Id { get; set; }
    public String? PhotoURl { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastActive { get; set; }

    // Navigational Properties for one to one relationship
    public int UserId { get; set; }
    public User? User { get; set; }

}
