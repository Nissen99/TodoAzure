using Models;

namespace TodoNetworkClient;

public class TodoRESTClient : HttpClientBase, ITodoNetwork
{
    public async Task AddTodoAsync(Todo newTodo)
    {
        HttpClient httpClient = new HttpClient();

        StringContent todoAsStringContent = FromObjectToStringContent(newTodo);

        HttpResponseMessage responseMessage = await httpClient.PostAsync(Uri + $"Todo/user/{newTodo.Responsible.Id}", todoAsStringContent);
        
        HandleResponseNoReturn(responseMessage);
    }

    public async Task<IList<Todo>> GetAllTodosAsync()
    {
        HttpClient httpClient = new HttpClient();
        
        HttpResponseMessage responseMessage = await httpClient.GetAsync(Uri + "Todo");

        return await HandleResponseGet<IList<Todo>>(responseMessage);
    }
}