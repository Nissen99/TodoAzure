using Models;

namespace TodoPersistence.DAO;

public interface IUserDAO
{
    Task AddUser(User user);
    Task<IList<User>> GetAllUsers();
}