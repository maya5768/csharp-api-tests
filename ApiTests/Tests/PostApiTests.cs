using System.Net;
using System.Net.Http.Json;
using ApiTests.Clients;
using ApiTests.Fixtures;
using ApiTests.Models;
using ApiTests.TestData;
using ApiTests.Validation;

namespace ApiTests.Tests;

public class PostApiTests : IClassFixture<ApiClientFixture>
{
    private static readonly JsonSchemaValidator PostSchemaValidator = new("post.schema.json");
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

    [Fact]
    public async Task GetPost_ContainsRequiredFields()
    {
        // Act
        HttpResponseMessage response = await _postsClient.GetPostByIdAsync(PostTestData.ExistingPostId);
        Post? post = await response.Content.ReadFromJsonAsync<Post>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(post);
        Assert.Equal(PostTestData.ExistingPostId, post.Id);
        Assert.True(post.UserId > 0);
        Assert.False(string.IsNullOrWhiteSpace(post.Title));
        Assert.False(string.IsNullOrWhiteSpace(post.Body));
    }

    [Fact]
    public async Task GetPost_MatchesSchema()
    {
        // Arrange
        HttpResponseMessage response = await _postsClient.GetPostByIdAsync(PostTestData.ExistingPostId);
        string json = await response.Content.ReadAsStringAsync();

        // Act
        SchemaValidationResult result = PostSchemaValidator.Validate(json);

        // Assert
        Assert.True(result.IsValid, string.Join(Environment.NewLine, result.Errors));
    }

    [Fact]
    public void PostMissingTitle_FailsSchema()
    {
        // Arrange
        string brokenPostJson = PostTestData.PostJsonMissingTitle();

        // Act
        SchemaValidationResult result = PostSchemaValidator.Validate(brokenPostJson);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.Contains("title"));
    }
}
