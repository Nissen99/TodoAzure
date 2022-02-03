using Models;

namespace TodoBlazor.Model;

public interface IUserModel
{
    Task AddUser(User newUser);
    Task<IList<User>> GetAllUsersAsync();
}