using ApiTests.Models;

namespace ApiTests.Clients;

public sealed class PostsApiClient : ApiClientBase
{
    private const string PostsPath = "posts";

    public PostsApiClient(HttpClient httpClient) : base(httpClient) { }

    public Task<HttpResponseMessage> GetPostByIdAsync(int postId) =>
        SendGetAsync($"{PostsPath}/{postId}");

    public Task<HttpResponseMessage> CreatePostAsync(CreatePostRequest request) =>
        SendPostAsync(PostsPath, request);
}
