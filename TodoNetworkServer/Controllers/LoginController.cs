using Microsoft.AspNetCore.Mvc;
using Models;
using TodoServices;

namespace TodoNetworkServer.Controllers;

[ApiController]
[Route("[controller]")] 
public class LoginController : ControllerBase
{

    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }



    [HttpGet]
    public async Task<ActionResult<User>> Login([FromQuery] string username, [FromQuery] string password)
    {
        try
        {
            User loggedInUser = await _loginService.Login(username, password);

            return Ok(loggedInUser);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
        
        
    }
}