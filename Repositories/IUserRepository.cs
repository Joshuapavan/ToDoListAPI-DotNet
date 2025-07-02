using System;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task<User> GetUSerByIdAsync(int id);
    public Task<User> GetUSerByUserNameAsync(string Username);

}
