using Models;
using TodoNetworkClient;

namespace TodoBlazor.Model;

public class TodoModel : ITodoModel
{

    private ITodoNetwork _todoNetwork;

    public TodoModel(ITodoNetwork todoNetwork)
    {
        _todoNetwork = todoNetwork;
    }

    public async Task AddTodoAsync(Todo newTodo)
    {
        await _todoNetwork.AddTodoAsync(newTodo);

    }

    public async Task<IList<Todo>> GetAllTodosAsync()
    {
        return await _todoNetwork.GetAllTodosAsync();
    }
}