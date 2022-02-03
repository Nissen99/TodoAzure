using Models;
using TodoNetworkClient;

namespace TodoBlazor.Model;

public class UserModel : IUserModel
{

    private IUserNetwork _userNetwork;

    public UserModel(IUserNetwork userNetwork)
    {
        _userNetwork = userNetwork;
    }

    public async Task AddUser(User newUser)
    {
        await _userNetwork.AddUser(newUser);
    }

    public async Task<IList<User>> GetAllUsersAsync()
    {
        return await _userNetwork.GetAllUsersAsync();
    }
}