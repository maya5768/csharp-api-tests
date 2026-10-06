using System.Net;
using ApiTests.Clients;
using ApiTests.Fixtures;
using ApiTests.TestData;

namespace ApiTests.Tests;

public class PostApiTests : IClassFixture<ApiClientFixture>
{
    private readonly PostsApiClient _postsClient;

    public PostApiTests(ApiClientFixture fixture)
    {
        _postsClient = fixture.PostsClient;
    }

    [Fact]
    public async Task GetPost_ReturnsOk()
    {
        // Act
        HttpResponseMessage response = await _postsClient.GetPostByIdAsync(PostTestData.ExistingPostId);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
