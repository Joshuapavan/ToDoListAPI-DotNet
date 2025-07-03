using System;

namespace ToDoListAPI.Dtos;

public class UserDto
{
    public required String Username { get; set; }
    public required String Token { get; set; }
}
