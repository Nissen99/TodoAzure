using Models;

namespace TodoPersistence.DAO;

public interface ITodoDAO
{
    Task AddTodoAsync(Todo todo);
    Task<IList<Todo>> GetAllTodosAsync();
}