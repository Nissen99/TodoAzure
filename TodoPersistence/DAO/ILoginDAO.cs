using Models;

namespace TodoPersistence.DAO;

public interface ILoginDAO
{
    Task<User> Login(string username, string password);
}