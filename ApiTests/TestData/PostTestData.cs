using ApiTests.Models;

namespace ApiTests.TestData;

public static class PostTestData
{
    public const int ExistingPostId = 1;
    public const int NonExistingPostId = 99999;

    public static CreatePostRequest NewValidPost() =>
        new(UserId: 1, Title: "Test title", Body: "Test body");
}
