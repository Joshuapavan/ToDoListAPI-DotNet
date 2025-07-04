using System;
using ToDoListAPI.Dtos;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories;

public interface IUserRepository
{
    public Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
    public Task<UserDto> LoginUserAsync(LoginDto loginDto);

    public Task<List<Todo>> FetchAllUsersTodos(int userId);

}
