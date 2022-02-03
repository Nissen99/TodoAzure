using Models;

namespace TodoServices;

public interface ITodoService
{
    Task AddTodoAsync(Todo todo, int id);
    Task<IList<Todo>> GetAllTodosAsync();
}