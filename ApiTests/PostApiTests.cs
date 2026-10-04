using System.Net;

namespace ApiTests;

public class PostApiTests
{
    // This HttpClient is declared as "static readonly" so that a single instance is
    // created once and reused across all tests in this class, instead of creating a
    // new client per test. Creating many HttpClient instances can exhaust the number
    // of available sockets and lead to connection issues, so sharing one instance is
    // the recommended practice.
    //
    // The BaseAddress is set to the root URL of the API under test (JSONPlaceholder,
    // a free fake REST API used for testing/prototyping). Because BaseAddress is set
    // here, every request made with this client only needs to specify the relative
    // path (e.g. "posts/1") instead of the full URL.
    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
    };

    // [Fact] is an xUnit attribute that marks this method as a single, standalone
    // test case (as opposed to [Theory], which runs the same test with multiple
    // sets of input data). xUnit's test runner will discover this method
    // automatically and execute it when the test suite runs.
    //
    // Test purpose: confirm that requesting an existing resource (post with id 1)
    // from the API returns a successful HTTP 200 OK status code. This is a basic
    // "happy path" test that checks the API endpoint is reachable and behaves as
    // expected for valid input.
    [Fact]
    public async Task GetPost_ReturnsOk()
    {
        // "async Task" lets this test perform asynchronous (non-blocking) I/O.
        // "await" pauses execution of this method until the HTTP request completes,
        // without blocking the thread, and then resumes with the result.
        //
        // client.GetAsync("posts/1") sends an HTTP GET request to:
        // https://jsonplaceholder.typicode.com/posts/1
        // and returns an HttpResponseMessage once the server responds.
        HttpResponseMessage response = await client.GetAsync("posts/1");

        // Assert.Equal is an xUnit assertion that checks the two values are equal.
        // If they are not equal, xUnit throws an exception, marking this test as
        // failed and reporting the mismatch.
        //
        // Here we verify that the status code returned by the server
        // (response.StatusCode) matches HttpStatusCode.OK (i.e. HTTP 200),
        // confirming the request succeeded.
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
