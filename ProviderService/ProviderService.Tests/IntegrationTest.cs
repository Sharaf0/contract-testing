using ProviderServiceTests;

public class IntegrationTest : IntegrationTestFixture
{
    [Fact]
    public async Task ProviderService_ReturnsWeatherForecast()
    {
        var response = await HttpClient.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("temperature", content);
        Assert.Contains("summary", content);
    }

    [Fact]
    public async Task ProviderService_ReturnsHelloWorld()
    {
        var response = await HttpClient.GetAsync("/hello");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Hello World!", content);
    }
}