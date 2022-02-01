using Models;

namespace TodoServices;

public interface ILoginService
{
    Task<User> Login(string username, string password);
}