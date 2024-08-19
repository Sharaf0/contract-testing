var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var Summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/hello", () => "Hello World!");

app.MapGet("/weather", () => new
{
    Date = DateTime.Now,
    TemperatureC = new Random().Next(-20, 55),
    Summary = Summaries[new Random().Next(Summaries.Length)]
});

app.Run();
