using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Extensions;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet("get-todos")]
    public async Task<ActionResult<List<Todo>>> GetTodosOfCurrentUser()
    {
        return await userRepository.FetchAllUsersTodos(int.Parse(User.GetUserId()));
    }

    [HttpGet("get-todos/{id:int}")]
    public async Task<ActionResult<List<Todo>>> GetTodosOfUser(int id)
    {
        return await userRepository.FetchAllUsersTodos(id);
    }
}
