using ApplicationCore.Entities;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of WeatherForecastService class.
    /// </summary>
    /// <param name="mapper">OR mapper object</param>
    public WeatherForecastService(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public WeatherForecastDto[] GetWeatherForecasts()
    {
        var entities = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        var weatherForecasts = _mapper.Map<IEnumerable<WeatherForecast>, WeatherForecastDto[]>(entities);
        return weatherForecasts;
    }
}
