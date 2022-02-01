using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace TodoNetworkClient;

public class HttpClientBase
{
    protected readonly string Uri = "https://localhost:7191/";
        
    protected async Task<T> HandleResponseGet<T>(HttpResponseMessage responseMessage)
    { 
        CheckForBadStatusCode(responseMessage);
            
        return await responseMessage.Content.ReadFromJsonAsync<T>();
    }
    protected StringContent FromObjectToStringContent<T>(T toStringContent)
    {
        string toJson = JsonSerializer.Serialize(toStringContent);
            

        return new StringContent(toJson, Encoding.UTF8, "application/json");
    }

    public void CheckForBadStatusCode(HttpResponseMessage responseMessage)
    {
        Console.WriteLine($"Handle Response print out: \n {responseMessage}");

        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine("Not good");
            throw new Exception($"Error: {responseMessage.StatusCode}, " +
                                $"{responseMessage.ReasonPhrase}");
        }
    }

    protected void HandleResponseNoReturn(HttpResponseMessage responseMessage)
    {
        CheckForBadStatusCode(responseMessage);
    }
}