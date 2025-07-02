using System;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories.Implementation;

public class UserRepository : IUserRepository
{
    public Task<User> GetUSerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUSerByUserNameAsync(string Username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}
