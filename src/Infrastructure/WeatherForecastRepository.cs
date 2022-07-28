using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// Initializes a new instance of ApplicationUserManager class.
    /// </summary>
    /// <param name="context">Database context object</param>
    public WeatherForecastRepository(DatabaseContext context)
    {
        _context = context;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <inheritdoc/>
    public IEnumerable<WeatherForecast> GetWeatherForecasts()
    {
        var entities = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
        return entities;
    }
}
