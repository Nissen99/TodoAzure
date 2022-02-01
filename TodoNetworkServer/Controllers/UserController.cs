using Microsoft.AspNetCore.Mvc;
using Models;
using TodoServices;

namespace TodoNetworkServer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody] User user)
    {
        try
        {
           
            await _userService.AddUser(user);

            return Created("noUriYet", user);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
      
    }

    

    
    
    [HttpGet]
    public async Task<ActionResult<IList<User>>> GetUsers()
    {
        try
        {
            IList<User> allUsers = await _userService.GetAllUsers();

            return Ok(allUsers);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}