namespace ApiTests.Models;

public sealed record CreatePostRequest(int UserId, string Title, string Body);
