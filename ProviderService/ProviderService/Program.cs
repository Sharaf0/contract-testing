namespace ProviderService;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        var weatherMappings = new List<WeatherMapping>
{
    new(-40, -20, "Freezing"),
    new(-20, -10, "Bracing"),
    new(-10, 0, "Chilly"),
    new(0, 10, "Cool"),
    new(10, 20, "Mild"),
    new(20, 30, "Sunny"),
    new(30, 40, "Hot"),
    new(40, 55, "Scorching")
};

        app.MapGet("/hello", () => "Hello World!");

        app.MapGet("/weatherforecast", () =>
        {
            var temperature = new Random().Next(-20, 55);
            var weather = weatherMappings.First(w => temperature >= w.Min && temperature <= w.Max);
            return new
            {
                //Date = DateTime.Now,
                Temperature = temperature,
                weather.Summary
            };
        });

        app.Run();
    }
}

record WeatherMapping(int Min, int Max, string Summary);