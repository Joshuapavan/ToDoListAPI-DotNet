using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Dtos;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IUserRepository userRepository) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto registerDto)
    {
        UserDto userDto = await userRepository.RegisterUserAsync(registerDto);
        return userDto;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser(LoginDto loginDto)
    {
        UserDto userDto = await userRepository.LoginUserAsync(loginDto);
        return userDto;
    }
}