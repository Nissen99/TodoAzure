using Microsoft.AspNetCore.Mvc;
using TodoServices;

namespace TodoNetworkServer.Controllers;

[ApiController]
[Route("[controller]")] 
public class TodoController : ControllerBase
{

    private ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    
    
    
    
}