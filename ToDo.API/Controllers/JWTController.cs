using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Middleware;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly JWT _jwt;

    public AuthController(JWT jwt)
    {
        _jwt = jwt;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {

        var token = _jwt.GenerateToken(model.UserId);
        return Ok(new { Token = token });
    }
}

public class LoginModel
{
    public string UserId { get; set; }
    public string Password { get; set; }
}