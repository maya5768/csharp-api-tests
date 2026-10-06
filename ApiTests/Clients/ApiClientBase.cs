using System.Net.Http.Json;

namespace ApiTests.Clients;

public abstract class ApiClientBase
{
    private readonly HttpClient _httpClient;

    protected ApiClientBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    protected Task<HttpResponseMessage> SendGetAsync(string relativePath) =>
        _httpClient.GetAsync(relativePath);

    protected Task<HttpResponseMessage> SendPostAsync<TBody>(string relativePath, TBody body) =>
        _httpClient.PostAsJsonAsync(relativePath, body);
}
