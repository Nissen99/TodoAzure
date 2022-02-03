using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoPersistence.DAO;

public class TodoDAO : ITodoDAO
{
    public async Task AddTodoAsync(Todo todo)
    {
        using TodoContext ctx = new TodoContext();
        ctx.User.Attach(todo.Responsible);
        await ctx.Todo.AddAsync(todo);
        await ctx.SaveChangesAsync();
        
    }

    public async Task<IList<Todo>> GetAllTodosAsync()
    {
        await using TodoContext ctx = new TodoContext();
        return await ctx.Todo.Include(todo => todo.Responsible).ToListAsync();
    }
}