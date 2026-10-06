namespace ApiTests.Configuration;

public static class ApiSettings
{
    public static readonly Uri BaseUrl = new("https://jsonplaceholder.typicode.com/");
    public static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(30);
}
