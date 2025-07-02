using System;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface ITokenService
{
    public String GenerateToken(User user);

}
