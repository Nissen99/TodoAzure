using Models;

namespace TodoNetworkClient;

public interface ITodoNetwork
{
    Task AddTodoAsync(Todo newTodo);
    Task<IList<Todo>> GetAllTodosAsync();
}