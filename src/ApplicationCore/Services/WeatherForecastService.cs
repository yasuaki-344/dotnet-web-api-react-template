using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Initializes a new instance of WeatherForecastService class.
    /// </summary>
    /// <param name="logger">Logging object</param>
    public WeatherForecastService()
    {
    }

    /// <inheritdoc/>
    public WeatherForecastDto[] GetWeatherForecasts()
    {
        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        return weatherForecasts;
    }
}
