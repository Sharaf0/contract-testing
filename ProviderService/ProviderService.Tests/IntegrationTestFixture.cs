namespace ProviderServiceTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

public class WebAppFactory : WebApplicationFactory<ProviderService.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
    }
}

public static class HttpClientFactory
{
    public static HttpClient Create(WebAppFactory factory)
    {
        var httpClient = factory.CreateClient();
        httpClient.BaseAddress = new Uri("https://localhost/");

        return httpClient;
    }
}

public class IntegrationTestFixture : IDisposable
{
    private readonly WebAppFactory Factory = null!;
    protected HttpClient HttpClient = null!;

    public IntegrationTestFixture()
    {
        Factory = new WebAppFactory();
        HttpClient = HttpClientFactory.Create(Factory);
    }

    public void Dispose()
    {
        Factory.Dispose();
        HttpClient.Dispose();
    }
}