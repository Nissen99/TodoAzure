using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoPersistence.DAO;

public class UserDAO : IUserDAO
{
    public async Task AddUser(User user)
    {
        await using TodoContext ctx = new TodoContext();
        ctx.User.Add(user);
        await ctx.SaveChangesAsync();

    }

    public async Task<IList<User>> GetAllUsers()
    {
        await using TodoContext ctx = new TodoContext();
        IList<User> allUsers = await ctx.User.ToListAsync();
        return allUsers;
    }

    public async Task<User> GetUserFromIdAsync(int id)
    {
        await using TodoContext ctx = new TodoContext();
        User userFromId = await ctx.User.FirstOrDefaultAsync(user => user.Id == id);
        return userFromId;
    }
}