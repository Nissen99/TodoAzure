using Models;

namespace TodoNetworkClient;

public class UserRESTClient : HttpClientBase, IUserNetwork
{
    public async Task AddUser(User newUser)
    {
        HttpClient httpClient = new HttpClient();

        StringContent userAsStringContent = FromObjectToStringContent(newUser);

        HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "User", userAsStringContent);
        
        HandleResponseNoReturn(responseMessage);
    }

    public async Task<IList<User>> GetAllUsersAsync()
    {
        HttpClient httpClient = new HttpClient();

        HttpResponseMessage responseMessage = await httpClient.GetAsync(Uri + "User");

        return await HandleResponseGet<IList<User>>(responseMessage);
    }
}