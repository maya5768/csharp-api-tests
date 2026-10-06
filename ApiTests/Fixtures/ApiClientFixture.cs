using ApiTests.Clients;
using ApiTests.Configuration;

namespace ApiTests.Fixtures;

public sealed class ApiClientFixture : IDisposable
{
    private readonly HttpClient _httpClient;

    public ApiClientFixture()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = ApiSettings.BaseUrl,
            Timeout = ApiSettings.RequestTimeout
        };
        PostsClient = new PostsApiClient(_httpClient);
    }

    public PostsApiClient PostsClient { get; }

    public void Dispose() => _httpClient.Dispose();
}
