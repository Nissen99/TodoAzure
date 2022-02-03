using Models;

namespace TodoNetworkClient;

public interface IUserNetwork
{
    Task AddUser(User newUser);
    Task<IList<User>> GetAllUsersAsync();
}