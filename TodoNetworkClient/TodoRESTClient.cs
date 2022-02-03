using Models;

namespace TodoNetworkClient;

public class TodoRESTClient : HttpClientBase, ITodoNetwork
{
    public async Task AddTodoAsync(Todo newTodo)
    {
        HttpClient httpClient = new HttpClient();

        StringContent todoAsStringContent = FromObjectToStringContent(newTodo);

        HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + "Todo", todoAsStringContent);
        
        HandleResponseNoReturn(responseMessage);
    }
}