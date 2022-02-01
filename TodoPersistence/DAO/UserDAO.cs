using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoPersistence.DAO;

public class UserDAO : IUserDAO
{
    public async Task AddUser(User user)
    {
        await using TodoContext ctx = new TodoContext();
        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();

    }

    public async Task<IList<User>> GetAllUsers()
    {
        await using TodoContext ctx = new TodoContext();
        IList<User> allUsers = await ctx.Users.ToListAsync();
        return allUsers;
    }
}