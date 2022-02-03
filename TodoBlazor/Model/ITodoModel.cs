using Models;

namespace TodoBlazor.Model;

public interface ITodoModel
{
    Task AddTodoAsync(Todo newTodo);
    Task<IList<Todo>> GetAllTodosAsync();
}