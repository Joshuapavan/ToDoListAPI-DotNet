using System;
using ToDoListAPI.Dtos;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task<User> GetUSerByIdAsync(int id);
    public Task<User> GetUSerByUserNameAsync(string Username);

    public Task<UserDto> RegisterUserAsync(RegisterDto registerDto);
    public Task<UserDto> LoginUserAsync(LoginDto loginDto);

}
