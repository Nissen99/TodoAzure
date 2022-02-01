using Models;

namespace TodoServices;

public interface IUserService
{
    Task AddUser(User user);
    Task<IList<User>> GetAllUsers();
}