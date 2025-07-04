using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Todo>>> GetTodosOfCurrentUser()
    {
        return await userRepository.FetchAllUsersTodos(1);
    }

    [HttpGet]
    [Route("/{id:int}")]
    public async Task<ActionResult<List<Todo>>> GetTodosOfUser(int id)
    {
        return await userRepository.FetchAllUsersTodos(1);
    }
}
