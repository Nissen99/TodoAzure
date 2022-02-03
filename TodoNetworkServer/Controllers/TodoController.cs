using Microsoft.AspNetCore.Mvc;
using Models;
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


    [HttpPost]
    [Route("user/{id:int}")]
    public async Task<ActionResult<Todo>> AddTodo([FromBody] Todo todo, [FromRoute] int id)
    {
      
        try
        {
            await _todoService.AddTodoAsync(todo, id);
            return Created("NoUriAtm", todo);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e.StackTrace);

            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);

            return Problem(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IList<Todo>>> GetTodos()
    {
        try
        {
            IList<Todo> allTodos = await _todoService.GetAllTodosAsync();
            return Ok(allTodos);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return Problem(e.Message);
        }
    }



}