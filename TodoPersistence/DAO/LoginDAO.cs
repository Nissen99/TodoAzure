using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoPersistence.DAO;

public class LoginDAO : ILoginDAO
{
    /**
     * If no matching users found retured User == null
     */
    public async Task<User> Login(string username, string password)
    {
        await using TodoContext ctx = new TodoContext();
        User loggedInUser = await ctx.User.FirstOrDefaultAsync(user => user.Username.Equals(username) && user.Password.Equals(password));
        return loggedInUser;
    }
}