using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHeathCheckStatus()
    {
        return Ok(new { status = 200, message = "The server is up and running"  });
    }
}
