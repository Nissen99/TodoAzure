using Models;
using TodoPersistence.DAO;

namespace TodoServices;

public class TodoService : ITodoService
{
    private ITodoDAO _todoDao;
    private IUserDAO _userDao;

    public TodoService(ITodoDAO todoDao, IUserDAO userDao)
    {
        _todoDao = todoDao;
        _userDao = userDao;
    }

    public async Task AddTodoAsync(Todo todo, int id)
    {
        User responsibleUser = await _userDao.GetUserFromIdAsync(id);
        if (responsibleUser == null)
        {
            throw new KeyNotFoundException("No user with given id found");
        }
        todo.Responsible = responsibleUser;
        await _todoDao.AddTodoAsync(todo);
    }

    public async Task<IList<Todo>> GetAllTodosAsync()
    {
        return await _todoDao.GetAllTodosAsync();
    }
}