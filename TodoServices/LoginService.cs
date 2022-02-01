using Models;
using TodoPersistence.DAO;
using TodoServices.Util;

namespace TodoServices;

public class LoginService : ILoginService
{
    private ILoginDAO _loginDao;

    public LoginService(ILoginDAO loginDao)
    {
        _loginDao = loginDao;
    }

    public async Task<User> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Username or password empty");
        }
        
        User loggedInUser = await _loginDao.Login(username, password);
        
        if (loggedInUser == null)
        {
            throw new KeyNotFoundException("No user matching username and password found");
        }

        return loggedInUser;

    }
}