using Models;
using TodoPersistence.DAO;

namespace TodoServices;

public class UserService : IUserService
{

    private IUserDAO _userDao;

    public UserService(IUserDAO userDao)
    {
        _userDao = userDao;
    }

    public async Task AddUser(User user)
    {
        await _userDao.AddUser(user);
    }

    public async Task<IList<User>> GetAllUsers()
    {
        return await _userDao.GetAllUsers();
    }
}